// Created by OverGenerator
/*Section="Imports"*/
import { ViewChild, AfterViewInit, Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestGroup } from '@helpdesk/model/request-group.model';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { RequestGroupEditComponent } from '@helpdesk/screen/request-group/request-group-edit/request-group-edit.component';

/*Section="ClassHeader"*/

@Component({
    selector: 'ot-request-group-list',
    templateUrl: './request-group-list.component.html',
    styleUrls: ['./request-group-list.component.css', ]
})
export class RequestGroupListComponent extends ListScreenBase<RequestGroup> implements AfterViewInit {
    @ViewChild(RequestGroupEditComponent, {static: true}) editScreen: RequestGroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestGroupService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Group', RouterLink: '/helpdesk/request-group'}];
    }

    createEmptyModel(): RequestGroup {
        return new RequestGroup();
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
