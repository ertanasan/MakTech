// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { BankStatement } from '@accounting/model/bank-statement.model';
import { BankStatementService } from '@accounting/service/bank-statement.service';
import { BankStatementEditComponent } from '@accounting/screen/bank-statement/bank-statement-edit/bank-statement-edit.component';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';
import { HttpErrorResponse } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { observable, Observable } from 'rxjs';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-bank-statement-list',
    templateUrl: './bank-statement-list.component.html',
    styleUrls: ['./bank-statement-list.component.css', ]
})
export class BankStatementListComponent extends ListScreenBase<BankStatement> implements AfterViewInit, OnInit {
    @ViewChild(BankStatementEditComponent, {static: true}) editScreen: BankStatementEditComponent;
    @ViewChild('fileInput', {static: true}) fileInput: ElementRef;

    settings: Array<any> = [{text: 'TEB'}, {text: 'Vakıfbank'}, {text: 'ING Bank'}];
    selectedBank: string;
    selectedDay: Date = new Date(Date.now());
    statementList: any;
    statementActiveList: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: BankStatementService,
        public bankService: BankService,
        public datePipe: DatePipe
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        // this.listParams.take = 10;
        if (this.statementList) {
            this.statementActiveList = process(this.statementList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Bank Statement', RouterLink: '/accounting/bank-statement'}];
    }

    createEmptyModel(): BankStatement {
        return new BankStatement();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.bankService.completeList) {
            this.bankService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getDateList() {
        if (this.selectedDay) {
            const d = new Date(this.selectedDay);
            const selectedDayString = this.datePipe.transform(d, 'yyyy-MM-dd');
            this.dataService.loading = true;
            this.dataService.listDay(selectedDayString).subscribe(result => {
                this.statementList = result;
                ((<BankStatement[]>this.statementList)).map(t => {
                    t.Date = new Date(t.Date);
                });
                this.refreshList();
                this.dataService.loading = false;
            },
            error => {
                this.messageService.error(error);
                this.dataService.loading = false;
            });
        }
    }

    onFileSelected(event) {
        this.dataService.loading = true;
        const formData = new FormData();
        formData.append('file[]', event.target.files[0]);
        let o: Observable<any>;
        if (this.selectedBank === 'ING Bank') {
            o = this.dataService.loadIngBankStatementFile(formData);
        } else if (this.selectedBank === 'TEB') {
            o = this.dataService.loadTebBankStatementFile(formData);
        } else if (this.selectedBank === 'Vakıfbank') {
            o = this.dataService.loadVakifBankStatementFile(formData);
        }
        o.subscribe(result => {
            // console.log('result ', result);
            this.dataService.loading = false;
            // if (!result || result === '') {
                this.messageService.success('Veriler sisteme başarılı bir şekilde aktarıldı.');
            // } else {
                // this.messageService.error(result.toString());
            // }
            event.target.value = '';
            this.refreshList();
        }, (error: HttpErrorResponse) => {
            console.log('error ', error);
            this.dataService.loading = false;
            this.messageService.error(error.error.text);
            event.target.value = '';
        });
    }

    bankSelect(event) {
        this.selectedBank = event.text;
        this.fileInput.nativeElement.click();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
