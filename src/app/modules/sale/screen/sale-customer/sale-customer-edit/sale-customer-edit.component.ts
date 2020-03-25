// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SaleCustomer } from '@sale/model/sale-customer.model';
import { SaleCustomerService } from '@sale/service/sale-customer.service';
import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-customer-edit',
    templateUrl: './sale-customer-edit.component.html',
    styleUrls: ['./sale-customer-edit.component.css', ]
})
export class SaleCustomerEditComponent extends CRUDDialogScreenBase<SaleCustomer> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<SaleCustomer>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SaleCustomerService,
        public salesService: SalesService,
    ) {
        super(messageService, translateService, dataService, 'Sale Customer');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SaleCustomerId: new FormControl(),
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
            Sale: new FormControl(),
            EInvoiceFlag: new FormControl(),
            CustomerName: new FormControl(),
            Address: new FormControl(),
            TaxCenterName: new FormControl(),
            TaxIdentityNo: new FormControl(),
            Email: new FormControl(),
            PhoneNumber: new FormControl(),
            FiscalSerial: new FormControl(),
            EInvoiceZetNumber: new FormControl(),
            EInvoiceReceiptNumber: new FormControl(),
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
