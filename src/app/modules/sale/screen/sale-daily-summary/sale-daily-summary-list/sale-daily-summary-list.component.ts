// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { SaleDailySummary } from '@sale/model/sale-daily-summary.model';
import { SaleDailySummaryService } from '@sale/service/sale-daily-summary.service';
import { SaleDailySummaryEditComponent } from '@sale/screen/sale-daily-summary/sale-daily-summary-edit/sale-daily-summary-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { UserService } from '@frame/security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-daily-summary-list',
    templateUrl: './sale-daily-summary-list.component.html',
    styleUrls: ['./sale-daily-summary-list.component.css', ]
})
export class SaleDailySummaryListComponent extends ListScreenBase<SaleDailySummary> implements AfterViewInit, OnInit {
    @ViewChild(SaleDailySummaryEditComponent, {static: true}) editScreen: SaleDailySummaryEditComponent;

    transactionDate: Date;
    zetList: any;
    zetActiveList: any;
    zetLoading: boolean = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SaleDailySummaryService,
        public storeService: StoreService,
        public datePipe: DatePipe,
        public userService: UserService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.zetList) {
            this.zetActiveList = process(this.zetList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Sale' }, {Caption: 'Sale Daily Summary', RouterLink: '/sale/sale-daily-summary'}];
    }

    createEmptyModel(): SaleDailySummary {
        let sd =  new SaleDailySummary();
        sd.TransactionDate = this.transactionDate;
        sd.Event = 1045;
        sd.Organization = 1;
        return sd;
    }

    refreshData() {
        this.getDateList();
        this.refreshList();
    }

    getDateList() {
        
        let d = new Date(this.transactionDate);
        const transactionDateString = this.datePipe.transform(d, 'yyyy-MM-dd');
        this.zetLoading = true;
        this.dataService.listDate(transactionDateString).subscribe(result => {
            this.zetList = result;
            this.refreshList();
            this.zetLoading = false;
        },
        error => {
            this.messageService.error(error);
            this.zetLoading = false;
        });
    }
    ngOnInit() {
        this.transactionDate = new Date();
        this.transactionDate.setDate(this.transactionDate.getDate() - 1);
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }

        if (!this.userService.completeList) {
            this.userService.listAll();
        }
        this.getDateList();
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = state.skip;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {

        if (actionName === 'Update') {
            this.editScreen.storeID.isReadOnly = true;
        }
        super.showDialog(target, actionName, dataItem);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
