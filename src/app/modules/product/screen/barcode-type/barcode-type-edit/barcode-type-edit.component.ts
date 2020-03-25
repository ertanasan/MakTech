// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { BarcodeType } from '@product/model/barcode-type.model';
import { BarcodeTypeService } from '@product/service/barcode-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-barcode-type-edit',
    templateUrl: './barcode-type-edit.component.html',
    styleUrls: ['./barcode-type-edit.component.css', ]
})
export class BarcodeTypeEditComponent extends CRUDDialogScreenBase<BarcodeType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<BarcodeType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: BarcodeTypeService,
    ) {
        super(messageService, translateService, dataService, 'Barcode Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            BarcodeTypeId: new FormControl(),
            BarcodeTypeName: new FormControl(),
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
