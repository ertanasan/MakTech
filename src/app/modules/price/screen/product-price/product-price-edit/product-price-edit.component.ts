// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductPrice } from '@price/model/product-price.model';
import { ProductPriceService } from '@price/service/product-price.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-price-edit',
    templateUrl: './product-price-edit.component.html',
    styleUrls: ['./product-price-edit.component.css', ]
})
export class ProductPriceEditComponent extends CRUDDialogScreenBase<ProductPrice> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductPrice>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ProductPriceService,
    ) {
        super(messageService, translateService, dataService, 'Product Price');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductPriceId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            PriceType: new FormControl(),
            PriceAmount: new FormControl(),
            Product: new FormControl(),
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
