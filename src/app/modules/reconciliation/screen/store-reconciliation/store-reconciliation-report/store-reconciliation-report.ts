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
import { SelectableSettings } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { StoreReconciliationService } from '@reconciliation/service/store-reconciliation.service';

@Component({
    selector: 'ot-store-reconciliation-report',
    templateUrl: './store-reconciliation-report.html',
    styleUrls: ['./store-reconciliation-report.css']
})
export class ReconciliationReportComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    categoryName: string;
    categoryStoreLoading: boolean = false;
    lpCategoryStore: any;
    reconciliationStoreData: any;
    categoryStoreActiveList: any;
    
    ReconciliatedCount: number;
    ApprovedCount: number;
    PositiveDifference: number;
    NegativeDifference: number;

    loading: boolean = false;
    lpCategoryProduct: any;
    categoryProduct: any;
    categoryProductActiveList: any;

    categorySalesLoading: boolean = false;
    //categorySales: any;

    categoryStore: any;
    saleTotal: number;
    quantityTotal: number;
    customerTotal: number;
    avgQuantity: number;
    avgSale: number;
    avgUnit: number;
    selectedStoreId: number = -1;
    selectedStoreName: string = "";
    selectedProductId: number = -1;
    selectedProductName: string = "";
    storeSelection: number[] = [];
    productSelection: number[] = [];
    selectableSettings: SelectableSettings;

    categoryProductLoading: boolean = false;
    categorySales: any;

    dayGroup: number = 1;


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public reconciliationService: StoreReconciliationService,
        public ts: TranslateService,
        public router: ActivatedRoute,
        public datePipe: DatePipe
    ) {
        super(messageService, translateService);
//        this.setSelectableSettings();
    }

    // public setSelectableSettings(): void {
    //     this.selectableSettings = {
    //         checkboxOnly: false,
    //         mode: 'single'
    //     };
    // }

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
                len = this.storeSelection.length;
                if (len === 0) {
                    this.selectedStoreId = -1;
                    this.selectedStoreName = "";
                } else {
                    this.selectedStoreId = e[0];
                    this.selectedStoreName = ' - '+this.reconciliationStoreData.filter(f => f.STORE === e[0])[0].STORE_NM;
                }
                this.categorySaleRefreshData();
                this.refreshProductData();
                break;
            case 2 : 
                len = this.productSelection.length;
                if (len === 0) {
                    this.selectedProductId = -1;
                    this.selectedProductName = "";
                } else {
                    this.selectedProductId = e[0];
                    this.selectedProductName = ' - '+this.categoryProduct.filter(f => f.PRODUCTID === e[0])[0].PRODUCTNAME;
                }
                this.categorySaleRefreshData();
                this.refreshData();
                break;    

        }
     
    }

    // public getSaleCaption(): string {
    //     return `Satışlar ${this.selectedStoreName} ${this.selectedProductName}`;
    // }

    public getStoreCaption(): string {
        return `Mağaza Dağılımı ${this.selectedProductName}`;
    }

    // public getProductCaption(): string {
    //     return `Ürün Dağılımı ${this.selectedStoreName}`;
    // }

    public getStoreFileName(): string {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `${this.categoryName}_Magazalar_${d2}_${(this.dayGroup===1)?'bugun':(this.dayGroup===2)?'dun':(this.dayGroup===3)?'son7gun':'son30gun'}${this.selectedProductName}.xlsx`;
    }

    // public getProductFileName(): string {
    //     const d: Date = new Date();
    //     const d2 = this.datePipe.transform(d, 'yyyyMMdd');
    //     return `${this.categoryName}_Urunler_${d2}_${(this.dayGroup===1)?'bugun':(this.dayGroup===2)?'dun':(this.dayGroup===3)?'son7gun':'son30gun'}${this.selectedStoreName}.xlsx`;
    // }

    handleSortChange(sort: SortDescriptor[], gridGroup: number) {

        if (sort) {
            switch (gridGroup) {
                case 1 : 
                    this.lpCategoryStore.sort = sort;
                    this.categoryStoreActiveList = process(this.reconciliationStoreData, this.lpCategoryStore);
                    break;
                case 2 : 
                    this.lpCategoryProduct.sort = sort;
                    this.categoryProductActiveList = process(this.categoryProduct, this.lpCategoryProduct);
                    break;    
            }
        }
    }
    

    refreshData() {
        this.categoryStoreLoading = true;
        this.reconciliationService.getReconciliationStoreData(this.dayGroup).subscribe(data => {
                this.reconciliationStoreData = data.Data;
                this.categoryStoreActiveList = data.Data;
                this.ReconciliatedCount = this.reconciliationStoreData[0].ReconciliatedCount;
                this.ApprovedCount = this.reconciliationStoreData[0].ApprovedCount;
                this.PositiveDifference = this.reconciliationStoreData[0].PositiveDifference;
                this.NegativeDifference = this.reconciliationStoreData[0].NegativeDifference;
            },
            error => {
                this.categoryStoreLoading = false;
            });
    }

    refreshProductData() {
        this.loading = true;
        this.reconciliationService.getReconciliationStoreData(this.dayGroup).subscribe(data => {
                this.categoryProduct = data.Data;
                this.categoryProductActiveList = data.Data;
                this.loading = false;
            },
            error => {
                this.loading = false;
            });
    }

    categorySaleRefreshData() {
        // this.categorySalesLoading = true;
        // this.reconciliationService.getSaleByCategoryName(this.categoryName, this.selectedStoreId, this.selectedProductId).subscribe(data => {
        //     this.categorySales = data.Data;
        //     this.categorySalesLoading = false;
        // },
        // error => {
        //     console.log(error);
        //     this.categorySalesLoading = false;
        // });
    }

    ngAfterViewInit() {
    }

    

    ngOnInit() {
        this.categoryName = this.router.snapshot.params['categoryName'];
        this.lpCategoryStore = new ListParams();
        this.lpCategoryProduct = new ListParams();
        this.refreshData();
        this.refreshProductData();
        // this.categorySaleRefreshData();
    }

    onSelectedChange(event, dayGroup) {
        if (event) {
            this.dayGroup = dayGroup;
            this.refreshData();
            this.refreshProductData();
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
