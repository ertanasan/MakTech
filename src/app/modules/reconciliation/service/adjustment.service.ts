// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Adjustment } from '@reconciliation/model/adjustment.model';

/*Section="ClassHeader"*/
@Injectable()
export class AdjustmentService extends CRUDLService<Adjustment> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Reconciliation', 'Adjustment');
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    Adjustment(storeId, date) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);        
        params = params.append('date', date);        
        return  this.httpClient.get<number>(this.baseRoute + 'Adjustment', { observe: 'body', responseType: 'json', params: params });
    }
}
