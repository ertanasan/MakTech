// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-unit-edit',
    templateUrl: './unit-edit.component.html',
    styleUrls: ['./unit-edit.component.css', ]
})
export class UnitEditComponent extends CRUDDialogScreenBase<Unit> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Unit>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: UnitService,
    ) {
        super(messageService, translateService, dataService, 'Unit');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            UnitId: new FormControl(),
            Name: new FormControl(),
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
