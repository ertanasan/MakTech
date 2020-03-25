// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ReturnDestination } from '@warehouse/model/return-destination.model';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';
import { ReturnDestinationEditComponent } from '@warehouse/screen/return-destination/return-destination-edit/return-destination-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-destination-list',
    templateUrl: './return-destination-list.component.html',
    styleUrls: ['./return-destination-list.component.css', ]
})
export class ReturnDestinationListComponent extends ListScreenBase<ReturnDestination> implements AfterViewInit {
    @ViewChild(ReturnDestinationEditComponent, {static: true}) editScreen: ReturnDestinationEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReturnDestinationService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Return Destination', RouterLink: '/warehouse/return-destination'}];
    }

    createEmptyModel(): ReturnDestination {
        return new ReturnDestination();
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
