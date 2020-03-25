// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-city-edit',
    templateUrl: './city-edit.component.html',
    styleUrls: ['./city-edit.component.css', ]
})
export class CityEditComponent extends CRUDDialogScreenBase<City> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<City>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: CityService,
    ) {
        super(messageService, translateService, dataService, 'City');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CityId: new FormControl(),
            CityName: new FormControl(),
            PlateCode: new FormControl(),
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
