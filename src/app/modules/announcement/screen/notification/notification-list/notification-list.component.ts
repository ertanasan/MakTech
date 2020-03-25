// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Notification } from '@announcement/model/notification.model';
import { NotificationService } from '@announcement/service/notification.service';
import { NotificationEditComponent } from '@announcement/screen/notification/notification-edit/notification-edit.component';
import { NotificationType } from '@announcement/model/notification-type.model';
import { NotificationTypeService } from '@announcement/service/notification-type.service';
import { NotificationStatus } from '@announcement/model/notification-status.model';
import { NotificationStatusService } from '@announcement/service/notification-status.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { finalize } from 'rxjs/operators';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
import { UserAuthType, KendoGridCommandColumnWidth } from 'app/util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-list',
    templateUrl: './notification-list.component.html',
    styleUrls: ['./notification-list.component.css', ]
})
export class NotificationListComponent extends ListScreenBase<Notification> implements AfterViewInit, OnInit {
    @ViewChild(NotificationEditComponent, {static: true}) editScreen: NotificationEditComponent;
    publishmentLoading = false;
    userAuth = UserAuthType.Other;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationService,
        public notificationTypeService: NotificationTypeService,
        public notificationStatusService: NotificationStatusService,
        private privilegeCacheService: PrivilegeCacheService,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Notification', RouterLink: '/announcement/notification'}];
    }

    createEmptyModel(): Notification {
        const tmpNotification = new Notification();
        tmpNotification.NotificationStatus = 1;
        tmpNotification.NotificationType = 2;
        return tmpNotification;
    }

    ngOnInit() {
        // this.commandColumnWidth = KendoGridCommandColumnWidth.ThreeButton;

        // Determine user auth level
        const privilegePromiseArr = [];
        privilegePromiseArr.push(this.privilegeCacheService.checkPrivilege('ANN-CustomAdmin Notification').toPromise());
        privilegePromiseArr.push(this.privilegeCacheService.checkPrivilege('ANN-CustomRegion Notification').toPromise());
        Promise.all(privilegePromiseArr).then(resultSet => {
            if (resultSet[0]) {
                this.userAuth = UserAuthType.Admin;
            } else if (resultSet[1]) {
                this.userAuth = UserAuthType.Region;
                this.createEnabled = false;
                this.updateEnabled = false;
                this.deleteEnabled = false;
            } else {
                this.userAuth = UserAuthType.Other;
                this.createEnabled = false;
                this.updateEnabled = false;
                this.deleteEnabled = false;
            }

            super.ngOnInit();
        });

        // Fill reference lists
        if (!this.notificationTypeService.completeList) {
            this.notificationTypeService.listAll();
        }
        if (!this.notificationStatusService.completeList) {
            this.notificationStatusService.listAll();
        }
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const tmpId = this.modeContext.id.substr(1, this.modeContext.id.indexOf('U') - 1);  // NOTIFICATIONID
            // const orderId = this.modeContext.id;
            // this.dataService.read(orderId).subscribe(order => {
            this.dataService.read(tmpId).subscribe(order => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), order);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    publishControl(notification: Notification) {
        if (!notification.UserCount) {
            this.dataService.read(notification.NotificationId).subscribe(
                result => {
                    if (result.UserCount) {
                        this.publishNotification(notification);
                    } else {
                        this.messageService.warning(this.translateService.instant('No user selected for this notification'));
                    }
                }, error => this.messageService.warning(this.translateService.instant('No user selected for this notification'))
            );
        } else {
            this.publishNotification(notification);
        }
    }

    publishNotification(notification: Notification) {
        this.publishmentLoading = true;
        this.dataService.publishNotification(notification)
        .pipe(
            finalize(() => {
                this.refreshList();
                this.publishmentLoading = false;
            })
        )
        .subscribe(
            result => {
                this.messageService.success(this.translateService.instant('Notification successfully published to users'));
            }, error => {
                this.messageService.error(this.translateService.instant('Publication process failed'));
        });
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate'];
        super.handleDataStateChange(state);
    }

    readDataItem(dataItem: Notification) {
        return this.dataService.read(dataItem.NotificationId);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
