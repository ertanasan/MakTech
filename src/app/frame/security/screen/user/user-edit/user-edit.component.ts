// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { Organization } from '@organization/model/organization.model';
import { OrganizationService } from '@organization/service/organization.service';
import { Department } from '@organization/model/department.model';
import { DepartmentService } from '@organization/service/department.service';
import { Branch } from '@organization/model/branch.model';
import { BranchService } from '@organization/service/branch.service';
import { Profession } from '@security/model/profession.model';
import { ProfessionService } from '@security/service/profession.service';
import { Title } from '@security/model/title.model';
import { TitleService } from '@security/service/title.service';
import { Location } from '@security/model/location.model';
import { LocationService } from '@security/service/location.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-user-edit',
    templateUrl: './user-edit.component.html',
    styleUrls: ['./user-edit.component.css', ]
})
export class UserEditComponent extends CRUDDialogScreenBase<User> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<User>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: UserService,
        public organizationService: OrganizationService,
        public departmentService: DepartmentService,
        public branchService: BranchService,
        public professionService: ProfessionService,
        public titleService: TitleService,
        public locationService: LocationService,
    ) {
        super(messageService, translateService, dataService, 'User');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            UserId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            Password: new FormControl(),
            SecurityStamp: new FormControl(),
            UserFullName: new FormControl(),
            Department: new FormControl(),
            Branch: new FormControl(),
            Profession: new FormControl(),
            Title: new FormControl(),
            Manager: new FormControl(),
            TechnicalManager: new FormControl(),
            Location: new FormControl(),
            Gender: new FormControl(),
            Photo: new FormControl(),
            EMail: new FormControl(),
            Description: new FormControl(),
            AccessDeniedCount: new FormControl(),
            Active: new FormControl(),
            UserOSName: new FormControl(),
            NationalIdentityNo: new FormControl(),
            PhoneNumber: new FormControl(),
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
