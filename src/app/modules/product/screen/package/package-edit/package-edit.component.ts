// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Package } from '@product/model/package.model';
import { PackageService } from '@product/service/package.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-edit',
    templateUrl: './package-edit.component.html',
    styleUrls: ['./package-edit.component.css', ]
})
export class PackageEditComponent extends CRUDDialogScreenBase<Package> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Package>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: PackageService,
    ) {
        super(messageService, translateService, dataService, 'Package');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PackageId: new FormControl(),
            Name: new FormControl(),
            ParentPackage: new FormControl(),
            Amount: new FormControl(),
            Description: new FormControl(),
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
