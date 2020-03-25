import { Component, OnInit } from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { StoreService } from '@store/service/store.service';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';
import { DatePipe } from '@angular/common';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { RelationId } from '@otmodel/relation-id.model';
import { ListParams } from '@otmodel/list-params.model';
import { UsersStoresService } from '@store/service/users-stores.service';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent, GridComponent } from '@progress/kendo-angular-grid';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import * as _ from 'lodash';
import { RegionManagersService } from '@store/service/region-managers.service';


@Component({
  selector: 'ot-expense-detail',
  templateUrl: './expense-detail.component.html',
  styleUrls: ['./expense-detail.component.css']
})
export class ExpenseDetailComponent extends MainScreenBase implements OnInit {

  public range = {
    start: new Date(),
    end: new Date()
  };
  public storeSelection: number[] = [];
  public managerSelection: number[] = [];
  public typeSelection: number[] = [];
  public groupedList = [];
  public groupedListData;
  chartData;

  totalExpense = 0;
  storeListParams: ListParams;
  manageListParams: ListParams;
  categoryListParams: ListParams;
  listParams: ListParams;
  paymentStatus: any[] = [{ StatusValue: true, StatusText: 'Ödenmedi' }, { StatusValue: false, StatusText: 'Ödendi' }];
  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public utilityService: OTUtilityService,
    public dataService: ExpenseService,
    public managerService: RegionManagersService,
    public expenseTypeService: ExpenseTypeService,
    public storeService: StoreService,
    public datePipe: DatePipe,
  ) {
    super(messageService, translateService);
    this.storeListParams = new ListParams();
    this.storeListParams.skip = 0;
    this.storeListParams.take = 1000;
    this.manageListParams = new ListParams();
    this.manageListParams.skip = 0;
    this.manageListParams.take = 1000;
    this.categoryListParams = new ListParams();
    this.categoryListParams.skip = 0;
    this.categoryListParams.take = 1000;
    this.listParams = new ListParams();
    this.listParams.skip = 0;
    this.listParams.take = 20;

  }

  ngOnInit() {

    this.expenseTypeService.listAll();
    this.expenseTypeService.completeListChanged.subscribe(() => this.refreshData(3));
    this.managerService.listAll();
    this.managerService.completeListChanged.subscribe(() => this.refreshData(2));
    this.storeService.listAll();
    this.storeService.completeListChanged.subscribe(() => this.refreshData(1));
    this.readDate();

  }

  getBreadcrumbItems(): MenuItem[] {
    return [];
  }

  refreshData(id?: number | RelationId) {
    switch (id) {
      case 1: this.storeService.activeList = process(this.storeService.completeList, this.storeListParams); break;
      case 2: this.managerService.activeList = process(this.managerService.completeList, this.manageListParams); break;
      case 3: this.expenseTypeService.activeList = process(this.expenseTypeService.completeList, this.categoryListParams); break;
      case 4: this.groupedListData = process(this.groupedList, this.listParams); break;
    }
  }

  createEmptyItem() {
  }

  readDate() {
    this.dataService.ExpenseReport(this.range.start, this.range.end, this.storeSelection, this.managerSelection, this.typeSelection).subscribe(expense => {
      this.groupedList = expense.Data;
      this.totalExpense = _.sumBy(expense.Data, 'EXPENSE_AMT');
      // console.log('ExpenseDetailComponent.readDate.groupedList: ', this.groupedList);
      this.refreshData(4);
      // console.log(this.groupedList);
    });
    this.dataService.ExpenseReportChart(this.storeSelection, this.managerSelection, this.typeSelection).subscribe(expense => {
      this.chartData = expense.Data;
      // console.log(this.chartData);
    });
    // console.log(this.groupedList);
    // console.log(this.chartData);
  }

  onSelectedKeysChange() {
    this.readDate();

    // const multiGroupBy = (array, group?, ...restGroups) => {
    //   if (!group) {
    //     return array;
    //   }
    //   const currGrouping = _.groupBy(array, group);
    //   if (!restGroups.length) {
    //     return currGrouping;
    //   }
    //   return _.transform(currGrouping, (result, value, key) => {
    //     result[key] = multiGroupBy(value, ...restGroups);
    //   }, {});
    // };


    // _.forEach(multiGroupBy(this.dataService.activeList.data, 'StoreName', 'CreateUserName', 'ExpenseTypeName'), function (value, key1) {
    //    _.forEach(value,
    //     (val2, key2) => {
    //        _.forEach(val2,
    //         (val3, key3) => {
    //           console.log(key1,key2,key3,_.sumBy(val3, 'ExpenseAmount'));
    //           this.groupedList.push({'StoreName': key1, 'CreateUserName': key2, 'ExpenseTypeName': key3, 'ExpenseTotalAmount': _.sumBy(val3, 'ExpenseAmount')});
    //         }
    //       );
    //     });
    // });

    // console.log(multiGroupBy(this.dataService.activeList.data, 'StoreName', 'CreateUserName', 'ExpenseTypeName'));
  }

  handleDataStateChange(state: DataStateChangeEvent, i: number) {
    let _listParams = new ListParams();
    _listParams.skip = 0;
    _listParams.take = 1000;
    switch (i) {
      case 1: _listParams = this.storeListParams; break;
      case 2: _listParams = this.manageListParams; break;
      case 3: _listParams = this.categoryListParams; break;
      case 4: _listParams = this.listParams; break;
    }
    _listParams.skip = state.skip;
    if (state.sort) {
      _listParams.sort = state.sort;
    }
    if (state.filter) {
      _listParams.filter = state.filter;
    }
    if (state.group) {
      _listParams.group = state.group;
    }
    switch (i) {
      case 1: this.storeListParams = _listParams; this.refreshData(1); break;
      case 2: this.manageListParams = _listParams; this.refreshData(2); break;
      case 3: this.categoryListParams = _listParams; this.refreshData(3); break;
      case 4: this.listParams = _listParams; this.refreshData(4); break;
    }
  }
  public exportToExcel(grid: GridComponent): void {
    grid.saveAsExcel();
}
  getxlsFileName() {
    return `Harcamalar_${this.datePipe.transform(this.range.start, 'dd.MM.yyyy')}-${this.datePipe.transform(this.range.end, 'dd.MM.yyyy')}.xlsx`;
  }

  allData() {
    const lp = new ListParams();
    lp.pageable = true;
    lp.take = 200000;
    const filteredList = process(this.dataService.completeList, lp);
    return filteredList;
  }
}
