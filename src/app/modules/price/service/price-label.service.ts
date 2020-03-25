import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';
import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { PriceLabel } from '@price/model/price-label.model';

@Injectable()
export class PriceLabelService extends CRUDLService<PriceLabel> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'PriceLabel');
    }

    getLabelPriceList() {
        let req = this.httpClient.get<PriceLabel[]>(this.baseRoute + 'PriceLabelList', { observe: 'body', responseType: 'json'/*, params: p */});
        req.subscribe
        (
            result => {
            }
        );
        return req;
    }
    getLabelPriceCheckedList(pSize:string) {
        return  this.httpClient.get<any>(this.baseRoute + 'PriceLabelCheckedList', { observe: 'body', responseType: 'json', params:{ pS:pSize}});
        // req.subscribe
        // (
        //     result => {
        //     }
        // );
       // return req;
    }
}
