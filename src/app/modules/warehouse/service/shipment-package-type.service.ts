// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ShipmentPackageType } from '@warehouse/model/shipment-package-type.model';

/*Section="ClassHeader"*/
@Injectable()
export class ShipmentPackageTypeService extends CRUDLService<ShipmentPackageType> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'ShipmentPackageType');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    shortList: ShipmentPackageType[];
    //#endregion Customized

    /*Section="ClassFooter"*/
}
