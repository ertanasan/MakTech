// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { ReconciliationEditComponent } from '@reconciliation/screen/reconciliation/reconciliation-edit/reconciliation-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { BanknoteService } from '@reconciliation/service/banknote.service';
import { Banknote } from '@reconciliation/model/banknote.model';
import { Expense } from '@reconciliation/model/expense.model';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { SaleDailySummaryService } from '@sale/service/sale-daily-summary.service';
import { SaleDailySummary } from '@sale/model/sale-daily-summary.model';
import { DiffReasonService } from '@reconciliation/service/diff-reason.service';
import { DiffReason } from '@reconciliation/model/diff-reason.model';
import { CashDistribution } from '@reconciliation/model/cash-distribution.model';
import { CardDistribution } from '@reconciliation/model/card-distribution.model';
import { AdjustmentService } from '@reconciliation/service/adjustment.service';
import { CancelReasonService } from '@sale/service/cancel-reason.service';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { CancelReason } from '@sale/model/cancel-reason.model';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { GridComponent, RowFilterModule, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { MessageDialogComponent } from '@otuicontainer/dialog/message-dialog/message-dialog.component';
import { ZControlLog } from '@reconciliation/model/z-control-log.model';
import { SaleInvoiceService } from '@accounting/service/sale-invoice.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-reconciliation-list',
    templateUrl: './reconciliation-list.component.html',
    styleUrls: ['./reconciliation-list.component.css', ]
})
export class ReconciliationListComponent extends ListScreenBase<Reconciliation> implements AfterViewInit, OnInit {
    @ViewChild(GridComponent, {static: true}) reasonGrid: GridComponent;
    @ViewChild(MessageDialogComponent, {static: true}) warningMessageDialog: MessageDialogComponent;

    warningMessage = 'Kasadan Z Raporu alınmış! Z Raporu almadan mutabakat işlemine başlamanız gerekmektedir. Z raporu almanız gereken zaman uyarı olarak gelecektir.'
    storeList: Store[];
    storeListLoading: any;
    selectedStoreId: number;
    selectedStore: Store;

    storeReadOnly = false;
    recDate: Date;
    screenNo = 1;

    bankNotes: any[];
    bankNotesForBank: any[];
    bankNotesinHand: any[];
    totalBankNotesinHand: number;

    expenses: Expense[];
    expenseTotal: number;
    expensePayment: number;
    adjustmentTotal: number;
    invoiceTotal: number;

    cancelReasons: CancelReason[];

    prevRec: Reconciliation;
    rec: Reconciliation;

    zetStore: SaleDailySummary[];
    zetTotal: number;
    zetCount: number;

    netOff: number;
    cashForBank: number;

    diffReasons: DiffReason[];
    xdiffReasons: DiffReason[];
    diffReasonCodes: any[];

    totalCashDeficit = 0;
    dailyCashDeficit = 0;
    dailyCashSurplus = 0;
    diffReadonly = true;
    recoverAmountReadonly = true;
    deficitCount = 0;

    authenticate = false;

    LastStep = 10;
    diffLimit = 5;
    allSent = false;
    cancelReasonsActiveList: any;
    listParamsCancel: ListParams = new ListParams();
    zetWarningMessage = true;
    zReportStatus: string;
    intervalHolder: any;
    zClassOK: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReconciliationService,
        public storeService: StoreService,
        public bankNoteService: BanknoteService,
        public datePipe: DatePipe,
        public currencyPipe: CurrencyPipe,
        public expenseService: ExpenseService,
        public adjustmentService: AdjustmentService,
        public invoiceService: SaleInvoiceService,
        public zetService: SaleDailySummaryService,
        public diffReasonService: DiffReasonService,
        public cancelReasonService: CancelReasonService,
        public formBuilder: FormBuilder,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.listParamsCancel.take = 1000;
        if (this.cancelReasons) {
            this.cancelReasonsActiveList = process(this.cancelReasons, this.listParamsCancel);
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParamsCancel.take = 1000;
        if (state.sort) {
            this.listParamsCancel.sort = state.sort;
        }
        this.refreshList();
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Reconciliation', RouterLink: '/reconciliation/reconciliation'}];
    }

    createEmptyModel(): Reconciliation {
        return new Reconciliation();
    }

