// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { MaterialCategory } from '@warehouse/model/material-category.model';
import { MaterialCategoryService } from '@warehouse/service/material-category.service';
import { MaterialCategoryEditComponent } from '@warehouse/screen/material-category/material-category-edit/material-category-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-category-list',
    templateUrl: './material-category-list.component.html',
    styleUrls: ['./material-category-list.component.css', ]
})
export class MaterialCategoryListComponent extends ListScreenBase<MaterialCategory> implements AfterViewInit {
    @ViewChild(MaterialCategoryEditComponent, { static: true }) editScreen: MaterialCategoryEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: MaterialCategoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Material Category', RouterLink: '/warehouse/material-category'}];
    }

    createEmptyModel(): MaterialCategory {
        return new MaterialCategory();
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
