// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { StoreEditComponent } from '@store/screen/store/store-edit/store-edit.component';
import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';
import { Town } from '@store/model/town.model';
import { TownService } from '@store/service/town.service';
import { RegionManagersService } from '@store/service/region-managers.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-list',
    templateUrl: './store-list.component.html',
    styleUrls: ['./store-list.component.css', ]
})
export class StoreListComponent extends ListScreenBase<Store> implements AfterViewInit, OnInit {
    @ViewChild(StoreEditComponent, {static: true}) editScreen: StoreEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreService,
        public cityService: CityService,
        public townService: TownService,
        public regionManagersService: RegionManagersService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store', RouterLink: '/store/store'}];
    }

    createEmptyModel(): Store {
        return new Store();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.cityService.completeList) {
            this.cityService.listAll();
        }
        if (!this.townService.completeList) {
            this.townService.listAll();
        }
        // if (!this.regionManagersService.completeList) {
        //     this.regionManagersService.listAll();
        // }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['OpeningDate', 'ClosingDate'];
        super.handleDataStateChange(state);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
