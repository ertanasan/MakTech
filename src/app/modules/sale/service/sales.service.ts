// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Sales, DeviceInfoModel } from '@sale/model/sales.model';
import { ListParams } from '@otmodel/list-params.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';
import { Refund } from '@sale/model/refund.model';

/*Section="ClassHeader"*/
@Injectable()
export class SalesService extends CRUDLService<Sales> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Sale', 'Sales');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    dashboardData: any;
    storeName: string;

    getDashboardData() {
        const obs = this.httpClient.get<any>(this.baseRoute + 'GetDashboardData', { observe: 'body', responseType: 'json' });
        obs.subscribe( result => {
            this.dashboardData = result.Data;
            this.dashboardData.forEach(r => {
                r.daydiff = r.t_amount - r.t_refund - r.lwt_amount + r.lwt_refund;
                r.weekdiff = r.weekly_amount - r.weekly_refund - r.prevweek_amount + r.prevweek_refund;
                r.monthdiff = r.monthly_amount - r.monthly_refund - r.prevmonth_amount + r.prevmonth_refund;
                r.yesterdaydiff = r.y_amount - r.y_refund - r.lwy_amount + r.lwy_refund;
                r.yeardiff = r.annual_amount - r.annual_refund - r.prevyear_amount + r.prevyear_refund;
                r.dailyIncrease = (100.0 * ((r.annual_amount - r.annual_refund) / r.annual_daycount) / ((r.prevyear_amount + r.prevyear_refund) / r.prevyear_daycount )) - 100.0;
            });
            if (this.dashboardData.length === 1) {
                this.storeName = this.dashboardData[0].storename;
            } else {
                this.storeName = '';
            }
        });
        return obs;
    }

    getDashboardCategoryData() {
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardCategoryData', { observe: 'body', responseType: 'json' });
    }

    getDashboardStoreCount() {
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardStoreCount', { observe: 'body', responseType: 'json' });
    }

    getDashboardMissingSaleStore() {
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardMissingSaleStore', { observe: 'body', responseType: 'json' });
    }

    getRegionManagerSales(listparams: ListParams) {
        const params = this.prepareListParams(listparams);
        return this.httpClient.get<any>(this.baseRoute + 'GetRegionManagerSales', { observe: 'body', responseType: 'json', params: params });
    }

    getDashboardZCompare(period, baseDate, termDetail) {
        let params = new HttpParams().append('period', period);
        params = params.append('baseDate', baseDate);
        params = params.append('termDetail', termDetail);
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardZCompare', { observe: 'body', responseType: 'json', params: params });
    }

    getMissingZet() {
        return this.httpClient.get<any>(this.baseRoute + 'GetMissingZet', { observe: 'body', responseType: 'json'});
    }

    getCategoryStoreData(categoryName, productId, endDate, dayGroup) {
        let params = new HttpParams().append('categoryName', categoryName);
        params = params.append('productId', productId);
        params = params.append('endDate', endDate);
        params = params.append('dayGroup', dayGroup);
        return this.httpClient.get<any>(this.baseRoute + 'GetCategoryStoreData', { observe: 'body', responseType: 'json', params: params });
    }

    getCategoryProductData(categoryName, storeId, endDate, dayGroup) {
        let params = new HttpParams().append('categoryName', categoryName);
        params = params.append('storeId', storeId);
        params = params.append('endDate', endDate);
        params = params.append('dayGroup', dayGroup);
        return this.httpClient.get<any>(this.baseRoute + 'GetCategoryProductData', { observe: 'body', responseType: 'json', params: params });
    }

    getSaleByCategoryName(categoryName, storeId, endDate, productId) {
        let params = new HttpParams().append('categoryName', categoryName);
        params = params.append('storeId', storeId);
        params = params.append('endDate', endDate);
        params = params.append('productId', productId);
        return this.httpClient.get<any>(this.baseRoute + 'GetSaleByCategoryName', { observe: 'body', responseType: 'json', params: params });
    }

    stockOutSummary(startDate, endDate, storeCountSold, categoryId) {
        let params = new HttpParams().append('startDate', startDate);
        params = params.append('endDate', endDate);
        params = params.append('storeCountSold', storeCountSold);
        params = params.append('categoryId', categoryId);
        return this.httpClient.get<any>(this.baseRoute + 'StockOutSummary', { observe: 'body', responseType: 'json', params: params });
    }

    stockOutStore(startDate, endDate, storeCountSold, storeId, categoryId) {
        let params = new HttpParams().append('startDate', startDate);
        params = params.append('endDate', endDate);
        params = params.append('storeCountSold', storeCountSold);
        params = params.append('storeId', storeId);
        params = params.append('categoryId', categoryId);
        return this.httpClient.get<any>(this.baseRoute + 'StockOutStore', { observe: 'body', responseType: 'json', params: params });
    }

    // [/MCEM] For Third Chart of Dashboard
    getDashboardStoreData() {
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardStoreData', { observe: 'body', responseType: 'json' });
    }

    listDateStore(transactionDate, storeId) {
        let params = new HttpParams().append('transactionDate', transactionDate);
        params = params.append('storeId', storeId);
        return this.httpClient.get<any>(this.baseRoute + 'ListDateStore', { observe: 'body', responseType: 'json', params: params }).pipe(
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

    listSalesComparison(storeId, startDate, endDate, comparingStartDate, comparingEndDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        params = params.append('comparingStartDate', comparingStartDate);
        params = params.append('comparingEndDate', comparingEndDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListSalesComparison', { observe: 'body', responseType: 'json', params: params });
    }

    getSalesSummaryReport(storeId, startDate, endDate, aggregationFlag = 'N') {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        params = params.append('aggregationFlag', aggregationFlag);
        return this.httpClient.get<any>(this.baseRoute + 'ListSalesSummaryReport', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreSales(listparams: ListParams) {
        const params = this.prepareListParams(listparams);
        return this.httpClient.get<any>(this.baseRoute + 'ListStoreSales', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreDashboardSaleInfo(storeId: number) {
        const params = new HttpParams().append('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'StoreDashboardSaleInfo', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreCategorySale(storeId: number) {
        const params = new HttpParams().append('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'ListStoreCategorySale', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreCategoryProductSale(storeId: number, categoryId: number) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('categoryId', categoryId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'ListStoreCategoryProductSale', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreDashboardStockInfo(storeId: number) {
        const params = new HttpParams().append('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'StoreDashboardStockInfo', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreDashboardDailyStockOut(storeId: number, dayCount: number) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('dayCount', dayCount.toString());
        return this.httpClient.get<any>(this.baseRoute + 'StoreDashboardDailyStockOut', { observe: 'body', responseType: 'json', params: params });
    }

    getStoreDashboardDayStockOut(storeId: number, dayCount: number, day: string) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('dayCount', dayCount.toString());
        params = params.append('day', day);
        return this.httpClient.get<any>(this.baseRoute + 'StoreDashboardDayStockOut', { observe: 'body', responseType: 'json', params: params });
    }

    getDailySaleTrend(storeId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'DailySaleTrendByStore', { observe: 'body', responseType: 'json', params: params });
    }

    listRefunds(storeId, productId) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('productId', productId);
        return this.httpClient.get<Refund[]>(this.baseRoute + 'ListRefunds', { observe: 'body', responseType: 'json', params: params });
    }

    readRefund(saleDetailId) {
        const params = new HttpParams().append('saleDetailId', saleDetailId.toString());
        return this.httpClient.get<Refund>(this.baseRoute + 'ReadRefund', { observe: 'body', responseType: 'json', params: params });
    }

    logDeviceInfo(deviceInfo) {
        const m: DeviceInfoModel = new DeviceInfoModel();
        m.DeviceInfo = deviceInfo;
        this.httpClient.post<any>(this.baseRoute + 'LogDeviceInfo', m).subscribe(result => { });
    }

    listCancelledSale(storeId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId.toString());
        params = params.append('startDate', startDate.toDateString());
        params = params.append('endDate', endDate.toDateString());
        return this.httpClient.get<Sales[]>(this.baseRoute + 'ListCancelledSale', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
