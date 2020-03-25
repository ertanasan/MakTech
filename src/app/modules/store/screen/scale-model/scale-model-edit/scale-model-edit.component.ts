// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ScaleModel } from '@store/model/scale-model.model';
import { ScaleModelService } from '@store/service/scale-model.service';
import { ScaleBrand } from '@store/model/scale-brand.model';
import { ScaleBrandService } from '@store/service/scale-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-scale-model-edit',
    templateUrl: './scale-model-edit.component.html',
    styleUrls: ['./scale-model-edit.component.css', ]
})
export class ScaleModelEditComponent extends CRUDDialogScreenBase<ScaleModel> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ScaleModel>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: ScaleModelService,
        public scaleBrandService: ScaleBrandService,
    ) {
        super(messageService, translateService, dataService, 'Scale Model');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ScaleModelId: new FormControl(),
            Brand: new FormControl(),
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
