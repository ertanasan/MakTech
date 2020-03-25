// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PackageType } from '@price/model/package-type.model';
import { PackageTypeService } from '@price/service/package-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-type-edit',
    templateUrl: './package-type-edit.component.html',
    styleUrls: ['./package-type-edit.component.css', ]
})
export class PackageTypeEditComponent extends CRUDDialogScreenBase<PackageType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PackageType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: PackageTypeService,
    ) {
        super(messageService, translateService, dataService, 'Package Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PackageTypeId: new FormControl(),
            PackageTypeName: new FormControl(),
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
