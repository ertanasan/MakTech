// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SeasonType } from '@product/model/season-type.model';
import { SeasonTypeService } from '@product/service/season-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-season-type-edit',
    templateUrl: './season-type-edit.component.html',
    styleUrls: ['./season-type-edit.component.css', ]
})
export class SeasonTypeEditComponent extends CRUDDialogScreenBase<SeasonType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SeasonType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: SeasonTypeService,
    ) {
        super(messageService, translateService, dataService, 'Season Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SeasonTypeId: new FormControl(),
            SeasonTypeName: new FormControl(),
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
