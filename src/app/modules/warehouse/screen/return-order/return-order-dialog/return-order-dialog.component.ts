// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input, AfterViewInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ReturnOrder } from '@warehouse/model/return-order.model';
import { ReturnOrderService } from '@warehouse/service/return-order.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ReturnStatus } from '@warehouse/model/return-status.model';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { OrderStatusHistoryService } from '@warehouse/service/order-status-history.service';
import { OrderStatusHistory } from '@warehouse/model/order-status-history.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-order-dialog',
    templateUrl: './return-order-dialog.component.html',
    styleUrls: ['./return-order-dialog.component.css', ]
})
export class ReturnOrderDialogComponent implements OnInit {
    @ViewChild(InputDialogComponent, {static: true}) container: InputDialogComponent;

    mainScreen: MainScreenBase;
    public isApprove: boolean;
    public rejectReason: string;
    public approveMessage: string;
    public rejectMesssage: string;
    callScreen: any;

    dataItem: ReturnOrder;

    constructor(public dataService: ReturnOrderService,
        public messageService: GrowlMessageService,
        public orderStatusHistoryService: OrderStatusHistoryService ) {
    }

    ngOnInit() {
    }


    onAction() {
        this.callScreen.callReview();
        this.container.hide();
        /*
        if (this.isApprove) {
            this.dataItem.Status = this.dataItem.Status + 1;
        } else {
            if (this.rejectReason.length === 0) {
                this.messageService.warning('İade nedeni giriniz.');
                return;
            }
            this.dataItem.Status = this.dataItem.Status - 1;
        }
        this.dataService.update(this.dataItem).subscribe( () => {
            const h: OrderStatusHistory = new OrderStatusHistory();
            h.Status = this.dataItem.Status;
            h.ReturnOrder = this.dataItem.ReturnOrderId;
            h.OperationCode = this.isApprove ? 1 : 2;
            h.Comment = this.rejectReason;
            this.orderStatusHistoryService.create(h).subscribe(() => {
                this.messageService.success(this.isApprove ? 'Onaylama işlemi tamamlandı.' : 'Ürün iade işlemi ret edildi.');
                this.mainScreen.refreshData(this.dataItem.ReturnOrderId);
                this.container.hide();
            }, error => {
                this.messageService.error(`İade emri statü tarihçe oluşturma hatası : ${error}`);
            });
        }, error => {
            this.messageService.error(`İade emri statü güncelleme hatası : ${error}`);
        });
        */
    }

    onClose() {
        this.callScreen.notAccepted();
    }

}
