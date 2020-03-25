// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ShipmentPackageType } from '@warehouse/model/shipment-package-type.model';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';
import { ShipmentPackageTypeEditComponent } from '@warehouse/screen/shipment-package-type/shipment-package-type-edit/shipment-package-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-shipment-package-type-list',
    templateUrl: './shipment-package-type-list.component.html',
    styleUrls: ['./shipment-package-type-list.component.css', ]
})
export class ShipmentPackageTypeListComponent extends ListScreenBase<ShipmentPackageType> implements AfterViewInit {
    @ViewChild(ShipmentPackageTypeEditComponent, {static: true}) editScreen: ShipmentPackageTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ShipmentPackageTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Shipment Package Type', RouterLink: '/warehouse/shipment-package-type'}];
    }

    createEmptyModel(): ShipmentPackageType {
        return new ShipmentPackageType();
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
