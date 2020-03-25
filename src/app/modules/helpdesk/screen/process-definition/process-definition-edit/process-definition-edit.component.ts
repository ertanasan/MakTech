// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProcessDefinition } from '@helpdesk/model/process-definition.model';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-process-definition-edit',
    templateUrl: './process-definition-edit.component.html',
    styleUrls: ['./process-definition-edit.component.css', ]
})
export class ProcessDefinitionEditComponent extends CRUDDialogScreenBase<ProcessDefinition> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProcessDefinition>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProcessDefinitionService,
    ) {
        super(messageService, translateService, dataService, 'Process Definition');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProcessDefinitionId: new FormControl(),
            ProcessDefinitionName: new FormControl(),
            ProcessNo: new FormControl(),
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
