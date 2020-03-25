// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationStatus } from '@announcement/model/notification-status.model';
import { NotificationStatusService } from '@announcement/service/notification-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-status-edit',
    templateUrl: './notification-status-edit.component.html',
    styleUrls: ['./notification-status-edit.component.css', ]
})
export class NotificationStatusEditComponent extends CRUDDialogScreenBase<NotificationStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<NotificationStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: NotificationStatusService,
    ) {
        super(messageService, translateService, dataService, 'Notification Status');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            NotificationStatusId: new FormControl(),
            NotificationStatusName: new FormControl(),
            Description: new FormControl(),
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
