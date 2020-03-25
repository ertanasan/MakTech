// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ShipmentType } from '@warehouse/model/shipment-type.model';
import { ShipmentTypeService } from '@warehouse/service/shipment-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-type-edit',
    templateUrl: './shipment-type-edit.component.html',
    styleUrls: ['./shipment-type-edit.component.css', ]
})
export class ShipmentTypeEditComponent extends CRUDDialogScreenBase<ShipmentType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ShipmentType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ShipmentTypeService,
    ) {
        super(messageService, translateService, dataService, 'Shipment Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ShipmentTypeId: new FormControl(),
            ShipmentTypeName: new FormControl(),
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
