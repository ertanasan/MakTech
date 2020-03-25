// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { NotificationStore } from '@announcement/model/notification-store.model';
import { NotificationStoreService } from '@announcement/service/notification-store.service';
import { Notification } from '@announcement/model/notification.model';
import { NotificationService } from '@announcement/service/notification.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-store-edit',
    templateUrl: './notification-store-edit.component.html',
    styleUrls: ['./notification-store-edit.component.css', ]
})
export class NotificationStoreEditComponent extends CRUDDialogScreenBase<NotificationStore> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<NotificationStore>;
    allStoresFlag = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationStoreService,
        public notificationService: NotificationService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Notification Store');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Notification: new FormControl(),
            Store: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            ProcessInstance: new FormControl(),
            StoreList: new FormControl()
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

            if (this.allStoresFlag) {
                this.container.currentItem.StoreList = this.storeService.completeList.map(s => s.StoreId);
            }

            this.dataService.create(this.container.currentItem, 'AddNotificationStores').subscribe(
                result => {
                    // const returnedItem = Object.assign(this.currentItem, model);
                    this.messageService.success(this.translateService.instant(`Stores added to distribution list of the notification`));
                    this.mainScreen.refreshData();
                    this.container.hide();
                    this.container.hideProgress();
                },
                error => {
                    this.messageService.error(this.translateService.instant('Process failed'));
                    this.container.hideProgress();
                }
            );
        } else {
            super.onSubmit();
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
