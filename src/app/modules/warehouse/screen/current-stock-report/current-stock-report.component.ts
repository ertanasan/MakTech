import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { SelectableSettings, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { StoreService } from '@store/service/store.service';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { Store } from '@store/model/store.model';
import { ListScreenBase } from '@otscreen-base/list-screen-base';

@Component({
    selector: 'ot-current-stock-report',
    templateUrl: './current-stock-report.component.html',
    styleUrls: ['./current-stock-report.component.css']
})
export class CurrentStockReportComponent extends ListScreenBase<Store> implements OnInit, AfterViewInit {

    selectedStoreId = -1;
    selectedStoreName = '';
    storeList: any[] = [];
    storeListLoading = false;

    selectedProductId = -1;
    selectedProductName = '';

    productDataLoading = false;
    productData: any;
    productDataActiveList: any;
    lpProductData: any;

    productSelection: number[] = [];
    selectableSettings: SelectableSettings;

    tranDataLoading = false;
    tranData: any;
    tranDataActiveList: any;
    lpTranData: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StockTakingService,
        public storeService: StoreService,
        public stockTakingScheduleService: StockTakingScheduleService,
        public datePipe: DatePipe
    ) {
        super(messageService, translateService);
        this.setSelectableSettings();
    }

    public setSelectableSettings(): void {
        this.selectableSettings = {
            checkboxOnly: false,
            mode: 'single'
        };
    }

    createEmptyModel(): Store {
        return new Store();
    }

    findColor(pct) {
        if (pct >= 110) {
            return 'success';
        } else if (pct >= 90) {
            return 'primary';
        } else if (pct >= 80) {
            return 'warning';
        } else if (pct > 0) {
            return 'danger';
        } else {
            return 'primary';
        }
    }

    onStoreChange(e) {

        if (this.selectedStoreId && this.selectedStoreId !== -1) {
            this.selectedStoreName = this.storeList.filter(r => r.StoreId === this.selectedStoreId)[0].Name;
            this.productDataLoading = true;
            this.dataService.ListCurrentStocks(this.selectedStoreId).subscribe(result => {
                this.productData = result.Data;
                this.productDataActiveList = result.Data;
                this.productDataLoading = false;
            },
            error => {
                console.log(error);
                this.messageService.error(error);
                this.productDataLoading = false;
            });
        }
    }

    public onSelectedKeysChange(e) {

        let len;
        len = this.productSelection.length;
        if (len === 0) {
            this.selectedProductId = -1;
            this.selectedProductName = '';
            this.tranData = null;
            this.tranDataActiveList = null;
        } else {
            this.selectedProductId = e[0];
            const selectedRow = this.productData.filter(f => f.PRODUCTID === e[0])[0];
            this.selectedProductName = ' - ' + selectedRow.PRODUCT_NM;
            this.tranDataLoading = true;
            this.dataService.listStockTransactions(this.selectedStoreId, this.selectedProductId, selectedRow.STOCK).subscribe(result => {
                this.tranData = result.Data;
                this.tranDataActiveList = result.Data;
                this.tranDataLoading = false;
            },
            error => {
                console.log(error);
                this.messageService.error(error);
                this.tranDataLoading = false;
            });
        }
    }

    public getStoreCaption(): string {
        return `Stok Hareketleri ${this.selectedProductName}`;
    }

    public getProductCaption(): string {
        return `Stoklar ${this.selectedStoreName}`;
    }

    public getStoreFileName(): string {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `Magazalar_${d2}_${this.selectedProductName}.xlsx`;
    }

    public getProductFileName(): string {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `Urunler_${d2}_${this.selectedStoreName}.xlsx`;
    }

    public refreshData() {

    }

    handleStateChange(state: DataStateChangeEvent, gridGroup: number) {

        if (gridGroup === 1) {
            if (state.sort) {
                this.lpProductData.sort = state.sort;
                this.productDataActiveList = process(this.productData, this.lpProductData);
            }

            if (state.filter) {
                this.lpProductData.filter = state.filter;
                this.productDataActiveList = process(this.productData, this.lpProductData);
            }
        } else {
            if (state.sort) {
                this.lpTranData.sort = state.sort;
                this.tranDataActiveList = process(this.tranData, this.lpTranData);
            }

            if (state.filter) {
                this.lpTranData.filter = state.filter;
                this.tranDataActiveList = process(this.tranData, this.lpTranData);
            }
        }
    }

    refreshList() {

    }

    ngAfterViewInit() {
    }

    ngOnInit() {
        this.storeListLoading = true;
        this.stockTakingScheduleService.CountedStores().subscribe(result => {
            this.storeList = result;
            this.storeListLoading = false;
        }, error => {
            this.messageService.error(error);
            this.storeListLoading = false;
        });
        this.lpProductData = new ListParams();
        this.lpProductData.pageable = false;
        this.lpProductData.take = 1000;

        this.lpTranData = new ListParams();
        this.lpTranData.pageable = false;
        this.lpTranData.take = 1000;
    }


    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
