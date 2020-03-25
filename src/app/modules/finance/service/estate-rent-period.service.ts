// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { EstateRentPeriod } from '@finance/model/estate-rent-period.model';
import {Observable} from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class EstateRentPeriodService extends CRUDMLService<EstateRentPeriod> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Finance', 'EstateRentPeriod');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    generateAllPeriods(isKeepExistingRecords = true): Observable<number> {
        const params = new HttpParams().append('isKeepExistingRecords', isKeepExistingRecords.toString());
        return this.httpClient.get<number>(this.baseRoute + 'GenerateAllPeriods', { observe: 'body', responseType: 'json', params: params });
    }

    clonePeriod(templatePeriodId: number) {
        const params = new HttpParams().append('templateRecordId', templatePeriodId.toString());
        return this.httpClient.get<number>(this.baseRoute + 'ClonePeriod', { observe: 'body', responseType: 'json', params: params });
    }

    // sendContractEndDateNotification(estateRentPeriodId: number): Observable<any> {
    //     const params = new HttpParams().append('estateRentPeriodId', estateRentPeriodId.toString());
    //     this.baseRoute = this.baseRoute.replace('EstateRentPeriod', 'EstateLandlord' );
    //     return this.httpClient.post<any>(`${this.baseRoute}SendNegotiationReminderNotification`, null, { observe: 'body', responseType: 'json', params: params});
    // }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
