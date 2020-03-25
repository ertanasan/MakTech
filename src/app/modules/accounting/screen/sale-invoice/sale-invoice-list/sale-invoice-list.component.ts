// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { SaleInvoice } from '@accounting/model/sale-invoice.model';
import { SaleInvoiceService } from '@accounting/service/sale-invoice.service';
import { SaleInvoiceEditComponent } from '@accounting/screen/sale-invoice/sale-invoice-edit/sale-invoice-edit.component';
import { StoreService } from '@store/service/store.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { Store } from '@store/model/store.model';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-invoice-list',
    templateUrl: './sale-invoice-list.component.html',
    styleUrls: ['./sale-invoice-list.component.css', ]
})
export class SaleInvoiceListComponent extends ListScreenBase<SaleInvoice> implements AfterViewInit, OnInit {
    @ViewChild(SaleInvoiceEditComponent, { static: true }) editScreen: SaleInvoiceEditComponent;
    storeList: Store[];

    eInvoiceStatusList = [{value: 0, text: 'Giriş'}, {value: 1, text: 'Merkeze Gönderildi'}, {value: 2, text: 'Muhasebeleşti'}, {value: 3, text: 'İptal'}];
    branchType: any;
    isHeadQuarter: boolean;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SaleInvoiceService,
        public storeService: StoreService,
        public privilegeCacheService: PrivilegeCacheService,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Sale Invoice', RouterLink: '/accounting/sale-invoice'}];
    }

    createEmptyModel(): SaleInvoice {
        return new SaleInvoice();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const saleInvoiceId = this.modeContext.id;
            this.dataService.read(saleInvoiceId).subscribe(result => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), result);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        this.storeService.listUserStores().subscribe(list => {
            this.storeList = list;
            this.editScreen.storeList = this.storeList;
            this.branchType = list[0].UserBranchType;
            this.isHeadQuarter = (this.branchType === 'Central Office');
            this.editScreen.isHeadQuarter = this.isHeadQuarter;
        });

        this.privilegeCacheService.checkPrivilege('ACC-Create SaleInvoice').subscribe( result => {
            this.createEnabled = result;
        });

        super.ngOnInit();
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.saleDetails = null;
        this.editScreen.customerId = null;
        this.editScreen.invoice = dataItem;
        super.showDialog(target, actionName, dataItem);

        if (actionName === 'Update' || actionName === 'Review' || actionName === 'Read') {
            this.editScreen.SelectedStore = dataItem.SaleStore;
            this.editScreen.CustomerId = dataItem.CustomerIdNumber;
            this.editScreen.saleReadOnly = this.storeList && this.storeList.length === 1;
        } else if (this.storeList && this.storeList.length === 1) {
            this.editScreen.saleReadOnly = false;
            this.editScreen.SelectedStore = this.storeList[0].StoreId;
        }
    }

    sendtoAccounting(dataItem: SaleInvoice) {
        dataItem.StatusCode = 1;
        this.dataService.SendEInvoice(dataItem).subscribe(result => {
            this.messageService.success('Fatura muhasebeye gönderildi.');
            this.refreshData();
        }, error => {
            this.messageService.error(error);
            this.refreshData();
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
