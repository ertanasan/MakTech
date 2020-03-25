// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CountingStatus } from '@warehouse/model/counting-status.model';
import { CountingStatusService } from '@warehouse/service/counting-status.service';
import { CountingStatusEditComponent } from '@warehouse/screen/counting-status/counting-status-edit/counting-status-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-counting-status-list',
    templateUrl: './counting-status-list.component.html',
    styleUrls: ['./counting-status-list.component.css', ]
})
export class CountingStatusListComponent extends ListScreenBase<CountingStatus> implements AfterViewInit {
    @ViewChild(CountingStatusEditComponent, {static: true}) editScreen: CountingStatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CountingStatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Counting Status', RouterLink: '/warehouse/counting-status'}];
    }

    createEmptyModel(): CountingStatus {
        return new CountingStatus();
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
