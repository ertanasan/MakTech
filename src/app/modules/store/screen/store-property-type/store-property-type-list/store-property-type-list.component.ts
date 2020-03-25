// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StorePropertyType } from '@store/model/store-property-type.model';
import { StorePropertyTypeService } from '@store/service/store-property-type.service';
import { StorePropertyTypeEditComponent } from '@store/screen/store-property-type/store-property-type-edit/store-property-type-edit.component';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-property-type-list',
    templateUrl: './store-property-type-list.component.html',
    styleUrls: ['./store-property-type-list.component.css', ]
})
export class StorePropertyTypeListComponent extends ListScreenBase<StorePropertyType> implements AfterViewInit {
    @ViewChild(StorePropertyTypeEditComponent, {static: true}) editScreen: StorePropertyTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StorePropertyTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store Property Type', RouterLink: '/store/store-property-type'}];
    }

    createEmptyModel(): StorePropertyType {
        return new StorePropertyType();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.assignOption = 'none';
        this.editScreen.assignValue = null;
        super.showDialog(target, actionName, dataItem);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
