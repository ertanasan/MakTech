// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { BarcodeType } from '@product/model/barcode-type.model';
import { BarcodeTypeService } from '@product/service/barcode-type.service';
import { BarcodeTypeEditComponent } from '@product/screen/barcode-type/barcode-type-edit/barcode-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-barcode-type-list',
    templateUrl: './barcode-type-list.component.html',
    styleUrls: ['./barcode-type-list.component.css', ]
})
export class BarcodeTypeListComponent extends ListScreenBase<BarcodeType> implements AfterViewInit {
    @ViewChild(BarcodeTypeEditComponent, {static: true}) editScreen: BarcodeTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: BarcodeTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Barcode Type', RouterLink: '/product/barcode-type'}];
    }

    createEmptyModel(): BarcodeType {
        return new BarcodeType();
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
