// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Gathering, GatheringStats } from '@warehouse/model/gathering.model';
import { finalize, map } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { GatheringControlList } from '@warehouse/model/gathering-control-list.model';
import { OrderGathering } from '@warehouse/model/order-gathering.model';
import { WarehouseDashboard } from '@warehouse/model/whdashboard.model';
import { OrderTrend, WDashboardOrder } from '@warehouse/model/wdashboard-order.model';
import {
    WDGatheringTrendByUser,
    WDashboardGathering,
    WDGatheringTrend
} from '@warehouse/model/wdashboard-gathering.model';

/*Section="ClassHeader"*/
@Injectable()
export class GatheringService extends CRUDLService<Gathering> {
    gatheringLoading = false;
    onGatheringDone = new Subject();
    processingGathering: Gathering;
    gatheringForConsentDialog: Gathering;
    processingGatheringControl: Gathering;

    activeGatherings: Gathering[];

    poolStats: GatheringStats = new GatheringStats();
    gatheredProductsPercentage = 0;

    wdTrendDataTypes = [
        {caption: this.translateService.instant('Amount'),  value: 'Amount',    orderQtyLegendText: this.translateService.instant('Ordered Amount'),    shippedQtyLegendText: this.translateService.instant('Shipped Amount'),  gatherQtyLegendText: this.translateService.instant('Gather Amount') },
        {caption: this.translateService.instant('Package'), value: 'Package',   orderQtyLegendText: this.translateService.instant('Ordered Package'),   shippedQtyLegendText: this.translateService.instant('Shipped Package'), gatherQtyLegendText: this.translateService.instant('Gather Package') },
        {caption: this.translateService.instant('Weight'),  value: 'Weight',    orderQtyLegendText: this.translateService.instant('Ordered Weight'),    shippedQtyLegendText: this.translateService.instant('Shipped Weight'),  gatherQtyLegendText: this.translateService.instant('Gather Weight') }];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'Gathering');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listActiveGatherings(productGroup: number, status: number) {
        this.gatheringLoading = true;
        let params = new HttpParams().append('productGroup', productGroup.toString());
        params = params.append('gatheringStatus', status.toString());
        return this.httpClient.get<Gathering[]>(this.baseRoute + 'ListActiveGatherings', { observe: 'body', responseType: 'json', params: params })
            .pipe(finalize(() => this.gatheringLoading = false));
    }

    getPendingGathering(productGroup: number) {
        this.gatheringLoading = true;
        const params = new HttpParams().append('productGroup', productGroup.toString());
        return this.httpClient.get<Gathering>(this.baseRoute + 'GetPendingGathering', { observe: 'body', responseType: 'json', params: params })
            .pipe(finalize(() => this.gatheringLoading = false));
    }

    startGathering(gatheringId: number, allowReGather = 'N') {
        this.gatheringLoading = true;
        let params = new HttpParams().append('gatheringPalletId', gatheringId.toString());
        params = params.append('allowReGather', allowReGather);
        return this.httpClient.post<number>(`${this.baseRoute}StartGathering/${gatheringId}/${allowReGather}`, { observe: 'body', responseType: 'json', params: params})
            .pipe(finalize(() => this.gatheringLoading = false));
    }

    // getGatheringPoolStats(purpose: string = 'forReporting') {
    //     this.gatheringLoading = true;
    //     const params = new HttpParams().append('purpose', purpose);
    //     return this.httpClient.get<GatheringStats>(this.baseRoute + 'GetGatheringPoolStats', { observe: 'body', responseType: 'json', params: params })
    //             .pipe(map(result => { this.poolStats = result; this.gatheringLoading = false; }));
    // }

    completeGathering() {
        return this.httpClient.put(this.baseRoute + 'CompleteGathering', this.processingGathering);
    }

    abortGathering() {
        return this.httpClient.put(this.baseRoute + 'AbortGathering', this.processingGathering);
    }

    listGatheringByStoreOrderId(storeOrderId: number) {
        this.gatheringLoading = true;
        const params = new HttpParams().append('storeOrderId', storeOrderId.toString());
        return this.httpClient.get<Gathering[]>(this.baseRoute + 'GetGatheringByStoreOrder', { observe: 'body', responseType: 'json', params: params })
            .pipe(finalize(() => this.gatheringLoading = false));
    }

    // listByShipmentDate(startDate: string, endDate: string) {
    //     this.gatheringLoading = true;
    //     let params = new HttpParams().append('startDate', startDate);
    //     params = params.append('endDate', endDate);
    //     return this.httpClient.get<Gathering[]>(this.baseRoute + 'ListByShipmentDate', { observe: 'body', responseType: 'json', params: params })
    //         .pipe(finalize(() => this.gatheringLoading = false));
    // }

    getGatheringControlList(shipmentDate) {
        this.gatheringLoading = true;
        const params = new HttpParams().append('ShipmentDate', shipmentDate);
        return this.httpClient.get<GatheringControlList[]>(this.baseRoute + 'GetGatheringControlList', { observe: 'body', responseType: 'json', params: params})
            .pipe(finalize(() => this.gatheringLoading = false));
    }

    listOrderGathering(storeOrderId) {
        const params = new HttpParams().append('storeOrderId', storeOrderId);
        return this.httpClient.get<OrderGathering[]>(this.baseRoute + 'ListOrderGathering', { observe: 'body', responseType: 'json', params: params });
    }

    transferGathering(storeOrderId) {
        const params = new HttpParams().append('storeOrderId', storeOrderId);
        return this.httpClient.post<any>(`${this.baseRoute}TransferGathering/${storeOrderId}`, { observe: 'body', responseType: 'json', params: params});
    }

    warehouseDashboard() {
        return this.httpClient.get<WarehouseDashboard>(this.baseRoute + 'WarehouseDashboard', { observe: 'body', responseType: 'json'});
    }

    dashboardHourGathering() {
        return this.httpClient.get<any>(this.baseRoute + 'DashboardHourGathering', { observe: 'body', responseType: 'json'});
    }

    getWDashboardOrderData() {
        return this.httpClient.get<WDashboardOrder>(this.baseRoute + 'WDashboardOrder', { observe: 'body', responseType: 'json'});
    }

    listOrderTrendData(type: string, dayCount: number) {
        const params = new HttpParams().append('trendDataType', type)
                                       .append('dayCount', dayCount.toString());
        return this.httpClient.get<OrderTrend>(this.baseRoute + 'WDOrderTrendData', { observe: 'body', responseType: 'json', params: params});
    }

    getWdGatheringData(gatheringType: number) {
        const params = new HttpParams().append('gatheringType', gatheringType.toString());
        return this.httpClient.get<WDashboardGathering>(this.baseRoute + 'WDashboardGathering', { observe: 'body', responseType: 'json', params: params});
    }

    listGatheringTrend(gatheringType: number, trendDataType: number, dayCount: number, gatheringUserId = -1) {
        const params = new HttpParams().append('gatheringType', gatheringType.toString())
            .append('trendDataType', trendDataType.toString())
            .append('dayCount', dayCount.toString())
            .append('gatheringUserId', gatheringUserId.toString());
        return this.httpClient.get<WDGatheringTrend[]>(this.baseRoute + 'WDGatheringTrendData', { observe: 'body', responseType: 'json', params: params});
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
