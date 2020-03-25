// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { TransferProduct } from '@warehouse/model/transfer-product.model';
import { TransferProductService } from '@warehouse/service/transfer-product.service';
import { TransferProductStatusService } from '@warehouse/service/transfer-product-status.service';
import { TransferProductEditComponent } from '@warehouse/screen/transfer-product/transfer-product-edit/transfer-product-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { TransferProductDetailListComponent } from '@warehouse/screen/transfer-product-detail/transfer-product-detail-list/transfer-product-detail-list.component';
import { TransferProductDetail } from '@warehouse/model/transfer-product-detail.model';
import { finalize } from 'rxjs/operators';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-transfer-product-list',
    templateUrl: './transfer-product-list.component.html',
    styleUrls: ['./transfer-product-list.component.css']
})
export class TransferProductListComponent extends ListScreenBase<TransferProduct> implements AfterViewInit, OnInit {
    @ViewChild(TransferProductEditComponent, {static: true}) editScreen: TransferProductEditComponent;
    @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;

    store: Store;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: TransferProductService,
        public transferProductStatusService: TransferProductStatusService,
        public storeService: StoreService,
        public returnDestinationService: ReturnDestinationService,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Warehouse' }, { Caption: 'Transfer Product', RouterLink: '/warehouse/transfer-product' }];
    }

    createEmptyModel(): TransferProduct {
        const model = new TransferProduct();
        if (!this.modeReview && this.editScreen.container.actionName === 'Create') {
            model.SourceStore = this.store.StoreId;
            model.TransferStatus = 1;
            this.editScreen.isPreviousCommentVisible = false;
        }
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        this.readEnabled = true;
        this.storeService.listUserStores().subscribe(list => {
            if (list.length === 1) {
                this.store = list[0];
                this.deleteEnabled = false;
            } else {
                this.store = null;
                this.createEnabled = false;
                this.updateEnabled = true;
            }
        });

        this.storeService.listStoresAndWarehouses();
        this.transferProductStatusService.listAll();
        this.returnDestinationService.listAll();
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const transferProductId = this.modeContext.id;
            this.dataService.read(transferProductId).subscribe(transferProduct => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), transferProduct);
                this.showDialog(this.editScreen, 'Review', dataItem);
            });
        }
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (actionName === 'ShowHistory') {
            this.historyScreen.ProcessInstanceId = dataItem.ProcessInstance;
            this.historyScreen.dialog.show();
        } else {
            this.editScreen.transferProductDetailService.obsData.next(new Array<TransferProductDetail>());
            Object.assign(this.editScreen.transferProductDetailService.initialItem, new Array<TransferProductDetail>());
            if (dataItem) {
                this.editScreen.transferProductDetailService.obsData.next(dataItem.TransferDetails);
                this.editScreen.transferProductDetailService.initialItem = JSON.parse(JSON.stringify(dataItem.TransferDetails));

                this.editScreen.isPreviousCommentVisible = dataItem.TransferStatus > 2 ? true : false;
                this.editScreen.isWaybillNoVisible = dataItem.TransferStatus > 2 ? true : false;
                this.editScreen.isDestinationWarehouseVisible = dataItem.TransferStatus > 3 && dataItem.DestinationStore === 999 ? true : false;
                dataItem.DestinationStore === 999 ? dataItem.TransferToWarehouse = true : dataItem.TransferToWarehouse = false;
            }
            this.editScreen.detail.isReadOnly = actionName === 'Read' ? true : false;
            this.editScreen.detail.transferProductChanged.next({'dataItem': actionName !== 'Create' ? dataItem : null, 'store': (this.store && this.store !== null) ? this.store : null});
            super.showDialog(target, actionName, dataItem);
        }
    }

    send(dataItem: TransferProduct) {
        if (dataItem.TransferDetails.length === 0) {
            this.messageService.error(this.translateService.instant('En az bir ürün eklemelisiniz', { 0: 'Hata:' }));
        } else {
            dataItem.DestinationStore === 999 ? dataItem.TransferToWarehouse = true : dataItem.TransferToWarehouse = false;
            this.dataService.send(dataItem).pipe(
                finalize(() => {
                    this.refreshData();
                })
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant('Talep Gönderildi', { 0: 'Başarılı:' }));
                },
                error => {
                    console.log(error);
                    this.messageService.error(this.translateService.instant('Talep Gönderilemedi', { 0: 'Hata Oluştu:' }));
                }
            );
        }
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate'];
        super.handleDataStateChange(state);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
