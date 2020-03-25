// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RegionManagers } from '@store/model/region-managers.model';
import { RegionManagersService } from '@store/service/region-managers.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-region-managers-edit',
    templateUrl: './region-managers-edit.component.html',
    styleUrls: ['./region-managers-edit.component.css', ]
})
export class RegionManagersEditComponent extends CRUDDialogScreenBase<RegionManagers> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RegionManagers>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RegionManagersService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Region Managers');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RegionManagersId: new FormControl(),
            RegionManagerName: new FormControl(),
            TelNo: new FormControl(),
            Email: new FormControl(),
            RegionUser: new FormControl(),
            ExpenseAccountCode: new FormControl(),
            MikroProjectCode: new FormControl(),
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
