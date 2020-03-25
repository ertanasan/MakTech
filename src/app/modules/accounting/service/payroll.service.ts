// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Payroll, MikroTransferPayrollListModel } from '@accounting/model/payroll.model';

/*Section="ClassHeader"*/
@Injectable()
export class PayrollService extends CRUDLService<Payroll> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'Payroll');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    loadHRFile(formData) {
        return this.httpClient.post(this.baseRoute + 'LoadHRFile', formData, { responseType: 'text' });
    }

    MikroTransfer(year, month) {
        const m: MikroTransferPayrollListModel = new MikroTransferPayrollListModel();
        m.Year = year;
        m.Month = month;
        return this.httpClient.post<any>(this.baseRoute + 'MikroTransfer', m);
    }

    listMonth(year, month) {
        let params = new HttpParams().append('year', year);
        params = params.append('month', month);
        return this.httpClient.get<any>(this.baseRoute + 'ListMonth', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
