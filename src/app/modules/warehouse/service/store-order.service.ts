// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreOrder } from '@warehouse/model/store-order.model';
import { saveAs } from 'file-saver';
import { ListParams } from '@otmodel/list-params.model';
import { StoreScales } from '@store/model/store-scales.model';
import { StoreOrderDetail } from '@warehouse/model/store-order-detail.model';
import { Store } from '@store/model/store.model';


/*Section="ClassHeader"*/
@Injectable()
export class StoreOrderService extends CRUDLService<StoreOrder> {

    currentTime: Date;
    public keptList ;
    public keptListParams;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StoreOrder');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public getShipmentDay(storeId) {

        const params = new HttpParams().append('storeId', storeId);
        return this.httpClient.get(this.baseRoute + 'getShipmentDay', { observe: 'body', responseType: 'json', params: params });

    }

    public getOrderofDay(storeId, shipmentDay) {

        const params = new HttpParams().append('storeId', storeId).append('shipmentDay', shipmentDay);
        return this.httpClient.get(this.baseRoute + 'GetOrderofDay', { observe: 'body', responseType: 'json', params: params });

    }

    public getTime() {
        const obs = this.httpClient.get(this.baseRoute + 'GetTime', { observe: 'body', responseType: 'json' });
        obs.subscribe(result => this.currentTime = <Date> result);
        return obs;
    }

    public dispatch(storeOrder) {

        return this.httpClient.post(this.baseRoute + 'Dispatch', storeOrder);

    }

    exportReportData(listParams: ListParams) {

        const params = this.prepareListParams(listParams);
        return this.httpClient.get(this.baseRoute + 'ExportStoreOrders', { responseType: 'blob', headers: {'Accept': 'application/vnd.ms-excel'}, observe: 'body', params: params }).subscribe(
            blob => {
                saveAs(blob, 'storeOrder' + '.xlsx');
                this.messageService.success('Export completed.');
            },
            error => {
                this.messageService.error('Export Order Data failed: ' + error.message);
                console.log('exportOrderData : ', error);
            }
        );
    }

    listOrderSaleProductDetails(storeId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListOrderSaleProductDetails', { observe: 'body', responseType: 'json', params: params });
    }

    listOrderSaleDateDetails(storeId, productId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListOrderSaleDateDetails', { observe: 'body', responseType: 'json', params: params });
    }

    listOrderSaleStoreDetails(productId, startDate, endDate) {
        let params = new HttpParams().append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListOrderSaleStoreDetails', { observe: 'body', responseType: 'json', params: params });
    }

    constraintTheory(storeId, productId, startDate, endDate, startBuffer, shipmenUnit,
        greenCycle, bufferBandwith, ceiling) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        params = params.append('startBuffer', startBuffer);
        params = params.append('shipmenUnit', shipmenUnit);
        params = params.append('greenCycle', greenCycle);
        params = params.append('bufferBandwith', bufferBandwith);
        params = params.append('ceiling', ceiling);
        return this.httpClient.get<any>(this.baseRoute + 'ConstraintTheory', { observe: 'body', responseType: 'json', params: params });
    }

    topSaleDayGroup(storeId, productId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'TopSaleDayGroup', { observe: 'body', responseType: 'json', params: params });
    }

    printOrders(storeOrderId) {
        const orders = {storeOrderId : storeOrderId};
        const params = new HttpParams().append('orders', JSON.stringify(orders));
        return this.httpClient.get<any>(this.baseRoute + 'PrintOrders', { observe: 'body', responseType: 'json', params: params });
    }

    printDetails(storeOrderId) {
        const params = new HttpParams().append('orders', JSON.stringify({storeOrderId: storeOrderId}));
        return this.httpClient.get<any>(this.baseRoute + 'printDetails', { observe: 'body', responseType: 'json', params: params });
    }

    listOrders(includeCompletedOrders: boolean, baseDate) {
        let params = new HttpParams().append('includeCompletedOrders', includeCompletedOrders ? 'Y' : 'N');
        params = params.append('baseDate', baseDate);
        return this.httpClient.get<StoreOrder[]>(this.baseRoute + 'ListOrders', { observe: 'body', responseType: 'json', params: params });
    }

    mikroShipmentControl(storeOrderId) {
        const params = new HttpParams().append('storeOrderId', storeOrderId);
        return this.httpClient.get<StoreOrderDetail[]>(this.baseRoute + 'MikroShipmentControl', { observe: 'body', responseType: 'json', params: params });
    }

    addProductsFromExcel(formData, storeOrderId) {
        const params = new HttpParams().append('storeOrderId', storeOrderId);
        return this.httpClient.post(this.baseRoute + 'AddProductsFromExcel', formData, { responseType: 'text', params: params });
    }

    // METHODS FOR DATA STATE MANAGEMENT
    keepState(params: ListParams, list: any) {
       this.keptList = list;
       this.keptListParams = params;
    }

    getKeptState(variableName: string) {
        switch (variableName) {
            case 'activeList':
                return this.keptList;
            case 'listParams':
                return this.keptListParams;
            default:
                return null;
        }
    }

    clearKeptState() {
        this.keptList = null;
        this.keptListParams = null;
    }

    noOrderStoreList() {
        return this.httpClient.get<Store[]>(this.baseRoute + 'NoOrderStoreList', { observe: 'body', responseType: 'json'});
    }

    stockDashboard() {
        return this.httpClient.get<any>(this.baseRoute + 'StockDashboard', { observe: 'body', responseType: 'json'});
    }

    StockDashboardTrend(categoryName, productName, storeName) {
        let params = new HttpParams().append('categoryName', categoryName);
        params = params.append('productName', productName);
        params = params.append('storeName', storeName);
        return this.httpClient.get<any>(this.baseRoute + 'StockDashboardTrend', { observe: 'body', responseType: 'json', params: params});
    }   
    //#endregion Customized

    /*Section="ClassFooter"*/
}
