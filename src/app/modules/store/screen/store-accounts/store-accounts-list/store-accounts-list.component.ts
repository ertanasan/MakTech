// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreAccounts } from '@store/model/store-accounts.model';
import { StoreAccountsService } from '@store/service/store-accounts.service';
import { StoreAccountsEditComponent } from '@store/screen/store-accounts/store-accounts-edit/store-accounts-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';
import { StoreAccountTypeService } from '@store/service/store-account-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-accounts-list',
    templateUrl: './store-accounts-list.component.html',
    styleUrls: ['./store-accounts-list.component.css', ]
})
export class StoreAccountsListComponent extends ListScreenBase<StoreAccounts> implements AfterViewInit, OnInit {
    @ViewChild(StoreAccountsEditComponent, {static: true}) editScreen: StoreAccountsEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreAccountsService,
        public storeService: StoreService,
        public bankService: BankService,
        public storeAccountTypeService: StoreAccountTypeService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (!this.isEmbedded) {
            this.dataService.list(this.listParams);
        } else {
            const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
            if (result) {
                this.dataLoading = true;
                result.subscribe(
                    list => {
                        this.dataList = list;
                    },
                    error => {
                        this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                    },
                    () => this.dataLoading = false
                );
            }
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store Accounts', RouterLink: '/store/store-accounts'}];
    }

    createEmptyModel(): StoreAccounts {
        const model = new StoreAccounts();
        if (this.isEmbedded) {
            model.Store = this.masterId;
            this.editScreen.storeVisible = false;
        } else {
            this.editScreen.storeVisible = true;
        }
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.bankService.completeList) {
            this.bankService.listAll();
        }
        if (!this.storeAccountTypeService.completeList) {
            this.storeAccountTypeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
