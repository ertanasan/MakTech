// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreAccountType } from '@store/model/store-account-type.model';
import { StoreAccountTypeService } from '@store/service/store-account-type.service';
import { StoreAccountTypeEditComponent } from '@store/screen/store-account-type/store-account-type-edit/store-account-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-account-type-list',
    templateUrl: './store-account-type-list.component.html',
    styleUrls: ['./store-account-type-list.component.css', ]
})
export class StoreAccountTypeListComponent extends ListScreenBase<StoreAccountType> implements AfterViewInit {
    @ViewChild(StoreAccountTypeEditComponent, {static: true}) editScreen: StoreAccountTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreAccountTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store Account Type', RouterLink: '/store/store-account-type'}];
    }

    createEmptyModel(): StoreAccountType {
        return new StoreAccountType();
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
