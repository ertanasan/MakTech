// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StorePropertyType } from '@store/model/store-property-type.model';

/*Section="ClassHeader"*/
@Injectable()
export class StorePropertyTypeService extends CRUDLService<StorePropertyType> {

    remainingPropertyTypes: any;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StorePropertyType');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listRemainingPropertyTypes(storeId) {
        const params = new HttpParams().append('storeId', storeId);
        const obsRemainingPropertyTypes = this.httpClient.get<StorePropertyType[]>(this.baseRoute + 'RemainingPropertyTypes', { observe: 'body', responseType: 'json', params: params });
        obsRemainingPropertyTypes.subscribe(
                list => {
                    this.remainingPropertyTypes = list;
                },
                error => {
                    this.messageService.error(error.message);
                }
            );
        return obsRemainingPropertyTypes;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
