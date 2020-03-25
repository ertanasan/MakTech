// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SaleDetail } from '@sale/model/sale-detail.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class SaleDetailService extends CRUDLService<SaleDetail> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Sale', 'SaleDetail');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listSaleDetail(saleId) {
        const params = new HttpParams().append('saleId', saleId);
        return this.httpClient.get<any>(this.baseRoute + 'ListSaleDetail', { observe: 'body', responseType: 'json', params: params }).pipe(
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

    listCancelDetail( start: Date, end: Date){
        return this.httpClient.get<any>(this.baseRoute + 'CancelDetails/' + start.toDateString() + '/' + end.toDateString(), { observe: 'body', responseType: 'json'});
    }

    listCancel( start: Date, end: Date, storeId: string){
        const params = new HttpParams().append('storeId' , storeId);
        return this.httpClient.get<any>(this.baseRoute + 'CancelDetails/' + start.toDateString() + '/' + end.toDateString(), { observe: 'body', responseType: 'json', params: params});
    }

    weeklyCancels(start, end) {
        let params = new HttpParams().append('startDate' , start);
        params = params.append('endDate' , end);
        return this.httpClient.get<any>(this.baseRoute + 'WeeklyCancels', { observe: 'body', responseType: 'json', params: params});
    }


    //#endregion Customized

    /*Section="ClassFooter"*/
}
