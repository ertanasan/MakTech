// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Expense, MikroTransferListModel } from '@reconciliation/model/expense.model';
import { DatePipe } from '@angular/common';

/*Section="ClassHeader"*/
@Injectable()
export class ExpenseService extends CRUDLService<Expense> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public datePipe: DatePipe,
    ) {
        super(httpClient, messageService, translateService, 'Reconciliation', 'Expense');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    OpenExpenses(storeId, date) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        params = params.append('date', date);
        return  this.httpClient.get<Expense[]>(this.baseRoute + 'OpenExpenses', { observe: 'body', responseType: 'json', params: params });
    }

    PaidExpenses(storeId, date) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        params = params.append('date', date);
        return  this.httpClient.get<Expense[]>(this.baseRoute + 'PaidExpenses', { observe: 'body', responseType: 'json', params: params });
    }

    ReadDate(startDate, endDate) {
        let params = new HttpParams();
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return  this.httpClient.get<Expense[]>(this.baseRoute + 'ReadDate', { observe: 'body', responseType: 'json', params: params });
    }

    ExpenseReport(startDate, endDate, storeSelection: number[], managerSelection: number[], typeSelection: number[]) {
        let params = new HttpParams();
        params = params.append('startDate', this.datePipe.transform(startDate, 'yyyy-MM-dd'));
        params = params.append('endDate', this.datePipe.transform(endDate, 'yyyy-MM-dd'));
        params = params.append('storeList', storeSelection.toString());
        params = params.append('expenseTypeList', typeSelection.toString());
        params = params.append('managerList', managerSelection.toString());
        return  this.httpClient.get<any>(this.baseRoute + 'ExpenseReport', { observe: 'body', responseType: 'json', params: params });
    }

    ExpenseReportDetail(startDate, endDate, storeSelection: number[], managerSelection: number[], typeSelection: number[]) {
        let params = new HttpParams();
        params = params.append('startDate', this.datePipe.transform(startDate, 'yyyy-MM-dd'));
        params = params.append('endDate', this.datePipe.transform(endDate, 'yyyy-MM-dd'));
        params = params.append('storeList', storeSelection.toString());
        params = params.append('expenseTypeList', typeSelection.toString());
        params = params.append('managerList', managerSelection.toString());
        return  this.httpClient.get<any>(this.baseRoute + 'ExpenseReportDetail', { observe: 'body', responseType: 'json', params: params });
    }

    ExpenseReportChart(storeSelection: number[], managerSelection: number[], typeSelection: number[]) {
        let params = new HttpParams();
        params = params.append('storeList', storeSelection.toString());
        params = params.append('expenseTypeList', typeSelection.toString());
        params = params.append('managerList', managerSelection.toString());
        return  this.httpClient.get<any>(this.baseRoute + 'ExpenseReportChart', { observe: 'body', responseType: 'json', params: params });
    }

    MikroTransferList(regionManagerId) {
        let params = new HttpParams();
        params = params.append('regionManagerId', regionManagerId);
        return  this.httpClient.get<Expense[]>(this.baseRoute + 'MikroTransferList', { observe: 'body', responseType: 'json', params: params });
    }

    MikroTransfer(regionManagerId, expenseList) {
        const m: MikroTransferListModel = new MikroTransferListModel();
        m.RegionManagerId = regionManagerId;
        m.ExpenseList = expenseList.toString();
        // console.log(m);
        return this.httpClient.post<any>(this.baseRoute + 'MikroTransfer', m);
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    addMinutes(_datetime, _minute) {
        const d = new Date(_datetime);
        d.setMinutes(d.getMinutes() + _minute);
        return d;
    }

    ListExpenseLog(expenseId) {
        let params = new HttpParams();
        params = params.append('expenseId', expenseId);
        return  this.httpClient.get<any>(this.baseRoute + 'ListExpenseLog', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
