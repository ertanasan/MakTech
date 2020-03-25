import {Component, OnInit, ViewChild, AfterViewInit, ElementRef, ChangeDetectorRef, OnDestroy} from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { Gathering } from '@warehouse/model/gathering.model';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent, GridDataResult, GridComponent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { HttpErrorResponse } from '@angular/common/http';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { WarehouseDashboard, GatheringDBList, ControlDBList } from '@warehouse/model/whdashboard.model';
import * as _ from 'lodash';
import { StoreService } from '@store/service/store.service';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { Router } from '@angular/router';

class widgetdata {
  title: string;
  desc: string;
  value: string;
}


@Component({
  selector: 'ot-warehouse-dashboard',
  templateUrl: './warehouse-dashboard.component.html',
  styleUrls: ['./warehouse-dashboard.component.css']
})
export class WarehouseDashboardComponent extends MainScreenBase implements OnInit, AfterViewInit, OnDestroy {


  data: WarehouseDashboard;
  heavyGatheringList: widgetdata[] = [];
  lightGatheringList: widgetdata[] = [];
  heavyControlList: widgetdata[] = [];
  lightControlList: widgetdata[] = [];
  orderActiveList: any;
  listParams: ListParams = new ListParams();

  refreshTime: Date;
  intervalHolder: any;

