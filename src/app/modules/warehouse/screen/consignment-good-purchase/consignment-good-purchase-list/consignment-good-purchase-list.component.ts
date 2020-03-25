// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ConsignmentGoodPurchase } from '@warehouse/model/consignment-good-purchase.model';
import { ConsignmentGoodPurchaseService } from '@warehouse/service/consignment-good-purchase.service';
import { ConsignmentGoodPurchaseEditComponent } from '@warehouse/screen/consignment-good-purchase/consignment-good-purchase-edit/consignment-good-purchase-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { ListParams } from '@otmodel/list-params.model';
import { UnitService } from '@product/service/unit.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-consignment-good-purchase-list',
    templateUrl: './consignment-good-purchase-list.component.html',
    styleUrls: ['./consignment-good-purchase-list.component.css', ]
})
export class ConsignmentGoodPurchaseListComponent extends ListScreenBase<ConsignmentGoodPurchase> implements AfterViewInit, OnInit {
    @ViewChild(ConsignmentGoodPurchaseEditComponent, {static: true}) editScreen: ConsignmentGoodPurchaseEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ConsignmentGoodPurchaseService,
        public storeService: StoreService,
        public productService: ProductService,
        public supplierService: SupplierService,
        public unitService: UnitService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Consignment Good Purchase', RouterLink: '/warehouse/consignment-good-purchase'}];
    }

    createEmptyModel(): ConsignmentGoodPurchase {
        return new ConsignmentGoodPurchase();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.userStores) {
            this.storeService.listUserStores().subscribe();
        }
        if (!this.productService.consignmentGoodList) {
            this.productService.listConsignmentGoods();
        }
        if (!this.supplierService.completeList) {
            this.supplierService.listAll();
        }
        this.unitService.listAll();
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate'];
        super.handleDataStateChange(state);
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
