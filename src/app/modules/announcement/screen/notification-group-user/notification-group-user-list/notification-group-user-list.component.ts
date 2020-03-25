// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationGroupUser } from '@announcement/model/notification-group-user.model';
import { NotificationGroupUserService } from '@announcement/service/notification-group-user.service';
import { NotificationGroupUserEditComponent } from '@announcement/screen/notification-group-user/notification-group-user-edit/notification-group-user-edit.component';
import { NotificationGroup } from '@announcement/model/notification-group.model';
import { NotificationGroupService } from '@announcement/service/notification-group.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-group-user-list',
    templateUrl: './notification-group-user-list.component.html',
    styleUrls: ['./notification-group-user-list.component.css', ]
})
export class NotificationGroupUserListComponent extends ListScreenBase<NotificationGroupUser> implements AfterViewInit, OnInit {
    @ViewChild(NotificationGroupUserEditComponent, { static: true }) editScreen: NotificationGroupUserEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationGroupUserService,
        public notificationGroupService: NotificationGroupService,
        public userService: UserService,
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.dataLoading = true;
        this.dataService.listAsync(this.listParams).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            listResult => {
                this.dataList = listResult.Data;
            },
            error => {
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Notification Group User', RouterLink: '/announcement/notification-group-user'}];
    }

    createEmptyModel(): NotificationGroupUser {
        const notificationGroupUser = new NotificationGroupUser();
        if (this.leftRelationId > 0) {
            notificationGroupUser.NotificationGroup = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            notificationGroupUser.User = this.rightRelationId;
        }
        return notificationGroupUser;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId && !this.notificationGroupService.completeList) {
            this.notificationGroupService.listAll();
        }
        if (!this.rightRelationId && !this.userService.completeList) {
            this.userService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
