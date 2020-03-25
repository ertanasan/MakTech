import { Injectable } from '@angular/core';
import { CRUDLService } from '@otservice/crudl.service';
import { Sales } from '@sale/model/sales.model';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

@Injectable()
export class MikroTransferService extends CRUDLService<any> {


    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Sale', 'Sales');
    }
    listData(startDate, endDate, checkDate) {
        let params = new HttpParams().append('checkDate', checkDate);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);

        return this.httpClient.get<any>(this.baseRoute + 'ListMikroData', { observe: 'body', responseType: 'json', params: params }).pipe(
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
    loadMikro(transactionDate, storeId) {
        // let params = new HttpParams().append('transactionDate', transactionDate);
        // params = params.append('storeId', storeId);
        this.httpClient.post<any>(this.baseRoute + 'LoadMikro/' + transactionDate + '/' + storeId, null).subscribe(
            result => {
                this.messageService.success('Mikroya aktarıldı.');
            }, error => {
                this.messageService.error(error);
            });
    }

}
