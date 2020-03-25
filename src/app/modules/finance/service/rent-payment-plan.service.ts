// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { RentPaymentPlan } from '@finance/model/rent-payment-plan.model';
import {Observable} from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class RentPaymentPlanService extends CRUDMLService<RentPaymentPlan> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Finance', 'RentPaymentPlan');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    generateAllPayments(isKeepExistingRecords = true): Observable<number> {
        const params = new HttpParams().append('isKeepExistingRecords', isKeepExistingRecords.toString());
        return this.httpClient.get<number>(this.baseRoute + 'GenerateAllPayments', { observe: 'body', responseType: 'json', params: params });
    }

    clonePayment(templatePaymentId: number) {
        const params = new HttpParams().append('templateRecordId', templatePaymentId.toString());
        return this.httpClient.get<number>(this.baseRoute + 'ClonePayment', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
