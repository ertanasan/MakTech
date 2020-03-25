// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { PackageType } from '@price/model/package-type.model';
import { PackageTypeService } from '@price/service/package-type.service';
import { PackageTypeEditComponent } from '@price/screen/package-type/package-type-edit/package-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-type-list',
    templateUrl: './package-type-list.component.html',
    styleUrls: ['./package-type-list.component.css', ]
})
export class PackageTypeListComponent extends ListScreenBase<PackageType> implements AfterViewInit {
    @ViewChild(PackageTypeEditComponent, {static: true}) editScreen: PackageTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: PackageTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Package Type', RouterLink: '/price/package-type'}];
    }

    createEmptyModel(): PackageType {
        return new PackageType();
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
