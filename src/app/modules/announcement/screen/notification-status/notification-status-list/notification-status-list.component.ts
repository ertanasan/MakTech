// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationStatus } from '@announcement/model/notification-status.model';
import { NotificationStatusService } from '@announcement/service/notification-status.service';
import { NotificationStatusEditComponent } from '@announcement/screen/notification-status/notification-status-edit/notification-status-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-status-list',
    templateUrl: './notification-status-list.component.html',
    styleUrls: ['./notification-status-list.component.css', ]
})
export class NotificationStatusListComponent extends ListScreenBase<NotificationStatus> implements AfterViewInit {
    @ViewChild(NotificationStatusEditComponent, {static: true}) editScreen: NotificationStatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationStatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Notification Status', RouterLink: '/announcement/notification-status'}];
    }

    createEmptyModel(): NotificationStatus {
        return new NotificationStatus();
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
