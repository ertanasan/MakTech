// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ReturnStatus } from '@warehouse/model/return-status.model';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { ReturnStatusEditComponent } from '@warehouse/screen/return-status/return-status-edit/return-status-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-status-list',
    templateUrl: './return-status-list.component.html',
    styleUrls: ['./return-status-list.component.css', ]
})
export class ReturnStatusListComponent extends ListScreenBase<ReturnStatus> implements AfterViewInit {
    @ViewChild(ReturnStatusEditComponent, {static: true}) editScreen: ReturnStatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReturnStatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Return Status', RouterLink: '/warehouse/return-status'}];
    }

    createEmptyModel(): ReturnStatus {
        return new ReturnStatus();
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
