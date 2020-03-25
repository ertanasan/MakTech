// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { UserEditComponent } from '@security/screen/user/user-edit/user-edit.component';
import { Organization } from '@organization/model/organization.model';
import { OrganizationService } from '@organization/service/organization.service';
import { Profession } from '@security/model/profession.model';
import { ProfessionService } from '@security/service/profession.service';
import { Title } from '@security/model/title.model';
import { TitleService } from '@security/service/title.service';
import { Location } from '@security/model/location.model';
import { LocationService } from '@security/service/location.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-user-list',
    templateUrl: './user-list.component.html',
    styleUrls: ['./user-list.component.css', ]
})
export class UserListComponent extends ListScreenBase<User> implements AfterViewInit, OnInit {
    @ViewChild(UserEditComponent, {static: true}) editScreen: UserEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: UserService,
        public organizationService: OrganizationService,
        public professionService: ProfessionService,
        public titleService: TitleService,
        public locationService: LocationService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Security' }, {Caption: 'User', RouterLink: '/security/user'}];
    }

    createEmptyModel(): User {
        return new User();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.organizationService.completeList) {
            this.organizationService.listAll();
        }
        if (!this.professionService.completeList) {
            this.professionService.listAll();
        }
        if (!this.titleService.completeList) {
            this.titleService.listAll();
        }
        if (!this.locationService.completeList) {
            this.locationService.listAll();
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
