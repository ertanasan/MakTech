import { Component, OnInit, ViewChild, Output, ViewChildren, QueryList, OnDestroy, ɵConsole } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { StoreReconciliation } from '@reconciliation/model/store-reconciliation.model';
import { StoreReconciliationService } from '@reconciliation/service/store-reconciliation.service';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { TranslateService } from '@ngx-translate/core';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { areAllEquivalent } from '@angular/compiler/src/output/output_ast';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';

@Component({
    selector: 'ot-store-reconciliation-entry',
    templateUrl: './store-reconciliation-entry.component.html',
    styleUrls: ['./store-reconciliation-entry.component.css',]
})
export class StoreReconciliationEntry extends MainScreenBase implements OnInit, OnDestroy {
    @ViewChild(InputDialogComponent, {static: true}) contactDialog: InputDialogComponent;

    mainForm: FormGroup;
    storeReconciliation = new StoreReconciliation();
    reconciliationDate = new Date();
    reconciliationSaved: boolean = false;

    contextState$: Observable<OTContext>;

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    refreshData(id?: number) {
        throw new Error('Method not implemented.');
    }

    createEmptyItem() {
        throw new Error('Method not implemented.');
    }

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public storeReconciliationService: StoreReconciliationService,
        private formBuilder: FormBuilder) {
        super(messageService, translateService);
        this.createForm();
    }

    createForm() {
        this.mainForm = this.formBuilder.group({
            StoreReconciliationId: new FormControl(),
            TransactionDate: new FormControl(),
            StoreID: new FormControl(),
            PreviousDayAmount: new FormControl(),
            SaleTotal: new FormControl(),
            CashTotal: new FormControl(),
            CardTotal: new FormControl(),
            ToBank: new FormControl(),
            Difference: new FormControl(),
            DifferenceExplanation: new FormControl(),
            EodAdvance: new FormControl(),
            Completed: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    ngOnDestroy() {
        super.ngOnDestroy();
    }

    markAsTouched(formGroup: FormGroup | FormArray) {
        (<any>Object).values(formGroup.controls).forEach(control => {
            control.markAsTouched();
            if (control.controls) {
                this.markAsTouched(control);
            }
        });
    }

    gotoReconciliationDate() {

        var r = this.storeReconciliation;

        this.storeReconciliationService.getStoreReconciliation(this.reconciliationDate).subscribe
            (
                result => {
                    this.reconciliationSaved = false;
                    
                    if (result.Reconciliated) {
                        this.messageService.warning("Tamamlanmış mutabakatlar görüntülenemez.");
                        return;
                    }
                    if (result.MissingReconciliation) {
                        this.messageService.warning("Son mutabakat yapılmış günün ertesi gününden başlayarak mutabakatları tamamlamalısınız. (Son başarılı mutabakat yapılan tarih: " + result.LastReconciliationDate + ")");
                        return;
                    }
                    if (result.ZetCount == 0) {
                        this.messageService.warning("Henüz Z raporu gelmemiş. Mutabakat girişi yapılamaz.");
                        return;
                    }
                    r = Object.assign(r, result);
                    this.mainForm.patchValue(r);
                    console.log(r);
                }
            );
    }

    calculateFields(sourceName) {
        var r = this.storeReconciliation;
        var roundedAmount: number = 0.00;

        r.Difference = (r.CashTotal + r.CardTotal) - r.SaleTotal - r.PreviousDayAmount;
        r.Difference = parseFloat(r.Difference.toFixed(2));


        if (r.Difference >= 0) {

            if (r.CashTotal > r.PreviousDayAmount) {
                r.ToBank = r.CashTotal - r.PreviousDayAmount + r.Difference + r.Completed;
                r.EodAdvance = r.PreviousDayAmount;
            }
            else {
                r.ToBank = 0;
                r.EodAdvance = r.PreviousDayAmount;
            }
            roundedAmount = r.ToBank - Math.round(r.ToBank);
            r.ToBank = Math.round(r.ToBank);
            r.EodAdvance = r.EodAdvance + roundedAmount
        }
        else {
            if (r.CashTotal > r.PreviousDayAmount) {
                r.ToBank = r.CashTotal - r.PreviousDayAmount + Math.abs(r.Difference);
            }
            else {
                r.ToBank = r.CashTotal + Math.abs(r.Difference);
            }
            roundedAmount = r.ToBank - Math.round(r.ToBank);
            r.ToBank = Math.round(r.ToBank);
            r.EodAdvance = r.PreviousDayAmount + r.Difference + r.Completed + roundedAmount;

        }
        console.log(r.EodAdvance,  roundedAmount, r.EodAdvance + roundedAmount);
        console.log("Hesaplamadan sonra");
        console.log("PreviousDayAmount", r.PreviousDayAmount);
        console.log("AssignedAdvance", r.AssaignedAdvance);
        console.log("CardTotal", r.CardTotal);
        console.log("ToBank", r.ToBank);
        console.log("SaleTotal", r.SaleTotal);
        console.log("CashTotal", r.CashTotal);
        console.log("Reconciliated", r.Reconciliated);
        console.log("Difference", r.Difference);
        console.log("Completed", r.Completed);
        console.log("EodAdvance", r.EodAdvance);
        console.log("rounded", roundedAmount);
    }


    showContactDialog() {

        var r = this.storeReconciliation;

        if (((r.SaleTotal + r.PreviousDayAmount) - (r.CashTotal + r.CardTotal + r.Completed) > 1)) {
            this.contactDialog.caption = "Kasanız 1 TL'den fazla miktarda eksiktir. Mutabakat 'BAŞARISIZ' olarak kayıt edilecektir. Emin misiniz?";
        }
        else {
            this.contactDialog.caption = "Mutabakat 'BAŞARILI' olarak kayıt edilecektir. Emin misiniz?";
        }
        this.contactDialog.show();
    }

    saveReconciliation(action) {

        var r = this.storeReconciliation;
        this.contactDialog.hide();

        if (action.currentTarget.innerText == 'OK') {
            r = Object.assign(r, this.mainForm.value);
            r.Reconciliated = true;
            this.storeReconciliationService.saveReconciliation(this.reconciliationDate, r);
            this.reconciliationSaved = true;
        } else {
            this.reconciliationSaved = false;
            this.markAsTouched(this.mainForm);
            r.Reconciliated = false;
        }
    }

    generateAction(action) 
    { 

    }
}



