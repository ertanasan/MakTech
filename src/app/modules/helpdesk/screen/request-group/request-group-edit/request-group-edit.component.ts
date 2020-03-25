// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestGroup } from '@helpdesk/model/request-group.model';
import { RequestGroupService } from '@helpdesk/service/request-group.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-group-edit',
    templateUrl: './request-group-edit.component.html',
    styleUrls: ['./request-group-edit.component.css', ]
})
export class RequestGroupEditComponent extends CRUDDialogScreenBase<RequestGroup> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RequestGroup>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestGroupService,
    ) {
        super(messageService, translateService, dataService, 'Request Group');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestGroupId: new FormControl(),
            RequestGroupName: new FormControl(),
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
