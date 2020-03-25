// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SubContactType } from '@contact/model/sub-contact-type.model';

/*Section="ClassHeader"*/
@Injectable()
export class SubContactTypeService extends CRUDMLService<SubContactType> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Contact', 'SubContactType');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
