// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductStockGroup } from '@product/model/product-stock-group.model';
import { ProductStockGroupService } from '@product/service/product-stock-group.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { StockGroupName } from '@product/model/stock-group-name.model';
import { StockGroupNameService } from '@product/service/stock-group-name.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-stock-group-edit',
    templateUrl: './product-stock-group-edit.component.html',
    styleUrls: ['./product-stock-group-edit.component.css', ]
})
export class ProductStockGroupEditComponent extends CRUDDialogScreenBase<ProductStockGroup> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductStockGroup>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductStockGroupService,
        public productService: ProductService,
        public stockGroupNameService: StockGroupNameService,
    ) {
        super(messageService, translateService, dataService, 'Product Stock Group');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Product: new FormControl(),
            StockGroup: new FormControl(),
            StockGroupId: new FormControl(),
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
