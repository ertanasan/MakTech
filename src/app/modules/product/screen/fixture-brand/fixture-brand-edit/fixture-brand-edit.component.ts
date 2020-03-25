// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { FixtureBrand } from '@product/model/fixture-brand.model';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { Fixture } from '@product/model/fixture.model';
import { FixtureService } from '@product/service/fixture.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-brand-edit',
    templateUrl: './fixture-brand-edit.component.html',
    styleUrls: ['./fixture-brand-edit.component.css', ]
})
export class FixtureBrandEditComponent extends CRUDDialogScreenBase<FixtureBrand> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<FixtureBrand>;

    masterId: any;
    masterObject: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FixtureBrandService,
        public fixtureService: FixtureService,
    ) {
        super(messageService, translateService, dataService, 'Fixture Brand');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FixtureBrandId: new FormControl(),
            Fixture: new FormControl(),
            BrandName: new FormControl(),
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
