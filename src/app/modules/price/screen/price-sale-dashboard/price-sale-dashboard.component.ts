import { Component, OnInit } from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { ProductService } from '@product/service/product.service';
import { ProductPriceService } from '@price/service/product-price.service';
import { StoreService } from '@store/service/store.service';
import { DatePipe } from '@angular/common';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { Store } from '@store/model/store.model';

@Component({
  selector: 'ot-price-sale-dashboard',
  templateUrl: './price-sale-dashboard.component.html',
  styleUrls: ['./price-sale-dashboard.component.css']
})
export class PriceSaleDashboardComponent extends MainScreenBase implements OnInit {

  chartColors = [];
  weightedPriceScales: {'min': number, 'max': number};
  storeFilterDefaultItem = new Store();

  salesByPriceGroupsData: any;
  salesByPriceGroupsActiveList: any;
  salesByPriceGroupsLoading = false;
  salesByPriceGroupsFilterParams: any;
  // salesByPriceGroupsCategories: any;

  salesTrendData: any;
  salesTrendActiveList: any;
  salesTrendLoading = false;
  salesTrendFilterParams: any;
  // salesTrendCategories: any;

  selectedProduct: number;
  selectedStore: number;
  startDate = new Date();
  endDate = new Date();

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public datePipe: DatePipe,
    public dataService: ProductPriceService,
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
    this.storeFilterDefaultItem.Name = 'TÜM MAĞAZALAR';
    this.storeFilterDefaultItem.StoreId = -1;

    if (!this.productService.completeList) {
      this.productService.listAll();
    }
    if (!this.storeService.completeList) {
      this.storeService.listUserStores();
    }

    this.salesByPriceGroupsFilterParams = new ListParams();
    this.salesTrendFilterParams = new ListParams();
  }

  getBreadcrumbItems() { return null; }

  refreshData() {
    // this.salesByPriceGroupsActiveList = process(this.salesByPriceGroupsData, this.salesByPriceGroupsFilterParams);
    // this.salesTrendActiveList = process(this.salesTrendData, this.salesTrendFilterParams);
  }

  createEmptyItem() { throw new Error('Method not implemented'); }

  handleStateChange(state: DataStateChangeEvent, gridName: string) {

    if (state.sort) {
      switch (gridName) {
            // case 'salesByPriceGroups' :
            //     this.salesByPriceGroupsFilterParams.sort = state.sort;
            //     this.salesByPriceGroupsActiveList = process(this.salesByPriceGroupsData, this.salesByPriceGroupsFilterParams);
            //     break;
            case 'salesTrend' :
                this.salesTrendFilterParams.sort = state.sort;
                this.salesTrendActiveList = process(this.salesTrendData, this.salesTrendFilterParams);
                break;
        }
    }

    if (state.filter) {
        switch (gridName) {
            // case 'salesByPriceGroups' :
            //     this.salesByPriceGroupsFilterParams.filter = state.filter;
            //     this.salesByPriceGroupsActiveList = process(this.salesByPriceGroupsData, this.salesByPriceGroupsFilterParams);
            //     break;
            case 'salesTrend' :
                this.salesTrendFilterParams.filter = state.filter;
                this.salesTrendActiveList = process(this.salesTrendData, this.salesTrendFilterParams);
                break;
        }
    }
  }

  onGetPriceDashboardData() {
    if (this.selectedProduct) {
      if (this.selectedStore > 0) {
        this.salesByPriceGroupsFilterParams = new ListParams();
        this.salesByPriceGroupsFilterParams.pageable = false;
        this.salesByPriceGroupsFilterParams.take = 1000;

        this.salesByPriceGroupsLoading = true;
        this.dataService.listSalesByPriceGroups(this.selectedStore, this.selectedProduct,
                                              this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
                                              this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd')
                                              ).subscribe(data => {
                                                              this.salesByPriceGroupsData = data.Data;
                                                              this.salesByPriceGroupsLoading = false;
                                                              this.salesByPriceGroupsActiveList = process(this.salesByPriceGroupsData, this.salesByPriceGroupsFilterParams);
                                                          },
                                                          error => {
                                                            this.salesByPriceGroupsLoading = false;
                                                            this.messageService.error(`Can not get PriceGroup data from WebService: ${error}`);
                                                          });
      }
      this.salesTrendFilterParams = new ListParams();
      this.salesTrendFilterParams.pageable = false;
      this.salesTrendFilterParams.take = 1000;

      this.salesTrendLoading = true;
      this.dataService.listSalesTrendWithPriceChanges(this.selectedStore, this.selectedProduct,
                                                      this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
                                                      this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd')
                                                      ).subscribe(data => {
                                                                  this.salesTrendData = data.Data;
                                                                  this.salesTrendLoading = false;
                                                                  this.salesTrendActiveList = process(this.salesTrendData, this.salesTrendFilterParams);
                                                                  this.weightedPriceScales = this.arrangeChartScale(this.salesTrendData, 'WEIGHTEDAVGPRICE', 0.10);
                                                                },
                                                                error => {
                                                                  this.salesTrendLoading = false;
                                                                  this.messageService.error(`Can not get SaleTrend data from WebService: ${error}`);
                                                                });
    } else {
      this.messageService.warning(`Product have to be selected to get data`);
    }
  }

  onClear() {
    this.selectedStore = null;
    this.selectedProduct = null;

    this.salesByPriceGroupsData = null;
    this.salesByPriceGroupsActiveList = null;

    this.salesTrendData = null;
    this.salesTrendActiveList = null;
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
