// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { ReconciliationEditComponent } from '@reconciliation/screen/reconciliation/reconciliation-edit/reconciliation-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { DiffReasonService } from '@reconciliation/service/diff-reason.service';
import { CashDistributionService } from '@reconciliation/service/cash-distribution.service';
import { CardDistributionService } from '@reconciliation/service/card-distribution.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ListParams } from '@otmodel/list-params.model';
import { ZetImageViewComponent } from '@reconciliation/screen/zet-image-view/zet-image-view.component';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { PhotoStatus } from '@reconciliation/screen/zet-image/zet-image.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-reconciliation-view',
    templateUrl: './reconciliation-view.component.html',
    styleUrls: ['./reconciliation-view.component.css', ]
})
export class ReconciliationViewComponent extends ListScreenBase<Reconciliation> implements AfterViewInit, OnInit {

    @ViewChild(ReconciliationEditComponent, {static: true}) editScreen: ReconciliationEditComponent;
    @ViewChild(ZetImageViewComponent, {static: true}) zetImageViewScreen: ZetImageViewComponent;
    @ViewChild(CustomDialogComponent, {static: true}) notReconStores: CustomDialogComponent;

    notReconList;
    storeList: Store[];
    storeListLoading: any;
    selectedStoreId = -1;
    selectedStore: Store;
    startDate: Date;
    endDate: Date;
    rec: Reconciliation[];
    recActiveList: any;
    authorized = false;
    recLoading: boolean;
    authorization: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReconciliationService,
        public storeService: StoreService,
        public datePipe: DatePipe,
        public currencyPipe: CurrencyPipe,
        public cashDistService: CashDistributionService,
        public cardDistService: CardDistributionService,
        public diffReasonService: DiffReasonService,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    allData() {
        const lp = new ListParams();
        lp.pageable = false;
        lp.take = 200000;
        const filteredList = process(this.rec, lp);
        return filteredList;
    }

    refreshList() {
        if (this.rec) {
            this.recActiveList = process(this.rec, this.listParams);
        }
    }

    refreshData() {
        this.onFilter();
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Reconciliation', RouterLink: '/reconciliation/reconciliation'}];
    }

