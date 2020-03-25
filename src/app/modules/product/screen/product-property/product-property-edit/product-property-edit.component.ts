// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductProperty } from '@product/model/product-property.model';
import { ProductPropertyService } from '@product/service/product-property.service';
import { PropertyType } from '@product/model/property-type.model';
import { PropertyTypeService } from '@product/service/property-type.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-property-edit',
    templateUrl: './product-property-edit.component.html',
    styleUrls: ['./product-property-edit.component.css', ]
})
export class ProductPropertyEditComponent extends CRUDDialogScreenBase<ProductProperty> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductProperty>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ProductPropertyService,
        public propertyTypeService: PropertyTypeService,
        public productService: ProductService,
    ) {
        super(messageService, translateService, dataService, 'Product Property');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductPropertyId: new FormControl(),
            PropertyType: new FormControl(),
            Product: new FormControl(),
            Value: new FormControl(),
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