    saveRec(laststepno, callback) {
        this.rec.Event = 1;
        this.rec.Organization = 1;
        this.rec.Store = this.selectedStoreId;
        this.rec.ZetAmount = this.zetTotal;
        this.rec.DefinedAdvance = this.selectedStore.Advance;
        this.rec.ExpenseAmount = this.expenseTotal;
        this.rec.NetoffAmount = this.netOff;
        this.rec.ExpenseReturn = this.expensePayment;
        this.rec.TotalOpenExpense = this.prevRec.TotalOpenExpense + this.expenseTotal - this.expensePayment;
        this.rec.AdjustmentAmount = this.adjustmentTotal;
        //if (!this.rec.LastStepNo || this.screenNo > this.rec.LastStepNo) {
            this.rec.LastStepNo = laststepno; //this.screenNo;
        //}
        this.rec.CompleteFlag = (this.screenNo === this.LastStep);
        if (this.rec.CompleteFlag && (this.rec.DefinedAdvance - this.rec.CurrentAdvance - this.rec.TotalOpenExpense) > this.diffLimit) {
            if (this.prevRec.StoreReconciliationId > 0) {
                this.rec.DeficitCycleCount = this.prevRec.DeficitCycleCount + 1;
            } else {
                this.rec.DeficitCycleCount = 1;
            }
        } else {
            this.rec.DeficitCycleCount = 0;
        }
        if (Math.abs(this.netOff) <= this.diffLimit) {
            this.rec.DiffReason = '';
            this.rec.DiffReasonCodes = '';
            this.diffReasonCodes = [];
        } else if (this.diffReasonCodes) {
            this.rec.DiffReasonCodes = '';
            this.diffReasonCodes.forEach(a => this.rec.DiffReasonCodes += a.toString() + ',');
        }
        // console.log('SaveRec, rec : ', this.rec);
        this.dataService.SaveReconciliation(this.rec).subscribe(result => {
            // console.log('saveRec : ', result);
            this.rec.StoreReconciliationId = parseInt(result.toString(), 10);
            if (this.rec.CashDist[0].CashDistributionId === 0) {
                this.readRec(() => {});
            }
            callback();
        }, error => {
            this.messageService.error('Kaydedilemedi, sayfayı yenile yapıp mutabakata devam edebilirsiniz.');
        });
    }

    readCancelReasons(callback) {
        this.cancelReasonService.ListReconciliationCancels(this.datePipe.transform(this.rec.ReconciliationDate, 'yyyy-MM-dd'), this.rec.Store).subscribe(result => {
            this.cancelReasons = result;
            this.refreshList();
            callback();
        });
    }

