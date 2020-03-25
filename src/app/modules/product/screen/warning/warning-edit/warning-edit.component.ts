// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Warning } from '@product/model/warning.model';
import { WarningService } from '@product/service/warning.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-warning-edit',
    templateUrl: './warning-edit.component.html',
    styleUrls: ['./warning-edit.component.css', ]
})
export class WarningEditComponent extends CRUDDialogScreenBase<Warning> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Warning>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: WarningService,
    ) {
        super(messageService, translateService, dataService, 'Warning');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            WarningId: new FormControl(),
            WarningText: new FormControl(),
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