    createEmptyModel(): Reconciliation {
        return new Reconciliation();
    }


    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.toRead = false;
        this.editScreen.toUpdate = false;
        this.editScreen.toDelete = false;
        if (actionName === 'Read') {
            this.editScreen.toRead = true;
            // console.log(dataItem.StoreReconciliationId);
            this.editScreen.StoreReconciliationId = dataItem.StoreReconciliationId;
        } else if (actionName === 'Update') {
            this.editScreen.toUpdate = true;
        } else if (actionName === 'Delete') {
            this.editScreen.toDelete = true;
        }
        super.showDialog(target, actionName, dataItem);
    }

    onStoreSelected(event) {
        // console.log(event);
        if (event.StoreId) {
            this.selectedStoreId = event.StoreId;
        } else {
            this.selectedStoreId = event;
        }
        this.selectedStore = this.storeList.filter(row => (row.StoreId === this.selectedStoreId))[0];
    }

    addAllStores() {
        const allStore = new Store();
        allStore.StoreId = -1;
        allStore.Name = 'Tüm Mağazalar';
        this.storeList.push(allStore);
    }

    ngOnInit() {
        if (!this.diffReasonService.completeList) {
            this.diffReasonService.listAll();
        }
        this.storeListLoading = true;
        this.storeService.listUserStores().subscribe(result => {
            this.storeList = result;
            this.storeListLoading = false;

            if (result[0].UserBranchType === 'Central Office') {
                this.authorization = 'HQ';
            } else {
                this.authorization = 'ST';
            }

            // console.log(this.storeList.length);
            if (this.storeList.length === 1) {
                this.selectedStore = this.storeList[0];
                this.selectedStoreId = this.storeList[0].StoreId;
                // console.log(this.selectedStoreId);
                this.authorized = false;
            } else {
                this.authorized = true;
                this.addAllStores();
                this.storeList.sort(function (a, b) {
                    if (a.StoreId < b.StoreId) {
                      return -1;
                    } else if (a.StoreId > b.StoreId) {
                      return 1;
                    }
                    return 0;
                  });
            }
        }, error => {
            this.messageService.error(error);
            this.storeListLoading = false;
        });

        const d = new Date();
        d.setDate(d.getDate() - 1);
        this.endDate = new Date(this.datePipe.transform(d, 'yyyy-MM-dd'));
        d.setDate(d.getDate() - 6);
        this.startDate = new Date(this.datePipe.transform(d, 'yyyy-MM-dd'));
        super.ngOnInit();
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        // this.listParams.dateFields = ['ReconciliationDate', 'UpdateDate'];
        super.handleDataStateChange(state);
    }


    onFilter() {
        this.recLoading = true;
        // console.log(this.selectedStoreId);
        this.dataService.ReconciliationStoreDate(this.selectedStoreId,
            this.datePipe.transform(this.startDate, 'yyyy-MM-dd'),
            this.datePipe.transform(this.endDate, 'yyyy-MM-dd')).subscribe(result => {
            // console.log(result);
            this.rec = result;
            ((<Reconciliation[]>this.rec)).map(t => {
                t.AllowCancel = (t.ReconciliationDate === t.LastReconciliationDate);
                t.ReconciliationDate = new Date(t.ReconciliationDate);
                t.UpdateDate = new Date(t.UpdateDate);
                t.LastReconciliationDate = new Date(t.LastReconciliationDate);
            });
            this.recLoading = false;
            this.rec.forEach(row => {
                let reasoncodes = '';
                if (row.DiffReasonCodes && row.DiffReasonCodes.length > 0) {
                    const x = row.DiffReasonCodes.split(',');
                    x.forEach(a => {
                        if ( parseInt(a, 10) > 0) {
                            const reason = this.diffReasonService.completeList.filter(r => r.DiffReasonId === parseInt(a, 10));
                            if (reason.length > 0) {
                                if (reasoncodes.length > 0) {
                                    reasoncodes += '; ' + this.diffReasonService.completeList.filter(r => r.DiffReasonId === parseInt(a, 10))[0].ReasonName;
                                } else {
                                    reasoncodes = this.diffReasonService.completeList.filter(r => r.DiffReasonId === parseInt(a, 10))[0].ReasonName;
                                }
                            }
                        }
                    });
                }
                row['ReasonCodes'] = reasoncodes;
            });
            this.refreshList();
        },
        error => {
            this.recLoading = false;
            this.messageService.error(error);
        });
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    getxlsFileName() {
        if (this.selectedStore) {
            return `Mutabakat_${this.selectedStore.Name}_${this.datePipe.transform(this.startDate, 'dd.MM.yyyy')}-${this.datePipe.transform(this.endDate, 'dd.MM.yyyy')}.xlsx`;
        } else {
            return 'Mutabakat.xlsx';
        }
    }

    onZetImageViewClicked(dataItem: Reconciliation) {

        this.zetImageViewScreen.dialog.caption = `${dataItem.StoreName} - ${this.datePipe.transform(dataItem.ReconciliationDate, 'dd.MM.yyyy')} - ` + this.translateService.instant('Zet Photos');
        this.zetImageViewScreen.reconciliationId = dataItem.StoreReconciliationId;
        this.zetImageViewScreen.zetPhotos = [];

        this.zetImageViewScreen.camera.listCashRegisters(dataItem.Store);
        this.zetImageViewScreen.camera.zetPhoto = null;
        this.zetImageViewScreen.camera.cameraStatus = PhotoStatus.StandBy;
        // this.zetImageViewScreen.camera.setPhotoArea();
        this.zetImageViewScreen.refreshData();
        this.zetImageViewScreen.dialog.show();
    }


    onNotReconStores() {
        this.dataService.NotReconStores(this.datePipe.transform(this.startDate, 'yyyy-MM-dd'), this.datePipe.transform(this.endDate, 'yyyy-MM-dd')).subscribe(list => {
            this.notReconList = {data: list.Data, total: list.Total};
            this.notReconStores.caption = `${'Mutabakat Yapmayanlar'} - ${this.datePipe.transform(this.startDate, 'dd.MM.yyyy')} - ${this.datePipe.transform(this.endDate, 'dd.MM.yyyy')}`;
            this.notReconStores.show();
        });

    }
}
