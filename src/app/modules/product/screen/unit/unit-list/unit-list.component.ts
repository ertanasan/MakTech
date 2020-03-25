// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';
import { UnitEditComponent } from '@product/screen/unit/unit-edit/unit-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-unit-list',
    templateUrl: './unit-list.component.html',
    styleUrls: ['./unit-list.component.css', ]
})
export class UnitListComponent extends ListScreenBase<Unit> implements AfterViewInit {
    @ViewChild(UnitEditComponent, {static: true}) editScreen: UnitEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: UnitService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Unit', RouterLink: '/product/unit'}];
    }

    createEmptyModel(): Unit {
        return new Unit();
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
