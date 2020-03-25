// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationUser } from '@announcement/model/notification-user.model';
import { NotificationUserService } from '@announcement/service/notification-user.service';
import { NotificationUserEditComponent } from '@announcement/screen/notification-user/notification-user-edit/notification-user-edit.component';
import { NotificationService } from '@announcement/service/notification.service';
import { NotificationGroupService } from '@announcement/service/notification-group.service';
import { NotificationGroupUserService } from '@announcement/service/notification-group-user.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-user-list',
    templateUrl: './notification-user-list.component.html',
    styleUrls: ['./notification-user-list.component.css', ]
})
export class NotificationUserListComponent extends ListScreenBase<NotificationUser> implements AfterViewInit, OnInit {
    @ViewChild(NotificationUserEditComponent, {static: true}) editScreen: NotificationUserEditComponent;
    @Input() notificationPublished = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationUserService,
        public notificationService: NotificationService,
        public notificationGroupService: NotificationGroupService,
        public notificationGroupUserService: NotificationGroupUserService
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.listParams.take = 10000;
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
        return [{Caption: 'Announcement' }, {Caption: 'Notification User', RouterLink: '/announcement/notification-user'}];
    }

    createEmptyModel(): NotificationUser {
        const notificationUser = new NotificationUser();
        if (this.leftRelationId > 0) {
            notificationUser.Notification = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            notificationUser.User = this.rightRelationId;
        }
        return notificationUser;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId && !this.notificationService.completeList) {
            this.notificationService.listAll();
        }
        this.dataService.listActiveUsers();
        this.dataService.listActiveStores();
        this.notificationGroupService.listAll();
        this.notificationGroupUserService.listAllGroupUsers();
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
