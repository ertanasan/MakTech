// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ReturnStatus } from '@warehouse/model/return-status.model';
import { ReturnStatusService } from '@warehouse/service/return-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-status-edit',
    templateUrl: './return-status-edit.component.html',
    styleUrls: ['./return-status-edit.component.css', ]
})
export class ReturnStatusEditComponent extends CRUDDialogScreenBase<ReturnStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ReturnStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ReturnStatusService,
    ) {
        super(messageService, translateService, dataService, 'Return Status');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ReturnStatusId: new FormControl(),
            StatusName: new FormControl(),
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
