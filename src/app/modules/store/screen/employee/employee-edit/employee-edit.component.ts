// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Employee } from '@store/model/employee.model';
import { EmployeeService } from '@store/service/employee.service';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-employee-edit',
    templateUrl: './employee-edit.component.html',
    styleUrls: ['./employee-edit.component.css', ]
})
export class EmployeeEditComponent extends CRUDDialogScreenBase<Employee> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Employee>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: EmployeeService,
        public departmentService: AccountingDepartmentService,
    ) {
        super(messageService, translateService, dataService, 'Employee');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            EmployeeId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            EmployeeName: new FormControl(),
            DepartmentCode: new FormControl(),
            DepartmentName: new FormControl(),
            IncentiveActCode: new FormControl(),
            StartDate: new FormControl(),
            QuitDate: new FormControl(),
            WorkingType: new FormControl(),
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
