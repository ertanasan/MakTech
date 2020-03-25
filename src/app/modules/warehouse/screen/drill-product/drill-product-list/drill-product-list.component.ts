// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { DrillProduct } from '@warehouse/model/drill-product.model';
import { DrillProductService } from '@warehouse/service/drill-product.service';
import { DrillProductEditComponent } from '@warehouse/screen/drill-product/drill-product-edit/drill-product-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-drill-product-list',
    templateUrl: './drill-product-list.component.html',
    styleUrls: ['./drill-product-list.component.css', ]
})
export class DrillProductListComponent extends ListScreenBase<DrillProduct> implements AfterViewInit, OnInit {
    @ViewChild(DrillProductEditComponent, {static: true}) editScreen: DrillProductEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: DrillProductService,
        public productService: ProductService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Drill Product', RouterLink: '/warehouse/drill-product'}];
    }


    createEmptyModel(): DrillProduct {
        const model: DrillProduct = new DrillProduct();
        const d = new Date();
        d.setDate(d.getDate());
        model.CountingDate = d;
        this.editScreen.tomorrow = d;
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        this.storeService.listStoresAndWarehouses();
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
