// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreAccounts } from '@store/model/store-accounts.model';
import { StoreAccountsService } from '@store/service/store-accounts.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { StoreAccountType } from '@store/model/store-account-type.model';
import { StoreAccountTypeService } from '@store/service/store-account-type.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-accounts-edit',
    templateUrl: './store-accounts-edit.component.html',
    styleUrls: ['./store-accounts-edit.component.css', ]
})
export class StoreAccountsEditComponent extends CRUDDialogScreenBase<StoreAccounts> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreAccounts>;

    public storeVisible = true;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreAccountsService,
        public storeService: StoreService,
        public storeAccountTypeService: StoreAccountTypeService,
        public bankService: BankService,
    ) {
        super(messageService, translateService, dataService, 'Store Accounts');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreAccountsId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Store: new FormControl(),
            AccountType: new FormControl(),
            Bank: new FormControl(),
            AccountText: new FormControl(),
            AccountDescription: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
