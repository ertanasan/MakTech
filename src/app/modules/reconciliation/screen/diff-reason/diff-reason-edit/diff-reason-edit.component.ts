// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { DiffReason } from '@reconciliation/model/diff-reason.model';
import { DiffReasonService } from '@reconciliation/service/diff-reason.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-diff-reason-edit',
    templateUrl: './diff-reason-edit.component.html',
    styleUrls: ['./diff-reason-edit.component.css', ]
})
export class DiffReasonEditComponent extends CRUDDialogScreenBase<DiffReason> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<DiffReason>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: DiffReasonService,
    ) {
        super(messageService, translateService, dataService, 'Diff Reason');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            DiffReasonId: new FormControl(),
            ReasonName: new FormControl(),
            ShortFlag: new FormControl(),
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
