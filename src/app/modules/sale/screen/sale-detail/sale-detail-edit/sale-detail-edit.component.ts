// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SaleDetail } from '@sale/model/sale-detail.model';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-detail-edit',
    templateUrl: './sale-detail-edit.component.html',
    styleUrls: ['./sale-detail-edit.component.css', ] 
})
export class SaleDetailEditComponent extends CRUDDialogScreenBase<SaleDetail> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SaleDetail>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SaleDetailService,
        public salesService: SalesService,
        public productService: ProductService,
        public storeService: StoreService,
        public unitService: UnitService,
    ) {
        super(messageService, translateService, dataService, 'Sale Detail');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SaleDetailId: new FormControl(),
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
            SaleID: new FormControl(),
            TransactionID: new FormControl(),
            TransactionDate: new FormControl(),
            Barcode: new FormControl(),
            ProductID: new FormControl(),
            ProductCode: new FormControl(),
            Store: new FormControl(),
            Price: new FormControl(),
            VATRate: new FormControl(),
            Quantity: new FormControl(),
            Unit: new FormControl(),
            CancelFlag: new FormControl(),
            UnitPrice: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
