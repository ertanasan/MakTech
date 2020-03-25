// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationType } from '@announcement/model/notification-type.model';
import { NotificationTypeService } from '@announcement/service/notification-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-type-edit',
    templateUrl: './notification-type-edit.component.html',
    styleUrls: ['./notification-type-edit.component.css', ]
})
export class NotificationTypeEditComponent extends CRUDDialogScreenBase<NotificationType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<NotificationType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: NotificationTypeService,
    ) {
        super(messageService, translateService, dataService, 'Notification Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            NotificationTypeId: new FormControl(),
            NotificationTypeName: new FormControl(),
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
