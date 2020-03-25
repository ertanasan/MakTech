// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Material } from '@warehouse/model/material.model';
import { MaterialService } from '@warehouse/service/material.service';
import { MaterialEditComponent } from '@warehouse/screen/material/material-edit/material-edit.component';
import { MaterialCategoryService } from '@warehouse/service/material-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-material-list',
    templateUrl: './material-list.component.html',
    styleUrls: ['./material-list.component.css', ]
})
export class MaterialListComponent extends ListScreenBase<Material> implements OnInit, AfterViewInit {
    @ViewChild(MaterialEditComponent, { static: true }) editScreen: MaterialEditComponent;

    UnitCodeList = [{value: 1, text: 'Adet'}, {value: 2, text: 'Kg'}];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: MaterialService,
        public materialCategoryService: MaterialCategoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Material', RouterLink: '/warehouse/material'}];
    }

    createEmptyModel(): Material {
        return new Material();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        if (!this.materialCategoryService.completeList) {
            this.materialCategoryService.listAll();
        }
        super.ngOnInit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
