// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Warning } from '@product/model/warning.model';
import { WarningService } from '@product/service/warning.service';
import { WarningEditComponent } from '@product/screen/warning/warning-edit/warning-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-warning-list',
    templateUrl: './warning-list.component.html',
    styleUrls: ['./warning-list.component.css', ]
})
export class WarningListComponent extends ListScreenBase<Warning> implements AfterViewInit {
    @ViewChild(WarningEditComponent, {static: true}) editScreen: WarningEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: WarningService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Warning', RouterLink: '/product/warning'}];
    }

    createEmptyModel(): Warning {
        return new Warning();
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
