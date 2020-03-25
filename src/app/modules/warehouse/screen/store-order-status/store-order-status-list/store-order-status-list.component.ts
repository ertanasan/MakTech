// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreOrderStatus } from '@warehouse/model/store-order-status.model';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { StoreOrderStatusEditComponent } from '@warehouse/screen/store-order-status/store-order-status-edit/store-order-status-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-status-list',
    templateUrl: './store-order-status-list.component.html',
    styleUrls: ['./store-order-status-list.component.css', ]
})
export class StoreOrderStatusListComponent extends ListScreenBase<StoreOrderStatus> implements AfterViewInit {
    @ViewChild(StoreOrderStatusEditComponent, {static: true}) editScreen: StoreOrderStatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreOrderStatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Store Order Status', RouterLink: '/warehouse/store-order-status'}];
    }

    createEmptyModel(): StoreOrderStatus {
        return new StoreOrderStatus();
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