    readRec(cb) {
        this.dataService.ReadReconciliationDetails(this.selectedStoreId).subscribe(result => {
            this.rec = result;
            if (this.rec.StoreReconciliationId === 0) {
                // console.log('this.rec.ReconciliationDate = this.recDate', this.recDate);
                this.rec.ReconciliationDate = this.dataService.addHours(this.recDate, 3);
            } else {
                // console.log('this.recDate = new Date(this.rec.ReconciliationDate)', this.rec.ReconciliationDate);
                this.recDate = new Date(this.rec.ReconciliationDate);
            }
            this.readZet(() => {});

            if (this.rec.CashDist.length === 0) {
                this.bankNoteService.listAllAsync().subscribe(noteresult => {
                    noteresult.forEach(row => {
                        const r1: CashDistribution = new CashDistribution();
                        r1.Event = 1;
                        r1.Organization = 1;
                        r1.Banknote = row.BanknoteId;
                        r1.BanknoteAmount = row.BanknoteAmount;
                        r1.CoinFlag = row.CoinFlag;
                        r1.Quantity = 0;
                        r1.Amount = 0;
                        r1.GroupCode = 1;
                        this.rec.CashDist.push(r1);
                        // 1 lira ve üzeri şartı kalktı, artık kuruşlarda loomis'e gönderilecek. 
                        // if (row.BanknoteAmount >= 1) {
                            const r2 = JSON.parse(JSON.stringify(r1));
                            r2.GroupCode = 2;
                            this.rec.CashDist.push(r2);
                        // }
                        const r3 = JSON.parse(JSON.stringify(r1));
                        r3.GroupCode = 3;
                        this.rec.CashDist.push(r3);
                    });
                    this.bankNotes = this.rec.CashDist.filter(row => (row.GroupCode === 1));
                });
            } else {
                this.bankNotes = this.rec.CashDist.filter(row => (row.GroupCode === 1));
                this.diffReasonCodes = [];
                // console.log(this.rec.DiffReasonCodes, this.rec.NetoffAmount);
                if (this.rec.DiffReasonCodes && Math.abs(this.rec.NetoffAmount) > this.diffLimit) {
                    const x = this.rec.DiffReasonCodes.split(',');
                    x.forEach(a => {
                        if (parseInt(a, 10) > 0) {
                            this.diffReasonCodes.push(parseInt(a, 10));
                        }
                    });
                }
            }

            if (this.rec.CardDist.length === 0) {
                const r1: CardDistribution = new CardDistribution();
                r1.Event = 1;
                r1.Organization = 1;
                r1.CardGroupCode = 1;
                r1.CardGroupName = 'KASA 1 Kredi Kartı Gün Sonu';
                r1.CardZetAmount = 0;
                this.rec.CardDist.push(r1);
                const r2 = JSON.parse(JSON.stringify(r1));
                r2.CardGroupCode = 2;
                r2.CardGroupName = 'KASA 2 Kredi Kartı Gün Sonu';
                this.rec.CardDist.push(r2);
                const r3 = JSON.parse(JSON.stringify(r1));
                r3.CardGroupCode = 3;
                r3.CardGroupName = '1.Mobil POS Kredi Kartı Gün Sonu';
                this.rec.CardDist.push(r3);
                const r4 = JSON.parse(JSON.stringify(r1));
                r4.CardGroupCode = 4;
                r4.CardGroupName = '2.Mobil POS Kredi Kartı Gün Sonu';
                this.rec.CardDist.push(r4);
            }
            cb();
        });
    }

    readZet(cb) {
        this.zetService.StoreZet(this.datePipe.transform(this.recDate, 'yyyy-MM-dd'), this.selectedStoreId).subscribe(result => {
            this.zetStore = result;
            this.zetTotal = 0;
            this.zetCount = 0;
            let terminalCode = 0;
            this.zetStore.forEach(row => {
                if (row.CashRegister !== terminalCode) {
                    terminalCode = row.CashRegister;
                    this.zetCount++;
                }
                this.zetTotal += row.ReceiptTotal + row.SlpTotal - row.RefundAmount;
            });
            // console.log('zettotal:', this.zetTotal);
            if (this.zetTotal > 0) {
                this.zetTotal += this.invoiceTotal;
            }
            // console.log('New zettotal:', this.zetTotal);
            cb();
        });
    }

    readReasons() {
        this.diffReasonService.listAllAsync().subscribe(result => {
            this.diffReasons = result;
        });
    }

    readDateExtra() {
        this.expenseService.OpenExpenses(this.selectedStoreId, this.datePipe.transform(this.recDate, 'yyyy-MM-dd')).subscribe(result => {
            this.expenses = result;
            this.expenseTotal = 0;
            // console.log(this.expenses);
            this.expenses.forEach(row => {
                this.expenseTotal += row.ExpenseAmount;
            });
        });
        this.expenseService.PaidExpenses(this.selectedStoreId, this.datePipe.transform(this.recDate, 'yyyy-MM-dd')).subscribe(result => {
            this.expensePayment = 0;
            result.forEach(row => {
                this.expensePayment += row.ExpenseAmount;
            });
        });
        this.adjustmentService.Adjustment(this.selectedStoreId, this.datePipe.transform(this.recDate, 'yyyy-MM-dd')).subscribe(result => {
            this.adjustmentTotal = result;
        });
        this.invoiceService.EInvoice(this.selectedStoreId, this.datePipe.transform(this.recDate, 'yyyy-MM-dd')).subscribe(result => {
            this.invoiceTotal = result;
        });
    }

    readRecDate(storeId) {
        this.dataService.ReconciliationDate(storeId).subscribe(result => {
            this.prevRec = result;
            if (result.StoreReconciliationId !== 0) {
                this.recDate = new Date(result.NextDate);
                // this.recDate.setDate(this.recDate.getDate() + 1);
            } else {
                // this.recDate = new Date('2019-03-01');
                this.recDate = new Date();
            }
            this.readDateExtra();
            this.readRec(() => {});
            this.readReasons();
        });
    }

