// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StockTaking } from '@warehouse/model/stock-taking.model';
import { Product } from '@product/model/product.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';
import { DatePipe } from '@angular/common';

/*Section="ClassHeader"*/
@Injectable()
export class StockTakingService extends CRUDLService<StockTaking> {

    stockTakingProductList: StockTaking[];
    stockTakingDetails: any;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StockTaking');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    updateRow(model: StockTaking ) {
        return this.httpClient.put<any>(this.baseRoute + 'UpdateRow', model);
    }

    listStockTakingProducts(scheduleid: number, action = 'List') {
        const params = new HttpParams().append('scheduleId', scheduleid.toString());
        const obsStockTakingProducts = this.httpClient.get<StockTaking[]>(this.baseRoute + 'ListStockTakingProducts', { observe: 'body', responseType: 'json', params: params });
        obsStockTakingProducts.pipe(
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
        return obsStockTakingProducts;
    }

    // public assignValues(target: any, source: any): void {
    //     Object.assign(target, source);
    // }

    public PostStockTakings() {

        const updatedRows = [];
        this.stockTakingProductList.forEach((r) => {
            if (r.CountingValue != null && r.CountingValue !== r.InitialCountingValue) {
                updatedRows.push(r);
            }
        });
        // console.log(updatedRows);
        if (updatedRows.length > 0) {
            return this.httpClient.put(this.baseRoute + 'PostStoreTakingDetails', updatedRows);
        } else {
            return 0;
        }
    }

    public InsertFromBarcodeReader(scheduleId, zoneId, opCode, eanCode, totalWeight) {
        let params = new HttpParams().append('scheduleId', scheduleId);
        params = params.append('zoneId', zoneId);
        params = params.append('opCode', opCode);
        params = params.append('eanCode', eanCode);
        params = params.append('manualWeight', totalWeight);
        return this.httpClient.get<any>(this.baseRoute + 'InsertFromBarcodeReader', { observe: 'body', responseType: 'json', params: params } );
    }

    public ListCurrentStocks(storeId) {
        const params = new HttpParams().append('storeId', storeId);
        return this.httpClient.get<any>(this.baseRoute + 'ListCurrentStocks', { observe: 'body', responseType: 'json', params: params });
    }

    public listStockTransactions(storeId, productId, currentStock) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('currentStock', currentStock);
        return this.httpClient.get<any>(this.baseRoute + 'ListStockTransactions', { observe: 'body', responseType: 'json', params: params });
    }

    public listStocksAtCriticalLevel(storeId) {
        const params = new HttpParams().append('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'ListStocksAtCriticalLevel', { observe: 'body', responseType: 'json', params: params });
    }

    public listDailyStockTrendByStore(storeId, startDate, endDate) {
        let params = new HttpParams().append('store', storeId.toString());
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListDailyStockTrendByStore', { observe: 'body', responseType: 'json', params: params });
    }

    public fastEntryUpdate(stockTakingModel: StockTaking) {
        return this.httpClient.put(this.baseRoute + 'FastEntryUpdate', stockTakingModel);
    }

    public MikroTransfer() {
        return this.httpClient.post<any>(this.baseRoute + 'MikroTransfer',1);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
