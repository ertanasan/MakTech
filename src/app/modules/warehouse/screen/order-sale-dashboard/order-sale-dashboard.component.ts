import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';


import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { ListParams } from '@otmodel/list-params.model';
import { process, SortDescriptor, aggregateBy, FilterDescriptor, filterBy, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { SelectableSettings, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { dateFieldName } from '@telerik/kendo-intl';
import { StoreOrderService } from '@warehouse/service/store-order.service';

@Component({
    selector: 'ot-order-sale-dashboard',
    templateUrl: './order-sale-dashboard.component.html',
    styleUrls: ['./order-sale-dashboard.component.css']
})
export class OrderSaleDashboardComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    baseDate: Date;

    selectedStoreId: number = -1;
    selectedStoreName: string = "";
    selectedProductId: number = -1;
    selectedProductName: string = "";
    selectedStartDate : string;
    selectedEndDate: string;

    dateData: any;

    productDataLoading: boolean = false;
    productData: any;
    productDataActiveList: any;
    lpProductData: any;

    storeDataLoading: boolean = false;
    storeData: any;
    storeDataActiveList: any;
    lpStoreData: any;

    dayGroup: number;
    storeSelection: number[] = [];
    productSelection: number[] = [];
    selectableSettings: SelectableSettings;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StoreOrderService,
        public ts: TranslateService,
        public router: ActivatedRoute,
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

    public onSelectedKeysChange(e, gridGroup: number) {

        let len;
        switch (gridGroup) {
            case 1 : 
                len = this.productSelection.length;
                if (len === 0) {
                    this.selectedProductId = -1;
                    this.selectedProductName = "";
                } else {
                    this.selectedProductId = e[0];
                    this.selectedProductName = ' - '+this.productData.filter(f => f.PRODUCTID === e[0])[0].PRODUCT_NM;
                }
                this.refreshList(true, false, true);
                break;    
            case 2 : 
                len = this.storeSelection.length;
                if (len === 0) {
                    this.selectedStoreId = -1;
                    this.selectedStoreName = "";
                } else {
                    this.selectedStoreId = e[0];
                    this.selectedStoreName = ' - '+this.storeData.filter(f => f.STOREID === e[0])[0].STORE_NM;
                }
                this.refreshList(true, true, false);
                break;
        }
        
    }

    public getSaleCaption(): string {
        return `Satışlar ${this.selectedStoreName} ${this.selectedProductName}`;
    }

    public getStoreCaption(): string {
        return `Mağaza Dağılımı ${this.selectedProductName}`;
    }

    public getProductCaption(): string {
        return `Ürün Dağılımı ${this.selectedStoreName}`;
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

        if (state.sort) {
            switch (gridGroup) {
                case 1 : 
                    this.lpProductData.sort = state.sort;
                    this.productDataActiveList = process(this.productData, this.lpProductData);
                    break;
                case 2 : 
                    this.lpStoreData.sort = state.sort;
                    this.storeDataActiveList = process(this.storeData, this.lpStoreData);
                    break;    
            }
        }

        if (state.filter) {
            switch (gridGroup) {
                case 1 : 
                    this.lpProductData.filter = state.filter;
                    this.productDataActiveList = process(this.productData, this.lpProductData);
                    break;
                case 2 : 
                    this.lpStoreData.filter = state.filter;
                    this.storeDataActiveList = process(this.storeData, this.lpStoreData);
                    break;    
            }
        }
    }
    

    onBaseDateChange() {
        this.onSelectedChange(true, this.dayGroup);
    }

    refreshList(chart, productGrid, storeGrid) {

        if (chart) {
            this.dataService.listOrderSaleDateDetails(this.selectedStoreId, this.selectedProductId, this.selectedStartDate, this.selectedEndDate).subscribe( list => {
                this.dateData = list.Data;
            })
        }

        if (productGrid) {
            this.productDataLoading = true;
            this.dataService.listOrderSaleProductDetails(this.selectedStoreId, this.selectedStartDate, this.selectedEndDate).subscribe( list => {
                this.productData = list.Data;
                this.productDataActiveList = list.Data;
                this.productDataLoading = false;
            },
            error => {
                console.log(error);
                this.productDataLoading = false;
            })
        }

        if (storeGrid) {
            this.storeDataLoading = true;
            this.dataService.listOrderSaleStoreDetails(this.selectedProductId, this.selectedStartDate, this.selectedEndDate).subscribe( list => {
                this.storeData = list.Data;
                this.storeDataActiveList = list.Data;
                this.storeDataLoading = false;
            },
            error => {
                console.log(error);
                this.storeDataLoading = false;
            })
        }
        
    }

    ngAfterViewInit() {
    }
    

    ngOnInit() {
        
        let d = new Date();
        d.setDate(d.getDate() - 1);
        this.baseDate = d;

        this.onSelectedChange(true, 2);

        this.lpProductData = new ListParams();
        this.lpProductData.pageable = false;
        this.lpProductData.take = 1000;
        this.lpStoreData = new ListParams();
        this.lpStoreData.pageable = false;
        this.lpStoreData.take = 1000;
        this.refreshList(true, true, true);
    }

    onSelectedChange(event, dayGroup) {
        if (event) {
            this.dayGroup = dayGroup;
            let d = new Date(this.baseDate);
            this.selectedEndDate = this.datePipe.transform(d, 'yyyy-MM-dd');
            switch (dayGroup) {
                case 1 : break;
                case 2 : d.setDate(d.getDate() - 15); break;
                case 3 : d.setDate(d.getDate() - 30); break;
            }
            this.selectedStartDate = this.datePipe.transform(d, 'yyyy-MM-dd');
            this.refreshList(true, true, true);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
