// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { FakeOrder } from '@warehouse/model/fake-order.model';
import { FakeOrderService } from '@warehouse/service/fake-order.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { Subscription } from 'rxjs';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fake-order-edit',
    templateUrl: './fake-order-edit.component.html',
    styleUrls: ['./fake-order-edit.component.css', ]
})
export class FakeOrderEditComponent extends CRUDDialogScreenBase<FakeOrder> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<FakeOrder>;
    showSubscription: Subscription;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FakeOrderService,
        public storeService: StoreService,
        public productService: ProductService,
    ) {
        super(messageService, translateService, dataService, 'Fake Order');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FakeOrderId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            OrderDate: new FormControl(null, Validators.required),
            Store: new FormControl(),
            Product: new FormControl(0, Validators.required),
            SentAmount: new FormControl(0, Validators.required),
            StoreList: new FormControl(),
            AllStores: new FormControl(false),
        });
    }

    ngOnInit() {
        this.showSubscription = this.container.onShow.subscribe(item => {
            console.log(item);
            this.container.mainForm.get('OrderDate').patchValue(this.addHours(new Date(Date.now()), 24));
        });
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        this.container.currentItem.OrderDate = this.addHours(this.container.currentItem.OrderDate, 3);
        if (this.container.actionName === 'Create') {
            this.container.currentItem.Store = -1;
            if (this.container.mainForm.get('AllStores').value) {
                this.container.currentItem.StoreList = [];
                this.storeService.completeList.forEach(s => {
                    if (s.Deleted === false && s.ActiveFlag === true) {
                        this.container.currentItem.StoreList.push(s.StoreId);
                    }
                });
            } else if (!this.container.mainForm.get('StoreList').value || (<number[]>this.container.mainForm.get('StoreList').value).length <= 0) {
               this.messageService.warning(this.translateService.instant('At least one store must be selected'));
               return;
            }
        }
        super.onSubmit();
    }

    onAllStoreBlur() {
        this.container.mainForm.get('AllStores').reset(null);
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
