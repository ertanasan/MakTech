// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ReturnReason } from '@warehouse/model/return-reason.model';
import { ReturnReasonService } from '@warehouse/service/return-reason.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-reason-edit',
    templateUrl: './return-reason-edit.component.html',
    styleUrls: ['./return-reason-edit.component.css', ]
})
export class ReturnReasonEditComponent extends CRUDDialogScreenBase<ReturnReason> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ReturnReason>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ReturnReasonService,
    ) {
        super(messageService, translateService, dataService, 'Return Reason');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ReturnReasonId: new FormControl(),
            ReasonName: new FormControl(),
            Parent: new FormControl(),
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
