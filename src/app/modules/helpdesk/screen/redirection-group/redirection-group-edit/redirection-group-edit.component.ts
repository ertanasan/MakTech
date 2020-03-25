// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RedirectionGroup } from '@helpdesk/model/redirection-group.model';
import { RedirectionGroupService } from '@helpdesk/service/redirection-group.service';
import { RequestDefinition } from '@helpdesk/model/request-definition.model';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-redirection-group-edit',
    templateUrl: './redirection-group-edit.component.html',
    styleUrls: ['./redirection-group-edit.component.css', ]
})
export class RedirectionGroupEditComponent extends CRUDDialogScreenBase<RedirectionGroup> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RedirectionGroup>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RedirectionGroupService,
        public requestDefinitionService: RequestDefinitionService,
    ) {
        super(messageService, translateService, dataService, 'Redirection Group');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RedirectionGroupId: new FormControl(),
            GroupName: new FormControl(),
            RequestDefinition: new FormControl(),
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
