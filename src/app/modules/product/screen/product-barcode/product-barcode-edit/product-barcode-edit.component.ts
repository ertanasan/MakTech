// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductBarcode } from '@product/model/product-barcode.model';
import { ProductBarcodeService } from '@product/service/product-barcode.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { BarcodeType } from '@product/model/barcode-type.model';
import { BarcodeTypeService } from '@product/service/barcode-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-barcode-edit',
    templateUrl: './product-barcode-edit.component.html',
    styleUrls: ['./product-barcode-edit.component.css', ]
})
export class ProductBarcodeEditComponent extends CRUDDialogScreenBase<ProductBarcode> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductBarcode>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ProductBarcodeService,
        public productService: ProductService,
        public barcodeTypeService: BarcodeTypeService,
    ) {
        super(messageService, translateService, dataService, 'Product Barcode');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductBarcodeId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Product: new FormControl(),
            BarcodeType: new FormControl(),
            BarcodeText: new FormControl(),
        });
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.barcodeTypeService.completeList) {
            this.barcodeTypeService.listAll();
        }
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
