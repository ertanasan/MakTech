// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { EInvoiceClient } from '@accounting/model/e-invoice-client.model';
import { Sales } from '@sale/model/sales.model';
import { IdentityInfo } from '@accounting/model/identity-info.model';

/*Section="ClassHeader"*/
@Injectable()
export class EInvoiceClientService extends CRUDLService<EInvoiceClient> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private http: HttpClient,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'EInvoiceClient');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    readEInvoice(IdNo) {
        let params = new HttpParams().append('IdNo', IdNo.toString());
        return this.httpClient.get<EInvoiceClient>(this.baseRoute + 'readEInvoice', { observe: 'body', responseType: 'json', params: params });
    }

    readEInvoiceGIB(IdNo) {
        let params = new HttpParams().append('IdNo', IdNo.toString());
        return this.httpClient.get<EInvoiceClient>(this.baseRoute + 'readEInvoiceGIB', { observe: 'body', responseType: 'json', params: params });
    }

    readIdentityInfo(IdNo) {
        let params = new HttpParams().append('IdentityNo', IdNo.toString());
        return this.httpClient.get<IdentityInfo>(this.baseRoute + 'IdentityInfo', { observe: 'body', responseType: 'json', params: params });
    }
    
    
    //#endregion Customized

    /*Section="ClassFooter"*/
}
