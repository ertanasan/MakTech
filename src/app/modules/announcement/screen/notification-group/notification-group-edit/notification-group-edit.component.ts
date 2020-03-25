// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationGroup } from '@announcement/model/notification-group.model';
import { NotificationGroupService } from '@announcement/service/notification-group.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-group-edit',
    templateUrl: './notification-group-edit.component.html',
    styleUrls: ['./notification-group-edit.component.css', ]
})
export class NotificationGroupEditComponent extends CRUDDialogScreenBase<NotificationGroup> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<NotificationGroup>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: NotificationGroupService,
    ) {
        super(messageService, translateService, dataService, 'Notification Group');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            NotificationGroupId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            GroupName: new FormControl(),
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
