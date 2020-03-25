// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RequestAttribute } from '@helpdesk/model/request-attribute.model';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';
import { RequestAttributeEditComponent } from '@helpdesk/screen/request-attribute/request-attribute-edit/request-attribute-edit.component';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-request-attribute-list',
    templateUrl: './request-attribute-list.component.html',
    styleUrls: ['./request-attribute-list.component.css', ]
})
export class RequestAttributeListComponent extends ListScreenBase<RequestAttribute> implements AfterViewInit, OnInit {
    @ViewChild(RequestAttributeEditComponent, {static: true}) editScreen: RequestAttributeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RequestAttributeService,
        public requestGroupService: RequestGroupService,
        public requestDefinitionService: RequestDefinitionService,
        public attributeTypeService: AttributeTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Request Attribute', RouterLink: '/helpdesk/request-attribute'}];
    }

    createEmptyModel(): RequestAttribute {
        const model = new RequestAttribute();
        model.EditableFlag = false;
        model.RequiredFlag = false;
        model.isGroup = true;
        return model;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        if (!this.requestGroupService.completeList) {
            this.requestGroupService.listAll();
        }
        if (!this.requestDefinitionService.completeList) {
            this.requestDefinitionService.listAll();
        }
        if (!this.attributeTypeService.completeList) {
            this.attributeTypeService.listAll();
        }
        super.ngOnInit();
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (dataItem && dataItem.RequestGroup) {
            // console.log(1, dataItem);
            this.editScreen.isGroup = true;
            dataItem.isGroup = true;
            dataItem.RequestDefinition = null;
        } else if (dataItem && dataItem.RequestDefinition) {
            // console.log(2, dataItem);
            this.editScreen.isGroup = false;
            dataItem.isGroup = false;
            dataItem.RequestGroup = null;
        } else {
            this.editScreen.isGroup = true;
        }
        super.showDialog(target, actionName, dataItem);
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
