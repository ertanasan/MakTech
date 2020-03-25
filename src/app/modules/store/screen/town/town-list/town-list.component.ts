// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Town } from '@store/model/town.model';
import { TownService } from '@store/service/town.service';
import { TownEditComponent } from '@store/screen/town/town-edit/town-edit.component';
import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-town-list',
    templateUrl: './town-list.component.html',
    styleUrls: ['./town-list.component.css', ]
})
export class TownListComponent extends ListScreenBase<Town> implements AfterViewInit, OnInit {
    @ViewChild(TownEditComponent, {static: true}) editScreen: TownEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: TownService,
        public cityService: CityService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Town', RouterLink: '/store/town'}];
    }

    createEmptyModel(): Town {
        return new Town();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.cityService.completeList) {
            this.cityService.listAll();
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
