// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SaleDailySummary } from '@sale/model/sale-daily-summary.model';
import { SaleDailySummaryService } from '@sale/service/sale-daily-summary.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { StoreCashRegister } from '@store/model/store-cash-register.model';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-daily-summary-edit',
    templateUrl: './sale-daily-summary-edit.component.html',
    styleUrls: ['./sale-daily-summary-edit.component.css', ]
})
export class SaleDailySummaryEditComponent extends CRUDDialogScreenBase<SaleDailySummary> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SaleDailySummary>;
    @ViewChild(DropdownEntryComponent, {static: true}) storeID: DropdownEntryComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SaleDailySummaryService,
        public storeService: StoreService,
        public storeCashRegisterService: StoreCashRegisterService,
    ) {
        super(messageService, translateService, dataService, 'Sale Daily Summary');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SaleDailySummaryId: new FormControl(),
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
            StoreID: new FormControl(),
            TransactionDate: new FormControl(),
            ZetNo: new FormControl(),
            ReceiptCount: new FormControl(),
            ReceiptTotal: new FormControl(),
            RefundCount: new FormControl(),
            RefundAmount: new FormControl(),
            CashAmount: new FormControl(),
            CardAmount: new FormControl(),
            CashRegister: new FormControl(),
            SlpTotal: new FormControl(),
            SlpCount: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    onSubmit() {
        this.container.currentItem.TransactionDate = this.addHours(this.container.currentItem.TransactionDate,3);
        super.onSubmit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
