// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SaleInvoice } from '@accounting/model/sale-invoice.model';
import { IdentityInfo } from '@accounting/model/identity-info.model';

/*Section="ClassHeader"*/
@Injectable()
export class SaleInvoiceService extends CRUDLService<SaleInvoice> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'SaleInvoice');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    SendEInvoice(rec: SaleInvoice) {
        return this.httpClient.post<any>(this.baseRoute + 'SendEInvoice', rec);
    }

    CheckIfTaxIdentifierExists(vkn: string) {
        const params = new HttpParams().append('vkn', vkn);
        return this.httpClient.get<boolean>(this.baseRoute + 'CheckIfTaxIdentifierExists', { observe: 'body', responseType: 'json', params: params });
    } 

    EInvoice(storeId, invoiceDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('invoiceDate', invoiceDate);
        return this.httpClient.get<number>(this.baseRoute + 'StoreEInvoice', { observe: 'body', responseType: 'json', params: params });
    }

    CreateCurrentAccount(identityInfo: IdentityInfo) {
        return this.httpClient.post(this.baseRoute + 'CreateCurrentAccount', identityInfo);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
