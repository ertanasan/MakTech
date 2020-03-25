// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductBarcode } from '@product/model/product-barcode.model';
import { ProductBarcodeService } from '@product/service/product-barcode.service';
import { ProductBarcodeEditComponent } from '@product/screen/product-barcode/product-barcode-edit/product-barcode-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { BarcodeTypeService } from '@product/service/barcode-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-barcode-list',
    templateUrl: './product-barcode-list.component.html',
    styleUrls: ['./product-barcode-list.component.css', ]
})
export class ProductBarcodeListComponent extends ListScreenBase<ProductBarcode> implements AfterViewInit, OnInit {
    @ViewChild(ProductBarcodeEditComponent, {static: true}) editScreen: ProductBarcodeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: ProductBarcodeService,
        public productService: ProductService,
        public barcodeTypeService: BarcodeTypeService
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
        return [{Caption: 'Product' }, {Caption: 'Product Barcode', RouterLink: '/product/product-barcode'}];
    }

    createEmptyModel(): ProductBarcode {
        const productBarcode = new ProductBarcode();
        if (this.masterId) {
            productBarcode.Product = this.masterId;
        }
        return productBarcode;
    }

    ngOnInit() {
        // Fill reference lists
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
