// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ShipmentUnit } from '@warehouse/model/shipment-unit.model';
import { ShipmentUnitService } from '@warehouse/service/shipment-unit.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-unit-edit',
    templateUrl: './shipment-unit-edit.component.html',
    styleUrls: ['./shipment-unit-edit.component.css', ]
})
export class ShipmentUnitEditComponent extends CRUDDialogScreenBase<ShipmentUnit> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ShipmentUnit>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ShipmentUnitService,
    ) {
        super(messageService, translateService, dataService, 'Shipment Unit');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ShipmentUnitId: new FormControl(),
            UnitName: new FormControl(),
            PackageQuantity: new FormControl(),
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
