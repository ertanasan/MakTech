// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CancelReason } from '@sale/model/cancel-reason.model';
import { CancelReasonService } from '@sale/service/cancel-reason.service';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { SaleDetail } from '@sale/model/sale-detail.model';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cancel-reason-edit',
    templateUrl: './cancel-reason-edit.component.html',
    styleUrls: ['./cancel-reason-edit.component.css', ]
})
export class CancelReasonEditComponent extends CRUDDialogScreenBase<CancelReason> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CancelReason>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CancelReasonService,
        public reconciliationService: ReconciliationService,
        public saleDetailService: SaleDetailService,
    ) {
        super(messageService, translateService, dataService, 'Cancel Reason');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CancelReasonId: new FormControl(),
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
            StoreReconciliation: new FormControl(),
            SaleDetail: new FormControl(),
            ReasonText: new FormControl(),
            CashierName: new FormControl(),
            ProductName: new FormControl(),
            SaleTransactionTime: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        this.currentItem = this.container.currentItem;
        (<CancelReasonService>this.dataService).SaveCancelReasons([this.currentItem], () => {
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
