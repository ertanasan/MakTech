// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CountingStatus } from '@warehouse/model/counting-status.model';
import { CountingStatusService } from '@warehouse/service/counting-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-counting-status-edit',
    templateUrl: './counting-status-edit.component.html',
    styleUrls: ['./counting-status-edit.component.css', ]
})
export class CountingStatusEditComponent extends CRUDDialogScreenBase<CountingStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CountingStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CountingStatusService,
    ) {
        super(messageService, translateService, dataService, 'Counting Status');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CountingStatusId: new FormControl(),
            CountingStatusName: new FormControl(),
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
