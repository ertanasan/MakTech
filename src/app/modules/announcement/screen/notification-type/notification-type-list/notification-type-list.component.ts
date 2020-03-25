// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationType } from '@announcement/model/notification-type.model';
import { NotificationTypeService } from '@announcement/service/notification-type.service';
import { NotificationTypeEditComponent } from '@announcement/screen/notification-type/notification-type-edit/notification-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-type-list',
    templateUrl: './notification-type-list.component.html',
    styleUrls: ['./notification-type-list.component.css', ]
})
export class NotificationTypeListComponent extends ListScreenBase<NotificationType> implements AfterViewInit {
    @ViewChild(NotificationTypeEditComponent, {static: true}) editScreen: NotificationTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Notification Type', RouterLink: '/announcement/notification-type'}];
    }

    createEmptyModel(): NotificationType {
        return new NotificationType();
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