    onStoreSelected(event) {
        this.selectedStoreId = event;
        this.selectedStore = this.storeList.filter(row => (row.StoreId === this.selectedStoreId))[0];
        this.readRecDate(this.selectedStoreId);
        // setTimeout(() => {
        //     console.log(this.selectedStore.Advance);
        //     console.log(this.prevRec.CurrentAdvance);
        //     console.log(this.prevRec.TotalOpenExpense);
        // }, 300);
    }

    ngOnInit() {
        this.authenticate = false;
        this.storeListLoading = true;
        this.storeService.listUserStores().subscribe(result => {
            this.storeList = result;
            this.storeListLoading = false;

            if (this.storeList.length === 1) {
                this.authenticate = false;
                this.selectedStoreId = this.storeList[0].StoreId;
                this.selectedStore = this.storeList[0];
                this.storeReadOnly = true;
            } else {
                this.authenticate = true;
            }
        }, error => {
            this.messageService.error(error);
            this.storeListLoading = false;
        });

        super.ngOnInit();
    }

    calcNetOff() {
        // console.log("CashAmount: ", this.rec.CashAmount);
        // console.log("CardAmount: ", this.rec.CardAmount);
        // console.log("expenseTotal: ", this.expenseTotal);
        // console.log("zetTotal: ", this.zetTotal);
        // console.log("expensePayment: ", this.expensePayment);
        // console.log("RecoveredAmount: ", this.rec.RecoveredAmount);
        this.netOff = this.rec.CashAmount + this.rec.CardAmount + this.expenseTotal - this.zetTotal - this.expensePayment - this.rec.RecoveredAmount;
        // öneri hesaplama devreye alınmadı.
        // this.netOff = this.rec.CashAmount + this.rec.CardAmount - this.zetTotal + this.rec.TotalOpenExpense - this.prevRec.TotalOpenExpense;
        if (this.prevRec.StoreReconciliationId > 0) {
            this.netOff -= this.prevRec.CurrentAdvance;
        } else {
            this.netOff -= this.selectedStore.Advance;
        }
        // console.log("CurrentAdvance: ", this.prevRec.CurrentAdvance);
        // console.log("netOff: ", this.netOff);
    }

    calcCashForBank() {
        // sayılan nakit ve masraf farkı
        this.cashForBank = this.rec.CashAmount + this.expenseTotal - this.expensePayment;

        // önceki günkü kalan avansı düşülecek. Yeni başlandı ise mutabakata tanımlı avans düşülecek.
        if (this.prevRec.StoreReconciliationId > 0) {
            this.cashForBank -= this.prevRec.CurrentAdvance;
        } else {
            this.cashForBank -= this.selectedStore.Advance;
        }

        // avans değeri değiştiyse farkı yansıtılır.
        if (this.prevRec.StoreReconciliationId > 0 && this.prevRec.DefinedAdvance !== this.selectedStore.Advance) {
            this.cashForBank -= (this.selectedStore.Advance - this.prevRec.DefinedAdvance);
        }
        // kasa eksiği varsa onu avanstan alıp bankaya gönder.
        if (this.netOff < 0) {
            this.cashForBank -= this.netOff;
        }

        // tazmin tutarı varsa onu da düş
        if (this.rec.RecoveredAmount && this.rec.RecoveredAmount > 0) {
            this.cashForBank -= this.rec.RecoveredAmount;
        }

        // düzeltme tutarı varsa onu da düş
        if (this.adjustmentTotal && this.adjustmentTotal !== 0) {
            this.cashForBank -= this.adjustmentTotal;
        }

        // 1 lira altını dahil etme
        this.cashForBank = Math.round(this.cashForBank);

        /* Öneri hesaplama devreye alınmadı.
        // netoff 0'dan küçükse z - kart tutarı gönderilmeli
        if (this.netOff < 0) {
            this.cashForBank = this.zetTotal - this.rec.CardAmount;
        } else {
            this.cashForBank = this.rec.CashAmount + this.rec.TotalOpenExpense - this.prevRec.TotalOpenExpense;
            if (this.prevRec.StoreReconciliationId > 0) {
                this.cashForBank -= this.prevRec.CurrentAdvance;
            } else {
                this.cashForBank -= this.selectedStore.Advance;
            }
            if (this.rec.RecoveredAmount && this.rec.RecoveredAmount > 0) {
                if (this.netOff > this.rec.RecoveredAmount) {
                    this.cashForBank -= this.rec.RecoveredAmount;
                } else {
                    this.cashForBank -= this.netOff;
                }
            }
        }

        // düzeltme tutarı varsa onu da düş
        if (this.adjustmentTotal && this.adjustmentTotal != 0) {
            this.cashForBank -= this.adjustmentTotal;
        }

        // avans değeri değiştiyse farkı yansıtılır.
        if (this.prevRec.StoreReconciliationId > 0 && this.prevRec.DefinedAdvance !== this.selectedStore.Advance) {
            this.cashForBank -= (this.selectedStore.Advance - this.prevRec.DefinedAdvance);
        }

        // 1 lira altını dahil etme
        this.cashForBank = Math.round(this.cashForBank);
        */

        this.bankNotesForBank = this.rec.CashDist.filter(row => (row.GroupCode === 2));
        this.bankNotesForBank.forEach(row => {
            this.bankNotes.forEach(row2 => {
                if (row2.BanknoteAmount === row.BanknoteAmount) {
                    row.Quantity = row2.Quantity;
                    row.Amount = row2.Amount;
                }
            });
        });
        let a = this.cashForBank;
        this.bankNotesForBank.forEach(row => {
            if (a >= row.Amount) {
                a -= row.Amount;
            } else if (a > 0) {
                const b = Math.trunc(a / row.BanknoteAmount);
                a -= b * row.BanknoteAmount;
                row.Quantity = b;
                row.Amount = b * row.BanknoteAmount;
            } else {
                row.Quantity = 0;
                row.Amount = 0;
            }
        });
        this.allSent = false;
        if (a > 0) {
            this.allSent = true;
        }
        /* kasada para olmasa da bankaya gönderilecek para miktarı düşülmeyecek.
        if (a > 0) {
            this.cashForBank -= a;
        }*/

        this.rec.BankAmount = this.cashForBank;
    }

