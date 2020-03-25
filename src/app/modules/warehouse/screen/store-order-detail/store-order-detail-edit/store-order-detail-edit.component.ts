// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreOrderDetail } from '@warehouse/model/store-order-detail.model';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { StoreOrder } from '@warehouse/model/store-order.model';
import { StoreOrderService } from '@warehouse/service/store-order.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-detail-edit',
    templateUrl: './store-order-detail-edit.component.html',
    styleUrls: ['./store-order-detail-edit.component.css', ]
})
export class StoreOrderDetailEditComponent extends CRUDDialogScreenBase<StoreOrderDetail> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreOrderDetail>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreOrderDetailService,
        public productService: ProductService,
        public storeOrderService: StoreOrderService,
    ) {
        super(messageService, translateService, dataService, 'Store Order Detail');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreOrderDetailId: new FormControl(),
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
            Product: new FormControl(),
            OrderQuantity: new FormControl(),
            RevisedQuantity: new FormControl(),
            ShippedQuantity: new FormControl(),
            OrderUnitQuantity: new FormControl(),
            StoreOrder: new FormControl(),
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
