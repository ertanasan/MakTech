// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RedirectionGroup } from '@helpdesk/model/redirection-group.model';
import { RedirectionGroupService } from '@helpdesk/service/redirection-group.service';
import { RedirectionGroupEditComponent } from '@helpdesk/screen/redirection-group/redirection-group-edit/redirection-group-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-redirection-group-list',
    templateUrl: './redirection-group-list.component.html',
    styleUrls: ['./redirection-group-list.component.css', ]
})
export class RedirectionGroupListComponent extends ListScreenBase<RedirectionGroup> implements AfterViewInit {
    @ViewChild(RedirectionGroupEditComponent, {static: true}) editScreen: RedirectionGroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RedirectionGroupService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Redirection Group', RouterLink: '/helpdesk/redirection-group'}];
    }

    createEmptyModel(): RedirectionGroup {
        return new RedirectionGroup();
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
