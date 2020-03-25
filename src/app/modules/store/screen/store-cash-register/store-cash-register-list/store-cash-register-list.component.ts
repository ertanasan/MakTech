// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreCashRegister } from '@store/model/store-cash-register.model';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { StoreCashRegisterEditComponent } from '@store/screen/store-cash-register/store-cash-register-edit/store-cash-register-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CashRegisterModel } from '@store/model/cash-register-model.model';
import { CashRegisterModelService } from '@store/service/cash-register-model.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-cash-register-list',
    templateUrl: './store-cash-register-list.component.html',
    styleUrls: ['./store-cash-register-list.component.css']
})
export class StoreCashRegisterListComponent extends ListScreenBase<StoreCashRegister> implements AfterViewInit, OnInit {
    @ViewChild(StoreCashRegisterEditComponent, {static: true}) editScreen: StoreCashRegisterEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreCashRegisterService,
        public storeService: StoreService,
        public cashRegisterModelService: CashRegisterModelService,
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
        return [{ Caption: 'Store' }, { Caption: 'Store Cash Register', RouterLink: '/store/store-cash-register' }];
    }

    createEmptyModel(): StoreCashRegister {
        return new StoreCashRegister();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.cashRegisterModelService.completeList) {
            this.cashRegisterModelService.listAll();
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
