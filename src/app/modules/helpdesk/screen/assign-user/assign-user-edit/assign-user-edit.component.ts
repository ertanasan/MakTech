// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { AssignUser } from '@helpdesk/model/assign-user.model';
import { AssignUserService } from '@helpdesk/service/assign-user.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-assign-user-edit',
    templateUrl: './assign-user-edit.component.html',
    styleUrls: ['./assign-user-edit.component.css', ]
})
export class AssignUserEditComponent extends CRUDDialogScreenBase<AssignUser> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<AssignUser>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: AssignUserService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Assign User');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            AssignUserId: new FormControl(),
            GroupName: new FormControl(),
            ResponsibleUser: new FormControl(),
            AdminFlag: new FormControl(),
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
