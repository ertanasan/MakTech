// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductionContent } from '@warehouse/model/production-content.model';
import { ProductionContentService } from '@warehouse/service/production-content.service';
import { Production } from '@warehouse/model/production.model';
import { ProductionService } from '@warehouse/service/production.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-content-edit',
    templateUrl: './production-content-edit.component.html',
    styleUrls: ['./production-content-edit.component.css', ]
})
export class ProductionContentEditComponent extends CRUDDialogScreenBase<ProductionContent> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductionContent>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductionContentService,
        public productionService: ProductionService,
        public productService: ProductService,
    ) {
        super(messageService, translateService, dataService, 'Production Content');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductionContentId: new FormControl(),
            Production: new FormControl(),
            Product: new FormControl(),
            ShareRate: new FormControl(),
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
