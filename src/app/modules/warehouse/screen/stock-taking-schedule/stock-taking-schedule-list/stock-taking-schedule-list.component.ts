// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { StockTakingScheduleEditComponent } from '@warehouse/screen/stock-taking-schedule/stock-taking-schedule-edit/stock-taking-schedule-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CountingTypeService } from '@warehouse/service/counting-type.service';
import { CountingStatusService } from '@warehouse/service/counting-status.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { Router } from '@angular/router';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-taking-schedule-list',
    templateUrl: './stock-taking-schedule-list.component.html',
    styleUrls: ['./stock-taking-schedule-list.component.css', ]
})
export class StockTakingScheduleListComponent extends ListScreenBase<StockTakingSchedule> implements AfterViewInit, OnInit, OnDestroy {
    @ViewChild(StockTakingScheduleEditComponent, {static: true}) editScreen: StockTakingScheduleEditComponent;
    store: Store;
    updateCompletedCounting = false;
    branchType: any;
    isHeadQuarter: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StockTakingScheduleService,
        public storeService: StoreService,
        public countingTypeService: CountingTypeService,
        public countingStatusService: CountingStatusService,
        public route: Router,
        private privilegeCacheService: PrivilegeCacheService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.dataService.keepListParams !== null && this.dataService.keepListParams !== undefined) {
            this.dataService.activeList = this.dataService.keepActiveList;
            this.listParams = this.dataService.keepListParams;
            this.dataService.activeListChanged.next(this.dataService.activeList);
            this.dataService.keepActiveList = null;
            this.dataService.keepListParams = null;
        } else {
            this.dataService.list(this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'StockTaking Schedule', RouterLink: '/warehouse/stock-taking-schedule'}];
    }

    createEmptyModel(): StockTakingSchedule {
        // this.editScreen.countingStatusReadOnly = false;
        return new StockTakingSchedule();
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.countingStatusReadOnly = true;
        if (!dataItem || dataItem.CountingStatus !== 2 || this.updateCompletedCounting) {
            this.editScreen.countingStatusReadOnly = false;
        }
        super.showDialog(target, actionName, dataItem);
    }

    ngOnInit() {

        this.privilegeCacheService.checkPrivilege('Update Completed Counting').subscribe(
            result => {
                this.updateCompletedCounting = false;
                if (result) {
                    this.updateCompletedCounting = true;
                }
                // console.log(this.updateCompletedCounting);
        });

        const initPromiseArr = [];
        initPromiseArr.push(this.storeService.listUserStores().toPromise());
        initPromiseArr.push(this.countingTypeService.listAllAsync().toPromise());
        initPromiseArr.push(this.countingStatusService.listAllAsync().toPromise());

        Promise.all(initPromiseArr).then(resultArray => {
            this.storeService.userStores = resultArray[0];
            this.countingTypeService.completeList = resultArray[1];
            this.countingStatusService.completeList = resultArray[2];

            if (resultArray[0].length === 1) {
                this.store = resultArray[0][0];
            } else {
                this.store = null;
                if (resultArray[0].length > 0) {
                    this.branchType = this.storeService.userStores[0].UserBranchType;
                    this.isHeadQuarter = (this.branchType === 'Central Office');
                    if (this.isHeadQuarter) {
                        const warehouse = new Store();
                        warehouse.StoreId = 999;
                        warehouse.Name = 'MERKEZ DEPO';
                        this.storeService.userStores.unshift(warehouse);
                    }
                }
            }

            super.ngOnInit();
        });
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['ActualDate', 'PlannedDate'];
        super.handleDataStateChange(state);
    }

    ngOnDestroy() {
        if (this.route.routerState.snapshot.url.indexOf('/Warehouse/StockTaking/') === 0) {
            this.dataService.keepParams(this.listParams, this.dataService.activeList);
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
