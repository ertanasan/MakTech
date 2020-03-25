// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestDetail } from '@helpdesk/model/request-detail.model';
import { RequestDetailService } from '@helpdesk/service/request-detail.service';
import { HelpdeskRequest } from '@helpdesk/model/helpdesk-request.model';
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { RequestAttribute } from '@helpdesk/model/request-attribute.model';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-detail-edit',
    templateUrl: './request-detail-edit.component.html',
    styleUrls: ['./request-detail-edit.component.css', ]
})
export class RequestDetailEditComponent extends CRUDDialogScreenBase<RequestDetail> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RequestDetail>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestDetailService,
        public helpdeskRequestService: HelpdeskRequestService,
        public requestAttributeService: RequestAttributeService,
    ) {
        super(messageService, translateService, dataService, 'Request Detail');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestDetailId: new FormControl(),
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
            Attribute: new FormControl(),
            AttributeValue: new FormControl(),
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
