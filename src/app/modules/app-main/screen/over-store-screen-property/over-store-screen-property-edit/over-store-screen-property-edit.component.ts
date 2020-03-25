// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import { OverStoreScreenProperty } from '@app-main/model/over-store-screen-property.model';
import { OverStoreScreenPropertyService } from '@app-main/service/over-store-screen-property.service';

// import { OverStoreScreenProperty } from '@over-store-main/model/over-store-screen-property.model';
// import { OverStoreScreenPropertyService } from '@over-store-main/service/over-store-screen-property.service';
// import { Screen } from '@program/model/screen.model';
// import { ScreenService } from '@program/service/screen.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-over-store-screen-property-edit',
    templateUrl: './over-store-screen-property-edit.component.html',
    styleUrls: ['./over-store-screen-property-edit.component.css', ]
})
export class OverStoreScreenPropertyEditComponent extends CRUDDialogScreenBase<OverStoreScreenProperty> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<OverStoreScreenProperty>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: OverStoreScreenPropertyService,
        // public screenService: ScreenService,
    ) {
        super(messageService, translateService, dataService, 'OverStore Screen Property');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            OverStoreScreenPropertyId: new FormControl(),
            Screen: new FormControl(),
            PropertyName: new FormControl(),
            PropertyValue: new FormControl(),
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
