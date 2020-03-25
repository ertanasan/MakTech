// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestDetail } from '@helpdesk/model/request-detail.model';
import { RequestDetailService } from '@helpdesk/service/request-detail.service';
import { RequestDetailEditComponent } from '@helpdesk/screen/request-detail/request-detail-edit/request-detail-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-detail-list',
    templateUrl: './request-detail-list.component.html',
    styleUrls: ['./request-detail-list.component.css', ]
})
export class RequestDetailListComponent extends ListScreenBase<RequestDetail> implements AfterViewInit {
    @ViewChild(RequestDetailEditComponent, {static: true}) editScreen: RequestDetailEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestDetailService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Detail', RouterLink: '/helpdesk/request-detail'}];
    }

    createEmptyModel(): RequestDetail {
        return new RequestDetail();
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
