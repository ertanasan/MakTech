import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnDestroy, OnInit, SimpleChange, SimpleChanges, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { ListParams } from '@otmodel/list-params.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MenuItem } from '@otui/control/menu/menuitem';
import { DataStateChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { process } from '@progress/kendo-data-query';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { SalesService } from '@sale/service/sales.service';
import * as _ from 'lodash';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { SeriesItemComponent } from '@progress/kendo-angular-charts';


@Component({
    selector: 'ot-cancel-details',
    templateUrl: './cancel-details.component.html',
    styleUrls: ['./cancel-details.component.css']
})
export class CancelDetailComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {
    @ViewChild('kendoref', {static: true}) kendoRef: SeriesItemComponent;

    // @ViewChild('kendoct') kendoRef2;
    public startDate: Date;
    public endDate: Date;
    public endChangeDate: Date;
    public weeklyCancelList: any;
    chartColors;
    storeCancelList;
    storeCancelDetailList;
    ActiveDetailList;
    totalPrice: number;
    totalCancel: number;
    groupedData: any = [];
    storeName;
    cashierName;
    sDList;
    detailProcess: any = [];
    ActiveList;
    chartHeight = 600;
    listParams: any;
    listParams2;
    listParams3;
    OKListParams: any;
    storeId;
    Total: String = 'TOTAL';
    public groupedList: {
        date: Date,
        storeName: string,
        cashierName: string,
        saleId: number,
        totalAmt: number,
        tatalPrice: number,
        details: any[]
    }[] = [];
    day = 15;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private utility: OTUtilityService,
        public saleService: SalesService,
        public ts: TranslateService,
        public router: ActivatedRoute,
        public datePipe: DatePipe,
        public saleDetailService: SaleDetailService,
        public route: Router
    ) {
        super(messageService, translateService);
        this.chartColors = this.utility.colors.map(c => c.hex);
        this.allData = this.allData.bind(this);
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



    ngAfterViewInit() {
    }

    refreshData() {

    }


    ngOnInit() {

        // this.startDate = new Date(this.router.snapshot.queryParams['start']);
        // this.endDate = new Date(this.router.snapshot.queryParams['end']);



        this.router.params.subscribe(d => {

            this.startDate = new Date(d['start']);
            this.endDate = new Date(d['end']);

            this.saleDetailService.weeklyCancels(
                this.datePipe.transform(this.startDate, 'yyyy-MM-dd'),
                this.datePipe.transform(this.endDate, 'yyyy-MM-dd')).subscribe(list => {

                    this.weeklyCancelList = list.Data;

                }, error => {
                    this.messageService.error(error);
                });

            //           Object.assign(this.endChangeDate,this.endDate);
            this.router.queryParams.subscribe(a => {
                this.storeId = a['storeId'];
                this.storeName = a['storeName'];
                if (this.storeId) {
                    this.ActiveDetailList = [];
                    this.saleDetailService.listCancel(this.startDate, this.endDate, this.storeId).subscribe(list => {
                        this.ActiveDetailList = _.sortBy(list.Data, 'CANCELTOTAL_AMT').reverse();
                        this.groupedList = [];
                        this.groupedData = _.map(_.groupBy(this.ActiveDetailList, 'SALEID'), f => {

                            this.groupedList.push({
                                storeName: this.storeName,
                                date: f[0].TRANSACTION_DT,
                                saleId: f[0].SALEID,
                                totalAmt: f[0].TOTAL_AMT,
                                cashierName: f[0].CASHIER_NM,
                                tatalPrice: _.sumBy(_.filter(f, ['CANCEL_FL', 'Y']), 'PRICE'),
                                details: f
                            });
                            _.toArray(f);
                        }

                        );

                        this.storeCancelDetailList = _.sortBy(this.groupedList, 'tatalPrice').reverse();
                        this.sDList = this.storeCancelDetailList;
                    });
                }
            });

            this.saleDetailService.listCancelDetail(this.startDate, this.endDate).subscribe(list => {
                this.ActiveList = _.sortBy(list.Data, 'CANCELRATE_PCT').reverse();
                this.storeCancelList = this.ActiveList;

                this.totalPrice = _.sumBy(list.Data, 'TOTAL');
                this.totalCancel = _.sumBy(list.Data, 'PRICE');

            });


        });

        this.listParams = new ListParams();
        this.listParams.take = 1000;

        this.listParams2 = new ListParams();
        this.listParams2.take = 1000;



    }

    // consol(){

    //      this.kendoRef.xField==='TOTAL'?this.Total='CANCEL_QTY':this.Total='TOTAL';
    //  // console.log( this.kendoRef.xField);


    // }
    storeDataStateChange(state: DataStateChangeEvent, select: number) {

        this.listParams.skip = 0;
        this.listParams.take = 1000;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        if (select === 1) {
            this.ActiveList = process(this.ActiveList, this.listParams).data;
        }
        if (select === 2) {
            if (this.storeCancelDetailList) {
                if (!(this.storeCancelDetailList.date instanceof String)) {
                    this.storeCancelDetailList.map(t => {
                        t.date = new Date(t.date);
                    });
                }
            }
            this.sDList = process(this.storeCancelDetailList, this.listParams).data;
        }

    }
    // SaleDataStateChange(state: DataStateChangeEvent ) {


    //     this.listParams2.skip = 0;
    //     this.listParams2.take = 1000;
    //     if (state.sort) {
    //         this.listParams2.sort = state.sort;
    //     }
    //     if (state.filter) {
    //        this.listParams2.filter = state.filter;
    //     }
    //     if (state.group) {
    //       this.listParams2.group = state.group;
    //     }

    //     this.storeCancelDetailList = process(this.groupedList, this.listParams2);

    // }
    SaleDataStateChange2(state: DataStateChangeEvent, index: number) {


        this.listParams2.skip = 0;
        this.listParams2.take = 1000;
        if (state.sort) {
            this.listParams2.sort = state.sort;
        }
        if (state.filter) {
            this.listParams2.filter = state.filter;
        }
        if (state.group) {
            this.listParams2.group = state.group;
        }

        // this.groupedList[index].details  = process(this.groupedList[index].details, this.listParams3).data;
        //  this.storeCancelDetailList[index].details=  this.groupedList[index].details ;

        this.storeCancelDetailList[index].details = process(this.storeCancelDetailList[index].details, this.listParams2).data;

    }
    dayChange(day: number = this.day) {

        // this.startDate=Object.assign({},this.endDate);////!!!!!!!çalışmıyor
        // console.log('a', this.startDate, this.endDate);
        // Object.assign(this.endChangeDate,this.endDate);
        this.day = day;
        this.startDate = new Date(this.endDate);
        this.startDate.setDate(this.endDate.getDate() - day + 1);
        this.route.navigate(['/OverStoreMain/CancelDetails', this.startDate.toISOString().slice(0, 10), this.endDate.toISOString().slice(0, 10)], { queryParams: { storeId: this.storeId, storeName: this.storeName } });
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }

    onSeriesClick(event) {

        this.route.navigate([], { relativeTo: this.router, queryParams: { storeId: event.dataItem.STORE, storeName: event.dataItem.STORE_NM }, queryParamsHandling: 'merge' });

    }

    getDetailListCaption() {
        return `İptal Fişler - ${this.storeName}`;
    }

    allData() {
        const lp: ListParams = new ListParams();
        lp.pageable = false;
        lp.take = 200000;
        const filteredList = process(this.groupedList, lp);
        // console.log(filteredList);
        return filteredList;
    }

}


