// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationStore } from '@announcement/model/notification-store.model';
import { NotificationStoreService } from '@announcement/service/notification-store.service';
import { NotificationStoreEditComponent } from '@announcement/screen/notification-store/notification-store-edit/notification-store-edit.component';
import { NotificationService } from '@announcement/service/notification.service';
import { StoreService } from '@store/service/store.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-store-list',
    templateUrl: './notification-store-list.component.html',
    styleUrls: ['./notification-store-list.component.css', ]
})
export class NotificationStoreListComponent extends ListScreenBase<NotificationStore> implements AfterViewInit, OnInit {
    @ViewChild(NotificationStoreEditComponent, {static: true}) editScreen: NotificationStoreEditComponent;
    @Input() notificationPublished = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationStoreService,
        public notificationService: NotificationService,
        public storeService: StoreService,
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
        return [{Caption: 'Announcement' }, {Caption: 'Notification Store', RouterLink: '/announcement/notification-store'}];
    }

    createEmptyModel(): NotificationStore {
        const notificationStore = new NotificationStore();
        if (this.leftRelationId > 0) {
            notificationStore.Notification = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            notificationStore.Store = this.rightRelationId;
        }
        return notificationStore;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId && !this.notificationService.completeList) {
            this.notificationService.listAll();
        }
        if (!this.rightRelationId && !this.storeService.completeList) {
            this.storeService.listAll()
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    //#endregion Customized

    /*Section="ClassFooter"*/
}
