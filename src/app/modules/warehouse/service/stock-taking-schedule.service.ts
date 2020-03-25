// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { Store } from '@store/model/store.model';

/*Section="ClassHeader"*/
@Injectable()
export class StockTakingScheduleService extends CRUDLService<StockTakingSchedule> {

    public keepActiveList;
    public keepListParams;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StockTakingSchedule');
    }

    public ActiveSchedules() {
        return this.httpClient.get<StockTakingSchedule[]>(this.baseRoute + 'ActiveSchedules', { observe: 'body', responseType: 'json' });
    }

    public CountedStores() {
        return this.httpClient.get<Store[]>(this.baseRoute + 'CountedStores', { observe: 'body', responseType: 'json' });
    }

    public DrillCountPerformance() {
        return this.httpClient.get<any>(this.baseRoute + 'DrillCountPerformance', { observe: 'body', responseType: 'json' });
    }

    public DrillCountPerformanceDetail(storeId) {
        const params = new HttpParams().append('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'DrillCountPerformanceDetail', { observe: 'body', responseType: 'json', params: params });
    }

    public keepParams(currentListParams, currentActiveList) {
        this.keepActiveList = currentActiveList;
        this.keepListParams = currentListParams;
    }

}
