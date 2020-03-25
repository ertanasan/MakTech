// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { IntakeStatusType } from '@warehouse/model/intake-status-type.model';
import { IntakeStatusTypeService } from '@warehouse/service/intake-status-type.service';
import { IntakeStatusTypeEditComponent } from '@warehouse/screen/intake-status-type/intake-status-type-edit/intake-status-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-intake-status-type-list',
    templateUrl: './intake-status-type-list.component.html',
    styleUrls: ['./intake-status-type-list.component.css', ]
})
export class IntakeStatusTypeListComponent extends ListScreenBase<IntakeStatusType> implements AfterViewInit {
    @ViewChild(IntakeStatusTypeEditComponent, {static: true}) editScreen: IntakeStatusTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: IntakeStatusTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Intake Status Type', RouterLink: '/warehouse/intake-status-type'}];
    }

    createEmptyModel(): IntakeStatusType {
        return new IntakeStatusType();
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
