// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Town } from '@store/model/town.model';
import { TownService } from '@store/service/town.service';

import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-town-edit',
    templateUrl: './town-edit.component.html',
    styleUrls: ['./town-edit.component.css', ]
})
export class TownEditComponent extends CRUDDialogScreenBase<Town> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Town>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: TownService,
        public cityService: CityService,
    ) {
        super(messageService, translateService, dataService, 'Town');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            TownId: new FormControl(),
            City: new FormControl(),
            TownName: new FormControl(),
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
