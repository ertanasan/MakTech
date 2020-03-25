// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ExpenseType } from '@reconciliation/model/expense-type.model';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-type-edit',
    templateUrl: './expense-type-edit.component.html',
    styleUrls: ['./expense-type-edit.component.css', ]
})
export class ExpenseTypeEditComponent extends CRUDDialogScreenBase<ExpenseType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ExpenseType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExpenseTypeService,
    ) {
        super(messageService, translateService, dataService, 'Expense Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ExpenseTypeId: new FormControl(),
            ExpenseTypeName: new FormControl(),
            AccountCode: new FormControl(),
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
