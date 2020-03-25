// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Loomis, MikroTransferLoomisListModel } from '@accounting/model/loomis.model';

/*Section="ClassHeader"*/
@Injectable()
export class LoomisService extends CRUDLService<Loomis> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'Loomis');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    loadLoomisFile(formData) {
        return this.httpClient.post(this.baseRoute + 'LoadLoomisFile', formData, { responseType: 'text' });
    }

    MikroTransfer(day, loomisIdList) {
        const m: MikroTransferLoomisListModel = new MikroTransferLoomisListModel();
        m.LoomisIdList = loomisIdList;
        m.SaleDate = day;
        return this.httpClient.post<any>(this.baseRoute + 'MikroTransfer', m);
    }

    listDay(saleDate) {
        const params = new HttpParams().append('saleDate', saleDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListDay', { observe: 'body', responseType: 'json', params: params });
    }

    CancelMikroTransfer(day) {
        // const params = new HttpParams().append('blockedDate' , day);
        const params = new HttpParams().append('saleDate', day);
        return this.httpClient.post<any>(`${this.baseRoute}CancelMikroTransfer/${day}`, { observe: 'body', responseType: 'json', params: params});
    }

    ClearDate(day) {
        // const params = new HttpParams().append('blockedDate' , day);
        const params = new HttpParams().append('saleDate', day);
        return this.httpClient.post<any>(`${this.baseRoute}ClearDate/${day}`, { observe: 'body', responseType: 'json', params: params});
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
