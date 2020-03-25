// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ConsignmentGoodPurchase } from '@warehouse/model/consignment-good-purchase.model';
import { ConsignmentGoodPurchaseService } from '@warehouse/service/consignment-good-purchase.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { Subscription } from 'rxjs';
import { UnitService } from '@product/service/unit.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-consignment-good-purchase-edit',
    templateUrl: './consignment-good-purchase-edit.component.html',
    styleUrls: ['./consignment-good-purchase-edit.component.css', ]
})
export class ConsignmentGoodPurchaseEditComponent extends CRUDDialogScreenBase<ConsignmentGoodPurchase> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ConsignmentGoodPurchase>;
    showSubscription: Subscription;

    radioItems = [{value: 'Alım', text: 'Alım'}, {value: 'İade', text: 'İade'}];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ConsignmentGoodPurchaseService,
        public storeService: StoreService,
        public productService: ProductService,
        public supplierService: SupplierService,
        public unitService: UnitService,
    ) {
        super(messageService, translateService, dataService, 'Consignment Good Purchase');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ConsignmentGoodPurchaseId: new FormControl(),
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
            Store: new FormControl(),
            Product: new FormControl(null, Validators.required),
            Supplier: new FormControl(null, Validators.required),
            Quantity: new FormControl(null, Validators.required),
            UnitName: new FormControl(),
            TransactionType: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    onSubmit() {
        if (this.container.actionName === 'Create') {
            if (this.storeService.userStores.length === 1) {
                this.container.currentItem.Store = this.storeService.userStores[0].StoreId;
            }
            if (this.container.mainForm.controls.TransactionType.value === this.radioItems[1].value) {
                this.container.currentItem.Quantity = this.container.mainForm.controls.Quantity.value * -1;
            }
        }
        super.onSubmit();
    }

    onProductChange(productId) {
        const prd = this.productService.consignmentGoodList.find( p => p.ProductId === productId);
        const tmpUnitName = this.unitService.completeList.find( u => u.UnitId === prd.Unit);
        this.container.mainForm.patchValue( { UnitName: tmpUnitName.Name} );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