    calcCurrentAdvance() {

        this.rec.CurrentAdvance = this.rec.CashAmount - this.rec.BankAmount;

    }

    calcBanknotesInHand() {
        this.totalBankNotesinHand = 0;
        this.bankNotes.forEach(r1 => {
            const forBank = this.rec.CashDist.filter(cd => (cd.GroupCode === 2 && cd.Banknote === r1.Banknote));
            const inHand = this.rec.CashDist.filter(cd => (cd.GroupCode === 3 && cd.Banknote === r1.Banknote));
            if (forBank.length > 0) {
                inHand[0].Quantity = r1.Quantity - forBank[0].Quantity;
            } else {
                inHand[0].Quantity = r1.Quantity;
            }
            inHand[0].Amount = inHand[0].Quantity * inHand[0].BanknoteAmount;
            this.totalBankNotesinHand += inHand[0].Amount;
        });
        this.bankNotesinHand = this.rec.CashDist.filter(row => (row.GroupCode === 3));
    }

    calcRecoverAttributes() {
        if (this.prevRec.StoreReconciliationId > 0) {
            this.totalCashDeficit = this.selectedStore.Advance - this.prevRec.CurrentAdvance - this.prevRec.TotalOpenExpense;
            if (this.totalCashDeficit < 0) {
                this.totalCashDeficit = 0;
            }
        } else {
            this.totalCashDeficit = 0;
        }

        if (this.totalCashDeficit > this.diffLimit) {
            if (this.prevRec.StoreReconciliationId > 0) {
                this.deficitCount = this.prevRec.DeficitCycleCount + 1;
            } else {
                this.deficitCount = 1;
            }
        } else {
            this.deficitCount = 0;
        }

        this.recoverAmountReadonly = true;
        if (this.selectedStore.Advance - this.prevRec.CurrentAdvance - this.prevRec.TotalOpenExpense >= 1) {
            this.recoverAmountReadonly = false;
        }
    }

