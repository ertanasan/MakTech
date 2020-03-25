// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PropertyType } from '@product/model/property-type.model';
import { PropertyTypeService } from '@product/service/property-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-property-type-edit',
    templateUrl: './property-type-edit.component.html',
    styleUrls: ['./property-type-edit.component.css', ]
})
export class PropertyTypeEditComponent extends CRUDDialogScreenBase<PropertyType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PropertyType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: PropertyTypeService,
    ) {
        super(messageService, translateService, dataService, 'Property Type');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PropertyTypeId: new FormControl(),
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
