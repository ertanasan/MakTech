// Created by OverGenerator
/*Section="Imports"*/
import { OnInit, ViewChild, Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestStatus } from '@helpdesk/model/request-status.model';
import { RequestStatusService } from '@helpdesk/service/request-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-status-edit',
    templateUrl: './request-status-edit.component.html',
    styleUrls: ['./request-status-edit.component.css', ]
})
export class RequestStatusEditComponent extends CRUDDialogScreenBase<RequestStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RequestStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestStatusService,
    ) {
        super(messageService, translateService, dataService, 'Request Status');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestStatusId: new FormControl(),
            StatusName: new FormControl(),
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
