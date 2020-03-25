// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { FixtureModel } from '@product/model/fixture-model.model';
import { FixtureModelService } from '@product/service/fixture-model.service';
import { FixtureBrand } from '@product/model/fixture-brand.model';
import { FixtureBrandService } from '@product/service/fixture-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-model-edit',
    templateUrl: './fixture-model-edit.component.html',
    styleUrls: ['./fixture-model-edit.component.css', ]
})
export class FixtureModelEditComponent extends CRUDDialogScreenBase<FixtureModel> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<FixtureModel>;

    masterId: any;
    masterObject: any;
    
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: FixtureModelService,
        public fixtureBrandService: FixtureBrandService,
    ) {
        super(messageService, translateService, dataService, 'Fixture Model');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            FixtureModelId: new FormControl(),
            Brand: new FormControl(),
            ModelName: new FormControl(),
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
