// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { IntakeStatus } from '@warehouse/model/intake-status.model';

/*Section="ClassHeader"*/
@Injectable()
export class IntakeStatusService extends CRUDLService<IntakeStatus> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'IntakeStatus');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    transferToMikro(storeOrderDetailIds) {
        return this.httpClient.put(this.baseRoute + 'TransferToMikro', storeOrderDetailIds);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
