// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SuperGroup1 } from '@product/model/super-group1.model';
import { SuperGroup1Service } from '@product/service/super-group1.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group1-edit',
    templateUrl: './super-group1-edit.component.html',
    styleUrls: ['./super-group1-edit.component.css', ]
})
export class SuperGroup1EditComponent extends CRUDDialogScreenBase<SuperGroup1> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SuperGroup1>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: SuperGroup1Service,
    ) {
        super(messageService, translateService, dataService, 'Super Group 1');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SuperGroup1Id: new FormControl(),
            SuperGroup1Name: new FormControl(),
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
