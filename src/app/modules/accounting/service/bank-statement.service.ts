// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { BankStatement } from '@accounting/model/bank-statement.model';

/*Section="ClassHeader"*/
@Injectable()
export class BankStatementService extends CRUDLService<BankStatement> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'BankStatement');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    loadIngBankStatementFile(formData) {
        // const params = new HttpParams().append('bankName', bankName);
        return this.httpClient.post(this.baseRoute + 'LoadIngBankStatementFile', formData, { responseType: 'text' });
    }

    loadTebBankStatementFile(formData) {
        // const params = new HttpParams().append('bankName', bankName);
        return this.httpClient.post(this.baseRoute + 'LoadTebBankStatementFile', formData, { responseType: 'text' });
    }

    loadVakifBankStatementFile(formData) {
        // const params = new HttpParams().append('bankName', bankName);
        return this.httpClient.post(this.baseRoute + 'LoadVakifBankStatementFile', formData, { responseType: 'text' });
    }

    listDay(transactionDate) {
        const params = new HttpParams().append('transactionDate', transactionDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListDay', { observe: 'body', responseType: 'json', params: params });
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
