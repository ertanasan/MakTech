// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StorageZones } from '@warehouse/model/storage-zones.model';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { StorageZonesEditComponent } from '@warehouse/screen/storage-zones/storage-zones-edit/storage-zones-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-storage-zones-list',
    templateUrl: './storage-zones-list.component.html',
    styleUrls: ['./storage-zones-list.component.css', ]
})
export class StorageZonesListComponent extends ListScreenBase<StorageZones> implements AfterViewInit {
    @ViewChild(StorageZonesEditComponent, {static: true}) editScreen: StorageZonesEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StorageZonesService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Storage Zones', RouterLink: '/warehouse/storage-zones'}];
    }

    createEmptyModel(): StorageZones {
        return new StorageZones();
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
