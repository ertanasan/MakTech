// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SaleDailySummary } from '@sale/model/sale-daily-summary.model';
import { ListParams } from '@otmodel/list-params.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class SaleDailySummaryService extends CRUDLService<SaleDailySummary> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Sale', 'SaleDailySummary');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listDate(transactionDate) {
        let params = new HttpParams().append('transactionDate', transactionDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListDate', { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error(`An error occurred: ${err.error['ExceptionMessage']}`);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                }
                return empty();
            })
        );
    }

    StoreZet(transactionDate, storeId) {
        let params = new HttpParams().append('transactionDate', transactionDate);
        params = params.append('storeId', storeId);
        return this.httpClient.get<SaleDailySummary[]>(this.baseRoute + 'StoreZet', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
