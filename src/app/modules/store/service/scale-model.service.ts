// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ScaleModel } from '@store/model/scale-model.model';

/*Section="ClassHeader"*/
@Injectable()
export class ScaleModelService extends CRUDMLService<ScaleModel> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'ScaleModel');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
