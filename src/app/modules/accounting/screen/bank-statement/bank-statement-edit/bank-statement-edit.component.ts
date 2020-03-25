// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { BankStatement } from '@accounting/model/bank-statement.model';
import { BankStatementService } from '@accounting/service/bank-statement.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-bank-statement-edit',
    templateUrl: './bank-statement-edit.component.html',
    styleUrls: ['./bank-statement-edit.component.css', ]
})
export class BankStatementEditComponent extends CRUDDialogScreenBase<BankStatement> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<BankStatement>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: BankStatementService,
        public bankService: BankService,
    ) {
        super(messageService, translateService, dataService, 'Bank Statement');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            BankStatementId: new FormControl(),
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
            Bank: new FormControl(),
            Date: new FormControl(),
            Description: new FormControl(),
            TransactionAmount: new FormControl(),
            Balance: new FormControl(),
            Channel: new FormControl(),
            Info1: new FormControl(),
            Info2: new FormControl(),
            Info3: new FormControl(),
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
