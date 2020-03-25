// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { NotificationGroup } from '@announcement/model/notification-group.model';
import { NotificationGroupService } from '@announcement/service/notification-group.service';
import { NotificationGroupEditComponent } from '@announcement/screen/notification-group/notification-group-edit/notification-group-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-notification-group-list',
    templateUrl: './notification-group-list.component.html',
    styleUrls: ['./notification-group-list.component.css', ]
})
export class NotificationGroupListComponent extends ListScreenBase<NotificationGroup> implements AfterViewInit {
    @ViewChild(NotificationGroupEditComponent, { static: true }) editScreen: NotificationGroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: NotificationGroupService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Announcement' }, {Caption: 'Notification Group', RouterLink: '/announcement/notification-group'}];
    }

    createEmptyModel(): NotificationGroup {
        return new NotificationGroup();
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
