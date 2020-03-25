// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { OrderStatusHistory } from '@warehouse/model/order-status-history.model';

/*Section="ClassHeader"*/
@Injectable()
export class OrderStatusHistoryService extends CRUDLService<OrderStatusHistory> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'OrderStatusHistory');
    }

    public returnOrderStatusHistory(returnOrderId) {

        const params = new HttpParams().append('returnOrderId', returnOrderId);
        return this.httpClient.get<any>(this.baseRoute + 'ReturnOrderStatusHistory', { observe: 'body', responseType: 'json', params: params });

    }
}
