// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ShipmentPackageType } from '@warehouse/model/shipment-package-type.model';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-package-type-edit',
    templateUrl: './shipment-package-type-edit.component.html',
    styleUrls: ['./shipment-package-type-edit.component.css', ]
})
export class ShipmentPackageTypeEditComponent extends CRUDDialogScreenBase<ShipmentPackageType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ShipmentPackageType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ShipmentPackageTypeService,
    ) {
        super(messageService, translateService, dataService, 'Shipment Package Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ShipmentPackageTypeId: new FormControl(),
            PackageTypeName: new FormControl(),
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
