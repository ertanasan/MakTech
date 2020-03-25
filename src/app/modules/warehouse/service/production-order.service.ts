// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductionOrder } from '@warehouse/model/production-order.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductionOrderService extends CRUDLService<ProductionOrder> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'ProductionOrder');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    getTolerancePct () {
        return this.httpClient.get<number>(this.baseRoute + 'GetTolerancePct', { observe: 'body', responseType: 'json' });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
