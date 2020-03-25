// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SuperGroup3 } from '@product/model/super-group3.model';
import { SuperGroup3Service } from '@product/service/super-group3.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group3-edit',
    templateUrl: './super-group3-edit.component.html',
    styleUrls: ['./super-group3-edit.component.css', ]
})
export class SuperGroup3EditComponent extends CRUDDialogScreenBase<SuperGroup3> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SuperGroup3>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: SuperGroup3Service,
    ) {
        super(messageService, translateService, dataService, 'Super Group 3');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SuperGroup3Id: new FormControl(),
            SuperGroup3Name: new FormControl(),
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
