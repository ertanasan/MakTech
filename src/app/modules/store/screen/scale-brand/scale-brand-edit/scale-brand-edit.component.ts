// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ScaleBrand } from '@store/model/scale-brand.model';
import { ScaleBrandService } from '@store/service/scale-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-scale-brand-edit',
    templateUrl: './scale-brand-edit.component.html',
    styleUrls: ['./scale-brand-edit.component.css', ]
})
export class ScaleBrandEditComponent extends CRUDDialogScreenBase<ScaleBrand> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ScaleBrand>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ScaleBrandService,
    ) {
        super(messageService, translateService, dataService, 'Scale Brand');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ScaleBrandId: new FormControl(),
            Name: new FormControl(),
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