    calcDiffAttributes() {

        this.dailyCashDeficit = 0;
        this.dailyCashSurplus = 0;
        if (this.netOff < 0) {
            this.dailyCashDeficit = -1 * this.netOff;
        } else {
            this.dailyCashSurplus = this.netOff;
        }
        // console.log('calcDiffAttributes prevRec.CurrentAdvance : ',this.prevRec.CurrentAdvance);


        this.diffReadonly = true;
        if (Math.abs(this.netOff) > this.diffLimit) {
            this.diffReadonly = false;
        }

        this.xdiffReasons = [];
        if (this.dailyCashDeficit > this.diffLimit) {
            this.xdiffReasons = this.diffReasons.filter(row => row.ShortFlag === true);
        } else if (this.dailyCashSurplus > this.diffLimit) {
            this.xdiffReasons = this.diffReasons.filter(row => row.ShortFlag === false);
        }
        if (this.diffReasonCodes) {
            const x = JSON.parse(JSON.stringify(this.diffReasonCodes));
            this.diffReasonCodes = [];
            x.forEach(row => {
                if (this.xdiffReasons.filter(r => r.DiffReasonId === row).length > 0) {
                    this.diffReasonCodes.push(row);
                }
            });
        }
    }

    onRecoveredAmountChange(event) {
        this.calcNetOff();
        this.calcDiffAttributes();
    }

    controlBankQuantity(): boolean {
        let returnvalue = true;
        this.bankNotesForBank.forEach(r1 => {
            const q = this.rec.CashDist.filter(cd => (cd.GroupCode === 1 && cd.Banknote === r1.Banknote))[0].Quantity;
            if (r1.Quantity > q) {
                this.messageService.warning(`${r1.BanknoteAmount} lık olarak ${q} adet girebilirsiniz. `);
                returnvalue = false;
            }
        });
        return returnvalue;
    }

    public createFormGroup(dataItem: any): FormGroup {

        let fg: FormGroup = null;
        fg = this.formBuilder.group({
            CashierName: new FormControl(dataItem.CashierName),
            ReasonText: new FormControl(dataItem.ReasonText),
        });

        return fg;
    }

    onEnterClicked(e) {
        if (this.reasonGrid.activeCell) {
            if (this.reasonGrid.activeCell.colIndex === 4) {
                this.reasonGrid.focusCell(this.reasonGrid.activeCell.rowIndex, this.reasonGrid.activeCell.colIndex + 1);
            } else {
                this.reasonGrid.focusCell(this.reasonGrid.activeCell.rowIndex + 1, this.reasonGrid.activeCell.colIndex - 1);
            }
        } else {
            e.preventDefault();
        }
    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {

        if (!isEdited) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }

    }

