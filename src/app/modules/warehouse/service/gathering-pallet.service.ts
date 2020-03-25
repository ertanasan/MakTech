// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { GatheringPallet } from '@warehouse/model/gathering-pallet.model';
import {Observable, Subject} from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class GatheringPalletService extends CRUDLService<GatheringPallet> {
    activePallet: GatheringPallet;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'GatheringPallet');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    public ActiveControlPallets () {
        return this.httpClient.get<GatheringPallet[]>(this.baseRoute + 'ActiveControlPallets', { observe: 'body', responseType: 'json' });
    }

    public StartControl(gatheringPalletId, allowReControl) {
        let params = new HttpParams().append('gatheringPalletId', gatheringPalletId);
        params = params.append('allowReControl', allowReControl);
        return this.httpClient.post<number>(`${this.baseRoute}StartControl/${gatheringPalletId}/${allowReControl}`, { observe: 'body', responseType: 'json', params: params});
    }

    public listPalletByGatheringId(gatheringId: number, palletNo: number = -1): Observable<GatheringPallet[]> {
        const params = new HttpParams().append('gatheringId', gatheringId.toString());
        return this.httpClient.get<GatheringPallet[]>(this.baseRoute + 'ListPalletByGatheringId', { observe: 'body', responseType: 'json', params: params });

    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
