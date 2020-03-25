// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { OverStoreScreenProperty } from '@app-main/model/over-store-screen-property.model';

/*Section="ClassHeader"*/
@Injectable()
export class OverStoreScreenPropertyService extends CRUDLService<OverStoreScreenProperty> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'OverStoreMain', 'OverStoreScreenProperty');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    
    public listScreenProperties(screenId?: number) {
        let params = null;
        if (screenId) {
            params = new HttpParams().append('screenId', screenId.toString());
        } else {
            params = new HttpParams().append('screenId', '-1');
        }
        return this.httpClient.get<OverStoreScreenProperty[]>(this.baseRoute + 'ListScreenProperties', { observe: 'body', responseType: 'json', params: params});
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
