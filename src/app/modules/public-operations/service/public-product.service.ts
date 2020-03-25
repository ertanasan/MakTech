// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpBackend, HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Product } from '@product/model/product.model';
import {Observable} from 'rxjs';
import {StorageCondition} from '@product/model/storage-condition.model';
import {Country} from '@product/model/country.model';
import {Unit} from '@product/model/unit.model';
import { ProductBarcode } from '@product/model/product-barcode.model';

/*Section="ClassHeader"*/
@Injectable()
export class PublicProductService extends CRUDLService<Product> {
    storageConditionList: StorageCondition[];
    countryList: Country[];
    unitList: Unit[];
    ProductBarcodeList: ProductBarcode[];

    constructor(
        handler: HttpBackend,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(new HttpClient(handler), messageService, translateService, 'Product', 'Product');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    getProductInfo(productId: number): Observable<Product> {
        const params = new HttpParams().append('productId', productId.toString());
        return this.httpClient.get<Product>(this.baseRoute + 'GetProductInfo', { responseType: 'json', params: params});
    }

    // tslint:disable-next-line:typedef-whitespace
    // tslint:disable-next-line:no-shadowed-variable
    listProductBarcodes(productId: number): Observable<ProductBarcode[]> {
        const params = new HttpParams().append('productId', productId.toString());
        return this.httpClient.get<ProductBarcode[]>(this.baseRoute + 'ListBarcodeByProductId', {responseType: 'json', params: params});
    }

    listAllStorageConditions(): void {
        this.httpClient.get<StorageCondition[]>(this.baseRoute + 'ListAllStorageConditions', { responseType: 'json'})
            .subscribe(list => this.storageConditionList = list);
    }

    listAllCountries() {
        this.httpClient.get<Country[]>(this.baseRoute + 'ListAllCountries', { responseType: 'json'})
            .subscribe(list => this.countryList = list);
    }

    listAllUnits() {
        this.httpClient.get<Unit[]>(this.baseRoute + 'ListAllUnits', { responseType: 'json'})
            .subscribe(list => this.unitList = list);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
