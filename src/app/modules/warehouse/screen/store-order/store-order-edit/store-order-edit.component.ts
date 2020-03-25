// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, AfterViewInit, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreOrder } from '@warehouse/model/store-order.model';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { StoreOrderListComponent } from '../store-order-list/store-order-list.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-edit',
    templateUrl: './store-order-edit.component.html',
    styleUrls: ['./store-order-edit.component.css', ]
})
export class StoreOrderEditComponent extends CRUDDialogScreenBase<StoreOrder> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreOrder>;
    // statusReadOnly = false;
    // statusStepBack = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StoreOrderService,
        public storeOrderStatusService: StoreOrderStatusService
    ) {
        super(messageService, translateService, dataService, 'Store Order');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreOrderId: new FormControl(),
            OrderCode: new FormControl(),
            Status: new FormControl(),
            ShipmentDate: new FormControl(),
            // StatusToBackStep: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    onSubmit() {
        this.container.currentItem.ShipmentDate = (<StoreOrderListComponent>this.mainScreen).addHours(this.container.currentItem.ShipmentDate, 3);
        this.container.currentItem.OrderDate = (<StoreOrderListComponent>this.mainScreen).addHours(this.container.currentItem.OrderDate, 3);
        // if (this.statusStepBack) {
        //     this.container.currentItem.Status = 3;
        // }
        super.onSubmit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
