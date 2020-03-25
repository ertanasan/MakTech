// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Production } from '@warehouse/model/production.model';
import { ProductionService } from '@warehouse/service/production.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-edit',
    templateUrl: './production-edit.component.html',
    styleUrls: ['./production-edit.component.css', ]
})
export class ProductionEditComponent extends CRUDDialogScreenBase<Production> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Production>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductionService,
        public productService: ProductService,
    ) {
        super(messageService, translateService, dataService, 'Production');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductionId: new FormControl(),
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
