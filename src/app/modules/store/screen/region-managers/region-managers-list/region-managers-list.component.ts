// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RegionManagers } from '@store/model/region-managers.model';
import { RegionManagersService } from '@store/service/region-managers.service';
import { RegionManagersEditComponent } from '@store/screen/region-managers/region-managers-edit/region-managers-edit.component';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-region-managers-list',
    templateUrl: './region-managers-list.component.html',
    styleUrls: ['./region-managers-list.component.css', ]
})
export class RegionManagersListComponent extends ListScreenBase<RegionManagers> implements AfterViewInit, OnInit {
    @ViewChild(RegionManagersEditComponent, {static: true}) editScreen: RegionManagersEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RegionManagersService,
        public userService: UserService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Region Managers', RouterLink: '/store/region-managers'}];
    }

    createEmptyModel(): RegionManagers {
        return new RegionManagers();
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
