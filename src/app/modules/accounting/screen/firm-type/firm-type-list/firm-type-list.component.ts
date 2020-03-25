// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { FirmType } from '@accounting/model/firm-type.model';
import { FirmTypeService } from '@accounting/service/firm-type.service';
import { FirmTypeEditComponent } from '@accounting/screen/firm-type/firm-type-edit/firm-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-type-list',
    templateUrl: './firm-type-list.component.html',
    styleUrls: ['./firm-type-list.component.css', ]
})
export class FirmTypeListComponent extends ListScreenBase<FirmType> implements AfterViewInit {
    @ViewChild(FirmTypeEditComponent, { static: true }) editScreen: FirmTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FirmTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Firm Type', RouterLink: '/accounting/firm-type'}];
    }

    createEmptyModel(): FirmType {
        return new FirmType();
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
