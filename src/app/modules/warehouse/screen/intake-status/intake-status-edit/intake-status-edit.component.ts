// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { IntakeStatus } from '@warehouse/model/intake-status.model';
import { IntakeStatusService } from '@warehouse/service/intake-status.service';
import { StoreOrderDetail } from '@warehouse/model/store-order-detail.model';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { IntakeStatusType } from '@warehouse/model/intake-status-type.model';
import { IntakeStatusTypeService } from '@warehouse/service/intake-status-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-intake-status-edit',
    templateUrl: './intake-status-edit.component.html',
    styleUrls: ['./intake-status-edit.component.css', ]
})
export class IntakeStatusEditComponent extends CRUDDialogScreenBase<IntakeStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<IntakeStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: IntakeStatusService,
        public storeOrderDetailService: StoreOrderDetailService,
        public intakeStatusTypeService: IntakeStatusTypeService,
    ) {
        super(messageService, translateService, dataService, 'Intake Status');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            IntakeStatusId: new FormControl(),
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
            StoreOrderDetail: new FormControl(),
            IntakeStatusType: new FormControl(),
            Description: new FormControl(),
            IsTransferred: new FormControl(),
            MikroTransferTime: new FormControl(),
            QuantityDifference: new FormControl(),
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
