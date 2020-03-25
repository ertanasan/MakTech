// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { MaterialOrder, MaterialOrderUpdateList } from '@warehouse/model/material-order.model';
import { MaterialInfoService } from './material-info.service';

/*Section="ClassHeader"*/
@Injectable()
export class MaterialOrderService extends CRUDLService<MaterialOrder> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'MaterialOrder');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    UpdateStatus(statusCode, materialOrderIdList) {
        const m: MaterialOrderUpdateList = new MaterialOrderUpdateList();
        m.MaterialOrderIdList = materialOrderIdList;
        m.OrderStatusCode = statusCode;
        return this.httpClient.post<any>(this.baseRoute + 'UpdateStatus', m);
    }

    ListOrders(startDate, allRecords) {
        let params = new HttpParams().append('StartDate', startDate);
        params = params.append('AllRecords', allRecords);
        return this.httpClient.get<MaterialOrder[]>(this.baseRoute + 'ListOrders', { observe: 'body', responseType: 'json', params: params });
    }

    TakeOrderAction(actionCode, materialOrderIdList) {
        const m: MaterialOrderUpdateList = new MaterialOrderUpdateList();
        m.MaterialOrderIdList = materialOrderIdList;
        m.OrderStatusCode = actionCode;
        return this.httpClient.post<any>(this.baseRoute + 'TakeOrderAction', m);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
