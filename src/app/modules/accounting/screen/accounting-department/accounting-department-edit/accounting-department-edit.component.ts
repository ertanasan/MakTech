// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { AccountingDepartment } from '@accounting/model/accounting-department.model';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-accounting-department-edit',
    templateUrl: './accounting-department-edit.component.html',
    styleUrls: ['./accounting-department-edit.component.css', ]
})
export class AccountingDepartmentEditComponent extends CRUDDialogScreenBase<AccountingDepartment> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<AccountingDepartment>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: AccountingDepartmentService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Accounting Department');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            AccountingDepartmentId: new FormControl(),
            DepartmentName: new FormControl(),
            Store: new FormControl(),
            ExpenseCenter: new FormControl(),
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
