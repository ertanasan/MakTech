// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Expense } from '@reconciliation/model/expense.model';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { ExpenseType } from '@reconciliation/model/expense-type.model';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-transfer-edit',
    templateUrl: './expense-transfer-edit.component.html',
    styleUrls: ['./expense-transfer-edit.component.css', ]
})
export class ExpenseTransferEditComponent extends CRUDDialogScreenBase<Expense> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Expense>;

    @Input() storeList: Store[];
    @Input() selectedStore: Store;
    @Input() authorized: boolean;
    @Input() authorization: string;
    @Input() showOpenFlag: boolean;
    @Input() storeReadOnly: boolean;
    statusCode = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExpenseService,
        public expenseTypeService: ExpenseTypeService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Expense');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ExpenseId: new FormControl(),
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
            ExpenseType: new FormControl(),
            Store: new FormControl(),
            ExpenseDate: new FormControl(),
            ExpenseAmount: new FormControl(),
            ReceiptNo: new FormControl(),
            OpenFlag: new FormControl(),
            PayOffDate: new FormControl(),
            ExpenseDescription: new FormControl(),
            VATRate: new FormControl(),
            StatusCode: new FormControl(),
            StatusText: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    create() {
        if (!this.currentItem.Store || this.currentItem.Store === 0) {
            this.messageService.warning('Mağaza seçmeniz gerekmektedir.');
            return;
        }
        if (!this.currentItem.ExpenseType || this.currentItem.ExpenseType === 0) {
            this.messageService.warning('Harcama tipi seçmeniz gerekmektedir.');
            return;
        }
        if (!this.currentItem.ExpenseDate) {
            this.messageService.warning('Belge tarihi girmeniz gerekmektedir.');
            return;
        }
        if (!this.currentItem.ExpenseAmount || this.currentItem.ExpenseAmount === 0) {
            this.messageService.warning('Harcama tutarı girmeniz gerekmektedir.');
            return;
        }
        super.create();
    }

    update() {
        this.currentItem.ExpenseDate = this.addHours(this.currentItem.ExpenseDate, 3);
        if (this.statusCode) {
            this.currentItem.StatusCode = 2;
        } else {
            this.currentItem.StatusCode = undefined;
        }
        super.update();
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    onSubmit() {
        this.mainScreen.refreshData();
        super.onSubmit();
    }

    get openFlag(): FormControl { return this.container.mainForm.value.OpenFlag; }
}
