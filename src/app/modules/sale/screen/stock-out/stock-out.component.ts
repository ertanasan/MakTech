import { TranslateService } from '@ngx-translate/core';
import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { StoreService } from '@store/service/store.service';
import { DomSanitizer, SafeStyle  } from '@angular/platform-browser';
import { ProductCategoryService } from '@product/service/product-category.service';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';

@Component({
    selector: 'ot-stock-out',
    templateUrl: './stock-out.component.html',
    styleUrls: ['./stock-out.component.css']
})
export class StockOutComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    @ViewChild('categorycomp', {static: true}) categoryComp : DropdownEntryComponent;

    categoryId: any;
    storeCountSold: number = 50;
    detailCaption: string;

    productId: number;
    startDate: Date = new Date('2019-01-01');
    endDate: Date = new Date();
    startBuffer: number = 40;
    shipmentUnit: number = 5;
    greenCycle: number = 6;
    bufferBandwith: number = 33.33;
    ceiling: boolean = true;

    baseDate: Date;

    selectedStoreId: number = -1;
    selectedStoreName: string = "";
    selectedProductId: number = -1;
    selectedProductName: string = "";
    selectedStartDate : string;
    selectedEndDate: string;

    dateData: any;

    detailDataLoading: boolean = false;
    detailData: any;
    detailDataActiveList: any;
    lpDetailData: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SalesService,
        public ts: TranslateService,
        public router: ActivatedRoute,
        public datePipe: DatePipe,
        public storeService: StoreService,
        public categoryService: ProductCategoryService,
        private sanitizer: DomSanitizer,
    ) {
        super(messageService, translateService);
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

    
    public getFileName(): string {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `YokSatanUrunler_${this.detailCaption}_${d2}.xlsx`;
    }

    public bgColorCode(b, g, y, r): SafeStyle {
        let result;
        if (b>g) result = '#33b5e5' // mavi
        else if (b>y) result = '#00C851' // yeşil
        else if (b>r) result = '#ffbb33' // sarı
        else if (b>0) result = '#ff4444' // kırmızı
        else result = '#4B515D' // siyah
        return this.sanitizer.bypassSecurityTrustStyle(result);
    }

    public colorCode(b, r): SafeStyle {
        let result;
        if (b<r) result = '#ffffff' // beyaz
        else result = '#000000' // siyah
        return this.sanitizer.bypassSecurityTrustStyle(result);
    }

    public refreshData() {

    }

    handleDataStateChange(state: DataStateChangeEvent) {

        if (state.sort) {
            this.listParams.sort = state.sort;
        }

        if (state.filter) {
            this.listParams.filter = state.filter;
        }

        this.detailDataActiveList = process(this.detailData, this.listParams);
    }
    

    resultData: any;
    resultDataActiveList: any;
    resultDataLoading: boolean;
    listParams: any;
    summaryResult: any = [];
    totalDayProduct: number = 0;
    totalPrice: number = 0;
    onFilter() {
        this.clearData();
        this.resultDataLoading = true;
        this.dataService.stockOutSummary(this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
            this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd'), this.storeCountSold,
            this.categoryId?this.categoryId:-1).subscribe( list => {

            this.resultData = list.Data;
            this.resultDataLoading = false;

            this.totalDayProduct = 0;
            this.totalPrice = 0;
            this.resultData.forEach(row => {
                this.totalDayProduct += row.DAYPRODUCT_CNT;
                this.totalPrice += row.TOTAL_AMT;
            });
            
        },
        error => {
            console.log(error);
            this.resultDataLoading = false;
        })
    }

    clearData() {
        this.resultData = null;
        this.resultDataActiveList = null;
        this.detailData = null;
        this.detailDataActiveList = null;
        this.totalDayProduct = 0;
        this.totalPrice = 0;
        this.storeDayProductCount = 0;
        this.storeTotalPrice = 0;
    }

    onClear() {
        this.categoryId = null;
    }

    getDetailCaption() {
        return 'Tarih ve Ürün Detayları : '+this.detailCaption;
    }

    storeDayProductCount: number = 0;
    storeTotalPrice: number = 0;

    onStoreSeriesClick(event) {
        this.detailCaption = event.category;
        const storeId = this.resultData.filter(r=>r.STORE_NM===event.category)[0].STOREID;
        this.detailDataLoading = true;
        this.dataService.stockOutStore(this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
        this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd'), this.storeCountSold, storeId,
        this.categoryId?this.categoryId:-1).subscribe( list => {
            this.detailData = list.Data;
            this.detailDataActiveList = list.Data;
            this.detailDataLoading = false;

            this.storeDayProductCount = 0;
            this.storeTotalPrice = 0;
            this.detailData.forEach(row => {
                this.storeDayProductCount += 1;
                this.storeTotalPrice += row.TOTAL_AMT;
            })
        },
        error => {
            this.messageService.error(error);
            this.detailDataLoading = false;
        })
    }

    ngAfterViewInit() {
    }
    
    
    ngOnInit() {
        
        this.listParams = new ListParams();
        this.listParams.pageable = false;
        this.listParams.take = 1000;
        
        if (!this.categoryService.completeList) {
            this.categoryService.listAll();
        }
        
    }

    
    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