  dashboard = {OrderCount: 0, OldOrderCount: 0, ShippedOrderCount: 0, HeavyOrderWeight: 0, HeavyGatheredWeight: 0, 
    LightOrderWeight: 0, LightGatheredWeight: 0, controlPalletCount: 0, controlledPalletCount: 0, 
    WaitingHeavyControlPalletCount: 0, WaitingLightControlPalletCount: 0}
  hourData: any;
  hourLightData: any;
  hourHeavyData: any;
  yesterday: string;
  today: string;
  heavyDataYesterday: any;
  heavyDataToday: any;
  hourArray: number[] = [];
  lightDataYesterday: any;
  lightDataToday: any;
  hourHeavySelected = true;
  hourLightSelected = false;


  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    private changeDetectorRef: ChangeDetectorRef,
    public gatheringService: GatheringService,
    public utilityService: OverstoreCommonMethods,
    public datePipe: DatePipe,
    public storeService: StoreService,
    public orderStatusService: StoreOrderStatusService,
    public router: Router,
  ) {
      super(messageService, translateService);
      this.allData = this.allData.bind(this);

  }

  public allData(): any {
    let newList = JSON.parse(JSON.stringify(this.data.OrderList));
    newList.forEach(row => {
        row.StoreName = this.storeService.completeList.filter(r => r.StoreId === row.Store)[0].Name;
        row.OrderStatusName = this.orderStatusService.completeList.filter(r => r.StoreOrderStatusId === row.Status)[0].StatusName;
    })
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
    this.orderActiveList = process(this.data.OrderList, this.listParams);
  }

  refreshData() {
    this.listParams.take = 1000;
    this.listParams.pageable = false;
    this.refreshTime = new Date();
    this.gatheringService.warehouseDashboard().subscribe(result => {
      this.data = result;

      this.orderActiveList = process(this.data.OrderList, this.listParams);
      
      this.dashboard.OrderCount = this.data.OrderList.length;
      this.dashboard.OldOrderCount = this.data.OrderList.filter(row => row.OldOrderFlag).length;
      this.dashboard.ShippedOrderCount = this.data.OrderList.filter(row => row.Status > 3).length;
      this.dashboard.HeavyOrderWeight = _.sumBy(this.data.OrderList, 'HeavyOrderWeight'); 
      this.dashboard.HeavyGatheredWeight = _.sumBy(this.data.OrderList, 'HeavyGatheredWeight'); 
      this.dashboard.LightOrderWeight = _.sumBy(this.data.OrderList, 'LightOrderWeight'); 
      this.dashboard.LightGatheredWeight = _.sumBy(this.data.OrderList, 'LightGatheredWeight'); 

      this.dashboard.WaitingHeavyControlPalletCount = _.sumBy(this.data.OrderList, 'WaitingHeavyControlPalletCount'); 
      this.dashboard.WaitingLightControlPalletCount = _.sumBy(this.data.OrderList, 'WaitingLightControlPalletCount'); 

      this.dashboard.controlledPalletCount = _.sumBy(this.data.ControlList, 'ControlledPalletCount'); 
      this.dashboard.controlPalletCount = this.dashboard.controlledPalletCount + this.dashboard.WaitingHeavyControlPalletCount + this.dashboard.WaitingLightControlPalletCount;

      this.heavyGatheringList = []; 
      let index = 1;
      this.data.GatheringList.filter(r => r.GatheringType === 1).forEach(row => {
        this.heavyGatheringList.push({"title": `${index}. ${row.GatheringUserName}`, "desc": "Tonaj / Paket / Palet", "value": `${row.GatheredWeight.toFixed(0).toLocaleString()} / ${row.GatheredPackage} / ${row.GatheredPalletCount}`});
        index++;
      });

      this.lightGatheringList = []; 
      index = 1;
      this.data.GatheringList.filter(r => r.GatheringType === 2).forEach(row => {
        this.lightGatheringList.push({"title": `${index}. ${row.GatheringUserName}`, "desc": "Tonaj / Paket / Palet", "value": `${row.GatheredWeight.toFixed(0).toLocaleString()} / ${row.GatheredPackage} / ${row.GatheredPalletCount}`});
        index++;
      });

      this.heavyControlList = []; 
      index = 1;
      this.data.ControlList.filter(r => r.GatheringType === 1).forEach(row => {
        this.heavyControlList.push({"title": `${index}. ${row.ControlUserName}`, "desc": "Kontrol Edilen", "value": `${row.ControlledPalletCount}`});
        index++;
      });

      this.lightControlList = []; 
      index = 1;
      this.data.ControlList.filter(r => r.GatheringType === 2).forEach(row => {
        this.lightControlList.push({"title": `${index}. ${row.ControlUserName}`, "desc": "Kontrol Edilen", "value": `${row.ControlledPalletCount}`});
        index++;
      });
    });
    this.gatheringService.dashboardHourGathering().subscribe(result => {
      this.hourData = result.Data;
      this.hourArray = [];
      this.hourData.forEach ((row, index) => {
        const d = row.GATHER_DT;
        if (index === 0) {
          this.yesterday = d;
        }
        if (d !== this.yesterday) {
          this.today = d;
        }
        const rowhour = row.GATHERHOUR;
        const found = this.hourArray.find(r => r === rowhour);
        if (!found) this.hourArray.push(rowhour);
      });
      // console.log(this.hourArray);
      this.hourHeavyData = this.hourData.filter(row => row.GATHERINGTYPE === 1);
      this.heavyDataYesterday = this.hourHeavyData.filter(row => row.GATHER_DT === this.yesterday).map(x => x.GATHERINGWEIGHT);
      this.heavyDataToday = this.hourHeavyData.filter(row => row.GATHER_DT === this.today).map(x => x.GATHERINGWEIGHT);

      this.hourLightData = this.hourData.filter(row => row.GATHERINGTYPE === 2);
      this.lightDataYesterday = this.hourLightData.filter(row => row.GATHER_DT === this.yesterday).map(x => x.GATHERINGWEIGHT);
      this.lightDataToday = this.hourLightData.filter(row => row.GATHER_DT === this.today).map(x => x.GATHERINGWEIGHT);
    })
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

    if (!this.orderStatusService.completeList) {
      this.orderStatusService.listAll();
    }
    this.refreshData();
    this.intervalHolder = setInterval(() => {
      this.refreshData();
      this.changeDetectorRef.markForCheck();
    }, 1000 * 60); // 1 minute

    super.ngOnInit();
  }


  ngAfterViewInit() {
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalHolder);
  }


  handleDataStateChange(state: DataStateChangeEvent) {
    this.listParams.dateFields = ['OrderDate', 'ShipmentDate'];
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

    this.data.OrderList.map(o => {
      o.OrderDate = new Date(o.OrderDate);
      o.ShipmentDate = new Date(o.ShipmentDate);
    });
    this.refreshList();
  }

  hourSelectionChange(selection) {
    this.hourHeavySelected = (selection === 1);
    this.hourLightSelected = (selection === 2);
  }

  onWidgetClicked(widgetName: string) {
    switch (widgetName) {
      case 'Order':
        this.router.navigate(['/Warehouse/WdashboardOrder']);
        break;
      case 'Light':
        this.router.navigate(['/Warehouse/WdashboardLight']);
        break;
      case 'Heavy':
        this.router.navigate(['/Warehouse/WdashboardHeavy']);
        break;
      default:
        break;
    }
  }

}
