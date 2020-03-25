// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { FirmType } from '@accounting/model/firm-type.model';
import { FirmTypeService } from '@accounting/service/firm-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-type-edit',
    templateUrl: './firm-type-edit.component.html',
    styleUrls: ['./firm-type-edit.component.css', ]
})
export class FirmTypeEditComponent extends CRUDDialogScreenBase<FirmType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<FirmType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FirmTypeService,
    ) {
        super(messageService, translateService, dataService, 'Firm Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FirmTypeId: new FormControl(),
            Name: new FormControl(),
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
