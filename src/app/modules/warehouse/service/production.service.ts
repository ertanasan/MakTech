// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Production } from '@warehouse/model/production.model';
import { ProductionContent } from '@warehouse/model/production-content.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductionService extends CRUDLService<Production> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'Production');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ListProductionContentswithStocks(productionId) {
        const params = new HttpParams().append('productionId', productionId);
        return this.httpClient.get<ProductionContent[]>(this.baseRoute + 'ListProductionContentswithStocks', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
