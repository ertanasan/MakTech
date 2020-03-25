// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductBarcode } from '@product/model/product-barcode.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductBarcodeService extends CRUDMLService<ProductBarcode> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Product', 'ProductBarcode');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
