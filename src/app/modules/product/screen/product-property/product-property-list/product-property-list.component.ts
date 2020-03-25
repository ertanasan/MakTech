// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductProperty } from '@product/model/product-property.model';
import { ProductPropertyService } from '@product/service/product-property.service';
import { ProductPropertyEditComponent } from '@product/screen/product-property/product-property-edit/product-property-edit.component';
import { PropertyType } from '@product/model/property-type.model';
import { PropertyTypeService } from '@product/service/property-type.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-property-list',
    templateUrl: './product-property-list.component.html',
    styleUrls: ['./product-property-list.component.css', ]
})
export class ProductPropertyListComponent extends ListScreenBase<ProductProperty> implements AfterViewInit, OnInit {
    @ViewChild(ProductPropertyEditComponent, {static: true}) editScreen: ProductPropertyEditComponent;
    @Input() productID: number;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: ProductPropertyService,
        public propertyTypeService: PropertyTypeService,
        public productService: ProductService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.subscribe(
                list => {
                    this.dataList = list;
                    this.dataLoading = false;
                },
                error => {
                    this.dataLoading = false;
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Product' }, { Caption: 'Product Property', RouterLink: '/product/product-property' }];
    }

    createEmptyModel(): ProductProperty {
        const productProperty = new ProductProperty();
        if (this.masterId) {
            productProperty.Product = this.masterId;
        }
        return productProperty;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.propertyTypeService.completeList) {
            this.propertyTypeService.listAll();
        }
        if (!this.masterId && !this.productService.completeList) {
            this.productService.listAll();
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
