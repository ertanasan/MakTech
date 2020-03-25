// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { CashRegisterBrand } from '@store/model/cash-register-brand.model';
import { CashRegisterBrandService } from '@store/service/cash-register-brand.service';
import { CashRegisterBrandEditComponent } from '@store/screen/cash-register-brand/cash-register-brand-edit/cash-register-brand-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-register-brand-list',
    templateUrl: './cash-register-brand-list.component.html',
    styleUrls: ['./cash-register-brand-list.component.css', ]
})
export class CashRegisterBrandListComponent extends ListScreenBase<CashRegisterBrand> implements AfterViewInit {
    @ViewChild(CashRegisterBrandEditComponent, {static: true}) editScreen: CashRegisterBrandEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: CashRegisterBrandService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Cash Register Brand', RouterLink: '/store/cash-register-brand'}];
    }

    createEmptyModel(): CashRegisterBrand {
        return new CashRegisterBrand();
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
