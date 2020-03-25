// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationGroupUser } from '@announcement/model/notification-group-user.model';
import { NotificationGroupUserService } from '@announcement/service/notification-group-user.service';
import { NotificationGroup } from '@announcement/model/notification-group.model';
import { NotificationGroupService } from '@announcement/service/notification-group.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-group-user-edit',
    templateUrl: './notification-group-user-edit.component.html',
    styleUrls: ['./notification-group-user-edit.component.css', ]
})
export class NotificationGroupUserEditComponent extends CRUDDialogScreenBase<NotificationGroupUser> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<NotificationGroupUser>;
    userList: User[] = [];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: NotificationGroupUserService,
        public notificationGroupService: NotificationGroupService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Notification Group User');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            NotificationGroup: new FormControl(),
            User: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
        });
    }

    ngOnInit() {
        this.unsubscribe.push(this.userService.completeListChanged.subscribe(ul => {
            this.userList = this.userService.completeList.filter(u => !u.Deleted && u.Active && (u.Description === null || !u.Description.includes('#GenericUser')));
        }));
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
