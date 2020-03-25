// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductStockGroup } from '@product/model/product-stock-group.model';
import { ProductStockGroupService } from '@product/service/product-stock-group.service';
import { ProductStockGroupEditComponent } from '@product/screen/product-stock-group/product-stock-group-edit/product-stock-group-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { StockGroupNameService } from '@product/service/stock-group-name.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-stock-group-list',
    templateUrl: './product-stock-group-list.component.html',
    styleUrls: ['./product-stock-group-list.component.css', ]
})
export class ProductStockGroupListComponent extends ListScreenBase<ProductStockGroup> implements AfterViewInit, OnInit {
    @ViewChild(ProductStockGroupEditComponent, {static: true}) editScreen: ProductStockGroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductStockGroupService,
        public productService: ProductService,
        public stockGroupNameService: StockGroupNameService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Product Stock Group', RouterLink: '/product/product-stock-group'}];
    }

    createEmptyModel(): ProductStockGroup {
        return new ProductStockGroup();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        if (!this.stockGroupNameService.completeList) {
            this.stockGroupNameService.listAll();
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
