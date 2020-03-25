import { TranslateService } from '@ngx-translate/core';
import { OnInit, OnDestroy, AfterViewInit, Component, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';


import { MenuItem } from '@otui/control/menu/menuitem';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MainScreenBase } from '@otcommon/screen-base/main-screen-base';
import { SalesService } from '@sale/service/sales.service';
import { ListParams } from '@otmodel/list-params.model';
import { process, SortDescriptor, aggregateBy, FilterDescriptor, filterBy, CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { SelectableSettings, DataStateChangeEvent, GridComponent, GridDataResult } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { ProductPriceService } from '@price/service/product-price.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { StoreService } from '@store/service/store.service';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { SaleInvoiceEditComponent } from '@accounting/screen/sale-invoice/sale-invoice-edit/sale-invoice-edit.component';
import { ListScreenContainerComponent } from '@otuiscreen/list-screen-container/list-screen-container.component';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

@Component({
    selector: 'ot-drill-count-performance',
    templateUrl: './drill-count-performance.component.html',
    styleUrls: ['./drill-count-performance.component.css']
})
export class DrillCountPerformanceComponent extends MainScreenBase implements OnInit, OnDestroy, AfterViewInit {

    @ViewChild(CustomDialogComponent, { static: true }) perfStoreDetail: CustomDialogComponent;

    public branchType: string;
    public dcPerfList: any;
    public dcPerfDetailList: any;
    public dcPerfActiveList: any;
    public dcPerfDetailActiveList: any;
    public listParams: any;
    public listParamsDetail: any;

    perfLoading: boolean;
    perfDetailLoading: boolean;
    isHeadQuarter: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private utility: OTUtilityService,
        public stockTakingScheduleService: StockTakingScheduleService,
        public ts: TranslateService,
        public router: ActivatedRoute,
        public datePipe: DatePipe,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
        this.allDetailData = this.allDetailData.bind(this);
    }

    public allData(): any {

        let newList = JSON.parse(JSON.stringify(this.dcPerfList));
        newList.forEach(row => {
            let d: Date = new Date(row.LASTCOUNTING_DT);
            row.LASTCOUNTING_DT = d.toLocaleDateString();
        })
        return <GridDataResult> {
            data: newList,
            total: newList.length
        };
    }

    public allDetailData(): any {
        return <GridDataResult> {
            data: this.dcPerfDetailList,
            total: this.dcPerfDetailList.count
        };
    }

    ngAfterViewInit() {
    }

    refreshData() {

    }


    ngOnInit() {
        this.listParams = new ListParams();
        this.listParamsDetail = new ListParams();
        this.isHeadQuarter = false;
        if (this.storeService.userStores) {
            this.branchType = this.storeService.userStores[0].UserBranchType;
            this.isHeadQuarter = (this.branchType === 'Central Office');
        } else {
            this.storeService.listUserStores().subscribe(storeList => {
                this.branchType = storeList[0].UserBranchType;
                this.isHeadQuarter = (this.branchType === 'Central Office');
            });
        }
        this.perfLoading = true;
        this.stockTakingScheduleService.DrillCountPerformance().subscribe(list => {
            this.dcPerfList = list.Data;
            this.dcPerfActiveList = process(this.dcPerfList, this.listParams);
            this.perfLoading = false;
        }, error => {
            this.messageService.error(error.error.Message);
            console.log(error);
            this.perfLoading = false;
        });
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = state.skip;
        this.listParams.take = state.take;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.dcPerfActiveList = process(this.dcPerfList, this.listParams);
    }

    handleDetailDataStateChange(state: DataStateChangeEvent) {
        this.listParamsDetail.skip = state.skip;
        this.listParamsDetail.take = state.take;
        if (state.sort) {
            this.listParamsDetail.sort = state.sort;
        }
        if (state.filter) {
            this.listParamsDetail.filter = state.filter;
        }
        if (state.group) {
            this.listParamsDetail.group = state.group;
        }
        this.dcPerfDetailActiveList = process(this.dcPerfDetailList, this.listParamsDetail);
    }

    getBreadcrumbItems(): MenuItem[] {
        return null;
    }

    createEmptyItem() {
        throw new Error('Method not suported.');
    }

    public exportToExcel(grid: GridComponent): void {
        grid.saveAsExcel();
    }

    getFileName(gridName: string) {
        const d: Date = new Date();
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `${gridName}_${d2}.xlsx`;
    }

    onClickStore(dataItem) {
        this.perfDetailLoading = true;
        this.stockTakingScheduleService.DrillCountPerformanceDetail(dataItem.STORE).subscribe(result => {
            this.dcPerfDetailList = result.Data;
            this.dcPerfDetailActiveList = process(this.dcPerfDetailList, this.listParamsDetail);
            this.perfDetailLoading = false;
            this.perfStoreDetail.show();
        }, error => {
            this.messageService.error(error.error.Message);
            console.log(error);
            this.perfDetailLoading = false;
        });
    }
}
