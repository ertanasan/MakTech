// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';
import { SalesEditComponent } from '@sale/screen/sales/sales-edit/sales-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { TransactionType } from '@sale/model/transaction-type.model';
import { TransactionTypeService } from '@sale/service/transaction-type.service';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { Router, ActivatedRoute, } from '@angular/router';
import { SaleIdDate } from '@sale/service/sale-id-date.service';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';
import { ListParams } from '@otmodel/list-params.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sales-list',
    templateUrl: './sales-list.component.html',
    styleUrls: ['./sales-list.component.css']
})
export class SalesListComponent extends ListScreenBase<Sales> implements AfterViewInit, OnInit, OnDestroy {

    @ViewChild(SalesEditComponent, {static: true}) editScreen: SalesEditComponent;
    @ViewChild(DropdownEntryComponent, {static: true}) stores: DropdownEntryComponent;

    transactionDate: Date;
    storeId: number;
    saleList: any;
    saleActiveList: any;
    saleLoading = false;

    constructor(

        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SalesService,
        public storeService: StoreService,
        public router: ActivatedRoute,
        public transactionTypeService: TransactionTypeService,
        public datePipe: DatePipe,
        public saleIdDate: SaleIdDate,
        public route: Router

    ) {

        super(messageService, translateService);
    }


    refreshList() {
        if (this.saleList) {
            this.saleActiveList = process(this.saleList, this.listParams);
        }

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Sale' }, { Caption: 'Sales', RouterLink: '/sale/sales' }];
    }

    createEmptyModel(): Sales {
        const sd = new Sales();
        sd.TransactionDate = this.transactionDate;
        sd.Store = this.storeId;
        sd.Event = 1045;
        sd.Organization = 1;
        return sd;
    }

    refreshData() {
        this.getDateStoreList();
        this.refreshList();
    }

    getDateStoreList() {

        if (this.transactionDate && this.storeId) {
            const d = new Date(this.transactionDate);
            const transactionDateString = this.datePipe.transform(d, 'yyyy-MM-dd');
            this.saleLoading = true;
            this.dataService.listDateStore(transactionDateString, this.storeId).subscribe(result => {
                this.saleList = result;
                this.refreshList();
                this.saleLoading = false;
            },
                error => {
                    this.messageService.error(error);
                    this.saleLoading = false;
                });
        }
    }

    ngOnInit() {

        if (this.router.snapshot.params['transactionDate']) {
            this.transactionDate = new Date(this.router.snapshot.params['transactionDate']);
        } else {
            this.transactionDate = new Date();
            this.transactionDate.setDate(this.transactionDate.getDate() - 1);
        }

        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }

        if (this.router.snapshot.params['storeId']) {
            this.storeId = this.router.snapshot.params['storeId'];
        }

        if (!this.transactionTypeService.completeList) {
            this.transactionTypeService.listAll();
        }
        if (this.saleIdDate.sale1 !== undefined) {
            this.saleLoading = true;
            this.saleList = this.saleIdDate.get();
            this.listParams = this.saleIdDate.getParams();
            this.refreshList();
            this.saleLoading = false;

        }

        super.ngOnInit();

    }

    ngAfterViewInit() {

        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {

        if (actionName === 'Update') {
            this.editScreen.storeID.isReadOnly = true;
            this.editScreen.transactionDate.isReadOnly = true;
            this.editScreen.transactionCode.isReadOnly = true;
        }
        super.showDialog(target, actionName, dataItem);
    }


    //#endregion Customized

    ngOnDestroy() {
        if (this.route.routerState.snapshot.url.indexOf('/Sale/SaleDetail/') === 0) {
            this.saleIdDate.set(this.saleList);
            this.saleIdDate.setParams(this.listParams);

        }

        /*Section="ClassFooter"*/
    }
}
