// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreOrderHistory } from '@warehouse/model/store-order-history.model';
import { StoreOrderHistoryService } from '@warehouse/service/store-order-history.service';
import { StoreOrder } from '@warehouse/model/store-order.model';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrderStatus } from '@warehouse/model/store-order-status.model';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-history-edit',
    templateUrl: './store-order-history-edit.component.html',
    styleUrls: ['./store-order-history-edit.component.css', ]
})
export class StoreOrderHistoryEditComponent extends CRUDDialogScreenBase<StoreOrderHistory> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreOrderHistory>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreOrderHistoryService,
        public storeOrderService: StoreOrderService,
        public storeOrderStatusService: StoreOrderStatusService,
    ) {
        super(messageService, translateService, dataService, 'Store Order History');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreOrderHistoryId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            StoreOrder: new FormControl(),
            HistoryTime: new FormControl(),
            Status: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
