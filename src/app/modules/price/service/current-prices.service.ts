// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { CurrentPrices } from '@price/model/current-prices.model';

/*Section="ClassHeader"*/
@Injectable()
export class CurrentPricesService extends CRUDLService<CurrentPrices> {

    constructor(httpClient: HttpClient, messageService: GrowlMessageService, translateService: TranslateService) {
        super(httpClient, messageService, translateService, 'Price', 'CurrentPrices');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
