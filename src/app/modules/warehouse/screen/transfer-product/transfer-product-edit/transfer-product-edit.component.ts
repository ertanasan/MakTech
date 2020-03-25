// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { Subscription, Subject, } from 'rxjs';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { TransferProduct } from '@warehouse/model/transfer-product.model';
import { TransferProductService } from '@warehouse/service/transfer-product.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { TransferProductDetailListComponent } from '@warehouse/screen/transfer-product-detail/transfer-product-detail-list/transfer-product-detail-list.component';
import { TransferProductDetailService } from '@warehouse/service/transfer-product-detail.service';
import * as _ from 'lodash';
import { finalize } from 'rxjs/operators';
import { TransferProductDetail } from '@warehouse/model/transfer-product-detail.model';
import { TransferProductStatus } from '@warehouse/model/transfer-product-status.model';
import { TransferProductStatusService } from '@warehouse/service/transfer-product-status.service';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-transfer-product-edit',
    templateUrl: './transfer-product-edit.component.html',
    styleUrls: ['./transfer-product-edit.component.css']
})
export class TransferProductEditComponent extends CRUDDialogScreenBase<TransferProduct> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<TransferProduct>;
    @ViewChild(TransferProductDetailListComponent, {static: true}) detail: TransferProductDetailListComponent;

    isDestReadOnly = false;
    public isPreviousCommentVisible = false;
    isWaybillNoVisible = false;
    isDestinationWarehouseVisible = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: TransferProductService,
        public transferProductDetailService: TransferProductDetailService,
        public storeService: StoreService,
        public transferProductStatusService: TransferProductStatusService,
        public returnDestinationService: ReturnDestinationService,
    ) {
        super(messageService, translateService, dataService, 'Transfer Product');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            TransferProductId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            SourceStore: new FormControl(),
            DestinationStore: new FormControl(),
            ProcessInstance: new FormControl(),
            TransferStatus: new FormControl(),
            PreviousComment: new FormControl(),
            actionComment: new FormControl(),
            // TransferToWarehouse: new FormControl(),
            ProcessStatus: new FormControl(),
            WaybillNo: new FormControl(),
            TargetWarehouse: new FormControl(),
        });
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    // onWarehouseChecked(s) {
    //     if (s && !this.modeContext) {
    //         this.container.mainForm.controls.DestinationStore.setValue(null);
    //         this.container.mainForm.value.DestinationStore = 999;
    //     }
    //     s ? this.isDestReadOnly = true : this.isDestReadOnly = false;
    // }

    onSubmit() {
        // SUBMIT VALIDATION
        if (this.container.actionName !== 'Delete') {
            if (this.container.currentItem.DestinationStore === null) {
                this.messageService.warning(this.translateService.instant('Destination must be selected') + '!');
                return;
            }

            if (this.container.currentItem.TransferStatus === 3 && !this.container.mainForm.get('WaybillNo').value) {
                this.messageService.warning(this.translateService.instant('Waybill No field can not be null') + '!');
                return;
            }

            if (this.container.currentItem.TransferStatus === 4 && this.container.currentItem.DestinationStore === 999 && !this.container.mainForm.get('TargetWarehouse').value) {
                this.messageService.warning(this.translateService.instant('Target Warehouse field can not be null') + '!');
                return;
            }
        }

        // PROCESS PRODUCT DATA
        this.container.currentItem.TransferDetails = this.detail.transferData;

        if ((this.container.actionName === 'Update' || this.container.actionName === 'Review') && this.container.currentItem.TransferProductId > 0) {
            const deletedProducts = _.differenceBy(this.transferProductDetailService.initialItem, this.container.currentItem.TransferDetails, 'TransferProductDetailId');
            const createdProducts = this.container.currentItem.TransferDetails.filter(tp => tp.TransferProductDetailId === 0).map(ctp => { ctp.TransferProduct = this.container.currentItem.TransferProductId; return ctp; });
            const updatedProducts = _.difference(this.container.currentItem.TransferDetails, createdProducts);
            if (deletedProducts.length > 0) {
                this.detail.dataService.deleteAll(deletedProducts.map(u => u.TransferProductDetailId)).subscribe();
            }
            if (createdProducts.length > 0) {
                this.detail.dataService.createAll(createdProducts).subscribe();
            }
            if (updatedProducts.length > 0) {
                this.detail.dataService.updateAll(updatedProducts).subscribe();
            }
        }

        super.onSubmit();

        // CLEAR DETAIL COMPONENT DATA
        this.container.currentItem.TransferDetails = new Array<TransferProductDetail>();
        this.detail.transferData = [];
        this.transferProductDetailService.initialItem = new Array<TransferProductDetail>();
        this.transferProductDetailService.obsData.next(new Array<TransferProductDetail>());
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
