// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { OverStoreScreenProperty } from '@over-store-main/model/over-store-screen-property.model';
import { OverStoreScreenPropertyService } from '@over-store-main/service/over-store-screen-property.service';
import { OverStoreScreenPropertyEditComponent } from '@over-store-main/screen/over-store-screen-property/over-store-screen-property-edit/over-store-screen-property-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-over-store-screen-property-list',
    templateUrl: './over-store-screen-property-list.component.html',
    styleUrls: ['./over-store-screen-property-list.component.css', ]
})
export class OverStoreScreenPropertyListComponent extends ListScreenBase<OverStoreScreenProperty> implements AfterViewInit {
    @ViewChild(OverStoreScreenPropertyEditComponent, { static: true }) editScreen: OverStoreScreenPropertyEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: OverStoreScreenPropertyService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'OverStoreMain' }, {Caption: 'OverStore Screen Property', RouterLink: '/over-store-main/over-store-screen-property'}];
    }

    createEmptyModel(): OverStoreScreenProperty {
        return new OverStoreScreenProperty();
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
