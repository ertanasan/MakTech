// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Product } from '@product/model/product.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductService extends CRUDLService<Product> {

    products_filtered: any;
    consignmentGoodList: Product[];    // Used in ConsignmentGoodPurchase Component


    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Product', 'Product');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listConsignmentGoods() {
        this.httpClient.get<Product[]>(this.baseRoute + 'ListConsignmentGoods', { observe: 'body', responseType: 'json' }).subscribe(
            result => this.consignmentGoodList = [...result],
            error => this.messageService.error(this.translateService.instant('Consignment List can not be retrieved'))
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
