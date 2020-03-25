import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { environment } from '../../../../environments/environment';
import { StockTaking } from '@warehouse/model/stock-taking.model';
import { Product } from '@product/model/product.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';
import { DatePipe } from '@angular/common';

/*Section="ClassHeader"*/
@Injectable()
export class StockTrackingService {
    public stocktTackingProducts: any; 
    public stockTracking: any;
    // public stockTrackingActiveList: any;


    constructor(
        public httpClient: HttpClient,
        public messageService: GrowlMessageService,
        public translateService: TranslateService,
    ) {

    }
    listStocktracking(startDate: Date) {
        const params = new HttpParams().append('StartDate', startDate.toISOString());
        const obsStockTracking = this.httpClient.get<any>(`${environment.baseRoute}/Warehouse/StockTaking/` + 'listStocktracking', { observe: 'body', responseType: 'json', params: params });
        obsStockTracking.pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    this.messageService.error(`An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    this.messageService.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }));
        return obsStockTracking;
    }


    listStocktrackingProducts(product: number, startDate: Date, endDate: Date) {
        const params = new HttpParams().append('startDate', startDate.toISOString()).append('endDate', endDate.toISOString()).append('product', product.toString());
        const obsStockTrackingProducts = this.httpClient.get<any>(`${environment.baseRoute}/Warehouse/StockTaking/` + 'ListStocktrackingProducts', { observe: 'body', responseType: 'json', params: params });
        obsStockTrackingProducts.pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    this.messageService.error(`An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    this.messageService.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }));
        return obsStockTrackingProducts;
    }


}