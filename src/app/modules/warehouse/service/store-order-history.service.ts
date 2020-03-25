// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreOrderHistory } from '@warehouse/model/store-order-history.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class StoreOrderHistoryService extends CRUDLService<StoreOrderHistory> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StoreOrderHistory');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public ListStoreOrderHistory(storeOrderId) {
        const params = new HttpParams().append('storeOrderId', storeOrderId);
        const obsOrderHistory = this.httpClient.get<StoreOrderHistory[]>(this.baseRoute + 'ListStoreOrderHistory', { observe: 'body', responseType: 'json', params: params });
        obsOrderHistory.pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error( `An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error( `Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }));
        return obsOrderHistory;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
