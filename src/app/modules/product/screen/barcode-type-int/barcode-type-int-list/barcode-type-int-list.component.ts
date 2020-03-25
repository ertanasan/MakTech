// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { BarcodeTypeInt } from '@product/model/barcode-type-int.model';
import { BarcodeTypeIntService } from '@product/service/barcode-type-int.service';
import { BarcodeTypeIntEditComponent } from '@product/screen/barcode-type-int/barcode-type-int-edit/barcode-type-int-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-barcode-type-int-list',
    templateUrl: './barcode-type-int-list.component.html',
    styleUrls: ['./barcode-type-int-list.component.css', ]
})
export class BarcodeTypeIntListComponent extends ListScreenBase<BarcodeTypeInt> implements AfterViewInit {
    @ViewChild(BarcodeTypeIntEditComponent, {static: true}) editScreen: BarcodeTypeIntEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: BarcodeTypeIntService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Barcode Type Int', RouterLink: '/product/barcode-type-int'}];
    }

    createEmptyModel(): BarcodeTypeInt {
        return new BarcodeTypeInt();
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
