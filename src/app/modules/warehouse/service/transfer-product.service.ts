// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { TransferProduct } from '@warehouse/model/transfer-product.model';

/*Section="ClassHeader"*/
@Injectable()
export class TransferProductService extends CRUDLService<TransferProduct> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'TransferProduct');
    }

    send(dataItem: TransferProduct) {
     return this.httpClient.post<TransferProduct>(this.baseRoute + 'StartTransferProcess', dataItem);
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
