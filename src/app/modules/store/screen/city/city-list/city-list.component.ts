// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';
import { CityEditComponent } from '@store/screen/city/city-edit/city-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-city-list',
    templateUrl: './city-list.component.html',
    styleUrls: ['./city-list.component.css', ]
})
export class CityListComponent extends ListScreenBase<City> implements AfterViewInit {
    @ViewChild(CityEditComponent, {static: true}) editScreen: CityEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: CityService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'City', RouterLink: '/store/city'}];
    }

    createEmptyModel(): City {
        return new City();
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
