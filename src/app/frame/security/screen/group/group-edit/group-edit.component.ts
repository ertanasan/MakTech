// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Group } from '@security/model/group.model';
import { GroupService } from '@security/service/group.service';
import { Organization } from '@organization/model/organization.model';
import { OrganizationService } from '@organization/service/organization.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-group-edit',
    templateUrl: './group-edit.component.html',
    styleUrls: ['./group-edit.component.css', ]
})
export class GroupEditComponent extends CRUDDialogScreenBase<Group> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Group>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: GroupService,
        public organizationService: OrganizationService,
    ) {
        super(messageService, translateService, dataService, 'Group');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GroupId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            Description: new FormControl(),
            ExternalReference: new FormControl(),
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
