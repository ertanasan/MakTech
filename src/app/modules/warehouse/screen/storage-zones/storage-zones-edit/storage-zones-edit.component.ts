// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StorageZones } from '@warehouse/model/storage-zones.model';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-storage-zones-edit',
    templateUrl: './storage-zones-edit.component.html',
    styleUrls: ['./storage-zones-edit.component.css', ]
})
export class StorageZonesEditComponent extends CRUDDialogScreenBase<StorageZones> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StorageZones>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StorageZonesService,
    ) {
        super(messageService, translateService, dataService, 'Storage Zones');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StorageZonesId: new FormControl(),
            Location: new FormControl(),
            ZoneName: new FormControl(),
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
