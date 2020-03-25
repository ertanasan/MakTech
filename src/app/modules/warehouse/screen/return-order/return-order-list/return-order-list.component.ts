// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ReturnOrder } from '@warehouse/model/return-order.model';
import { ReturnOrderService } from '@warehouse/service/return-order.service';
import { ReturnOrderEditComponent } from '@warehouse/screen/return-order/return-order-edit/return-order-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { ReturnOrderDialogComponent } from '../return-order-dialog/return-order-dialog.component';
import { OrderStatusHistoryService } from '@warehouse/service/order-status-history.service';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-order-list',
    templateUrl: './return-order-list.component.html',
    styleUrls: ['./return-order-list.component.css', ]
})
export class ReturnOrderListComponent extends ListScreenBase<ReturnOrder> implements AfterViewInit, OnInit {
    @ViewChild(ReturnOrderEditComponent, {static: true}) editScreen: ReturnOrderEditComponent;
    @ViewChild(ReturnOrderDialogComponent, {static: true}) dialogScreen: ReturnOrderDialogComponent;
    // @ViewChild(ProductReturnEntryComponent) detailScreen: ProductReturnEntryComponent;

    public store: Store;
    public authorized: boolean;
    public isStore: boolean;
    public isRegion: boolean;
    public isCentralOffice: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReturnOrderService,
        public storeService: StoreService,
        public returnStatusService: ReturnStatusService,
        public orderStatusHistoryService: OrderStatusHistoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Return Order', RouterLink: '/warehouse/return-order'}];
    }

    createEmptyModel(): ReturnOrder {
        const model = new ReturnOrder();
        model.Status = 1;
        return model;
    }


    userStoreInfo() {
        this.storeService.listUserStores().subscribe(list => {
            // console.log(list);
            if (list.length === 1) {
                this.store = list[0];
                this.authorized = false;
            } else {
                this.authorized = true;
            }

            this.isStore = false;
            this.isRegion = false;
            this.isCentralOffice = false;
            if (list[0].UserBranchType === 'Branch') {
                this.isStore = true;
            } else if (list[0].UserBranchType === 'Region') {
                this.isRegion = true;
            } else if (list[0].UserBranchType === 'Central Office') {
                this.isCentralOffice = true;
            }

        });
    }

    ngOnInit() {
        // Fill reference lists
        this.userStoreInfo();

        if (!this.returnStatusService.completeList) {
            this.returnStatusService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
        // this.detailScreen.mainScreen = this;
        // this.dialogs.push(this.detailScreen);

        if (this.modeReview && !this.isEmbedded) {
            this.editScreen.showDetails = true;
            const orderId = this.modeContext.id;
            // console.log(this.modeContext);
            this.dataService.read(orderId).subscribe(order => {
                this.editScreen.modeContext = this.modeContext;
                // console.log(this.modeContext);
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), order);
                this.editScreen.returnOrderId = orderId;
                this.editScreen.initDetails();
                // console.log(dataItem);
                this.showDialog(this.editScreen, 'Review', dataItem );
                // this.showDetailScreen(dataItem);
            });
        }
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.isCreate = (actionName === 'Create');
        if (actionName === 'Read') {
            this.orderStatusHistoryService.returnOrderStatusHistory(dataItem.ReturnOrderId).subscribe(result => {
                this.editScreen.history = process(result.Data, new ListParams());
                this.editScreen.viewDetails = true;
                super.showDialog(target, actionName, dataItem);
            });
        } else {
            this.editScreen.viewDetails = false;
            if (actionName === 'Create') {
                console.log('return order list show dialog create');
                this.editScreen.returnOrderId = -1;
            } else {
                console.log('return order list show dialog : ', dataItem);
                this.editScreen.returnOrderId = dataItem.ReturnOrderId;
            }
            this.editScreen.initDetails();
            super.showDialog(target, actionName, dataItem);
        }
    }

    onApprove(dataItem) {
        this.dialogScreen.mainScreen = this;
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

    showDetailScreen(dataItem) {
        // this.detailCustom.caption = 'İade Ürün Listesi';
        // this.detailScreen.returnOrderId = dataItem.ReturnOrderId;
        // this.detailScreen.initDetails();
        /*
        this.detailCustom.mainForm = this.detailCustom.formBuilder.group({
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
            });*/
        // this.detailScreen.show(dataItem);
    }

    onReject(dataItem) {

        this.dialogScreen.mainScreen = this;
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

}
