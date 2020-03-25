// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { PosMovement } from '@store/model/pos-movement.model';

/*Section="ClassHeader"*/
@Injectable()
export class PosMovementService extends CRUDLService<PosMovement> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'PosMovement');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public PosMoveInitial() {
        return this.httpClient.post(this.baseRoute + 'PosMoveInitial', { observe: 'body', responseType: 'json' });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
