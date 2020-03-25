import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { StoreReconciliation } from '@reconciliation/model/store-reconciliation.model';
import { StoreReconciliationService } from '@reconciliation/service/store-reconciliation.service';
import { StoreReconciliationEditComponent } from '@reconciliation/screen/store-reconciliation/store-reconciliation-edit/store-reconciliation-edit.component';
import { StoreService } from '@store/service/store.service';
import { process, SortDescriptor, aggregateBy } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';

@Component({
    selector: 'ot-store-reconciliation-list',
    templateUrl: './store-reconciliation-list.component.html',
    styleUrls: ['./store-reconciliation-list.component.css',]
})
export class StoreReconciliationListComponent extends ListScreenBase<StoreReconciliation> implements AfterViewInit, OnInit {
    @ViewChild(StoreReconciliationEditComponent, {static: true}) editScreen: StoreReconciliationEditComponent;

    reconciliationDate = new Date();


    public aggregates_c1: any[] =
        [{field: 'CashTotal', aggregate: 'sum'},
         {field: 'CardTotal', aggregate: 'sum'}];

    public total_c1: any;



    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreReconciliationService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    public group: any[] = [{
        field: 'TransactionDate'
    }];

    public sort: any[] = [{
        field: 'StoreID', dir: 'asc' 
    }];

    public allData(): ExcelExportData {
        const result: ExcelExportData =  {
            data: process(this.dataService.reconciliations_filtered, { group: this.group, sort: [{ field: 'StoreID', dir: 'asc' }] }).data,
            group: this.group
        };

        return result;
    }

    refreshList() {
        if (this.dataService.reconciliations) {
            this.dataService.reconciliations_filtered = process(this.dataService.reconciliations, this.listParams);
        }
        
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Reconciliation' }, { Caption: 'Store Reconciliation', RouterLink: '/reconciliation/store-reconciliation' }];
    }

    createEmptyModel(): StoreReconciliation {
        return new StoreReconciliation();
    }

    ngOnInit() {
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    listReconciliations() {
        this.dataService.getStoreReconciliationList(this.reconciliationDate);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.take = 1000;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        this.refreshList();
    }
    
    approveReconciliations(reconciliationID) {

        let approveAll = "Tamamlanmış ancak muhasebe onayı verilmemiş tüm mutabakatlar onaylanacak ve muhasebe sistemine aktarılacaktır. Emin misiniz?";
        let approveSingle = "Muhasebe sistemine aktarılacak. Emin misiniz?";

        if (confirm((reconciliationID=0)?approveAll:approveSingle)){
            this.dataService.approveReconciliations(this.reconciliationDate, reconciliationID).subscribe(
                result => {
                    this.messageService.success("Onaylama işlemi başarılı.");
                    this.listReconciliations();
                    this.total_c1 = aggregateBy(this.dataService.reconciliations, this.aggregates_c1);
                    this.refreshList();
                },
                error => {
                    this.messageService.error("Bir hata oluştu. " + error);
                }
            );
        }
    }
    // exportReportData() {
    //     this.dataService.exportReconciliations(this.dataService.reconciliations_filtered);
    // }

}
