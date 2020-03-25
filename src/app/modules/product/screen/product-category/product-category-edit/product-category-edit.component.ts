// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductCategory } from '@product/model/product-category.model';
import { ProductCategoryService } from '@product/service/product-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-category-edit',
    templateUrl: './product-category-edit.component.html',
    styleUrls: ['./product-category-edit.component.css', ]
})
export class ProductCategoryEditComponent extends CRUDDialogScreenBase<ProductCategory> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductCategory>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ProductCategoryService,
    ) {
        super(messageService, translateService, dataService, 'Product Category');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CategoryID: new FormControl(),
            Category: new FormControl(),
            Comment: new FormControl(),
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
