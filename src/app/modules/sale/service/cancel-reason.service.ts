// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { CancelReason } from '@sale/model/cancel-reason.model';

/*Section="ClassHeader"*/
@Injectable()
export class CancelReasonService extends CRUDLService<CancelReason> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Sale', 'CancelReason');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ListReconciliationCancels (recDate, storeId) {
        let params = new HttpParams().append('recDate', recDate);
        params = params.append('storeId', storeId.toString());
        return this.httpClient.get<CancelReason[]>(this.baseRoute + 'ListRecCancelsByDate', { observe: 'body', responseType: 'json', params: params });
    }

    SaveCancelReasons(rec: CancelReason[], callback) {
        // console.log(rec);
        this.httpClient.post<any>(this.baseRoute + 'SaveCancelReasons', rec).subscribe(result => {
            // console.log('nedenler kaydedildi.');
            callback();
        }, error => {
            console.log(error);
            this.messageService.error(error.error);
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
