// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
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
import { VatGroupService } from '@reconciliation/service/vat-group.service';
import { Subscription } from 'rxjs';
import { RegionManagers } from '@store/model/region-managers.model';
import { RegionManagersService } from '@store/service/region-managers.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-edit',
    templateUrl: './expense-edit.component.html',
    styleUrls: ['./expense-edit.component.css', ]
})
export class ExpenseEditComponent extends CRUDDialogScreenBase<Expense> implements OnInit, OnDestroy {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Expense>;

    @Input() storeList: Store[];
    @Input() regionManagerList: RegionManagers[];
    @Input() selectedStore: Store;
    @Input() authorized: boolean;
    @Input() authorization: string;
    @Input() showOpenFlag: boolean;
    @Input() showHasReceipt: boolean;
    @Input() storeReadOnly: boolean;
    @Input() showRegionOrStore: boolean;
    showSubscription: Subscription;
    regionExpense = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExpenseService,
        public expenseTypeService: ExpenseTypeService,
        public storeService: StoreService,
        public regionManagerService: RegionManagersService,
        public vatGroupService: VatGroupService,
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
            VATRate: new FormControl(null, Validators.required),
            HasReceipt: new FormControl(),
            RegionOrStore: new FormControl(),
            RegionManager: new FormControl(),
        });
    }

    ngOnInit() {
        this.showSubscription = this.container.onShow.subscribe(item => {
            if (this.vatGroupService.completeList.map(a => a.VatRate).indexOf(this.container.initialItem.VATRate) === -1) {
                this.container.mainForm.get('VATRate').setValue(null);
            }
        });
        super.ngOnInit();
    }

    ngOnDestroy () {
        this.showSubscription.unsubscribe();
    }

    beforeSubmitValidations() {
        switch (this.container.actionName) {
            case 'Create':
                if (!this.regionExpense && (!this.container.currentItem.Store || this.container.currentItem.Store === 0)) {
                    this.messageService.warning('Mağaza seçmeniz gerekmektedir.');
                    return false;
                }
                if (this.regionExpense && (!this.container.currentItem.RegionManager || this.container.currentItem.RegionManager === 0)) {
                    this.messageService.warning('Bölge sorumlusu seçmeniz gerekmektedir.');
                    return false;
                }
                if (!this.container.currentItem.ExpenseType || this.container.currentItem.ExpenseType === 0) {
                    this.messageService.warning('Harcama tipi seçmeniz gerekmektedir.');
                    return false;
                }
                if (!this.container.currentItem.ExpenseDate) {
                    this.messageService.warning('Belge tarihi girmeniz gerekmektedir.');
                    return false;
                }
                if (!this.container.currentItem.ExpenseAmount || this.container.currentItem.ExpenseAmount === 0) {
                    this.messageService.warning('Harcama tutarı girmeniz gerekmektedir.');
                    return false;
                }
                if (this.container.currentItem.HasReceipt && !this.container.currentItem.ReceiptNo) {
                    this.messageService.warning('Fatura No girmeniz gerekmektedir.');
                    return false;
                }
                return true;
            case 'Update':
                if (this.selectedStore) {
                    const d1 = new Date(this.container.currentItem.CreateDate);
                    const d2 = new Date();
                    if (d1.getDate() !== d2.getDate() || d1.getMonth() !== d2.getMonth() || d1.getFullYear() !== d2.getFullYear()) {
                        this.messageService.warning('Aynı gün içinde güncelleme yapabilirsiniz, farklı bir günde girdiğiniz masrafı güncelleyemezsiniz.');
                        return false;
                    }
                }
                return true;
            default:
                return true;
        }
    }

    onSubmit() {
        if (this.beforeSubmitValidations()) {
            this.mainScreen.refreshData();
            super.onSubmit();
        }
    }

    onHasReceiptSwtiched(isOn) {
        if (!isOn) {
            this.container.mainForm.get('VATRate').setValue(0);
            this.container.mainForm.get('ReceiptNo').reset();
        } else if (this.container.initialItem.ExpenseId) {
            this.container.mainForm.get('VATRate').setValue(this.container.initialItem.VATRate);
            this.container.mainForm.get('ReceiptNo').setValue(this.container.initialItem.ReceiptNo);
        } else {
            this.container.mainForm.get('VATRate').reset();
        }
    }

    onRegionOrStoreSwtiched(isOn) {
        this.regionExpense = isOn;
        if (!isOn) {
            this.container.mainForm.get('RegionManager').reset();
        } else {
            this.container.mainForm.get('Store').reset();
        }
    }

    get openFlag(): FormControl { return this.container.mainForm.value.OpenFlag; }
    get hasReceipt(): FormControl { return this.container.mainForm.value.HasReceipt; }
}
