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
import { process, aggregateBy } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';
import { RegionManagersService } from '@store/service/region-managers.service';
import { RegionManagers } from '@store/model/region-managers.model';
import { ExpenseTransferEditComponent } from '../expense-transfer-edit/expense-transfer-edit.component';
import * as _ from 'lodash';
import { parse } from 'url';
import { ExpenseTransferPreviewComponent } from '../expense-transfer-preview/expense-transfer-preview.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-transfer-list',
    templateUrl: './expense-transfer-list.component.html',
    styleUrls: ['./expense-transfer-list.component.css', ]
})
export class ExpenseTransferListComponent extends ListScreenBase<Expense> implements AfterViewInit, OnInit {
    @ViewChild(ExpenseTransferEditComponent, {static: true}) editScreen: ExpenseTransferEditComponent;
    @ViewChild(ExpenseTransferPreviewComponent, {static: true}) previewDialog: ExpenseTransferPreviewComponent;
    storeList: Store[];
    selectedStore: Store;
    // today: Date;
    authorized: boolean;
    authorization: string;
    // startDate: Date;
    // endDate: Date;
    rec: Expense[];
    recActiveList: any;
    recLoading: boolean;
    paymentStatus: any[] = [{StatusValue: true, StatusText: 'Ödenmedi'}, {StatusValue: false, StatusText: 'Ödendi'}];
    actionUpdate: boolean;
    actionCreate: boolean;
    selectedRegionManager = -1;
    expenseList =  [];
    public aggregates_c1: any[] =
        [{field: 'ExpenseAmount', aggregate: 'sum'}];
    total_c1: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExpenseService,
        public expenseTypeService: ExpenseTypeService,
        public storeService: StoreService,
        public datePipe: DatePipe,
        public regionManagersService: RegionManagersService
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    allData() {
        const lp = new ListParams();
        lp.pageable = false;
        lp.take = 200000;
        const filteredList = process(this.rec, lp);
        return filteredList;
    }

    getxlsFileName() {
        return `Harcamalar.xlsx`;
    }

    refreshList() {
        if (this.rec) {
            this.rec.map(t => {
                t.ExpenseDate = new Date(t.ExpenseDate);
            });
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
            // model.ExpenseDate = this.today;
            // model.PayOffDate = this.today;
        }
        // console.log('createEmptyModel model : ',model);
        return model;
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.showOpenFlag = false;
        this.actionUpdate = false;
        this.actionCreate = false;
        if (actionName === 'Update') {
            this.actionUpdate = true;
            if (!dataItem.PayOffDate) {
                // dataItem.PayOffDate = this.today;
            }
            // console.log('showDialog dataItem : ',dataItem);
            const storeBranch = this.storeList.filter(row => row.StoreId === dataItem.Store)[0].OrganizationBranch;
            this.editScreen.storeReadOnly = (dataItem.CreateBranch === storeBranch);
            if (this.editScreen.authorized && dataItem.CreateBranch === storeBranch && (dataItem.OpenFlag || this.editScreen.authorization === 'HQ')) {
                this.editScreen.showOpenFlag = true;
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
        if (!this.selectedRegionManager) {
            this.messageService.warning('Seçtiğiniz bölge sorumlusunun Maktech kullanıcısı ile ilişkilendirilmesi yapılmamış.');
            return;
        }
        this.recLoading = true;
        this.dataService.MikroTransferList(this.selectedRegionManager).subscribe(result => {
            this.rec = result;
            if (this.rec.length > 0) {
                this.total_c1 = aggregateBy(this.rec, this.aggregates_c1);
            }
            this.recLoading = false;
            this.refreshList();
        },
        error => {
            this.recLoading = false;
            this.messageService.error(error);
        });
    }

    public onSelectedKeysChange(event) {
        let selectedSum = 0;
        event.forEach(r => {
            selectedSum += _.filter(this.rec, ['ExpenseId', r])[0].ExpenseAmount;
        });
        this.total_c1.ExpenseAmount.sum = selectedSum;
    }

    public onMikro() {
        if (this.expenseList) {
            this.previewDialog.onShow.next(this.rec.filter(r => this.expenseList.includes(r.ExpenseId)));
            this.previewDialog.dialog.show();
        } else {
            this.messageService.warning(this.translateService.instant('No expense selected'));
        }
        // this.dataService.MikroTransfer(this.selectedRegionManager, this.expenseList).subscribe(
        //     result => {
        //         this.messageService.success(`Mikroya aktarıldı. MBS-${result}`);
        //         this.onFilter();
        //     }, error => {
        //         this.messageService.error(error);
        //         this.onFilter();
        //     });
    }

    onPrint() {

    }

    ngOnInit() {
        if (!this.expenseTypeService.completeList) {
            this.expenseTypeService.listAll();
        }

        if (!this.regionManagersService.completeList) {
            this.regionManagersService.listAll();
        }

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
            } else {
              this.editScreen.authorization = 'ST';
              this.authorization = 'ST';
            }
          }, error => {
            this.messageService.error(error);
        });


        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.previewDialog.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

}
