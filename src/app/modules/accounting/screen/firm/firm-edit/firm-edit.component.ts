// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Firm } from '@accounting/model/firm.model';
import { FirmService } from '@accounting/service/firm.service';
import { FirmType } from '@accounting/model/firm-type.model';
import { FirmTypeService } from '@accounting/service/firm-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-edit',
    templateUrl: './firm-edit.component.html',
    styleUrls: ['./firm-edit.component.css', ]
})
export class FirmEditComponent extends CRUDDialogScreenBase<Firm> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<Firm>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FirmService,
        public firmTypeService: FirmTypeService,
    ) {
        super(messageService, translateService, dataService, 'Firm');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FirmId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            FirmType: new FormControl(),
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
