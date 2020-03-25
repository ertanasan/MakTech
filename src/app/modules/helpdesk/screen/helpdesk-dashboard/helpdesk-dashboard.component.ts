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
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';
import { HelpdeskRequestListComponent } from '../helpdesk-request/helpdesk-request-list/helpdesk-request-list.component';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { Subscription } from 'rxjs';
import { InboxService } from '@frame/bpm-core/service/inbox.service';
import { DynamicComponentLoader } from '@otui/dynamic-component-loader/dynamic-component-loader.service';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

class widgetdata {
  title: string;
  desc: string;
  value: string;
}


@Component({
  selector: 'ot-helpdesk-dashboard',
  templateUrl: './helpdesk-dashboard.component.html',
  styleUrls: ['./helpdesk-dashboard.component.css']
})
export class HelpdeskDashboardComponent extends MainScreenBase implements OnInit, AfterViewInit, OnDestroy {

  @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;
  @ViewChild('reviewComponent', { static: true, read: ViewContainerRef }) reviewComponent;
  @ViewChild('assignUserPanel', {static: true}) assignUserPanel: CustomDialogComponent;

  componentRef: any;
  componentSubscription: Subscription;
  actionSubscription: Subscription;
  screenModeSubscription: Subscription;

  data: any;
  openTasks: any;
  openTasksFilteredList: any;

  taskList: any;
  taskFilteredList: any;
  taskGridLP: ListParams = new ListParams();

  responsibleUserList: any;
  activeRequestId: number;
  selectedResponsible: number;

  openTaskGroupList: any;
  groupCheckedList = [];
  openTaskDefGroupList: any;
  defGroupCheckedList = [];
  openTaskDurationList: any;
  durationCheckedList = [];
  openTaskUserList: any;
  userCheckedList = [];

  closeTaskGroupList: widgetdata[] = [];
  closeTaskDefGroupList: widgetdata[] = [];
  closeTaskDurationList: widgetdata[] = [];
  closeTaskUserList: widgetdata[] = [];
  taskActiveList: any;
  listParams: ListParams = new ListParams();

  refreshTime: Date;
  intervalHolder: any;