    public cellCloseHandler(args: any) {

        const { formGroup, dataItem, column } = args;

        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            dataItem.CashierName = formGroup.value.CashierName;
            dataItem.ReasonText = formGroup.value.ReasonText;
        }
    }

    zetControl(warningMessage: Boolean, stopProcess: Boolean, cb) {
        this.readZet(() => {
            if (stopProcess) {
                if (this.zetTotal <= 0) {
                    this.messageService.warning('Henüz bugüne ait Z değeriniz yok, mutabakata devam edemezsiniz.');
                } else if (this.zetCount < this.selectedStore.TerminalCount) {
                    this.messageService.warning('Tüm tanımlı kasalarınızdan Z değeri gelmemiş, mutabakata devam edemezsiniz.');
                } else {
                    cb();
                }
            } else if (warningMessage && !this.authenticate) {
                if (this.zetTotal > 0) {
                    this.zetWarningMessage = false;
                    let zLogObject: ZControlLog = new ZControlLog();
                    zLogObject.Store = this.selectedStoreId;
                    zLogObject.ReconciliationDate = this.rec.ReconciliationDate;
                    zLogObject.ZetAmount = this.zetTotal;
                    this.dataService.createZControlLog(zLogObject).subscribe(() => {}, error => { console.log(error);});
                    this.warningMessageDialog.show();
                } else {
                    cb();
                }
            } else {
                cb();
            }
        });
    }

    zetPassControl() {
        this.zetControl(false, false, () => {
            if (this.zetCount >= this.selectedStore.TerminalCount) {
                this.zClassOK = true;
                this.zReportStatus = 'Mutabakata devam edebilirsiniz.';
            } else {
                this.zClassOK = false;
                this.zReportStatus = 'Z Raporları henüz Maktech sistemine düşmedi, bekleyiniz.';
            }
        });
    }
    
    formatDate(date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();
    
        if (month.length < 2) 
            month = '0' + month;
        if (day.length < 2) 
            day = '0' + day;
    
        return [year, month, day].join('-');
    }

    onNext(currentId) {
        switch (currentId) {
            case 1 :
            this.readRec(() => {
                this.zetControl(this.zetWarningMessage, false, () => {
                    // console.log(this.formatDate(this.recDate));
                    const today = this.dataService.addHours(new Date(), -12);
                    // console.log(this.formatDate(today));
                    if (this.formatDate(this.recDate) > this.formatDate(today)) {
                        this.messageService.error('İleri tarihli mutabakat yapamazsınız.');
                    } else {
                        if (this.recDate) {
                            const lastStep = this.rec.LastStepNo;
                            if (lastStep === null) {
                                this.saveRec(this.screenNo, () => {
                                    this.calcRecoverAttributes();
                                    this.readCancelReasons(() => {
                                        this.screenNo = currentId + 1;
                                    });
                                }); 
                            } else {
                                this.calcRecoverAttributes();
                                this.readCancelReasons(() => {
                                    if (lastStep <= 1) {
                                        this.screenNo = currentId + 1;
                                    } else {
                                        this.calcNetOff();
                                        this.calcCashForBank();
                                        this.calcCurrentAdvance();
                                        this.calcDiffAttributes();
                                        this.calcBanknotesInHand();
                                        this.zetPassControl();
                                        this.screenNo = lastStep + 1;
                                    }
                                });
                            }
                        } else {
                            this.messageService.warning('Tarih seçmeden ilerleyemezsiniz.');
                        }
                    }
                });
            });
            break;
            case 2 :
            let reqControl = true;
            this.cancelReasons.forEach(row => {
                if (!row.CashierName || !row.ReasonText || row.CashierName.length < 4 || row.ReasonText.length < 4) {
                    reqControl = false;
                }
            });
            if (reqControl) {
                this.cancelReasonService.SaveCancelReasons(this.cancelReasons, () => {
                    this.readCancelReasons(() => {
                        this.saveRec(this.screenNo, () => {
                            this.screenNo = currentId + 1;
                        });
                    });
                });
            } else {
                this.messageService.warning(`İptal nedenlerini ve kasiyer bilgisini doldurmanız gerekmektedir.`);
            }
            break;
            case 3 :
            if ((this.selectedStore.Advance - this.prevRec.CurrentAdvance - this.prevRec.TotalOpenExpense) > 0
                && this.rec.RecoveredAmount > (this.selectedStore.Advance - this.prevRec.CurrentAdvance - this.prevRec.TotalOpenExpense)) {
                this.messageService.warning(`Tazmin tutarı toplam kasa eksiğinden büyük olamaz.`);
            } else {
                this.saveRec(this.screenNo, () => {
                    this.screenNo = currentId + 1;
                });
            }
            break;
            case 4 :
            if (this.rec.CashAmount > 500) {
                this.saveRec(this.screenNo, () => {
                    this.screenNo = currentId + 1;
                });
                this.zetPassControl();
                this.intervalHolder = setInterval(() => {
                    this.zetPassControl();
                }, 1000 * 30); 
            } else {
                this.messageService.warning('Kasanızdaki nakit tutarlarını girmeden bir sonraki sayfaya geçemezsiniz.');
            }
            break;
            case 5 : 
            if (this.zetCount >= this.selectedStore.TerminalCount) {
                clearInterval(this.intervalHolder);
                this.saveRec(this.screenNo, () => {
                    this.screenNo = currentId + 1;
                });
            }
            break;
            case 6 :
            this.saveRec(6, () => {
                this.screenNo = currentId + 1;
            });
            break;
            case 7 :
            this.readZet(() => {
                if (this.zetTotal <= 0) {
                    this.messageService.warning('Henüz bugüne ait Z değeriniz yok, mutabakat yapamazsınız.');
                } else if (this.zetCount < this.selectedStore.TerminalCount) {
                    this.messageService.warning('Tüm tanımlı kasalarınızdan Z değeri gelmemiş, mutabakat yapamazsınız.');
                } else if (this.rec.CardAmount === 0) {
                    this.messageService.warning('Kart harcamalarınızı giriniz.');
                } else {
                    this.calcNetOff();
                    this.calcCashForBank();
                    this.calcCurrentAdvance();
                    this.calcDiffAttributes();
                    this.saveRec(this.screenNo, () => {
                        this.screenNo = currentId + 1;
                    });
                }
            });
            break;
            case 8 :
            // console.log(this.netOff, this.diffReasonCodes, this.rec.DiffReason);
            if (Math.abs(this.netOff) > 5 && (this.diffReasonCodes.length === 0  || this.rec.DiffReason === '' || !this.rec.DiffReason)) {
                this.messageService.warning(`Kasa eksiği veya fazlası için neden seçmeniz ve açıklama girmeniz gerekmektedir.`);
                break;
            }
            this.calcNetOff();
            this.calcCashForBank();
            this.calcCurrentAdvance();
            this.calcBanknotesInHand();
            this.saveRec(this.screenNo, () => {
                this.screenNo = currentId + 1;
            });
            break;
            case 9 :
            if (!this.controlBankQuantity()) {
                break;
            }
            if (this.cashForBank !== this.rec.BankAmount) {
                this.messageService.warning(`Bankaya göndermeniz gereken tutar ${this.currencyPipe.transform(this.cashForBank, 'TRY', true, '1.0-0')} liradır.`);
                break;
            }
            this.saveRec(this.screenNo, () => {
                this.screenNo = currentId + 1;
            });
            break;
            case 10 :
            // console.log(this.allSent);
            if (!this.allSent && Math.abs(this.totalBankNotesinHand - this.rec.CurrentAdvance) > 1) {
                this.messageService.warning('Güncel avans değeri hatalı bilgi işlem ile temasa geçiniz.');
                break;
            }
            this.saveRec(this.screenNo, () => {
                this.recDate.setDate(this.recDate.getDate() + 1);
                this.recDate = this.dataService.addHours(this.recDate, 3);
                this.prevRec = JSON.parse(JSON.stringify(this.rec));
                this.diffReasonCodes = [];
                this.readRec(() => {});
                this.readDateExtra();
                this.readRecDate(this.selectedStoreId);
                this.messageService.success('Mutabakat tamamlanmıştır.');
                this.screenNo = 1;
                this.zetWarningMessage = true;
            });
            break;
        }

    }

    onPrev(currentId) {
        this.screenNo = currentId - 1;
    }

    calcTotalCashAmount() {
        this.rec.CashAmount = 0;
        this.bankNotes.forEach(row => this.rec.CashAmount += parseFloat(row.Amount));
    }

    calcTotalCashForBank() {
        this.allSent = true;
        this.bankNotesForBank.forEach(row => {
            this.bankNotes.forEach(row2 => {
                if (row2.BanknoteAmount === row.BanknoteAmount && row2.Quantity !== row.Quantity) {
                    this.allSent = false;
                }
            });
        });

        this.rec.BankAmount = 0;
        this.bankNotesForBank.forEach(row => this.rec.BankAmount += parseFloat(row.Amount));

        if (this.allSent && this.rec.BankAmount < this.cashForBank) {
            this.rec.BankAmount = this.cashForBank;
        }
    }

    onQuantityChanged(dataItem) {
        dataItem.Amount = dataItem.Quantity * dataItem.BanknoteAmount;
        // console.log('onQuantityChanged : ',dataItem.Quantity, dataItem.Amount, dataItem.BanknoteAmount);
        this.calcTotalCashAmount();
    }

    onAmountChanged(dataItem) {
        dataItem.Quantity = Math.round(dataItem.Amount / dataItem.BanknoteAmount);
        if (dataItem.BanknoteAmount < 1) {
            dataItem.Amount = Math.round(dataItem.Quantity * dataItem.BanknoteAmount * 100) / 100;
        } else {
            dataItem.Amount = Math.round(dataItem.Quantity * dataItem.BanknoteAmount);
        }
        // console.log('onAmountChanged : ',dataItem.Quantity, dataItem.Amount, dataItem.BanknoteAmount);
        this.calcTotalCashAmount();
    }

    onTotalChanged() {
        this.rec.CardAmount = 0;
        this.rec.CardDist.forEach(row => this.rec.CardAmount += row.CardZetAmount);
    }

    onBankQuantityChanged(dataItem) {
        dataItem.Amount = dataItem.Quantity * dataItem.BanknoteAmount;
        this.calcTotalCashForBank();
    }

    ngAfterViewInit() {
    }

    onActionWarningMessage(event) {
        this.warningMessageDialog.hide();
    }

}
