// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { WorkingHours } from '@store/model/working-hours.model';
import { WorkingHoursService } from '@store/service/working-hours.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-working-hours-edit',
    templateUrl: './working-hours-edit.component.html',
    styleUrls: ['./working-hours-edit.component.css', ]
})
export class WorkingHoursEditComponent extends CRUDDialogScreenBase<WorkingHours> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<WorkingHours>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: WorkingHoursService,
        public storeService: StoreService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Working Hours');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            WorkingHoursId: new FormControl(),
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
            StoreCode: new FormControl(),
            StoreName: new FormControl(),
            OpeningTime: new FormControl(),
            ClosingTime: new FormControl(),
            OpenUserName: new FormControl(),
            CloseUserName: new FormControl(),
            Store: new FormControl(),
            OpenUser: new FormControl(),
            CloseUser: new FormControl(),
            Note: new FormControl(),
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
