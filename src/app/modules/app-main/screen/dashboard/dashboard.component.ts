import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, OnDestroy, ChangeDetectorRef, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';

import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { DatePipe } from '@angular/common';
import { DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';

import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { OTContext } from '@otlib/auth/model/context.model';
import { DashboardDetailComponent } from '../dashboard-details/dashboard-details.component';
import { ProductPriceService } from '@price/service/product-price.service';
import { PriceLabelPrintService } from '@price/service/price-label-print.service';
import { ListParams } from '@otmodel/list-params.model';
import { process, GroupResult, groupBy } from '@progress/kendo-data-query';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
import { DeviceDetectorService } from 'ngx-device-detector';
import { first } from 'rxjs/operators';
import { GroupUserService } from '@frame/security/service/group-user.service';
import { GroupService } from '@frame/security/service/group.service';
import { HttpParams } from '@angular/common/http';
import { StoreService } from '@store/service/store.service';

@Component({
    selector: 'ot-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent extends MainScreenBase implements OnInit, OnDestroy {

    @ViewChild(DashboardDetailComponent, {static: true}) detailsScreen: DashboardDetailComponent;
    public today = new Date().toISOString().slice(0, 10);
    public lastDay = new Date(new Date().setHours(-14 * 24)).toISOString().slice(0, 10);
    intervalHolder: any;
    data: Observable<any>;
    dashboardData;
    categoryData;
    summaryData;
    refreshTime: Date;
    deviceInfo = null;
    saleViewCode = 1; // 1: Ciro, 2: Büyüme

    contextState$: Observable<OTContext>;

    chartColors = ['#5867dd', '#0abb87', '#fd397a', '#ffb822'];

    familyRevenue: any = [];
    familyGrandTotal = 0;

    regionTotals: any = [
        { region: 'İstanbul Avrupa', revenue: 27000 },
        { region: 'İstanbul Anadolu', revenue: 8000 },
        { region: 'Diğer', revenue: 4250 },
    ];
    regionGrandTotal = this.regionTotals.reduce((sum, item) => sum + item.revenue, 0);

    priceLoadTotals: any[] = [];

    printedLabelsPercentage: any[] = [];
    printedLabelValueAxis: any = {
        min: 0,
        max: 100,
        plotBands: [{
            from: 0, to: 100, color: '#B0C4DE', opacity: 0.15
        }]
    };

    storeSalesList: any[] = [];
    storeSalesLoading = false;
    storeSalesLP: ListParams = new ListParams();

    rmSalesList: any[] = [];
    rmSalesLoading = false;
    rmSalesLP: ListParams = new ListParams();
    dashboardAuthorization: string;
    isStore: boolean;
    isRegion: boolean;
    isCentralOffice: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public router: Router,
        public saleService: SalesService,
        public priceLabelPrintService: PriceLabelPrintService,
        private utility: OTUtilityService,
        private changeDetectorRef: ChangeDetectorRef,
        private store: Store<fromApp.AppState>,
        public ts: TranslateService,
        public productPriceService: ProductPriceService,
        public datePipe: DatePipe,
        private privilegeCacheService: PrivilegeCacheService,
        public route: Router,
        private deviceService: DeviceDetectorService,
        public groupUserService: GroupUserService,
        public groupService: GroupService,
        public storeService: StoreService
    ) {
        super(messageService, translateService);
        this.chartColors = this.utility.colors.map(c => c.hex);

        this.contextState$ = this.store.select('context');
    }

    epicFunction() {
        this.deviceInfo = this.deviceService.getDeviceInfo();
        this.saleService.logDeviceInfo(JSON.stringify(this.deviceInfo));
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

    clearSummaryData() {
        this.summaryData = {
            storeCount: 0,
            saleStoreCount: 0,
            stockKPI: 0,
            stockKPIOrder: 0,
            stockKPIRegionOrder: 0,
            regionStoreCount: 0,
            daily: {
                sale: 0,
                refund: 0,
                net: 0,
                receiptCount: 0,
                saleavg: 0,
                pct: 0,
                color: 'success',
                inverted: 'true'
            },
            lastWeekToday: {
                sale: 0,
                refund: 0,
                net: 0,
            },
            weekly: {
                sale: 0,
                refund: 0,
                net: 0,
                pct: 0,
                color: 'success',
                inverted: 'true'
            },
            prevWeek: {
                sale: 0,
                refund: 0,
                net: 0,
            },
            monthly: {
                sale: 0,
                refund: 0,
                net: 0,
                pct: 0,
                color: 'success',
                inverted: 'true'
            },
            prevMonth: {
                sale: 0,
                refund: 0,
                net: 0,
            },
            yesterday: {
                sale: 0,
                refund: 0,
                net: 0,
                pct: 0,
                color: 'success',
                inverted: 'true'
            },
            lastWeekYesterday: {
                sale: 0,
                refund: 0,
                net: 0,
            },
            annual: {
                pct: 0,
                color: 'success',
                inverted: 'true'
            },
            thisyear: {
                sale: 0,
                refund: 0,
                net: 0,
                storecount: 0,
            },
            lastyear: {
                sale: 0,
                refund: 0,
                net: 0,
                storecount: 0,
            }
        };
    }

    fillSummaryData() {
        this.refreshTime = new Date();
        this.clearSummaryData();
        this.summaryData.storeCount = this.dashboardData.filter(row => row.isactive === 'Y').length;
        let thisyeartotaldaycount = 0;
        let thisyeardaycount = 0;
        let lastyeartotaldaycount = 0;
        let lastyeardaycount = 0;
        this.dashboardData.forEach(d => {
            this.summaryData.daily.sale += d.t_amount;
            this.summaryData.daily.refund += d.t_refund;
            this.summaryData.daily.net += (d.t_amount - d.t_refund);
            this.summaryData.daily.receiptCount += d.t_sale;
            if (d.t_amount > 0) {
                this.summaryData.saleStoreCount++;
            }

            this.summaryData.stockKPI = d.STOCKSALEPCT;
            this.summaryData.stockKPIOrder = d.MAKBULORDER;
            this.summaryData.stockKPIRegionOrder = d.REGIONORDER;
            this.summaryData.regionStoreCount = d.REGIONSTORECOUNT;

            this.summaryData.lastWeekToday.sale += d.lwt_amount;
            this.summaryData.lastWeekToday.refund += d.lwt_refund;
            this.summaryData.lastWeekToday.net += (d.lwt_amount - d.lwt_refund);

            this.summaryData.weekly.sale += d.weekly_amount;
            this.summaryData.weekly.refund += d.weekly_refund;
            this.summaryData.weekly.net += (d.weekly_amount - d.weekly_refund);

            this.summaryData.prevWeek.sale += d.prevweek_amount;
            this.summaryData.prevWeek.refund += d.prevweek_refund;
            this.summaryData.prevWeek.net += (d.prevweek_amount - d.prevweek_refund);

            this.summaryData.monthly.sale += d.monthly_amount;
            this.summaryData.monthly.refund += d.monthly_refund;
            this.summaryData.monthly.net += (d.monthly_amount - d.monthly_refund);

            this.summaryData.prevMonth.sale += d.prevmonth_amount;
            this.summaryData.prevMonth.refund += d.prevmonth_refund;
            this.summaryData.prevMonth.net += (d.prevmonth_amount - d.prevmonth_refund);

            this.summaryData.thisyear.sale += d.annual_amount;
            this.summaryData.thisyear.refund += d.annual_refund;
            this.summaryData.thisyear.net += (d.annual_amount - d.annual_refund);
            thisyeartotaldaycount += d.annual_daycount;
            if (d.annual_daycount > thisyeardaycount) thisyeardaycount = d.annual_daycount;

            this.summaryData.lastyear.sale += d.prevyear_amount;
            this.summaryData.lastyear.refund += d.prevyear_refund;
            this.summaryData.lastyear.net += (d.prevyear_amount - d.prevyear_refund);
            lastyeartotaldaycount += d.prevyear_daycount;
            if (d.prevyear_daycount > lastyeardaycount) lastyeardaycount = d.prevyear_daycount;

            this.summaryData.yesterday.sale += d.y_amount;
            this.summaryData.yesterday.refund += d.y_refund;
            this.summaryData.yesterday.net += (d.y_amount - d.y_refund);

            this.summaryData.lastWeekYesterday.sale += d.lwy_amount;
            this.summaryData.lastWeekYesterday.refund += d.lwy_refund;
            this.summaryData.lastWeekYesterday.net += (d.lwy_amount - d.lwy_refund);
        });

        this.summaryData.thisyear.storecount = thisyeartotaldaycount * 1.0 / thisyeardaycount;
        this.summaryData.lastyear.storecount = lastyeartotaldaycount * 1.0 / lastyeardaycount;

        this.summaryData.daily.saleavg = this.summaryData.daily.sale / this.summaryData.daily.receiptCount;

        this.summaryData.daily.pct = 100 * this.summaryData.daily.net / this.summaryData.lastWeekToday.net;
        this.summaryData.weekly.pct = 100 * this.summaryData.weekly.net / this.summaryData.prevWeek.net;
        this.summaryData.monthly.pct = 100 * this.summaryData.monthly.net / this.summaryData.prevMonth.net;
        this.summaryData.annual.pct = 100 * this.summaryData.thisyear.net / this.summaryData.lastyear.net;
        this.summaryData.yesterday.pct = 100 * this.summaryData.yesterday.net / this.summaryData.lastWeekYesterday.net;

        this.summaryData.daily.color = this.findColor(this.summaryData.daily.pct);
        if (this.summaryData.daily.color === 'primary') {
            this.summaryData.daily.inverted = '';
        }

        this.summaryData.weekly.color = this.findColor(this.summaryData.weekly.pct);
        if (this.summaryData.weekly.color === 'primary') {
            this.summaryData.weekly.inverted = '';
        }

        this.summaryData.monthly.color = this.findColor(this.summaryData.monthly.pct);
        if (this.summaryData.monthly.color === 'primary') {
            this.summaryData.monthly.inverted = '';
        }

        this.summaryData.yesterday.color = this.findColor(this.summaryData.yesterday.pct);
        if (this.summaryData.yesterday.color === 'primary') {
            this.summaryData.yesterday.inverted = '';
        }

        this.summaryData.annual.color = this.findColor(this.summaryData.annual.pct);
        if (this.summaryData.annual.color === 'primary') {
            this.summaryData.annual.inverted = '';
        }
    }

    fillRegionData() {
        this.regionTotals = [];
        this.regionGrandTotal = 0;
        this.dashboardData.forEach(d => {
            const region = this.regionTotals.find(r => r.region === d.parentbranch);
            if (region) {
                region.revenue += (d.t_amount - d.t_refund);
            } else {
                this.regionTotals.push({ region: d.parentbranch, revenue: (d.t_amount - d.t_refund) });
            }
            this.regionGrandTotal += (d.t_amount - d.t_refund);
        });
    }

    refreshData() {
        this.saleService.getDashboardData().subscribe(data => {
            this.dashboardData = data.Data;
            this.fillSummaryData();
            this.fillRegionData();
            },
            error => {
                console.log(error);
        });

        this.saleService.getDashboardCategoryData().subscribe(data => {
            this.categoryData = data.Data;
            const familyRevenue = [];
            let familyGrandTotal = 0;
            this.categoryData.forEach(c => {
                const family = familyRevenue.find(f => f.family === c.PRODUCTFAMILY_NM);
                    if (family) {
                        family.revenue += c.NET;
                    } else {
                        familyRevenue.push({ family: c.PRODUCTFAMILY_NM, revenue: c.NET, color: c.COLOR_CD });
                    }
                    familyGrandTotal += c.NET;
                });
                if (familyRevenue.length > 0) {
                    familyRevenue.sort((a, b) => b.revenue - a.revenue);
                    this.familyGrandTotal = familyGrandTotal;
                    this.familyRevenue = familyRevenue;
                }
            },
        error => {
                console.log(error);
        });

        this.productPriceService.priceLoadStatus().subscribe(list => {
            this.productPriceService.loadStatusList = list.Data;
            this.priceLoadTotals = [];
            this.productPriceService.loadStatusList.forEach (r => {
                const row = this.priceLoadTotals.filter(f => f.Device === r.DEVICE);
                if (row[0]) {
                    row[0].Data[0] += r.LOADOK_CNT;
                    row[0].Data[1] += r.LOADNOTOK_CNT;
                } else {
                    this.priceLoadTotals.push({Device: r.DEVICE, Data: [r.LOADOK_CNT, r.LOADNOTOK_CNT]});
                }
            });
        });

        this.priceLabelPrintService.listPrintedLabels().subscribe(list => {
            let printedCount = 0;
            let allChangedProductCount = 0;
            list.Data.forEach(s => {
                printedCount += s.PRINTEDLABEL_CN;
                allChangedProductCount += s.CHANGEDPRODUCT_CN;
            });
            this.printedLabelsPercentage[0] = printedCount / allChangedProductCount * 100;
            // this.printedLabelBulletColor = this.printedLabelsPercentage[0] < 70 ? 'red' : 'green';

            this.priceLabelPrintService.printedLabelsRawData = list.Data;
            const pricaLabelListParams = new ListParams();
            pricaLabelListParams.pageable = false;
            pricaLabelListParams.take = 1000;
            this.priceLabelPrintService.printedLabelsActiveList = process(list.Data, pricaLabelListParams);
        });

        this.reloadRMSales();

        this.reloadStoreSales();
    }

    onPriceSeriesClick(event) {
        this.router.navigate(['/OverStoreMain/PriceDetails', event.category, event.stackValue]);
    }

    onStoreCountClick() {
        if (this.dashboardAuthorization != 'ST') {
            this.router.navigate(['/OverStoreMain/DashboardDetails', 1]);
        }
    }

    onProductReturnClick() {
        if (this.dashboardAuthorization != 'ST') {
            this.router.navigate(['/OverStoreMain/CancelDetails', this.lastDay, this.today]);
        }
    }

    onLabelPrintClick(event) {
        if (this.priceLabelPrintService.printedLabelsActiveList.total > 1) {
            this.router.navigate(['/OverStoreMain/PrintedLabels']);
        }
    }


    ngOnInit() {
        this.contextState$.pipe(first()).subscribe( context => {
            this.storeService.contextInfo = context;
            this.openHomePage();     
        });

        this.privilegeCacheService.checkPrivilege('Open Home Page').subscribe( result => {
            if(result) {
                this.storeService.listUserStores().subscribe(list => {
                    if (list[0].UserBranchType === 'Branch') {
                        this.dashboardAuthorization = 'ST';
                        this.isStore = true;
                    } else if (list[0].UserBranchType === 'Region') {
                        this.isRegion = true;
                    } else if (list[0].UserBranchType === 'Central Office') {
                        this.dashboardAuthorization = 'HQ';
                        this.isCentralOffice = true;
                    }
                });
        
                this.intervalHolder = setInterval(() => {
                    this.refreshData();
                    this.changeDetectorRef.markForCheck();
                }, 1000 * 60); // 1 minute
                this.epicFunction();
                this.refreshData();    
            }
        });
       
    }

    ngOnDestroy(): void {
        clearInterval(this.intervalHolder);
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }

    onSeriesClick(event) {
        // console.log(event);
        this.router.navigate(['/OverStoreMain/CategoryDetails', event.category]);
    }

    reloadStoreSales() {
        if (this.storeSalesLoading === true) { return; }
        this.storeSalesLoading = true;
        this.storeSalesLP.take = 1000;
        this.storeSalesLP.pageable = false;
        this.saleService.getStoreSales(this.storeSalesLP).subscribe(
            listStoreSales => {
                this.storeSalesLoading = false;
                this.storeSalesList = listStoreSales.Data;
            },
            error => {
                this.storeSalesLoading = false;
                this.messageService.error(`Unexpected error: ${error}`);
       });
    }

    reloadRMSales() {
        if (this.rmSalesLoading === true) { return; }
        this.rmSalesLoading = true;
        this.rmSalesLP.take = 1000;
        this.rmSalesLP.pageable = false;
        this.saleService.getRegionManagerSales(this.rmSalesLP).subscribe(
            listRegionSales => {
                this.rmSalesLoading = false;
                this.rmSalesList = listRegionSales.Data;
            },
            error => {
                this.rmSalesLoading = false;
                this.messageService.error(`Unexpected error: ${error}`);
       });
    }

    storeSalesHandleStateChange(state: DataStateChangeEvent) {
        if (state.sort) {
            this.storeSalesLP.sort = state.sort;
        }
        if (state.filter) {
            this.storeSalesLP.filter = state.filter;
        }
        this.reloadStoreSales();
    }

    rmSalesHandleStateChange(state: DataStateChangeEvent) {
        if (state.sort) {
            this.rmSalesLP.sort = state.sort;
        }
        this.reloadRMSales();
    }

    onStoreSelected(event) {
        this.router.navigate(['/OverStoreMain/StoreDashboard', event[0]]);
    }

    onSelectedChange(event, period) {
        if (event) {
            this.saleViewCode = period;
        }
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    getFileName(gridName: string) {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `${gridName}_${d2}.xlsx`;
    }

    openHomePage() {
        this.privilegeCacheService.checkPrivilege('Open Home Page').subscribe( dashboardResult => {
            if (!dashboardResult) {
                this.privilegeCacheService.checkPrivilege('Open Warehouse Home Page').subscribe( warehouseResult => {
                    if (warehouseResult) {
                        this.router.navigateByUrl('/Warehouse/WarehouseDashboard/Index');
                    } else {
                        this.privilegeCacheService.checkPrivilege('Open Gathering Home Page').subscribe( gatheringResult => {
                            if (gatheringResult) {
                                this.router.navigateByUrl('/Warehouse/Gathering/Index');
                            } else {
                                this.privilegeCacheService.checkPrivilege('Open Control Home Page').subscribe( controlResult => {
                                    if (controlResult) {
                                        this.router.navigateByUrl('/Warehouse/GatheringControl/Index');
                                    } else {
                                        switch (this.storeService.contextInfo.User.Name) {
                                            case 'oyuncu':
                                                this.router.navigateByUrl('/Gamification/GamePlay/Index');
                                                break;
                                            case 'makbul.bizim':
                                                this.router.navigateByUrl('/Announcement/SuggestionAnonymous/Index');
                                                break;
                                            default:
                                                this.router.navigateByUrl('/OverStoreMain/Inbox/Index'); 
                                                break;
                                        }
                                    }
                                });
                            }
                        });
                    }
                });
            }
        });
    }
}