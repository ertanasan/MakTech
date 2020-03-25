// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductReturn, ProductReturnHistory } from '@warehouse/model/product-return.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductReturnService extends CRUDLService<ProductReturn> {

    public StatusList =
        [
            {StatusCode : 1, StatusName : 'Giriş'},
            {StatusCode : 2, StatusName : 'Onaylandı'},
            {StatusCode : 3, StatusName : 'Sevk Edildi'},
            {StatusCode : 4, StatusName : 'Kabul Edildi'},
            // {StatusCode : 5, StatusName : 'Tamamlandı'},
            {StatusCode : 6, StatusName : 'Reddedildi'},
            {StatusCode : 7, StatusName : 'İptal'},
        ];
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'ProductReturn');
    }

    public ListStatus(statusCode) {
        let params = new HttpParams();
        params = params.append('statusCode', statusCode);
        return  this.httpClient.get<ProductReturn[]>(this.baseRoute + 'ListStatus', { observe: 'body', responseType: 'json', params: params });
    }

    public SaveProductReturn(rec) {
        return this.httpClient.post(this.baseRoute + 'SaveProductReturn', rec);
    }

    public ApproveProductReturn(rec) {
        return this.httpClient.post(this.baseRoute + 'ApproveProductReturn', rec);
    }

    public GetHistoryData(productReturnId: number) {
        const params = new HttpParams().append('productReturnId', productReturnId.toString());
        return this.httpClient.get<ProductReturnHistory[]>(this.baseRoute + 'ListHistoryData', { observe: 'body', responseType: 'json', params: params });
    }

}
