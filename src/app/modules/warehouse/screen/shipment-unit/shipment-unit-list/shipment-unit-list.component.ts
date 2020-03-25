// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ShipmentUnit } from '@warehouse/model/shipment-unit.model';
import { ShipmentUnitService } from '@warehouse/service/shipment-unit.service';
import { ShipmentUnitEditComponent } from '@warehouse/screen/shipment-unit/shipment-unit-edit/shipment-unit-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-unit-list',
    templateUrl: './shipment-unit-list.component.html',
    styleUrls: ['./shipment-unit-list.component.css', ]
})
export class ShipmentUnitListComponent extends ListScreenBase<ShipmentUnit> implements AfterViewInit {
    @ViewChild(ShipmentUnitEditComponent, {static: true}) editScreen: ShipmentUnitEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ShipmentUnitService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Shipment Unit', RouterLink: '/warehouse/shipment-unit'}];
    }

    createEmptyModel(): ShipmentUnit {
        return new ShipmentUnit();
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
