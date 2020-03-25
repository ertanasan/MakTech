// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreOrderHistory } from '@warehouse/model/store-order-history.model';
import { StoreOrderHistoryService } from '@warehouse/service/store-order-history.service';
import { StoreOrderHistoryEditComponent } from '@warehouse/screen/store-order-history/store-order-history-edit/store-order-history-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-history-list',
    templateUrl: './store-order-history-list.component.html',
    styleUrls: ['./store-order-history-list.component.css', ]
})
export class StoreOrderHistoryListComponent extends ListScreenBase<StoreOrderHistory> implements AfterViewInit {
    @ViewChild(StoreOrderHistoryEditComponent, {static: true}) editScreen: StoreOrderHistoryEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreOrderHistoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Store Order History', RouterLink: '/warehouse/store-order-history'}];
    }

    createEmptyModel(): StoreOrderHistory {
        return new StoreOrderHistory();
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
