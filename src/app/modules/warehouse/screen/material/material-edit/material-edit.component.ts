// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Material } from '@warehouse/model/material.model';
import { MaterialService } from '@warehouse/service/material.service';
import { MaterialCategory } from '@warehouse/model/material-category.model';
import { MaterialCategoryService } from '@warehouse/service/material-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-edit',
    templateUrl: './material-edit.component.html',
    styleUrls: ['./material-edit.component.css', ]
})
export class MaterialEditComponent extends CRUDDialogScreenBase<Material> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<Material>;

    UnitCodeList = [{value: 1, text: 'Adet'}, {value: 2, text: 'Kg'}];
    
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: MaterialService,
        public materialCategoryService: MaterialCategoryService,
    ) {
        super(messageService, translateService, dataService, 'Material');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            MaterialId: new FormControl(),
            MaterialName: new FormControl(),
            MikroCode: new FormControl(),
            UnitCode: new FormControl(),
            Category: new FormControl(),
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
