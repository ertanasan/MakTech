import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';


import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { ListParams } from '@otmodel/list-params.model';
import { process, SortDescriptor, aggregateBy, FilterDescriptor, filterBy, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { SelectableSettings, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { ProductPriceService } from '@price/service/product-price.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

@Component({
    selector: 'ot-price-details',
    templateUrl: './price-details.component.html',
    styleUrls: ['./price-details.component.css']
})
export class PriceDetailComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    deviceName: string;
    groupId: string;
    chartColors = [];
    priceLoadTotals: any[];
    priceStatus: any;
    priceStatus_ActiveList: any;
    priceOKTime: any;
    priceOKTime_ActiveList: any;
    chartHeight = 600;
    listParams: any;
    OKListParams: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private utility: OTUtilityService,
        public saleService: SalesService,
        public ts: TranslateService,
        public router: ActivatedRoute,
        public datePipe: DatePipe,
        public productPriceService: ProductPriceService
    ) {
        super(messageService, translateService);
        this.chartColors = this.utility.colors.map(c => c.hex);
    }


    findColor(pct) {
        if (pct >= 110) {
            return 'success';
        } else if (pct >= 90) {
            return 'primary';
        } else if (pct >= 80) {
            return 'warning';
        } else if (pct > 0) {
            return 'danger';
        } else {
            return 'primary';
        }
    }



    ngAfterViewInit() {
    }

    refreshData() {

    }

    fillData() {
        this.priceLoadTotals = [];
        const deviceList = this.productPriceService.loadStatusList.filter(r => (r.DEVICE === this.deviceName));
        deviceList.forEach (r => {
            const row = this.priceLoadTotals.filter(f => f.StoreName === r.STORE_NM);
            if (row[0]) {
                row[0].Data[0] += r.LOADOK_CNT;
                row[0].Data[1] += r.LOADNOTOK_CNT;
            } else {
                this.priceLoadTotals.push({StoreName: r.STORE_NM, Data: [r.LOADOK_CNT, r.LOADNOTOK_CNT]});
            }
        });
        this.chartHeight = this.priceLoadTotals.length * 30;
        this.priceStatus = this.productPriceService.loadStatusList.filter(r => (r.DEVICE === this.deviceName && r.LOADNOTOK_CNT > 0));
        this.priceStatus_ActiveList = this.priceStatus;
        this.priceOKTime = this.productPriceService.loadStatusList.filter(r => (r.DEVICE === this.deviceName && r.LOADOK_CNT > 0));
        this.priceOKTime_ActiveList = this.priceOKTime;
    }

    ngOnInit() {
        this.listParams = new ListParams();
        this.listParams.take = 1000;
        this.OKListParams = new ListParams();
        this.OKListParams.take = 1000;
        this.deviceName = this.router.snapshot.params['deviceName'];
        this.groupId = this.router.snapshot.params['groupId'];
        if (!this.productPriceService.loadStatusList) {
            this.productPriceService.priceLoadStatus().subscribe(list => {
                this.productPriceService.loadStatusList = list.Data;
                this.fillData();
            });
        } else {
            this.fillData();
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {

        this.listParams.skip = 0;
        this.listParams.take = 1000;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }

        this.priceStatus_ActiveList = process(this.priceStatus, this.listParams);
    }

    OKHandleDataStateChange(state: DataStateChangeEvent) {

        this.OKListParams.skip = 0;
        this.OKListParams.take = 1000;
        if (state.sort) {
            this.OKListParams.sort = state.sort;
        }
        if (state.filter) {
            this.OKListParams.filter = state.filter;
        }
        if (state.group) {
            this.OKListParams.group = state.group;
        }

        this.priceOKTime_ActiveList = process(this.priceOKTime, this.OKListParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
