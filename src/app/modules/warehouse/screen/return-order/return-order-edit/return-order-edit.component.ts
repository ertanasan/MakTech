// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ReturnOrder } from '@warehouse/model/return-order.model';
import { ReturnOrderService } from '@warehouse/service/return-order.service';
import { StoreService } from '@store/service/store.service';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { ProductService } from '@product/service/product.service';
import { ProductReturnListComponent } from '@warehouse/screen/product-return/product-return-list/product-return-list.component';
import { ReturnOrderDialogComponent } from '../return-order-dialog/return-order-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-order-edit',
    templateUrl: './return-order-edit.component.html',
    styleUrls: ['./return-order-edit.component.css', ]
})
export class ReturnOrderEditComponent extends CRUDDialogScreenBase<ReturnOrder> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ReturnOrder>;
    @ViewChild(ProductReturnListComponent, {static: true}) detailScreen: ProductReturnListComponent;
    @ViewChild(ReturnOrderDialogComponent, {static: true}) dialogScreen: ReturnOrderDialogComponent;

    isCreate: boolean;
    @Input() history: any;
    @Input() viewDetails: boolean;
    returnOrderId: any;
    showDetails = false;
    StoreList: number[] = [];
    allStoresFlag: boolean;
    storeListReadOnly: boolean;
    storeId: number;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ReturnOrderService,
        public storeService: StoreService,
        public returnStatusService: ReturnStatusService,
        public productService: ProductService,
    ) {
        super(messageService, translateService, dataService, 'Return Order');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ReturnOrderId: new FormControl(),
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
            Store: new FormControl(),
            Status: new FormControl(),
            actionComment: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();

    }

    initDetails() {
        console.log('Product Return Entry : ', this.returnOrderId);
        // console.log('Product Return Entry : ', this.detailScreen);
        this.detailScreen.returnOrderId = this.returnOrderId;
        console.log(`initDetails : ${this.storeId}`);
        this.detailScreen.storeId = this.storeId;
        this.detailScreen.modeContext = this.modeContext;
        this.detailScreen.modeReview = true;
    }

    onApprove(dataItem) {
        this.dialogScreen.callScreen = this;
        this.dialogScreen.isApprove = true;
        this.dialogScreen.dataItem = dataItem;
        this.dialogScreen.rejectReason = '';
        switch (dataItem.Status) {
            case 1 : this.dialogScreen.approveMessage = 'İade girişlerinizi tamamladınız mı? Bu onaydan sonra girişlerinizde değişiklik yapamayacaksınız. Emin misiniz?'; break;
            case 2 : this.dialogScreen.approveMessage = 'Mağaza girişini onaylıyorsunuz, bu işlem sonunda süreç merkeze geçecektir. Emin misiniz'; break;
            case 3 : this.dialogScreen.approveMessage = 'İade girişini onaylıyorsunuz. Bu işlem sonunda mağaza ürünleri paketleyip sevk edecektir. Emin misiniz?'; break;
            case 4 : this.dialogScreen.approveMessage = 'Ürünleri merkeze sevk ettiniz mi?'; break;
            case 5 : this.dialogScreen.approveMessage = 'Mağazadan iade edilen ürünleri listedeki uygun olarak teslim aldığınızı onaylıyorsunuz. Emin misiniz?'; break;
        }
        setTimeout(() => {
            this.dialogScreen.container.show();
        }, 100);

    }

    onReject(dataItem) {

        this.dialogScreen.callScreen = this;
        this.dialogScreen.isApprove = false;
        this.dialogScreen.dataItem = dataItem;
        this.dialogScreen.rejectReason = '';
        switch (dataItem.Status) {
            case 2 : this.dialogScreen.rejectMesssage = 'Mağazanın iade girişlerini ret ediyorsunuz, Emin misiniz?.'; break;
            case 3 : this.dialogScreen.rejectMesssage = 'Mağazanın iade girişlerini ret ediyorsunuz, Emin misiniz?'; break;
            // case 4 : this.dialogScreen.approveMessage = 'Ürünleri merkeze sevk ettiniz mi?'; break;
            case 5 : this.dialogScreen.rejectMesssage = 'Mağazanın iade girişlerini ret ediyorsunuz, Emin misiniz?'; break;
        }
        setTimeout(() => {
            this.dialogScreen.container.show();
        }, 100);
    }

    review() {
        if ((this.currentItem.actionChoice === 'Onay' ||
            this.currentItem.actionChoice === 'Gönder' ||
            this.currentItem.actionChoice === 'Tamamlandı')) {
            this.onApprove(this.currentItem);
        } else if (this.currentItem.actionChoice === 'İptal' && this.currentItem.actionComment !== null) {
            this.onReject(this.currentItem);
        } else if (this.currentItem.actionChoice === 'Revize' && this.currentItem.actionComment !== null) {
            super.review();
            this.container.hideProgress();
        } else if (this.currentItem.actionComment === null) {
            this.messageService.error(this.translateService.instant('Lütfen (Onaycı Yorumu) alanına gerekçenizi yazınız.'));
            this.container.hideProgress();
        }
    }

    callReview() {
        super.review();
    }

    notAccepted() {
        this.container.hideProgress();
    }

    onAllStoresChanged() {
        if (this.allStoresFlag) {
            this.StoreList = [];
            this.storeListReadOnly = true;
        } else {
            this.storeListReadOnly = false;
        }
    }

    create() {
        this.mainScreen.refreshData();
        this.container.hide();
        this.container.hideProgress();
        /*
        if (this.allStoresFlag) {
            this.StoreList = this.storeService.userStores.filter(s => s.ActiveFlag === true).map(s => s.StoreId);
        }
        const promiseArray = [];
        this.StoreList.forEach (sId => {
            this.currentItem.Store = sId;
            promiseArray.push(this.dataService.create(this.currentItem, 'Create').toPromise());
        });

        Promise.all(promiseArray).then(value => {
            this.messageService.success('Seçilen mağazalar için ürün iade süreci başlatıldı.');
            this.mainScreen.refreshData(this.currentItem.getId());

        }).catch(error => this.messageService.error('Beklenmeyen bir hata oluştu.'));
        */
    }
}
