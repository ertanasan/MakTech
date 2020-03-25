// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { AssignUser } from '@helpdesk/model/assign-user.model';
import { AssignUserService } from '@helpdesk/service/assign-user.service';
import { AssignUserEditComponent } from '@helpdesk/screen/assign-user/assign-user-edit/assign-user-edit.component';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-assign-user-list',
    templateUrl: './assign-user-list.component.html',
    styleUrls: ['./assign-user-list.component.css', ]
})
export class AssignUserListComponent extends ListScreenBase<AssignUser> implements AfterViewInit, OnInit {
    @ViewChild(AssignUserEditComponent, { static: true }) editScreen: AssignUserEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: AssignUserService,
        public userService: UserService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Assign User', RouterLink: '/helpdesk/assign-user'}];
    }

    createEmptyModel(): AssignUser {
        return new AssignUser();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.userService.completeList) {
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
