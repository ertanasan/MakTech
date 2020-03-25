// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { BarcodeTypeInt } from '@product/model/barcode-type-int.model';
import { BarcodeTypeIntService } from '@product/service/barcode-type-int.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-barcode-type-int-edit',
    templateUrl: './barcode-type-int-edit.component.html',
    styleUrls: ['./barcode-type-int-edit.component.css', ]
})
export class BarcodeTypeIntEditComponent extends CRUDDialogScreenBase<BarcodeTypeInt> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<BarcodeTypeInt>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: BarcodeTypeIntService,
    ) {
        super(messageService, translateService, dataService, 'Barcode Type Int');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            BarcodeTypeID: new FormControl(),
            BarcodeType: new FormControl(),
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
