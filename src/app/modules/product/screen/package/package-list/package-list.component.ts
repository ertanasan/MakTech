// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Package } from '@product/model/package.model';
import { PackageService } from '@product/service/package.service';
import { PackageEditComponent } from '@product/screen/package/package-edit/package-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-list',
    templateUrl: './package-list.component.html',
    styleUrls: ['./package-list.component.css', ]
})
export class PackageListComponent extends ListScreenBase<Package> implements AfterViewInit {
    @ViewChild(PackageEditComponent, {static: true}) editScreen: PackageEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: PackageService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Package', RouterLink: '/product/package'}];
    }

    createEmptyModel(): Package {
        return new Package();
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
