// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Production } from '@warehouse/model/production.model';
import { ProductionService } from '@warehouse/service/production.service';
import { ProductionEditComponent } from '@warehouse/screen/production/production-edit/production-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-list',
    templateUrl: './production-list.component.html',
    styleUrls: ['./production-list.component.css', ]
})
export class ProductionListComponent extends ListScreenBase<Production> implements AfterViewInit, OnInit {
    @ViewChild(ProductionEditComponent, {static: true}) editScreen: ProductionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductionService,
        public productService: ProductService,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Production', RouterLink: '/warehouse/production'}];
    }

    createEmptyModel(): Production {
        return new Production();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        super.ngOnInit();
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