  dashboard = {OpenTaskCountInGroup: 0, OpenTaskCount: 0, OpenTaskDurationInGroup: 0, OpenTaskDuration: 0, CloseTaskInGroup: 0,
               CloseTask: 0, CloseTaskDurationInGroup: 0, CloseTaskDuration: 0};
  activeDataItem: any;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    private changeDetectorRef: ChangeDetectorRef,
    public utilityService: OverstoreCommonMethods,
    public datePipe: DatePipe,
    public storeService: StoreService,
    public router: Router,
    public requestService: HelpdeskRequestService,
    public inboxService: InboxService,
    public dynamicComponentLoader: DynamicComponentLoader,
    private injector: Injector,
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
    this.taskActiveList = process(this.data.TaskList, this.listParams);
  }

  clearDashboardValues() {
    this.dashboard = {OpenTaskCountInGroup: 0, OpenTaskCount: 0, OpenTaskDurationInGroup: 0, OpenTaskDuration: 0, CloseTaskInGroup: 0,
                      CloseTask: 0, CloseTaskDurationInGroup: 0, CloseTaskDuration: 0};
  }

  createGroupLists() {
    this.openTaskGroupList =
        _(this.openTasksFilteredList)
        .groupBy('ACTIVITY_NM')
        .map((objs, key) => {
              return {
              'Name': key,
              'Count': _.sumBy(objs, 'OPENTASK_CNT')
              };
      }).value();
      this.openTaskGroupList = _.sortBy(this.openTaskGroupList, 'Count').reverse();

      this.openTaskDefGroupList =
        _(this.openTasksFilteredList)
        .groupBy('REQUESTDEF_NM')
        .map((objs, key) => {
              return {
              'Name': key,
              'Count': _.sumBy(objs, 'OPENTASK_CNT')
              };
      }).value();
      this.openTaskDefGroupList = _.sortBy(this.openTaskDefGroupList, 'Count').reverse();

      this.openTaskDurationList =
        _(this.openTasksFilteredList)
        .groupBy('DAYGROUP')
        .map((objs, key) => {
              return {
              'Name': key,
              'Count': _.sumBy(objs, 'OPENTASK_CNT')
              };
      }).value();
      this.openTaskDurationList = _.sortBy(this.openTaskDurationList, 'Count').reverse();

      this.openTaskUserList =
        _(this.openTasksFilteredList)
        .groupBy('RESPONSIBLEUSER_NM')
        .map((objs, key) => {
              return {
              'Name': key,
              'Count': _.sumBy(objs, 'OPENTASK_CNT')
              };
      }).value();
      this.openTaskUserList = _.sortBy(this.openTaskUserList, 'Count').reverse();
  }

  refreshData() {
    this.listParams.take = 1000;
    this.listParams.pageable = false;
    this.refreshTime = new Date();
    this.requestService.helpdeskDashboard().subscribe(result => {
      this.data = result;
      this.clearDashboardValues();
      this.data[0].Data.forEach(row => {
        this.dashboard.OpenTaskCountInGroup += parseInt(row.OPENGROUPTASK_CNT);
        row.OPENTASK_CNT = parseInt(row.OPENTASK_CNT);
        this.dashboard.OpenTaskCount += row.OPENTASK_CNT;
        this.dashboard.OpenTaskDurationInGroup += parseInt(row.OPENGROUPTASKDURATION);
        this.dashboard.OpenTaskDuration += parseInt(row.OPENTASKDURATION);
      });
      this.dashboard.OpenTaskDurationInGroup /= (this.dashboard.OpenTaskCountInGroup * 60.0);
      this.dashboard.OpenTaskDuration /= (this.dashboard.OpenTaskCount * 60.0);

      this.data[1].Data.forEach(row => {
        this.dashboard.CloseTaskInGroup += parseInt(row.CLOSEGROUPTASK_CNT);
        this.dashboard.CloseTask += parseInt(row.CLOSETASK_CNT);
        this.dashboard.CloseTaskDurationInGroup += parseInt(row.CLOSEGROUPDURATION);
        this.dashboard.CloseTaskDuration += parseInt(row.CLOSEDURATION);
      });
      this.dashboard.CloseTaskDurationInGroup /= (this.dashboard.CloseTaskInGroup * 60.0);
      this.dashboard.CloseTaskDuration /= (this.dashboard.CloseTask * 60.0);

      this.openTasks = JSON.parse(JSON.stringify(this.data[0].Data));
      this.taskList = JSON.parse(JSON.stringify(this.data[2].Data));
      this.responsibleUserList = JSON.parse(JSON.stringify(this.data[3].Data));
      this.onSelectedKeysChange();

      this.createGroupLists();

      // console.log(this.openTaskGroupList);
      // console.log(this.dashboard);
      // console.log(this.data);
    });
  }

  onSelectedKeysChange() {
    this.openTasksFilteredList = JSON.parse(JSON.stringify(this.openTasks));
    this.taskGridLP.filter.filters = [];
    if (!this.taskFilteredList) {
      this.taskFilteredList = JSON.parse(JSON.stringify(this.taskList));
    }

    this.groupCheckedList.forEach(name => {
      if (name === null || name === '' || name === 'null' || !name) {
        this.openTasksFilteredList = this.openTasksFilteredList.filter(row => !row.ACTIVITY_NM);
        this.taskGridLP.filter.filters.push({logic: 'or',
          filters: [{ field: 'ACTIVITY_NM', operator: 'eq', value: null },
            { field: 'ACTIVITY_NM', operator: 'eq', value: '' },
            { field: 'ACTIVITY_NM', operator: 'eq', value: 'null' },
            { field: 'ACTIVITY_NM', operator: 'eq', value: undefined }]}
        );
        // this.taskFilteredList = this.taskFilteredList.filter(row => !row.ACTIVITY_NM);
      } else {
        this.openTasksFilteredList = this.openTasksFilteredList.filter(row => row.ACTIVITY_NM === name);
        this.taskGridLP.filter.filters.push({ field: 'ACTIVITY_NM', operator: 'eq', value: name });
        // this.taskFilteredList = this.taskFilteredList.filter(row => row.ACTIVITY_NM === name);
      }
    });

    this.defGroupCheckedList.forEach(name => {
      this.openTasksFilteredList = this.openTasksFilteredList.filter(row => row.REQUESTDEF_NM === name);
      this.taskGridLP.filter.filters.push({ field: 'REQUESTDEF_NM', operator: 'eq', value: name });
      // this.taskFilteredList = this.taskFilteredList.filter(row => row.REQUESTDEF_NM === name);
    });

    this.durationCheckedList.forEach(name => {
      this.openTasksFilteredList = this.openTasksFilteredList.filter(row => row.DAYGROUP === name);
      this.taskGridLP.filter.filters.push({ field: 'DAYGROUP', operator: 'eq', value: name });
      // this.taskFilteredList = this.taskFilteredList.filter(row => row.DAYGROUP === name);
    });

    this.userCheckedList.forEach(name => {
      if (name === null || name === '' || name === 'null' || !name) {
        this.openTasksFilteredList = this.openTasksFilteredList.filter(row => !row.RESPONSIBLEUSER_NM);
        this.taskGridLP.filter.filters.push({logic: 'or',
          filters: [{ field: 'RESPONSIBLEUSER_NM', operator: 'eq', value: null },
            { field: 'RESPONSIBLEUSER_NM', operator: 'eq', value: '' },
            { field: 'RESPONSIBLEUSER_NM', operator: 'eq', value: 'null' },
            { field: 'RESPONSIBLEUSER_NM', operator: 'eq', value: undefined }]}
        );
        // this.taskFilteredList = this.taskFilteredList.filter(row => !row.RESPONSIBLEUSER_NM);
      } else {
        this.openTasksFilteredList = this.openTasksFilteredList.filter(row => row.RESPONSIBLEUSER_NM === name);
        this.taskGridLP.filter.filters.push({ field: 'RESPONSIBLEUSER_NM', operator: 'eq', value: name });
        // this.taskFilteredList = this.taskFilteredList.filter(row => row.RESPONSIBLEUSER_NM === name);
      }
    });
    this.createGroupLists();
    this.refreshTaskGrid();
  }

  showHistory(processInstance) {
    this.historyScreen.ProcessInstanceId = processInstance;
    this.historyScreen.dialog.show();
  }

  openTask(processInstance) {
    this.requestService.UserTask(processInstance).subscribe(dataItem => {
      const screenParts = dataItem.ScreenReference.split('#');
      if (screenParts.length === 3) {
          this.createReviewComponent(dataItem.ActionId, screenParts[0], screenParts[1], screenParts[2]);
      } else {
          this.messageService.warning('Screen Reference is not well-formatted. Screen Reference is:' + dataItem.ScreenReference );
      }
    });
  }

  clearComponent() {
    this.reviewComponent.clear();
    if (this.componentRef) { this.componentRef.destroy(); }
    if (this.componentSubscription) {
        this.componentSubscription.unsubscribe();
    }
    if (this.actionSubscription) {
        this.actionSubscription.unsubscribe();
    }
    if (this.screenModeSubscription) {
        this.screenModeSubscription.unsubscribe();
    }
  }

  createReviewComponent(actionId: number, moduleName: string, componentName: string, context: string): any {
    this.clearComponent();
    const componentMap = {
        'HelpdeskRequestListComponent': HelpdeskRequestListComponent,
      };
    this.actionSubscription = this.inboxService.readActionInfo(actionId).subscribe(actionInfo => {
        this.componentSubscription = this.dynamicComponentLoader
            .getComponentFactory(moduleName, componentMap['HelpdeskRequestListComponent'], this.injector)
            .subscribe(componentFactory => {
                const childActions = actionInfo['Choices'].join(';');
                this.componentRef = this.reviewComponent.createComponent(componentFactory);
                const screenRef = <OTScreenBase>this.componentRef._component;
                screenRef.modeDefault = false;
                screenRef.modeReview = true;
                screenRef.modeContext = { childActions: childActions, id: context, actionId: actionId };
                this.screenModeSubscription = screenRef.modeEvent.subscribe((data: any) => {
                    this.refreshList();
                });
                this.componentRef.changeDetectorRef.detectChanges();
            }, error => {
                console.warn(error);
            });
    });
  }

  assignUser(activeDataItem) {
    this.activeDataItem = activeDataItem;
    this.activeRequestId = activeDataItem.REQUESTID;
    this.assignUserPanel.caption = 'Sorumlu Ata';
    this.assignUserPanel.show();
  }

  assignResponsible() {
    this.requestService.read(this.activeRequestId).subscribe(result => {
      result.ResponsibleUser = this.selectedResponsible;
      this.requestService.update(result).subscribe(result2 => {
        this.activeDataItem.RESPONSIBLEUSER = this.selectedResponsible;
        this.activeDataItem.RESPONSIBLEUSER_NM = this.responsibleUserList.filter(row => row.USERID === this.selectedResponsible)[0].USERFULL_NM;
        this.assignUserPanel.hide();
      });
    });
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

    this.taskGridLP.take = 1000;
    this.taskGridLP.pageable = false;

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

  taskGridHandleDSC(state: DataStateChangeEvent) {
    // this.taskGridLP.dateFields = ['CREATE_DT'];
    // this.listParams.skip = state.skip;
    // this.listParams.take = state.take;
    if (state.sort) {
      this.taskGridLP.sort = state.sort;
    }
    // if (state.filter) {
    //   this.listParams.filter = state.filter;
    // }
    // if (state.group) {
    //   this.listParams.group = state.group;
    // }
    this.taskFilteredList.forEach(t => t.CREATE_DT = new Date(t.CREATE_DT));
    this.refreshTaskGrid();
  }

  refreshTaskGrid() {
    this.taskFilteredList = process(this.taskList, this.taskGridLP).data;
  }

}
