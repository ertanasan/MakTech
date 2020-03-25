// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { StoreCashRegister } from '@store/model/store-cash-register.model';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { TransactionType } from '@sale/model/transaction-type.model';
import { TransactionTypeService } from '@sale/service/transaction-type.service';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';
import { DateEntryComponent } from '@otuidataentry/date-entry/date-entry.component';
import { AlphaEntryComponent } from '@otuidataentry/alpha-entry/alpha-entry.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sales-edit',
    templateUrl: './sales-edit.component.html',
    styleUrls: ['./sales-edit.component.css', ]
})
export class SalesEditComponent extends CRUDDialogScreenBase<Sales> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Sales>;
    @ViewChild(DropdownEntryComponent, {static: true}) storeID: DropdownEntryComponent;
    @ViewChild(DateEntryComponent, {static: true}) transactionDate: DateEntryComponent;
    @ViewChild(AlphaEntryComponent, {static: true}) transactionCode: AlphaEntryComponent;
   
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SalesService,
        public storeService: StoreService,
        public storeCashRegisterService: StoreCashRegisterService,
        public transactionTypeService: TransactionTypeService,
    ) {
        super(messageService, translateService, dataService, 'Sales');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SalesId: new FormControl(),
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
            TransactionCode: new FormControl(),
            Store: new FormControl(),
            CashierCode: new FormControl(),
            CashRegister: new FormControl(),
            TransactionDate: new FormControl(),
            TransactionTime: new FormControl(),
            VATAmount: new FormControl(),
            Total: new FormControl(),
            ProductDiscount: new FormControl(),
            TotalDiscount: new FormControl(),
            ProductCount: new FormControl(),
            ProcessDuration: new FormControl(),
            Cancelled: new FormControl(),
            TransactionType: new FormControl(),
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
