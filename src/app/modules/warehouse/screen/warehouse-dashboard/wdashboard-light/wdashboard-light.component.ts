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

@Component({
  selector: 'ot-wdashboard-light',
  templateUrl: './wdashboard-light.component.html',
  styleUrls: ['./wdashboard-light.component.scss']
})
export class WdashboardLightComponent extends MainScreenBase implements OnInit {
  wdLightData: WDashboardGathering;
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
    this.gatheringList = process(this.wdLightData.GatheringTrend, this.listParams);
  }

  refreshData() {
    this.listParams.take = 1000;
    this.listParams.pageable = false;
    this.gatheringTrendLoading = true;
    this.gatheringService.getWdGatheringData(2)
        .pipe(finalize(() => this.gatheringTrendLoading = false))
        .subscribe(result => {
          this.wdLightData = result;
          this.groupTrendDataByUser();
          this.refreshList();
        });
  }

  refreshGatheringTrendData() {
    this.gatheringTrendLoading = true;
    this.gatheringService.listGatheringTrend(2, this.activeWdTrendDataTypeIndex + 1, this.gatheringTrendDays, this.gatheringUserId ? this.gatheringUserId : -1)
        .pipe(finalize(() => this.gatheringTrendLoading = false))
        .subscribe(result => {
          this.wdLightData.GatheringTrend = result;
          this.groupTrendDataByUser();
          this.refreshList();
        });
  }

  groupTrendDataByUser() {
    this.generateUserListAndErrorRate();
    this.wdLightData.GatheringTrendByUserList = [];
    this.gatheringUserList.forEach(u => {
      const trendListByUser = new WDGatheringTrendByUser();
      trendListByUser.GatherUserId = u.GatherUserId;
      trendListByUser.GatherUserName = u.GatherUserName;
      trendListByUser.GatheringTrendList = this.wdLightData.GatheringTrend.filter(gt => gt.GatherUserId === u.GatherUserId);
      this.wdLightData.GatheringTrendByUserList.push(trendListByUser);
    });
  }

  generateUserListAndErrorRate() {
    this.gatheringUserList = [];
    const userIdList = [];

    this.wdLightData.GatheringTrend.forEach(gt => {
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

    this.wdLightData.GatheringTrend.map(gt => gt.GatherDate = new Date(gt.GatherDate));
    this.refreshList();
  }

  public getxlsFileName(): string {
    const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
    return `${ 'HafifUrunlerToplamaVerileri' }_${ todayString }.xlsx`;
  }

  exportToExcel(grid: GridComponent): void {
    grid.saveAsExcel();
  }

  allData(): any {
    const newList = JSON.parse(JSON.stringify(this.wdLightData.GatheringTrend));
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
