// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestAdditionalInfo } from '@helpdesk/model/request-additional-info.model';
import { RequestAdditionalInfoService } from '@helpdesk/service/request-additional-info.service';
import { HelpdeskRequest } from '@helpdesk/model/helpdesk-request.model';
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { Folder } from '@document/model/folder.model';
import { FolderService } from '@document/service/folder.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-additional-info-edit',
    templateUrl: './request-additional-info-edit.component.html',
    styleUrls: ['./request-additional-info-edit.component.css', ]
})
export class RequestAdditionalInfoEditComponent extends CRUDDialogScreenBase<RequestAdditionalInfo> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<RequestAdditionalInfo>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestAdditionalInfoService,
        public helpdeskRequestService: HelpdeskRequestService,
        public folderService: FolderService,
    ) {
        super(messageService, translateService, dataService, 'Request Additional Info');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestAdditionalInfoId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            Request: new FormControl(),
            Cost: new FormControl(),
            WarrantyDueDate: new FormControl(),
            Folder: new FormControl(),
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
