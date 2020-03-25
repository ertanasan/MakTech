// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProcessDefinition } from '@helpdesk/model/process-definition.model';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';
import { ProcessDefinitionEditComponent } from '@helpdesk/screen/process-definition/process-definition-edit/process-definition-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-process-definition-list',
    templateUrl: './process-definition-list.component.html',
    styleUrls: ['./process-definition-list.component.css', ]
})
export class ProcessDefinitionListComponent extends ListScreenBase<ProcessDefinition> implements AfterViewInit {
    @ViewChild(ProcessDefinitionEditComponent, {static: true}) editScreen: ProcessDefinitionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProcessDefinitionService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Helpdesk' }, {Caption: 'Process Definition', RouterLink: '/helpdesk/process-definition'}];
    }

    createEmptyModel(): ProcessDefinition {
        return new ProcessDefinition();
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
