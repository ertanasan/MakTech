// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { BankPosTransactions, MikroTransferListModel } from '@accounting/model/bank-pos-transactions.model';
import { DatePipe } from '@angular/common';

/*Section="ClassHeader"*/
@Injectable()
export class BankPosTransactionsService extends CRUDLService<BankPosTransactions> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        datePipe: DatePipe,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'BankPosTransactions');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    loadBankPOSFile(formData) {
        return this.httpClient.post(this.baseRoute + 'LoadBankPOSFile', formData, { responseType: 'text' });
    }

    ziraatLoadBankPOSFile(formData) {
        return this.httpClient.post(this.baseRoute + 'ZiraatLoadBankPOSFile', formData, { responseType: 'text' });
    }

    MikroTransfer(day, bankPosTransactionsIdList) {
        const m: MikroTransferListModel = new MikroTransferListModel();
        m.BankPosTransactionsIdList = bankPosTransactionsIdList;
        m.BlockedDate = day;
        return this.httpClient.post<any>(this.baseRoute + 'MikroTransfer', m);
    }

    listDay(blockedDate) {
        const params = new HttpParams().append('blockedDate', blockedDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListDay', { observe: 'body', responseType: 'json', params: params });
    }

    CancelMikroTransfer(day) {
        // const params = new HttpParams().append('blockedDate' , day);
        const params = new HttpParams().append('blockedDate', day);
        return this.httpClient.post<any>(`${this.baseRoute}CancelMikroTransfer/${day}`, { observe: 'body', responseType: 'json', params: params});
    }

    ClearDate(day) {
        // const params = new HttpParams().append('blockedDate' , day);
        const params = new HttpParams().append('blockedDate', day);
        return this.httpClient.post<any>(`${this.baseRoute}ClearDate/${day}`, { observe: 'body', responseType: 'json', params: params});
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
