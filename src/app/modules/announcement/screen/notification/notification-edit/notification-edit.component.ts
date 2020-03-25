// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Notification } from '@announcement/model/notification.model';
import { NotificationService } from '@announcement/service/notification.service';
import { NotificationType } from '@announcement/model/notification-type.model';
import { NotificationTypeService } from '@announcement/service/notification-type.service';
import { NotificationStatus } from '@announcement/model/notification-status.model';
import { NotificationStatusService } from '@announcement/service/notification-status.service';
import { NotificationStore } from '@announcement/model/notification-store.model';
import { finalize } from 'rxjs/operators';
import { NotificationStoreService } from '@announcement/service/notification-store.service';
import { NotificationUser } from '@announcement/model/notification-user.model';
import { NotificationUserService } from '@announcement/service/notification-user.service';
import { Folder } from '@document/model/folder.model';
import { FolderService } from '@document/service/folder.service';
import { environment } from '../../../../../../environments/environment';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-edit',
    templateUrl: './notification-edit.component.html',
    styleUrls: ['./notification-edit.component.css', ]
})
export class NotificationEditComponent extends CRUDDialogScreenBase<Notification> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Notification>;
    notificationUser: NotificationUser;

    deleteUrl = '';
    downloadUrl = '';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: NotificationService,
        public notificationTypeService: NotificationTypeService,
        public notificationStatusService: NotificationStatusService,
        public notificationUserService: NotificationUserService,
        public folderService: FolderService,
    ) {
        super(messageService, translateService, dataService, 'Notification');
        this.deleteUrl = environment.baseRoute + '/Announcement/Notification/DeleteDocument';
        this.downloadUrl = environment.baseRoute + '/Announcement/Notification/DownloadDocument';
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            NotificationId: new FormControl(),
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
            NotificationText: new FormControl(),
            NotificationType: new FormControl(),
            NotificationStatus: new FormControl(),
            Folder: new FormControl(),
            FolderHandle: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.container.actionName === 'Review') {
            this.container.showProgress();
            const userId = this.modeContext.id.slice(this.modeContext.id.indexOf('U') + 1);
            this.notificationUserService.getNotificationUser(this.container.currentItem.NotificationId, userId).subscribe(
                result => {
                    this.notificationUser = result;
                    this.notificationUser.action = this.modeContext.actionId;
                    this.notificationUser.actionChoice = this.container.currentItem.actionChoice;
                    this.notificationUser.actionComment = this.container.currentItem.actionComment;
                    this.review();
                }, error => {
                    this.container.hideProgress();
                    return;
                }
            );
        } else {
            super.onSubmit();
        }
    }

    review() {
        this.notificationUserService.takeAction(this.notificationUser).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant('NotificationUser')}));
                this.mainScreen.refreshData(this.container.currentItem.getId());
                this.container.hide();
                this.mainScreen.modeEvent.emit();
            },
            error => {
                this.messageService.error(this.translateService.instant(this.updateFailMessage, {0: this.translateService.instant('NotificationUser'), 1: error}));
            }
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
