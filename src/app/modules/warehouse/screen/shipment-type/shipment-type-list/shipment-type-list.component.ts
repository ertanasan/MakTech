// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ShipmentType } from '@warehouse/model/shipment-type.model';
import { ShipmentTypeService } from '@warehouse/service/shipment-type.service';
import { ShipmentTypeEditComponent } from '@warehouse/screen/shipment-type/shipment-type-edit/shipment-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-type-list',
    templateUrl: './shipment-type-list.component.html',
    styleUrls: ['./shipment-type-list.component.css', ]
})
export class ShipmentTypeListComponent extends ListScreenBase<ShipmentType> implements AfterViewInit {
    @ViewChild(ShipmentTypeEditComponent, {static: true}) editScreen: ShipmentTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ShipmentTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Shipment Type', RouterLink: '/warehouse/shipment-type'}];
    }

    createEmptyModel(): ShipmentType {
        return new ShipmentType();
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
