// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductCategory } from '@product/model/product-category.model';
import { ProductCategoryService } from '@product/service/product-category.service';
import { ProductCategoryEditComponent } from '@product/screen/product-category/product-category-edit/product-category-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-category-list',
    templateUrl: './product-category-list.component.html',
    styleUrls: ['./product-category-list.component.css', ]
})
export class ProductCategoryListComponent extends ListScreenBase<ProductCategory> implements AfterViewInit {
    @ViewChild(ProductCategoryEditComponent, {static: true}) editScreen: ProductCategoryEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: ProductCategoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Product Category', RouterLink: '/product/product-category'}];
    }

    createEmptyModel(): ProductCategory {
        return new ProductCategory();
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
