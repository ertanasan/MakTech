// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Fixture } from '@product/model/fixture.model';
import { FixtureService } from '@product/service/fixture.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-edit',
    templateUrl: './fixture-edit.component.html',
    styleUrls: ['./fixture-edit.component.css', ]
})
export class FixtureEditComponent extends CRUDDialogScreenBase<Fixture> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<Fixture>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FixtureService,
    ) {
        super(messageService, translateService, dataService, 'Fixture');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FixtureId: new FormControl(),
            FixtureName: new FormControl(),
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
