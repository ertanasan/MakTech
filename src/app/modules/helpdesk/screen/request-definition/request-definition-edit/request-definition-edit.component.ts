// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestDefinition } from '@helpdesk/model/request-definition.model';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { RequestGroup } from '@helpdesk/model/request-group.model';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { ProcessDefinition } from '@helpdesk/model/process-definition.model';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-definition-edit',
    templateUrl: './request-definition-edit.component.html',
    styleUrls: ['./request-definition-edit.component.css', ]
})
export class RequestDefinitionEditComponent extends CRUDDialogScreenBase<RequestDefinition> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RequestDefinition>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestDefinitionService,
        public requestGroupService: RequestGroupService,
        public processDefinitionService: ProcessDefinitionService,
    ) {
        super(messageService, translateService, dataService, 'Request Definition');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestDefinitionId: new FormControl(),
            RequestDefinitionName: new FormControl(),
            RequestGroup: new FormControl(),
            Process: new FormControl(),
            MicroCode: new FormControl(),
            DisplayOrder: new FormControl(),
            ActiveFlag: new FormControl(),
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
