// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { IntakeStatusType } from '@warehouse/model/intake-status-type.model';
import { IntakeStatusTypeService } from '@warehouse/service/intake-status-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-intake-status-type-edit',
    templateUrl: './intake-status-type-edit.component.html',
    styleUrls: ['./intake-status-type-edit.component.css', ]
})
export class IntakeStatusTypeEditComponent extends CRUDDialogScreenBase<IntakeStatusType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<IntakeStatusType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: IntakeStatusTypeService,
    ) {
        super(messageService, translateService, dataService, 'Intake Status Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            IntakeStatusTypeId: new FormControl(),
            IntakeStatusTypeName: new FormControl(),
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
