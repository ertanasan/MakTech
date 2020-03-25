// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductShipmentUnit } from '@warehouse/model/product-shipment-unit.model';
import { ProductShipmentUnitService } from '@warehouse/service/product-shipment-unit.service';
import { ProductService } from '@product/service/product.service';
import { ShipmentTypeService } from '@warehouse/service/shipment-type.service';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-shipment-unit-edit',
    templateUrl: './product-shipment-unit-edit.component.html',
    styleUrls: ['./product-shipment-unit-edit.component.css', ]
})
export class ProductShipmentUnitEditComponent extends CRUDDialogScreenBase<ProductShipmentUnit> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductShipmentUnit>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductShipmentUnitService,
        public productService: ProductService,
        public shipmentTypeService: ShipmentTypeService,
        public shipmentPackageTypeService: ShipmentPackageTypeService,
    ) {
        super(messageService, translateService, dataService, 'Product Shipment Unit');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductShipmentUnitId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Product: new FormControl(),
            ShipmentType: new FormControl(),
            PackageQuantity: new FormControl(),
            PackageType: new FormControl(),
            // WarehouseLocation: new FormControl(),
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
