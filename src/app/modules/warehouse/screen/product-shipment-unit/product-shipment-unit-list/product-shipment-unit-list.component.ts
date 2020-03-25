// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductShipmentUnit } from '@warehouse/model/product-shipment-unit.model';
import { ProductShipmentUnitService } from '@warehouse/service/product-shipment-unit.service';
import { ProductShipmentUnitEditComponent } from '@warehouse/screen/product-shipment-unit/product-shipment-unit-edit/product-shipment-unit-edit.component';
import { ProductService } from '@product/service/product.service';
import { ShipmentTypeService } from '@warehouse/service/shipment-type.service';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-shipment-unit-list',
    templateUrl: './product-shipment-unit-list.component.html',
    styleUrls: ['./product-shipment-unit-list.component.css', ]
})
export class ProductShipmentUnitListComponent extends ListScreenBase<ProductShipmentUnit> implements AfterViewInit, OnInit {
    @ViewChild(ProductShipmentUnitEditComponent, {static: true}) editScreen: ProductShipmentUnitEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductShipmentUnitService,
        public productService: ProductService,
        public shipmentTypeService: ShipmentTypeService,
        public shipmentPackageTypeService: ShipmentPackageTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.masterId) {
            const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
            if (result) {
                this.dataLoading = true;
                result.subscribe(
                    list => {
                        this.dataList = list;
                    },
                    error => {
                        this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                    },
                    () => this.dataLoading = false
                 );
            }
        } else {
            this.dataService.list(this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Product Shipment Unit', RouterLink: '/warehouse/product-shipment-unit'}];
    }

    createEmptyModel(): ProductShipmentUnit {
        return new ProductShipmentUnit();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        if (!this.shipmentTypeService.completeList) {
            this.shipmentTypeService.listAll();
        }
        if (!this.shipmentPackageTypeService.completeList) {
            this.shipmentPackageTypeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
