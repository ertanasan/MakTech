import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { DataStateChangeEvent, PageChangeEvent, GridDataResult, GridComponent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { process, SortDescriptor, aggregateBy, FilterDescriptor, filterBy, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { Observable } from 'rxjs';
import { StoreService } from '@store/service/store.service';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

@Component({
    selector: 'ot-dashboard-details',
    templateUrl: './dashboard-details.component.html',
    styleUrls: ['./dashboard-details.component.css']
})
export class DashboardDetailComponent extends MainScreenBase implements OnInit {

    @ViewChild(CustomDialogComponent, {static: true}) missingZet: CustomDialogComponent;

    chartColors = [];
    storeCountList: any;
    detailId: string;
    storeDetails: boolean;
    compareDetails: boolean;
    compareWeeklyDetails: boolean;
    compareMonthlyDetails: boolean;
    compareYesterdayDetails: boolean;
    compareYearDetails: boolean;
    isStore = false;

    outdatedCodeList: any;
    outdatedCodeActiveList: any;
    outdatedCodeListLoading = false;
    outdatedCodeStoreLP: ListParams = new ListParams();

    missingSaleStoreList: any;
    missingSaleStoreListLoading = false;
    listParams: ListParams;
    missingSaleStoreActiveList: any;

    zComparisonListLoading = false;
    ZListParams: ListParams;
    zComparisonList: any;
    zComparisonActiveList: any;

    todayString: string;
    baseDate: Date;

    typeOfGraph = 'bar_local';  // bar_local, bar_sql, line_local, line_Sql, lineMix_local
    typeOfGraphArray: Array<string> = ['bar_local', 'bar_sql', 'line_local', 'line_Sql', 'lineMix_local', 'lineMix_sql'];
    monthlyStoreCount1: any;
    dashboardActiveList: any;
    public aggregates_c1: any[] =
        [{field: 't_amount', aggregate: 'sum'},
         {field: 't_refund', aggregate: 'sum'},
         {field: 'lwt_amount', aggregate: 'sum'},
         {field: 'lwt_refund', aggregate: 'sum'},
         {field: 'weekly_amount', aggregate: 'sum'},
         {field: 'weekly_refund', aggregate: 'sum'},
         {field: 'prevweek_amount', aggregate: 'sum'},
         {field: 'prevweek_refund', aggregate: 'sum'},
         {field: 'monthly_amount', aggregate: 'sum'},
         {field: 'monthly_refund', aggregate: 'sum'},
         {field: 'prevmonth_amount', aggregate: 'sum'},
         {field: 'prevmonth_refund', aggregate: 'sum'},
         {field: 'y_amount', aggregate: 'sum'},
         {field: 'y_refund', aggregate: 'sum'},
         {field: 'lwy_amount', aggregate: 'sum'},
         {field: 'lwy_refund', aggregate: 'sum'},
         {field: 'annual_amount', aggregate: 'sum'},
         {field: 'annual_refund', aggregate: 'sum'},
         {field: 'prevyear_amount', aggregate: 'sum'},
         {field: 'prevyear_refund', aggregate: 'sum'}];
    public total_c1: any;

    monthlyStoreCount = [
        { month: 'Ocak',    storeCount: 80,  monthlySalePerStore: 30000 },
        { month: 'Şubat',   storeCount: 81,  monthlySalePerStore: 28000 },
        { month: 'Mart',    storeCount: 90,  monthlySalePerStore: 22000 },
        { month: 'Nisan',   storeCount: 93,  monthlySalePerStore: 27000 },
        { month: 'Mayıs',   storeCount: 95,  monthlySalePerStore: 30000 },
        { month: 'Haziran', storeCount: 95,  monthlySalePerStore: 32000 },
        { month: 'Temmuz',  storeCount: 95,  monthlySalePerStore: 35000 },
        { month: 'Ağustos', storeCount: 102, monthlySalePerStore: 32000 },
        { month: 'Eylül',   storeCount: 120, monthlySalePerStore: 29000 },
        { month: 'EKim',    storeCount: 121, monthlySalePerStore: 28000 },
        { month: 'Kasım',   storeCount: 130, monthlySalePerStore: 26000 },
        { month: 'Aralık',  storeCount: 130, monthlySalePerStore: 27000 }
    ];
    period = 1;
    termDetail = false;
    timesDetail = false;
    missingZetList: { data: any; total: any; };

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public router: ActivatedRoute,
        public intl: IntlService,
        public saleService: SalesService,
        public datePipe: DatePipe,
        public storeService: StoreService
    ) {
        super(messageService, translateService);
        this.chartColors = this.utilityService.colors.map(c => c.hex);
        this.allZData = this.allZData.bind(this);
    }

    public allZData(): any {
        return <GridDataResult> {
            data: this.zComparisonList,
            total: this.zComparisonList.count
        };
    }

    public getxlsFileName(reportName: string): string {

        return `${reportName}_${this.todayString}.xlsx`;
    }

    selectionChange(value: any) {
        this.typeOfGraph = value;
    }


    onSelectedChange(event, period) {
        if (event) {
            this.period = period;
            this.refreshZList();
        }
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    onSelectedDetailChange() {
        this.termDetail = !this.termDetail;
        this.refreshZList();
    }

    onSelectedTimesChange() {
        this.timesDetail = !this.timesDetail;
    }

    refreshZList() {
        this.zComparisonListLoading = true;
        const d = new Date(this.baseDate);
        const baseDateString = this.datePipe.transform(d, 'yyyy-MM-dd');
        this.saleService.getDashboardZCompare(this.period, baseDateString, this.termDetail).subscribe(data => {
            this.zComparisonList = data.Data;
            this.zComparisonActiveList = data.Data;
            this.zRefreshList();
            this.zComparisonListLoading = false;
        },
        error => {
            console.log(error);
            this.zComparisonListLoading = false;
        });
    }

    onBaseDateChange() {
        this.refreshZList();
    }

    ngOnInit() {

        const bd = new Date();
        bd.setDate(bd.getDate() - 1);
        this.baseDate = bd;

        this.detailId = this.router.snapshot.params['detailId'];

        const d: Date = new Date();
        this.todayString = this.datePipe.transform(d, 'yyyyMMdd');

        this.storeDetails = (this.detailId === '1');
        this.compareDetails = (this.detailId === '2');
        this.compareWeeklyDetails = (this.detailId === '3');
        this.compareMonthlyDetails = (this.detailId === '4');

        this.listParams = new ListParams();

        if (this.storeDetails) {

            this.ZListParams = new ListParams();

            this.saleService.getDashboardStoreCount().subscribe(data => {
                this.storeCountList = data.Data;
            },
            error => {
                console.log(error);
            });

            this.refreshOutdatedCodeList();

            this.missingSaleStoreListLoading = true;
            this.saleService.getDashboardMissingSaleStore().subscribe(data => {
                this.missingSaleStoreList = data.Data;
                this.missingSaleStoreActiveList = data.Data;
                this.refreshList();
                this.missingSaleStoreListLoading = false;
            },
            error => {
                console.log(error);
                this.missingSaleStoreListLoading = false;
            });

            this.refreshZList();
        }

        this.storeService.listUserStores().subscribe(list => {
            if (list.length === 1) {
                this.isStore = true;
            } else {
                this.isStore = false;
            }
            this.compareYesterdayDetails = ((this.detailId === '5') && this.isStore);
            this.compareYearDetails = ((this.detailId === '5') && !this.isStore);
            if (this.compareDetails || this.compareWeeklyDetails || this.compareMonthlyDetails || this.compareYesterdayDetails || this.compareYearDetails) {
                if (!this.saleService.dashboardData) {
                    this.saleService.getDashboardData().subscribe(result => {
                        this.total_c1 = aggregateBy(this.saleService.dashboardData, this.aggregates_c1);
                        this.refreshList();
                    });
                } else {
                    this.total_c1 = aggregateBy(this.saleService.dashboardData, this.aggregates_c1);
                    this.refreshList();
                }
            }

        });
    }

    refreshList() {
        if (this.storeDetails && this.missingSaleStoreList) {
            this.missingSaleStoreActiveList = process(this.missingSaleStoreList, this.listParams);
        }
        if ((this.compareDetails || this.compareWeeklyDetails || this.compareMonthlyDetails || this.compareYesterdayDetails || this.compareYearDetails) && this.saleService.dashboardData) {
            this.listParams.take = 1000;
            this.dashboardActiveList = process(this.saleService.dashboardData, this.listParams);
        }
    }

    refreshOutdatedCodeList() {
        this.outdatedCodeListLoading = true;
        this.storeService.getDashboardOutdatedCodeStore().subscribe(
            data => {
                this.outdatedCodeList = data.Data;
                this.outdatedCodeActiveList = data.Data;
                this.refreshList();
                this.outdatedCodeListLoading = false;
            }, error => {
                this.messageService.error(this.translateService.instant('Data about stores with outdated code can not be retrieved'));
                this.outdatedCodeListLoading = false;
            }
        );
    }

    outdatedCodeHandleDSC(state: DataStateChangeEvent) {
        this.outdatedCodeStoreLP.skip = 0;
        if (state.sort) {
            this.outdatedCodeStoreLP.sort = state.sort;
        }
        if (state.filter) {
            this.outdatedCodeStoreLP.filter = state.filter;
        }
        if (state.skip) {
            this.outdatedCodeStoreLP.skip = state.skip;
        }
        if (state.take) {
            this.outdatedCodeStoreLP.take = state.take;
        }
        this.outdatedCodeList.map(t => t.HASH_TM = new Date(t.HASH_TM));
        this.outdatedCodeActiveList = process(this.outdatedCodeList, this.outdatedCodeStoreLP);
    }

    zRefreshList() {
        if (this.zComparisonList) {
            this.zComparisonActiveList = process(this.zComparisonList, this.ZListParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyModel(): any {
    }

    createEmptyItem(): any {
        return this.createEmptyModel();
    }

    refreshData(id?: number) {
        this.refreshList();
        this.zRefreshList();
    }

    handleDataStateChange(state: DataStateChangeEvent) {

        this.listParams.skip = 0;
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

    switchChange(event) {
    }
    zHandleDataStateChange(state: DataStateChangeEvent) {

        this.ZListParams.skip = 0;
        if (state.sort) {
            this.ZListParams.sort = state.sort;
        }
        if (state.filter) {
            // const filters = <FilterDescriptor[]>state.filter.filters;
            // filters.forEach(f => {
            //     if (f.field = 'DATE_DT') {
            //         f.value =  this.datePipe.transform (<Date> f.value, 'yyyy-MM-dd');
            //     }
            // });
            this.ZListParams.filter = state.filter;
        }
        if (state.group) {
            this.ZListParams.group = state.group;
        }

        this.zRefreshList();
    }

    handlePageChange(event: PageChangeEvent) {
        if (this.missingSaleStoreList != null) {
            this.listParams.skip = event.skip;
            this.missingSaleStoreActiveList = {
                data: this.missingSaleStoreList.slice(this.listParams.skip, this.listParams.skip + this.listParams.take),
                total: this.missingSaleStoreList.length
            };
            this.refreshList();
        }
    }

    zHandlePageChange(event: PageChangeEvent) {
        if (this.zComparisonList != null) {
            this.ZListParams.skip = event.skip;
            this.zComparisonActiveList = {
                data: this.zComparisonList.slice(this.listParams.skip, this.listParams.skip + this.listParams.take),
                total: this.zComparisonList.length
            };
            this.zRefreshList();
        }
    }

    handleSortChange(sort: SortDescriptor[]) {

        if (sort) {
            this.listParams.sort = sort;
        }
        this.refreshList();
    }

    zHandleSortChange(sort: SortDescriptor[]) {

        if (sort) {
            this.ZListParams.sort = sort;
        }
        this.zRefreshList();
    }

    showMissingZet() {
        this.saleService.getMissingZet().subscribe(list => {
            this.missingZetList = {data: list.Data, total: list.Total};
            this.missingZet.caption = 'Z Gelmeyenler';
            this.missingZet.show();
        });
    }
}
