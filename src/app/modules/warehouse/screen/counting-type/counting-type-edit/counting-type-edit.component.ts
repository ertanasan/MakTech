// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CountingType } from '@warehouse/model/counting-type.model';
import { CountingTypeService } from '@warehouse/service/counting-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-counting-type-edit',
    templateUrl: './counting-type-edit.component.html',
    styleUrls: ['./counting-type-edit.component.css', ]
})
export class CountingTypeEditComponent extends CRUDDialogScreenBase<CountingType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CountingType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CountingTypeService,
    ) {
        super(messageService, translateService, dataService, 'Counting Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CountingTypeId: new FormControl(),
            CountingTypeName: new FormControl(),
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
