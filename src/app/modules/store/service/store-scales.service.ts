// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreScales } from '@store/model/store-scales.model';

/*Section="ClassHeader"*/
@Injectable()
export class StoreScalesService extends CRUDMLService<StoreScales> {

    userScale: StoreScales[];
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StoreScales');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getUserScale() {
        this.httpClient.get<StoreScales[]>(this.baseRoute + 'GetUserScale', { observe: 'body', responseType: 'json' }).subscribe(result => {
            result.forEach(row => {
                if (row.SerialNumber && row.SerialNumber !== null) {
                    row.ScaleLongName = row.Name + ' - ' + row.SerialNumber;
                } else {
                    row.ScaleLongName = row.Name;
                }
            });
            this.userScale = result;
        });
    }

    createScale(model: StoreScales) {
       return this.httpClient.post<StoreScales>(this.baseRoute + 'CreateScale', model);
    }

    updateScale(model: StoreScales) {
        return this.httpClient.put<StoreScales>(this.baseRoute + 'UpdateScale', model);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/

}
