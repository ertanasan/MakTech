import {Component, OnInit, ViewChild, AfterViewInit, ElementRef, ChangeDetectorRef, OnDestroy, ViewContainerRef, Injector} from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { Gathering } from '@warehouse/model/gathering.model';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent, GridDataResult, GridComponent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { HttpErrorResponse } from '@angular/common/http';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import * as _ from 'lodash';
import { StoreService } from '@store/service/store.service';
import { Router } from '@angular/router';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { Subscription } from 'rxjs';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { parseNumber } from '@progress/kendo-angular-intl';
import { ContextMenuSelectEvent } from '@progress/kendo-angular-menu';

class widgetdata {
  title: string;
  desc: string;
  value: string;
}

export const items: any[] = [{text: 'Excel'}];


@Component({
  selector: 'ot-stock-dashboard',
  templateUrl: './stock-dashboard.component.html',
  styleUrls: ['./stock-dashboard.component.css']
})
export class StockDashboardComponent extends MainScreenBase implements OnInit, AfterViewInit, OnDestroy {

  @ViewChild(GridComponent, {static: false}) categoryGrid: GridComponent;
  @ViewChild(GridComponent, {static: false}) productGrid: GridComponent;
  @ViewChild(GridComponent, {static: false}) storeGrid: GridComponent;

  public items: any[] = items;
  storeListParams = new ListParams();
  productListParams = new ListParams();
  data: any;
  openTasks: any;
  openTasksFilteredList: any;

  categoryList: any;
  productList: any;
  productActiveList: any;
  storeList: any;
  storeActiveList: any;  
  storeLoading = false;
  monthGraphData: any;
  monthGraphDataLoading = false;
  groupCheckedList = [];
  storeCheckedList = [];
  productCheckedList = [];

  listParams: ListParams = new ListParams();

  refreshTime: Date;
  intervalHolder: any;

