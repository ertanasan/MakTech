import { Component, OnInit } from '@angular/core';
import { DataStateChangeEvent, GridComponent, GridDataResult } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { OverstoreCommonMethods } from '../../../../../util/common-methods.service';
import { DatePipe } from '@angular/common';
import { WDashboardOrder } from '@warehouse/model/wdashboard-order.model';
import { GatheringService } from '@warehouse/service/gathering.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { Router } from '@angular/router';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';

@Component({
    selector: 'ot-wdashboard-order',
    templateUrl: './wdashboard-order.component.html',
    styleUrls: ['./wdashboard-order.component.scss']
})
export class WdashboardOrderComponent extends MainScreenBase implements OnInit {

    chartColors;

    activeWdTrendDataTypeIndex = 0;
    orderQtyLegendText = this.gatheringService.wdTrendDataTypes[this.activeWdTrendDataTypeIndex].orderQtyLegendText;
    shippedQtyLegendText = this.gatheringService.wdTrendDataTypes[this.activeWdTrendDataTypeIndex].shippedQtyLegendText;

    listParams: ListParams = new ListParams();
    wDashboardOrderData: WDashboardOrder;
    gatheringDifferenceList: any;

    orderTrendLoading = false;
    orderTrendDays = 30;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public storeService: StoreService,
        public productService: ProductService,
        public gatheringService: GatheringService,
        public utilityService: OverstoreCommonMethods,
        public datePipe: DatePipe,
        public utility: OTUtilityService,
        public router: Router,
    ) {
        super(messageService, translateService);

        this.allData = this.allData.bind(this);
        this.chartColors = this.utility.colors.map(c => c.hex);
    }

    createEmptyItem(): any {
    }

    getBreadcrumbItems(): MenuItem[] {
        return [];
    }

    ngOnInit() {
        this.refreshData();
    }

    refreshList() {
        this.gatheringDifferenceList = process(this.wDashboardOrderData.GatheringDifferences, this.listParams);
    }

    refreshData() {
        this.listParams.take = 1000;
        this.listParams.pageable = false;
        this.gatheringService.getWDashboardOrderData().subscribe(result => {
            this.wDashboardOrderData = result;
            this.renameChartLegends();
            this.refreshList();
        });
    }

    public refreshOrderTrendData() {
        this.gatheringService.listOrderTrendData(this.gatheringService.wdTrendDataTypes[this.activeWdTrendDataTypeIndex].value, this.orderTrendDays).subscribe(result => {
            this.wDashboardOrderData.OrderTrend = result;
            this.renameChartLegends();
        });
    }

    renameChartLegends() {
        this.orderQtyLegendText = this.gatheringService.wdTrendDataTypes[this.activeWdTrendDataTypeIndex].orderQtyLegendText;
        this.shippedQtyLegendText = this.gatheringService.wdTrendDataTypes[this.activeWdTrendDataTypeIndex].shippedQtyLegendText;
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = state.skip;
        this.listParams.take = state.take;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    public getxlsFileName(): string {
        const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
        return `${ 'ToplanmayanÜrünler' }_${ todayString }.xlsx`;
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    public allData(): any {
        const newList = JSON.parse(JSON.stringify(this.wDashboardOrderData.GatheringDifferences));
        /* newList.forEach(row => {
            row.StoreName = this.storeService.completeList.filter(r => r.StoreId === row.Store)[0].Name;
            row.OrderStatusName = this.orderStatusService.completeList.filter(r => r.StoreOrderStatusId === row.Status)[0].StatusName;
        });*/
        return <GridDataResult>{
            data: process(newList, {sort: [{field: 'NotGatheredQuantity', dir: 'desc'}]}).data,
            total: newList.length
        };
    }

    public onBackBtnClicked() {
        this.router.navigate(['/Warehouse/WarehouseDashboard/Index']);
    }

}
