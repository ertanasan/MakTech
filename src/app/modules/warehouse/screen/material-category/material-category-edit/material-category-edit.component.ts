// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { MaterialCategory } from '@warehouse/model/material-category.model';
import { MaterialCategoryService } from '@warehouse/service/material-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-category-edit',
    templateUrl: './material-category-edit.component.html',
    styleUrls: ['./material-category-edit.component.css', ]
})
export class MaterialCategoryEditComponent extends CRUDDialogScreenBase<MaterialCategory> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<MaterialCategory>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: MaterialCategoryService,
    ) {
        super(messageService, translateService, dataService, 'Material Category');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            MaterialCategoryId: new FormControl(),
            CategoryName: new FormControl(),
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
