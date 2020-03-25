// Created by OverGenerator
/*Section="Imports"*/
import { ViewChild, AfterViewInit, Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestStatus } from '@helpdesk/model/request-status.model';
import { RequestStatusService } from '@helpdesk/service/request-status.service';
import { RequestStatusEditComponent } from '@helpdesk/screen/request-status/request-status-edit/request-status-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-status-list',
    templateUrl: './request-status-list.component.html',
    styleUrls: ['./request-status-list.component.css', ]
})
export class RequestStatusListComponent extends ListScreenBase<RequestStatus> implements AfterViewInit {
    @ViewChild(RequestStatusEditComponent, {static: true}) editScreen: RequestStatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestStatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Status', RouterLink: '/helpdesk/request-status'}];
    }

    createEmptyModel(): RequestStatus {
        return new RequestStatus();
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
