import { Component, OnInit } from '@angular/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { GatheringService } from '@warehouse/service/gathering.service';
import { finalize } from 'rxjs/operators';
import {
  WDashboardGathering,
  WDGatheringTrend,
  WDGatheringTrendByUser
} from '@warehouse/model/wdashboard-gathering.model';
import { DataStateChangeEvent, GridComponent, GridDataResult } from '@progress/kendo-angular-grid';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';
import { StoreOrder } from '@warehouse/model/store-order.model';

@Component({
  selector: 'ot-wdashboard-heavy',
  templateUrl: './wdashboard-heavy.component.html',
  styleUrls: ['./wdashboard-heavy.component.scss']
})
export class WdashboardHeavyComponent extends MainScreenBase implements OnInit {
  wdHeavyData: WDashboardGathering;
  gatheringList: any;
  listParams: ListParams = new ListParams();

  gatheringTrendDays = 30;
  gatheringUserId: number;
  gatheringTrendLoading = false;
  chartColors;

  activeWdTrendDataTypeIndex = 0;
  gatheringUserList: { GatherUserId: number, GatherUserName: string}[];

  constructor(
      messageService: GrowlMessageService,
      translateService: TranslateService,
      public router: Router,
      public datePipe: DatePipe,
      public utility: OTUtilityService,
      public gatheringService: GatheringService,
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
    this.gatheringList = process(this.wdHeavyData.GatheringTrend, this.listParams);
  }

  refreshData() {
    this.listParams.take = 1000;
    this.listParams.pageable = false;
    this.gatheringTrendLoading = true;
    this.gatheringService.getWdGatheringData(1)
        .pipe(finalize(() => this.gatheringTrendLoading = false))
        .subscribe(result => {
          this.wdHeavyData = result;
          this.groupTrendDataByUser();
          this.refreshList();
    });
  }

  refreshGatheringTrendData() {
    this.gatheringTrendLoading = true;
    this.gatheringService.listGatheringTrend(1, this.activeWdTrendDataTypeIndex + 1, this.gatheringTrendDays, this.gatheringUserId ? this.gatheringUserId : -1)
        .pipe(finalize(() => this.gatheringTrendLoading = false))
        .subscribe(result => {
          this.wdHeavyData.GatheringTrend = result;
          this.groupTrendDataByUser();
          this.refreshList();
        });
  }

  groupTrendDataByUser() {
    this.generateUserListAndErrorRate();
    this.wdHeavyData.GatheringTrendByUserList = [];
    this.gatheringUserList.forEach(u => {
      const trendListByUser = new WDGatheringTrendByUser();
      trendListByUser.GatherUserId = u.GatherUserId;
      trendListByUser.GatherUserName = u.GatherUserName;
      trendListByUser.GatheringTrendList = this.wdHeavyData.GatheringTrend.filter(gt => gt.GatherUserId === u.GatherUserId);
      this.wdHeavyData.GatheringTrendByUserList.push(trendListByUser);
    });
  }

  generateUserListAndErrorRate() {
    this.gatheringUserList = [];
    const userIdList = [];

    this.wdHeavyData.GatheringTrend.forEach(gt => {
      gt.ErrorRate = gt.GatherPackage !== 0 ? gt.ControlDiffPackage / gt.GatherPackage : 0;
      if (!userIdList.includes(gt.GatherUserId)) {
        userIdList.push(gt.GatherUserId);
        this.gatheringUserList.push({ GatherUserId: gt.GatherUserId, GatherUserName: gt.GatherUserName });
      }
    });
  }

  onBackBtnClicked() {
    this.router.navigate(['/Warehouse/WarehouseDashboard/Index']);
  }

  handleDataStateChange(state: DataStateChangeEvent) {
    this.listParams.dateFields = ['GatherDate'];
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

    this.wdHeavyData.GatheringTrend.map(gt => gt.GatherDate = new Date(gt.GatherDate));
    this.refreshList();
  }

  public getxlsFileName(): string {
    const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
    return `${ 'AgirUrunlerToplamaVerileri' }_${ todayString }.xlsx`;
  }

  exportToExcel(grid: GridComponent): void {
    grid.saveAsExcel();
  }

  allData(): any {
    const newList = JSON.parse(JSON.stringify(this.wdHeavyData.GatheringTrend));
    /* newList.forEach(row => {
            row.StoreName = this.storeService.completeList.filter(r => r.StoreId === row.Store)[0].Name;
            row.OrderStatusName = this.orderStatusService.completeList.filter(r => r.StoreOrderStatusId === row.Status)[0].StatusName;
        });*/
    return <GridDataResult>{
      data: process(newList, {sort: [{field: 'GatherDate', dir: 'asc'}]}).data,
      total: newList.length
    };
  }

}
