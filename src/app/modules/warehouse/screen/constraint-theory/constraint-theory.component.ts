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
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { DomSanitizer, SafeStyle  } from '@angular/platform-browser';
import { ProductShipmentUnitService } from '@warehouse/service/product-shipment-unit.service';

@Component({
    selector: 'ot-constraint-theory',
    templateUrl: './constraint-theory.component.html',
    styleUrls: ['./constraint-theory.component.css']
})
export class ConstraintTheoryComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    storeId: number;
    productId: number;
    startDate: Date = new Date('2018-09-01');
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
        public datePipe: DatePipe,
        public storeService: StoreService,
        public productService: ProductService,
        private sanitizer: DomSanitizer,
        public productShipmentUnitService: ProductShipmentUnitService
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
        return `KisitlarSonuc_${this.storeId}_${this.productId}_${this.startBuffer}_${this.shipmentUnit}_${this.greenCycle}_${d2}.xlsx`;
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

    handleStateChange(state: DataStateChangeEvent, gridGroup: number) {

        if (state.sort) {
            switch (gridGroup) {
                case 1 : 
                    this.listParams.sort = state.sort;
                    this.resultDataActiveList = process(this.resultData, this.listParams);
                    break;
            }
        }

        if (state.filter) {
            switch (gridGroup) {
                case 1 : 
                    this.listParams.filter = state.filter;
                    this.resultDataActiveList = process(this.resultData, this.listParams);
                    break;
            }
        }
    }
    

    resultData: any;
    resultDataActiveList: any;
    resultDataLoading: boolean;
    listParams: any;
    summaryResult: any = [];
    onFilter() {
        this.resultDataLoading = true;
        this.dataService.constraintTheory(this.storeId, this.productId, 
            this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
            this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd'), 
            this.startBuffer, this.shipmentUnit, this.greenCycle, this.bufferBandwith, this.ceiling).subscribe( list => {

            this.resultData = list[0].Data;
            this.resultDataActiveList = list[0].Data;
            this.resultDataLoading = false;
            
            this.summaryResult = [];
            for (let key in list[1].Data[0]) {
                this.summaryResult.push({'Measure':key, 'Value':list[1].Data[0][key]});
            }
        },
        error => {
            console.log(error);
            this.resultDataLoading = false;
        })
    }

    
    ngAfterViewInit() {
    }
    
    topDaysData: any;
    topDaysDataLoading: boolean = false;
    getTopSellingDayGroups() {
        this.topDaysDataLoading = true;
        this.dataService.topSaleDayGroup(this.storeId, this.productId, 
            this.datePipe.transform(new Date(this.startDate), 'yyyy-MM-dd'),
            this.datePipe.transform(new Date(this.endDate), 'yyyy-MM-dd')).subscribe(list => {
            this.topDaysData = list.Data;
            this.topDaysDataLoading = false;
        },
        error => {
            console.log(error);
            this.topDaysDataLoading = false;
        });
    }

    onProductValueChange(e) {
        const urow = this.productShipmentUnitService.completeList.filter(r=>(r.Product === e));
        
        if (urow.length === 1) {
            this.shipmentUnit = urow[0].PackageQuantity;
        }

        if (this.storeId && this.startDate && this.endDate) {
            this.getTopSellingDayGroups();
        }
    }

    onStoreValueChange(e) {
        if (this.productId && this.startDate && this.endDate) {
            this.getTopSellingDayGroups();
        }
    }

    ngOnInit() {
        
        this.listParams = new ListParams();
        this.listParams.pageable = false;
        this.listParams.take = 1000;
        
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        if (!this.productShipmentUnitService.completeList) {
            this.productShipmentUnitService.listAll();
        }
    }

    
    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }


}
