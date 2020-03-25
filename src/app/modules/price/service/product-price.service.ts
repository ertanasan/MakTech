// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProductPrice } from '@price/model/product-price.model';
import { ListParams } from '@otmodel/list-params.model';

/*Section="ClassHeader"*/
@Injectable()
export class ProductPriceService extends CRUDLService<ProductPrice> {

    loadStatusList: any;
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'ProductPrice');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public assignValues(target: any, source: any): void {
        Object.assign(target, source);
    }

    public updatePrices(prices: ProductPrice[]) {
        return this.httpClient.put(this.baseRoute + 'UpdateAll', prices);
    }

    public getPackagePrices(packageId: number) {
        const params = new HttpParams().set('packageId', packageId.toString());
        return this.httpClient.get<ProductPrice[]>(this.baseRoute + 'PackagePrices', { observe: 'body', responseType: 'json', params: params });
    }

    public priceLoadStatus() {
        return this.httpClient.get<any>(this.baseRoute + 'PriceLoadStatus', { observe: 'body', responseType: 'json' });
    }

    listSalesByPriceGroups(storeId, productId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListSalesByPriceGroups', { observe: 'body', responseType: 'json', params: params });
    }

    listSalesTrendWithPriceChanges(storeId, productId, startDate, endDate) {
        let params = new HttpParams().append('storeId', storeId);
        params = params.append('productId', productId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return this.httpClient.get<any>(this.baseRoute + 'ListSalesTrendWithPriceChanges', { observe: 'body', responseType: 'json', params: params });
    }
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
