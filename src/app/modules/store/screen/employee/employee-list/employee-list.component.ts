// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Employee } from '@store/model/employee.model';
import { EmployeeService } from '@store/service/employee.service';
import { EmployeeEditComponent } from '@store/screen/employee/employee-edit/employee-edit.component';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.css', ]
})
export class EmployeeListComponent extends ListScreenBase<Employee> implements OnInit, AfterViewInit {
    @ViewChild(EmployeeEditComponent, {static: true}) editScreen: EmployeeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: EmployeeService,
        public departmentService: AccountingDepartmentService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Employee', RouterLink: '/store/employee'}];
    }

    createEmptyModel(): Employee {
        return new Employee();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        if (!this.departmentService.completeList) {
            this.departmentService.listAll();
        }
        super.ngOnInit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
