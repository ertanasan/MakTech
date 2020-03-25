// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StockGroupName } from '@product/model/stock-group-name.model';
import { StockGroupNameService } from '@product/service/stock-group-name.service';
import { StockGroupNameEditComponent } from '@product/screen/stock-group-name/stock-group-name-edit/stock-group-name-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-group-name-list',
    templateUrl: './stock-group-name-list.component.html',
    styleUrls: ['./stock-group-name-list.component.css', ]
})
export class StockGroupNameListComponent extends ListScreenBase<StockGroupName> implements AfterViewInit {
    @ViewChild(StockGroupNameEditComponent, {static: true}) editScreen: StockGroupNameEditComponent;

    usageTypeList = [{value: 1, text: 'Stok Hesabı'}, {value: 2, text: 'Raporlama'}];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StockGroupNameService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Stock Group Name', RouterLink: '/product/stock-group-name'}];
    }

    createEmptyModel(): StockGroupName {
        return new StockGroupName();
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
