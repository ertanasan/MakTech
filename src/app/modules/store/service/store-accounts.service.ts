// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreAccounts } from '@store/model/store-accounts.model';
import { CRUDMLService } from '@otservice/crudml.service';

/*Section="ClassHeader"*/
@Injectable()
export class StoreAccountsService extends CRUDMLService<StoreAccounts> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StoreAccounts');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
