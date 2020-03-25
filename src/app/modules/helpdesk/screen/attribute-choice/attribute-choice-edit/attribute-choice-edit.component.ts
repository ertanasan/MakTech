// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { AttributeChoice } from '@helpdesk/model/attribute-choice.model';
import { AttributeChoiceService } from '@helpdesk/service/attribute-choice.service';
import { RequestAttribute } from '@helpdesk/model/request-attribute.model';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-attribute-choice-edit',
    templateUrl: './attribute-choice-edit.component.html',
    styleUrls: ['./attribute-choice-edit.component.css', ]
})
export class AttributeChoiceEditComponent extends CRUDDialogScreenBase<AttributeChoice> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<AttributeChoice>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: AttributeChoiceService,
        public requestAttributeService: RequestAttributeService,
    ) {
        super(messageService, translateService, dataService, 'Attribute Choice');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            AttributeChoiceId: new FormControl(),
            Attribute: new FormControl(),
            ChoiceName: new FormControl(),
            DisplayOrder: new FormControl(),
            PriorityPoint: new FormControl(),
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
