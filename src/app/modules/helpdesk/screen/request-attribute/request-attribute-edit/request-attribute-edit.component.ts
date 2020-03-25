// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RequestAttribute } from '@helpdesk/model/request-attribute.model';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';
import { RequestGroup } from '@helpdesk/model/request-group.model';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { RequestDefinition } from '@helpdesk/model/request-definition.model';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { AttributeType } from '@helpdesk/model/attribute-type.model';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-attribute-edit',
    templateUrl: './request-attribute-edit.component.html',
    styleUrls: ['./request-attribute-edit.component.css', ]
})
export class RequestAttributeEditComponent extends CRUDDialogScreenBase<RequestAttribute> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<RequestAttribute>;

    public isGroup = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RequestAttributeService,
        public requestGroupService: RequestGroupService,
        public requestDefinitionService: RequestDefinitionService,
        public attributeTypeService: AttributeTypeService,
    ) {
        super(messageService, translateService, dataService, 'Request Attribute');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RequestAttributeId: new FormControl(),
            AttributeName: new FormControl(),
            RequestGroup: new FormControl(),
            RequestDefinition: new FormControl(),
            AttributeType: new FormControl(),
            EditableFlag: new FormControl(),
            RequiredFlag: new FormControl(),
            DisplayOrder: new FormControl(),
            isGroup: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onGroupChange() {
        if (this.isGroup) {
            this.container.mainForm.patchValue({'RequestDefinition': null});
        } else {
            this.container.mainForm.patchValue({'RequestGroup': null});
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
