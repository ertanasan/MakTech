// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { MaterialInfo } from '@warehouse/model/material-info.model';
import { MaterialInfoService } from '@warehouse/service/material-info.service';
import { Material } from '@warehouse/model/material.model';
import { MaterialService } from '@warehouse/service/material.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-info-edit',
    templateUrl: './material-info-edit.component.html',
    styleUrls: ['./material-info-edit.component.css', ]
})
export class MaterialInfoEditComponent extends CRUDDialogScreenBase<MaterialInfo> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<MaterialInfo>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: MaterialInfoService,
        public materialService: MaterialService,
    ) {
        super(messageService, translateService, dataService, 'Material Info');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            MaterialInfoId: new FormControl(),
            Material: new FormControl(),
            ShortName: new FormControl(),
            InfoName: new FormControl(),
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
