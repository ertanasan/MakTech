// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductionContent } from '@warehouse/model/production-content.model';
import { CRUDMLService } from '@otservice/crudml.service';

/*Section="ClassHeader"*/
@Injectable()
export class ProductionContentService extends CRUDMLService<ProductionContent> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'ProductionContent');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