  dashboard = {StoreStockAmount: 0, WarehouseStockAmount: 0, StoreStockSaleRate: 0, WarehouseStockSaleRate: 0};
  activeDataItem: any;
  trendData: any;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    private changeDetectorRef: ChangeDetectorRef,
    public utilityService: OverstoreCommonMethods,
    public datePipe: DatePipe,
    public storeService: StoreService,
    public router: Router,
    public dashboardService: StoreOrderService,
  ) {
      super(messageService, translateService);
      this.allData = this.allData.bind(this);

  }

  public allData(): any {
    const newList = JSON.parse(JSON.stringify(this.data.OrderList));
    newList.forEach(row => {
        row.StoreName = this.storeService.completeList.filter(r => r.StoreId === row.Store)[0].Name;
    });
    return <GridDataResult> {
        data: process(newList, { sort: [{ field: 'ShipmentDate', dir: 'asc' }] }).data,
        total: newList.length
    };
  }

  public getxlsFileName(): string {
    const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
    return `${'SiparişListesi'}_${todayString}.xlsx`;
  }

  public exportToExcel(grid: GridComponent): void {
    grid.saveAsExcel();
  }

  refreshList() {
    this.storeActiveList = process(this.storeList, this.storeListParams);
    this.productActiveList = process(this.productList, this.productListParams);
  }

  handleDataStateChange(state: DataStateChangeEvent, lp: ListParams) {
    // lp.skip = state.skip;
    // lp.take = state.take;
    if (state.sort) {
        lp.sort = state.sort;
    }
    if (state.filter) {
        lp.filter = state.filter;
    }
    // if (state.group) {
    //     lp.group = state.group;
    // }
    this.refreshList();
  }

  clearDashboardValues() {
    this.dashboard = {StoreStockAmount: 0, WarehouseStockAmount: 0, StoreStockSaleRate: 0, WarehouseStockSaleRate: 0};
  }

  createGroupLists() {
      const today: Date = new Date(this.data[0].Data[0].TODAY);
      const month = today.getMonth();
      const day = today.getDate();
      const filteredList = this.data[1].Data.filter(row => (new Date(row.DATE_DT)).getDate() === day && (new Date(row.DATE_DT)).getMonth() === month);
      this.categoryList =
        _(filteredList)
        .groupBy('CATEGORY_NM')
        .map((objs, key) => {
              return {
              'Name': key,
              'StoreStock': _.sumBy(objs, 'STORESTOCK_AMT'),
              'StoreAvg': _.sumBy(objs, 'STORESALEAVG_AMT'),
              'WarehouseStock': _.sumBy(objs, 'WAREHOUSESTOCK_AMT'),
              'WarehouseAvg': _.sumBy(objs, 'WAREHOUSESALEAVG_AMT')
              };
      }).value();
      this.categoryList = _.sortBy(this.categoryList, 'StoreStock').reverse();
      this.categoryList.forEach(row => row.StoreAvgRate = row.StoreStock / row.StoreAvg);
      this.categoryList.forEach(row => row.WarehouseAvgRate = row.WarehouseStock / row.WarehouseAvg);

      const categoryFilteredList = this.data[1].Data.filter(row => row.CATEGORY_NM === this.groupCheckedList[0]);
      this.monthGraphData = 
        _(categoryFilteredList)
        .groupBy('DATE_DT')
        .map((objs, key) => {
              return {
              'Days': key,
              'StoreStock': _.sumBy(objs, 'STORESTOCK_AMT'),
              'WarehouseStock': _.sumBy(objs, 'WAREHOUSESTOCK_AMT')
              };
      }).value();

      this.productList = this.data[2].Data.filter(row => row.CATEGORY_NM === this.groupCheckedList[0]);  
      this.productList = _.sortBy(this.productList, 'STORESTOCK_AMT').reverse();
      this.productList.forEach(row => row.STOREAVGRATE = row.STORESTOCK_AMT / row.STORESALEAVG_AMT);
      this.productList.forEach(row => row.WAREHOUSEAVGRATE = row.WAREHOUSESTOCK_AMT / row.WAREHOUSESALEAVG_AMT);
      this.storeList = this.data[3].Data.filter(row => row.CATEGORY_NM === this.groupCheckedList[0]);  
      this.storeList = _.sortBy(this.storeList, 'STORESTOCK_AMT').reverse();
      this.storeList.forEach(row => row.STOREAVGRATE = row.STORESTOCK_AMT / row.STORESALEAVG_AMT);

      this.productCheckedList = [];
      this.storeCheckedList = [];
      this.refreshList();
  }

  refreshData() {
    this.listParams.take = 1000;
    this.listParams.pageable = false;
    this.refreshTime = new Date();
    this.dashboardService.stockDashboard().subscribe(result => {
      this.data = result;
      this.clearDashboardValues();
      this.data[0].Data.forEach(row => {
        this.dashboard.StoreStockAmount = row.STORESTOCK_AMT;
        this.dashboard.WarehouseStockAmount = row.WAREHOUSESTOCK_AMT;
        this.dashboard.StoreStockSaleRate = row.STORESTOCK_AMT / row.STORESALEAVG_AMT;
        this.dashboard.WarehouseStockSaleRate = row.WAREHOUSESTOCK_AMT / row.WAREHOUSESALEAVG_AMT;
      });
      if (this.groupCheckedList.length === 0) this.groupCheckedList.push('HEPSİ');
      this.createGroupLists();
    });
  }

  onSelectedKeysChange() {
    this.createGroupLists();
  }

  createEmptyItem() {

  }

  getBreadcrumbItems(): MenuItem[] {
    return [{Caption: 'Warehouse' }, {Caption: 'Warehouse Dashboard', RouterLink: '/warehouse/warehouse-dashboard'}];
  }

  createEmptyModel(): Gathering {
    return new Gathering();
  }

  ngOnInit() {

    if (!this.storeService.completeList) {
      this.storeService.listAll();
    }

    this.refreshData();
    this.intervalHolder = setInterval(() => {
      this.refreshData();
      this.changeDetectorRef.markForCheck();
    }, 5000 * 60); // 1 minute

    this.storeListParams.pageable = false;
    this.storeListParams.take = 1000;
    this.productListParams.pageable = false;
    this.productListParams.take = 1000;
    super.ngOnInit();

  }


  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalHolder);
  }

  onProductListChanged() {
    // seçili kalmadıysa mağaza kısmında tüm ürünlere ait veriler toplu gelsin.
    if (this.productCheckedList.length === 0) {
      this.createGroupLists();
    } else { // seçili varsa o ürüne ait mağaza bilgilerini getir. 
      let categoryName: string;
      let productName: string;
      let storeName: string;
      if (this.groupCheckedList.length > 0) categoryName = this.groupCheckedList[0]; else categoryName = 'HEPSİ';
      if (this.productCheckedList.length > 0) productName = this.productCheckedList[0]; else productName = 'HEPSİ';
      if (this.storeCheckedList.length > 0) storeName = this.storeCheckedList[0]; else storeName = 'HEPSİ';
      this.storeLoading = true;
      this.monthGraphDataLoading = true;
      this.dashboardService.StockDashboardTrend(categoryName, productName, storeName).subscribe(result => {
        this.storeLoading = false;
        this.monthGraphDataLoading = false;
        this.trendData = result;
        this.storeList = this.trendData[0].Data;
        this.storeList.forEach(row => row.STOREAVGRATE = row.STORESTOCK_AMT / row.STORESALEAVG_AMT);
        this.monthGraphData = this.trendData[1].Data;
        this.storeCheckedList = [];
        this.refreshList();
      }, error => {
        this.storeLoading = false;
        this.monthGraphDataLoading = false;
        console.log(error);
        this.messageService.error(error.error.text);
      });
    }
  }

  onStoreListChanged() {
    if (this.storeCheckedList.length === 0) {
      this.onProductListChanged();
    } else {
      let categoryName: string;
      let productName: string;
      let storeName: string;
      if (this.groupCheckedList.length > 0) categoryName = this.groupCheckedList[0]; else categoryName = 'HEPSİ';
      if (this.productCheckedList.length > 0) productName = this.productCheckedList[0]; else productName = 'HEPSİ';
      if (this.storeCheckedList.length > 0) storeName = this.storeCheckedList[0]; else storeName = 'HEPSİ';
      this.monthGraphDataLoading = true;
      this.dashboardService.StockDashboardTrend(categoryName, productName, storeName).subscribe(result => {
        this.monthGraphDataLoading = false;
        this.monthGraphData = result[1].Data;
      }, error => {
        this.monthGraphDataLoading = false;
        console.log(error);
        this.messageService.error(error.error.text);
      });
    }
  }

}
