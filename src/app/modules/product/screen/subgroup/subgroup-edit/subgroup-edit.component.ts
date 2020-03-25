// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Subgroup } from '@product/model/subgroup.model';
import { SubgroupService } from '@product/service/subgroup.service';
import { ProductCategory } from '@product/model/product-category.model';
import { ProductCategoryService } from '@product/service/product-category.service';
import { TranslateService } from '@ngx-translate/core';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-subgroup-edit',
    templateUrl: './subgroup-edit.component.html',
    styleUrls: ['./subgroup-edit.component.css', ]
})
export class SubgroupEditComponent extends CRUDDialogScreenBase<Subgroup> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Subgroup>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: SubgroupService,
        public productCategoryService: ProductCategoryService,
    ) {
        super(messageService, translateService, dataService, 'Subgroup');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SubgroupID: new FormControl(),
            SubgroupName: new FormControl(),
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
