// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ReturnReason } from '@warehouse/model/return-reason.model';
import { ReturnReasonService } from '@warehouse/service/return-reason.service';
import { ReturnReasonEditComponent } from '@warehouse/screen/return-reason/return-reason-edit/return-reason-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-reason-list',
    templateUrl: './return-reason-list.component.html',
    styleUrls: ['./return-reason-list.component.css', ]
})
export class ReturnReasonListComponent extends ListScreenBase<ReturnReason> implements AfterViewInit {
    @ViewChild(ReturnReasonEditComponent, {static: true}) editScreen: ReturnReasonEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReturnReasonService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Return Reason', RouterLink: '/warehouse/return-reason'}];
    }

    createEmptyModel(): ReturnReason {
        this.dataService.listAll();
        return new ReturnReason();
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
