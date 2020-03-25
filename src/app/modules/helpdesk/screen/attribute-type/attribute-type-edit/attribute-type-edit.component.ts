// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { AttributeType } from '@helpdesk/model/attribute-type.model';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-attribute-type-edit',
    templateUrl: './attribute-type-edit.component.html',
    styleUrls: ['./attribute-type-edit.component.css', ]
})
export class AttributeTypeEditComponent extends CRUDDialogScreenBase<AttributeType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<AttributeType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: AttributeTypeService,
    ) {
        super(messageService, translateService, dataService, 'Attribute Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            AttributeTypeId: new FormControl(),
            AttributeTypeName: new FormControl(),
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
