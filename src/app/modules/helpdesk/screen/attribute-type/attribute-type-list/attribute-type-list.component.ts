// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { AttributeType } from '@helpdesk/model/attribute-type.model';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';
import { AttributeTypeEditComponent } from '@helpdesk/screen/attribute-type/attribute-type-edit/attribute-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-attribute-type-list',
    templateUrl: './attribute-type-list.component.html',
    styleUrls: ['./attribute-type-list.component.css', ]
})
export class AttributeTypeListComponent extends ListScreenBase<AttributeType> implements AfterViewInit {
    @ViewChild(AttributeTypeEditComponent, {static: true}) editScreen: AttributeTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: AttributeTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Attribute Type', RouterLink: '/helpdesk/attribute-type'}];
    }

    createEmptyModel(): AttributeType {
        return new AttributeType();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
