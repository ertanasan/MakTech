// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { DrillProduct } from '@warehouse/model/drill-product.model';
import { DrillProductService } from '@warehouse/service/drill-product.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-drill-product-edit',
    templateUrl: './drill-product-edit.component.html',
    styleUrls: ['./drill-product-edit.component.css', ]
})
export class DrillProductEditComponent extends CRUDDialogScreenBase<DrillProduct> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<DrillProduct>;
    tomorrow: Date;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: DrillProductService,
        public productService: ProductService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Drill Product');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            DrillProductId: new FormControl(),
            CountingDate: new FormControl(),
            Product: new FormControl(),
            Store: new FormControl(),
            AllStores: new FormControl(false),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized


    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    onSubmit() {
        this.container.currentItem.CountingDate = this.addHours(this.container.currentItem.CountingDate, 3);
        if (this.submitValidation()) {
            if (this.container.mainForm.get('AllStores').value) {
                this.container.currentItem.Store = -1;
            }
            super.onSubmit();
        }
    }

    onAllStoreBlur() {
        this.container.mainForm.get('Store').reset(null);
    }

    submitValidation() {
        if (this.container.currentItem.CountingDate < this.tomorrow) {
            this.messageService.warning('Geçmiş tarihli giriş yapamazsınız.');
            return false;
        } else if (!this.container.mainForm.get('AllStores').value && !this.container.mainForm.get('Store').value) {
            this.messageService.warning(this.translateService.instant('No store selected'));
            return false;
        } else if (!this.container.mainForm.get('Product').value) {
            this.messageService.warning(this.translateService.instant('No product selected'));
            return false;
        } else {
            return true;
        }
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
