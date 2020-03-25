// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationUser } from '@announcement/model/notification-user.model';
import { NotificationUserService } from '@announcement/service/notification-user.service';
import { Notification } from '@announcement/model/notification.model';
import { NotificationService } from '@announcement/service/notification.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { StoreService } from '@store/service/store.service';
import { ListParams } from '@otmodel/list-params.model';
import { StorePackageListComponent } from '@price/screen/store-package/store-package-list/store-package-list.component';
import { NotificationGroupService } from '@announcement/service/notification-group.service';
import { NotificationGroupUserService } from '@announcement/service/notification-group-user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-user-edit',
    templateUrl: './notification-user-edit.component.html',
    styleUrls: ['./notification-user-edit.component.css', ]
})
export class NotificationUserEditComponent extends CRUDDialogScreenBase<NotificationUser> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<NotificationUser>;
    allStoresFlag = false;
    allUsersFlag = false;
    choiceByItems = [{value: 'User', text: this.translateService.instant('User Based')}
                  , {value: 'Store', text: this.translateService.instant('Store Based')}
                  , {value: 'Group', text: this.translateService.instant('Custom Groups')}];
    choiceBy = 'User';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationUserService,
        public notificationService: NotificationService,
        public userService: UserService,
        public storeService: StoreService,
        public notificationGroupService: NotificationGroupService,
        public notificationGroupUserService: NotificationGroupUserService
    ) {
        super(messageService, translateService, dataService, 'Notification User');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Notification: new FormControl(),
            User: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            ProcessInstance: new FormControl(),
            UserList: new FormControl(),
            StoreList: new FormControl(),
            GroupList: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.container.actionName === 'Create') {
            this.container.showProgress();

            switch (this.choiceBy) {
                case 'User': {
                    if (this.allUsersFlag) {
                        this.container.currentItem.UserList = this.dataService.activeUsers.filter(u => u.Department !== 1).map(ux => ux.UserId);
                    }
                    this.addNotificationUser();
                    break;
                }
                case 'Store': {
                    let branchIds;
                    this.storeService.listAllAsync().subscribe(
                        list => {
                            if (this.allStoresFlag) {
                                branchIds = list.map(l => l.OrganizationBranch);
                            } else {
                                branchIds = list.filter(s => this.container.form.form.value.StoreList.indexOf(s.StoreId) !== -1).map(l => l.OrganizationBranch);
                            }
                            this.container.currentItem.UserList = this.dataService.activeUsers.filter(u => branchIds.indexOf(u.Branch) !== -1).map(s => s.UserId);
                            this.addNotificationUser();
                    } );
                }
                case 'Group': {
                    console.log(this.container.form.form.value.GroupList);
                    this.container.currentItem.UserList = this.notificationGroupUserService.completeList.filter(ngu => this.container.form.form.value.GroupList.indexOf(ngu.NotificationGroup) !== -1).map(ngu => ngu.User);
                    console.log(this.container.currentItem);
                    this.addNotificationUser();
                }
            }
        } else { // UPDATE, DELETE
            super.onSubmit();
        }
    }

    addNotificationUser() {
        this.dataService.create(this.container.currentItem, 'AddNotificationUsers').subscribe(
            result => {
                // const returnedItem = Object.assign(this.currentItem, model);
                this.messageService.success(this.translateService.instant(`Users added to distribution list of the notification`));
                this.mainScreen.refreshData();
                this.container.hide();
                this.container.hideProgress();
            },
            error => {
                this.messageService.error(this.translateService.instant('Process failed'));
                this.container.hideProgress();
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
