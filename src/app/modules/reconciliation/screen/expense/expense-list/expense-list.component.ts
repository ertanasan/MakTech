// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Expense } from '@reconciliation/model/expense.model';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { ExpenseEditComponent } from '@reconciliation/screen/expense/expense-edit/expense-edit.component';
import { ExpenseType } from '@reconciliation/model/expense-type.model';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';
import { VatGroupService } from '@reconciliation/service/vat-group.service';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { RegionManagersService } from '@store/service/region-managers.service';
import { RegionManagers } from '@store/model/region-managers.model';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { first } from 'rxjs/operators';
import { Store as Store2} from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { GridComponent } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-list',
    templateUrl: './expense-list.component.html',
    styleUrls: ['./expense-list.component.css', ]
})
export class ExpenseListComponent extends ListScreenBase<Expense> implements AfterViewInit, OnInit {
    @ViewChild(ExpenseEditComponent, {static: true}) editScreen: ExpenseEditComponent;
    @ViewChild(CustomDialogComponent, {static: true}) expenseLog: CustomDialogComponent;

    expenseLogList;
    storeList: Store[];
    regionManagerList: RegionManagers[];
    selectedStore: Store;
    today: Date;
    authorized: boolean;
    authorization: string;
    startDate: Date;
    endDate: Date;
    rec: Expense[];
    recActiveList: any;
    recLoading: boolean;
    paymentStatus: any[] = [{StatusValue: true, StatusText: 'Ödenmedi'}, {StatusValue: false, StatusText: 'Ödendi'}];
    actionUpdate: boolean;
    actionCreate: boolean;
    contextState$: Observable<OTContext>;
    contextInfo;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExpenseService,
        public expenseTypeService: ExpenseTypeService,
        public storeService: StoreService,
        public regionManagerService: RegionManagersService,
        public vatGroupService: VatGroupService,
        public datePipe: DatePipe,
        private store: Store2<fromApp.AppState>,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);

        this.contextState$ = this.store.select('context');
    }

    allData() {
        const lp = new ListParams();
        lp.pageable = false;
        lp.take = 200000;
        const filteredList = process(this.rec, lp);
        return filteredList;
    }

    getxlsFileName() {
        return `Harcamalar_${this.datePipe.transform(this.startDate, 'dd.MM.yyyy')}-${this.datePipe.transform(this.endDate, 'dd.MM.yyyy')}.xlsx`;
    }

    refreshList() {
        if (this.rec) {
            this.recActiveList = process(this.rec, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Expense', RouterLink: '/reconciliation/expense'}];
    }


    createEmptyModel(): Expense {
        const model: Expense = new Expense();
        if (this.selectedStore) {
            model.Store = this.selectedStore.StoreId;
        }
        if (this.actionCreate) {
            if (this.editScreen.authorized) {
                model.OpenFlag = false;
            } else {
                model.OpenFlag = true;
            }
            model.ExpenseDate = this.today;
            model.PayOffDate = this.today;
            model.HasReceipt = true;
        }
        // console.log('createEmptyModel model : ',model);
        return model;
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.showOpenFlag = false;
        this.editScreen.showHasReceipt = false;
        this.actionUpdate = false;
        this.actionCreate = false;
        if (this.authorized) {
            this.editScreen.showHasReceipt = true;
        }
        if (actionName === 'Update') {
            this.actionUpdate = true;
            if (!dataItem.PayOffDate) {
                dataItem.PayOffDate = this.today;
            }
            // console.log('showDialog dataItem : ',dataItem);
            if (dataItem.Store) {
                const storeBranch = this.storeList.filter(row => row.StoreId === dataItem.Store)[0].OrganizationBranch;
                this.editScreen.storeReadOnly = (dataItem.CreateBranch === storeBranch);
                if (this.editScreen.authorized && dataItem.CreateBranch === storeBranch && (dataItem.OpenFlag || this.editScreen.authorization === 'HQ')) {
                    this.editScreen.showOpenFlag = true;
                }
                this.editScreen.regionExpense = false;
            } else {
                this.editScreen.storeReadOnly = true;
                this.editScreen.regionExpense = true;
            }
        } else if (actionName === 'Create') {
            this.actionCreate = true;
            this.editScreen.storeReadOnly = false;
        }
        super.showDialog(target, actionName, dataItem);
    }

    public refreshData() {
        this.onFilter();
        super.refreshData();
    }

    public onFilter() {
        this.recLoading = true;
        this.dataService.ReadDate(this.datePipe.transform(this.startDate, 'yyyy-MM-dd'),
            this.datePipe.transform(this.endDate, 'yyyy-MM-dd')).subscribe(result => {
            this.rec = result;
            this.recLoading = false;
            this.refreshList();
        },
        error => {
            this.recLoading = false;
            this.messageService.error(error);
        });
    }

    onPrint() {

    }

    ngOnInit() {
        this.today = new Date();
        // 21'den sonra yapılan işlemlerin tarihi ertesi gün olsun diye yapıldı.
        this.today = this.dataService.addMinutes(this.today, 150);

        const d = new Date();
        d.setDate(d.getDate());
        this.endDate = new Date(this.datePipe.transform(d, 'yyyy-MM-dd'));
        d.setDate(d.getDate() - 7);
        this.startDate = new Date(this.datePipe.transform(d, 'yyyy-MM-dd'));

        // Fill reference lists
        if (!this.expenseTypeService.completeList) {
            this.expenseTypeService.listAll();
        }
        if (!this.vatGroupService.completeList) {
            this.vatGroupService.listAll();
        }

        this.regionManagerService.listAllAsync().subscribe(regionManagerAllList => {
            this.storeService.listUserStores().subscribe(list => {
                this.storeList = list;
                this.editScreen.storeList = this.storeList;
    
                this.editScreen.selectedStore = null;
                if (this.storeList.length === 1) {
                    this.selectedStore = this.storeList[0];
                    this.editScreen.selectedStore = this.selectedStore;
                    this.editScreen.authorized = false;
                    this.authorized = false;
                } else {
                    this.editScreen.authorized = true;
                    this.authorized = true;
                }
    
                if (list[0].UserBranchType === 'Central Office') {
                  this.editScreen.authorization = 'HQ';
                  this.authorization = 'HQ';
                  this.regionManagerList = regionManagerAllList;
                  this.editScreen.showRegionOrStore = true;
                } else if (list[0].UserBranchType === 'Region') {
                  this.editScreen.authorization = 'RG';
                  this.authorization = 'RG';
                  this.editScreen.showRegionOrStore = true;
                  this.contextState$.pipe(first()).subscribe(
                    context => {
                        this.contextInfo = context;
                        // console.log(this.contextInfo);
                        // console.log(regionManagerAllList);
                        // console.log(this.contextInfo.User.UserId);
                        this.regionManagerList = regionManagerAllList.filter(row => row.RegionUser === this.contextInfo.User.Id);
                    });
                } else {
                  this.editScreen.showRegionOrStore = false;
                  this.editScreen.authorization = 'ST';
                  this.authorization = 'ST';  
                  this.regionManagerList = [];
                }
                this.editScreen.regionManagerList = this.regionManagerList;
              }, error => {
                this.messageService.error(error);
            });
        });

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onExpenseLogList(expenseId) {
        this.dataService.ListExpenseLog(expenseId).subscribe(list => {
            this.expenseLogList = {data: list.Data, total: list.Total};
            this.expenseLog.caption = `${'Masraf işlem logu'}`;
            this.expenseLog.show();
        });

    }
    
    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
