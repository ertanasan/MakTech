// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { BankPosTransactions } from '@accounting/model/bank-pos-transactions.model';
import { BankPosTransactionsService } from '@accounting/service/bank-pos-transactions.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-bank-pos-transactions-edit',
    templateUrl: './bank-pos-transactions-edit.component.html',
    styleUrls: ['./bank-pos-transactions-edit.component.css', ]
})
export class BankPosTransactionsEditComponent extends CRUDDialogScreenBase<BankPosTransactions> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<BankPosTransactions>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: BankPosTransactionsService,
        public bankService: BankService,
    ) {
        super(messageService, translateService, dataService, 'Bank Pos Transactions');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            BankPosTransactionsId: new FormControl(),
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
            Bank: new FormControl(),
            StoreRef: new FormControl(),
            PosRef: new FormControl(),
            BlockedDate: new FormControl(),
            ValueDate: new FormControl(),
            Quantity: new FormControl(),
            CreditAmount: new FormControl(),
            DebitAmount: new FormControl(),
            CommissionAmount: new FormControl(),
            MikroTransferTime: new FormControl(),
            MikroStatusCode: new FormControl(),
            MikroTransactionCode: new FormControl(),
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
