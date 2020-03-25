// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CashDistribution } from '@reconciliation/model/cash-distribution.model';
import { CardDistribution } from '@reconciliation/model/card-distribution.model';
import { HttpParams, HttpClient } from '@angular/common/http';
import { RecLog } from '@reconciliation/model/rec-log.model';
import { CancelReason } from '@sale/model/cancel-reason.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-reconciliation-edit',
    templateUrl: './reconciliation-edit.component.html',
    styleUrls: ['./reconciliation-edit.component.css', ]
})
export class ReconciliationEditComponent extends CRUDDialogScreenBase<Reconciliation> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Reconciliation>;

    @Input() toRead: boolean;
    @Input() toUpdate: boolean;
    @Input() toDelete: boolean;
    cashDist: CashDistribution[];
    totals: number[];
    cardDist: CardDistribution[];
    recLog: RecLog[];
    cancelReasons: CancelReason[];
    newCashDist: any[];

    @Input() set StoreReconciliationId(pId: number) {
        this.dataService.read(pId).subscribe(
          result => {
            // console.log(result);
            this.organizeCashDist(result.CashDist);
            this.cashDist = this.newCashDist;
            this.cardDist = result.CardDist;
            this.recLog = result.RecLog;
            this.cancelReasons = result.CancelReasons;
          }, error => {
              console.log(error);
              this.messageService.error(this.translateService.instant('An error occurred while getting history records'));
          }
        );
      }


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ReconciliationService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Reconciliation');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreReconciliationId: new FormControl(),
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
            Store: new FormControl(),
            ReconciliationDate: new FormControl(),
            ZetAmount: new FormControl(),
            DefinedAdvance: new FormControl(),
            ExpenseAmount: new FormControl(),
            CashAmount: new FormControl(),
            CardAmount: new FormControl(),
            RecoveredAmount: new FormControl(),
            AdjustmentAmount: new FormControl(),
            AdjustmentReason: new FormControl(),
            NetoffAmount: new FormControl(),
            BankAmount: new FormControl(),
            CurrentAdvance: new FormControl(),
            ExpenseReturn: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    organizeCashDist(cashDist) {
        this.newCashDist = [];
        this.totals = [0, 0, 0];
        const g1 = cashDist.filter(row => (row.GroupCode === 1));
        // console.log(g1);
        g1.forEach(row => {
            const r = { BanknoteAmount: row.BanknoteAmount, Quantity1: row.Quantity, Amount1: row.Amount, Quantity2: 0, Amount2: 0, Quantity3: 0, Amount3: 0 };
            this.newCashDist.push(r);
            this.totals[0] += row.Amount;
        });
        const g2 = cashDist.filter(row => (row.GroupCode === 2));
        g2.forEach(row => {
            this.newCashDist.forEach(cd => {
                if (cd.BanknoteAmount === row.BanknoteAmount) {
                    cd.Quantity2 = row.Quantity;
                    cd.Amount2 = row.Amount;
                }
            });
            this.totals[1] += row.Amount;
        });
        const g3 = cashDist.filter(row => (row.GroupCode === 3));
        g3.forEach(row => {
            this.newCashDist.forEach(cd => {
                if (cd.BanknoteAmount === row.BanknoteAmount) {
                    cd.Quantity3 = row.Quantity;
                    cd.Amount3 = row.Amount;
                }
            });
            this.totals[2] += row.Amount;
        });
    }
}
