// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SuperGroup2 } from '@product/model/super-group2.model';
import { SuperGroup2Service } from '@product/service/super-group2.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group2-edit',
    templateUrl: './super-group2-edit.component.html',
    styleUrls: ['./super-group2-edit.component.css', ]
})
export class SuperGroup2EditComponent extends CRUDDialogScreenBase<SuperGroup2> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<SuperGroup2>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: SuperGroup2Service,
    ) {
        super(messageService, translateService, dataService, 'Super Group 2');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SuperGroup2Id: new FormControl(),
            SuperGroup2Name: new FormControl(),
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
