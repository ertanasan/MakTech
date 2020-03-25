// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ReturnDestination } from '@warehouse/model/return-destination.model';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-return-destination-edit',
    templateUrl: './return-destination-edit.component.html',
    styleUrls: ['./return-destination-edit.component.css', ]
})
export class ReturnDestinationEditComponent extends CRUDDialogScreenBase<ReturnDestination> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ReturnDestination>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ReturnDestinationService,
    ) {
        super(messageService, translateService, dataService, 'Return Destination');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ReturnDestinationId: new FormControl(),
            DestinationName: new FormControl(),
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
