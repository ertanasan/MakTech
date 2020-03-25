import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ProductService } from '@product/service/product.service';
import { StoreService } from '@store/service/store.service';
import { Router } from '@angular/router';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { SalesService } from '@sale/service/sales.service';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';
import { Store } from '@store/model/store.model';

@Component({
  selector: 'ot-sale-summary-dashboard',
  templateUrl: './sale-summary-dashboard.component.html',
  styleUrls: ['./sale-summary-dashboard.component.css']
})
export class SaleSummaryDashboardComponent extends MainScreenBase implements OnInit {

  chartColors = [];
  mainColumnGroupHeader = '';
  comparingColumnGroupHeader = '';
  storeFilterDefaultItem: Store = new Store();

  selectedStore: number;
  startDate = new Date();
  endDate = new Date();
  comparingStartDate = new Date();
  comparingEndDate = new Date();

  // compareFlag = true;

  salesComparisonData: any;
  salesComparisonActiveList: any;
  salesComparisonLoading = false;
  salesComparisonFilterParams: any;
  // salesComparisonCategories: any;

  salesAggregateData: any;
  salesAggregateActiveList: any;
  salesAggregateLoading = false;
  salesAggregateFilterParams: any;

  // salesAggregateCategories: any;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public datePipe: DatePipe,
    public dataService: SalesService,
    public productService: ProductService,
    public storeService: StoreService,
    public router: Router,
    public utility: OTUtilityService
    ) {
      super(messageService, translateService);
      this.chartColors = this.utility.colors.map(c => c.hex);
     }

  ngOnInit() {
    // initialize parameters
    this.endDate.setDate(this.endDate.getDate() - 1);
    this.startDate.setMonth(this.endDate.getMonth() - 1);
    this.comparingEndDate.setMonth(this.startDate.getMonth());
    this.comparingEndDate.setDate(this.startDate.getDate() - 1);
    this.comparingStartDate.setMonth(this.comparingEndDate.getMonth() - 1);
    this.storeFilterDefaultItem.Name = 'TÜM MAĞAZALAR';
    this.storeFilterDefaultItem.StoreId = -1;

    this.salesComparisonFilterParams = this.initializeFilterParam();
    this.salesAggregateFilterParams = this.initializeFilterParam();

    if (!this.productService.completeList) {
      this.productService.listAll();
    }
    if (!this.storeService.completeList) {
      this.storeService.listUserStores();

    }
  }

  getBreadcrumbItems() { return null; }

  refreshData() {
  }

  createEmptyItem() { throw new Error('Method not implemented'); }

  handleStateChange(state: DataStateChangeEvent, gridName: string) {

    if (state.sort) {
      switch (gridName) {
            case 'saleComparison' :
              this.salesComparisonFilterParams.sort = state.sort;
              this.salesComparisonActiveList = process(this.salesComparisonData, this.salesComparisonFilterParams);
              break;
            // case 'saleAggregate' :
            //   this.salesAggregateFilterParams.sort = state.sort;
            //   this.salesAggregateActiveList = process(this.salesAggregateData, this.salesAggregateFilterParams);
            //   break;
        }
    }

    // if (state.filter) {
    //     switch (gridName) {
    //         case 'saleComparison' :
    //           this.salesComparisonFilterParams.filter = state.filter;
    //           this.salesComparisonActiveList = process(this.salesComparisonData, this.salesComparisonFilterParams);
    //           break;
    //         case 'saleAggregate' :
    //           this.salesAggregateFilterParams.filter = state.filter;
    //           this.salesAggregateActiveList = process(this.salesAggregateData, this.salesAggregateFilterParams);
    //           break;
    //     }
    // }
  }

  initializeFilterParam(): ListParams {
    const filterParams = new ListParams();
    filterParams.pageable = false;
    filterParams.take = 1000;
    return filterParams;
  }

  onGetSaleComparisonDashboardData() {
    this.clearData();
    // if ( this.compareFlag ) {
      this.salesComparisonFilterParams = this.initializeFilterParam();
      this.salesComparisonLoading = true;
      this.dataService.listSalesComparison(this.selectedStore,
                                            this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
                                            this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd'),
                                            this.datePipe.transform(new Date(this.comparingStartDate), 'yyyy-MM-dd'),
                                            this.datePipe.transform(new Date(this.comparingEndDate), 'yyyy-MM-dd')
                                            ).subscribe(data => {
                                                            this.salesComparisonData = data.Data;
                                                            // this.salesComparisonData.forEach(row => {
                                                            //   row.AVGSALE = row.SALE / row.SALE_QTY;
                                                            //   row.compAVGSALE = row.compSALE / row.compSALE_QTY;
                                                            // });
                                                            this.salesComparisonLoading = false;
                                                            this.mainColumnGroupHeader = this.datePipe.transform(new Date(this.startDate), 'dd.MM.yyyy') + ' - ' + this.datePipe.transform(new Date(this.endDate), 'dd.MM.yyyy');
                                                            this.comparingColumnGroupHeader = this.datePipe.transform(new Date(this.comparingStartDate), 'dd.MM.yyyy') + ' - ' + this.datePipe.transform(new Date(this.comparingEndDate), 'dd.MM.yyyy');
                                                            this.salesComparisonActiveList = process(this.salesComparisonData, this.salesComparisonFilterParams);
                                                        },
                                                        error => {
                                                          this.salesComparisonLoading = false;
                                                          this.messageService.error(`Can not get SaleComparsion data from WebService: ${error}`);
                                                        });
    // }
    // this.salesAggregateFilterParams = this.initializeFilterParam();
    // this.salesAggregateLoading = true;
    // this.dataService.getSalesSummaryReport(this.selectedStore,
    //                                         this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
    //                                         this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd'),
    //                                         'Y'
    //                                         ).subscribe(data => {
    //                                                         this.salesAggregateData = data.Data;
    //                                                         this.salesAggregateLoading = false;
    //                                                         this.salesAggregateActiveList = process(this.salesAggregateData, this.salesAggregateFilterParams);
    //                                                     },
    //                                                     error => {
    //                                                       this.salesAggregateLoading = false;
    //                                                       this.messageService.error(`Can not get SaleAggregate data from WebService: ${error}`);
    //                                                     });
  }

  onClear() {
    this.selectedStore = null;
    this.clearData();
  }

  clearData() {
    // this.salesAggregateData = null;
    // this.salesAggregateActiveList = null;

    this.salesComparisonData = null;
    this.salesComparisonActiveList = null;
    this.mainColumnGroupHeader = '';
    this.comparingColumnGroupHeader = '';
  }

  arrangeChartScale(data: any, categoryColumnName: string, percentMargin: number = 0) {
    const maxMin = {'min': 0, 'max': 0};
    maxMin.min = Math.round(Math.min.apply(null, Object.values(data.map(function(a) {return a[categoryColumnName]; }))) * (1 - percentMargin) * 10) / 10;
    maxMin.max = Math.round(Math.max.apply(null, Object.values(data.map(function(a) {return a[categoryColumnName]; }))) * (1 + percentMargin) * 10) / 10;
    if (maxMin.min < 0) { maxMin.min = 0; }
    return maxMin;
  }

  getFileName(gridName: string) {
    const d: Date = new Date();
    const d2 = this.datePipe.transform(d, 'yyyyMMdd');
    return this.selectedStore ? `${gridName}_${this.selectedStore}_${d2}.xlsx` : `${gridName}_AllStores_${d2}.xlsx`;
  }

}
