// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreOrderStatus } from '@warehouse/model/store-order-status.model';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-status-edit',
    templateUrl: './store-order-status-edit.component.html',
    styleUrls: ['./store-order-status-edit.component.css', ]
})
export class StoreOrderStatusEditComponent extends CRUDDialogScreenBase<StoreOrderStatus> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreOrderStatus>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreOrderStatusService,
    ) {
        super(messageService, translateService, dataService, 'Store Order Status');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreOrderStatusId: new FormControl(),
            StatusName: new FormControl(),
            Comment: new FormControl(),
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
