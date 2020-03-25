// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { GatheringPalletPhoto } from '@warehouse/model/gathering-pallet-photo.model';
import {finalize} from 'rxjs/operators';
import {Observable} from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class GatheringPalletPhotoService extends CRUDLService<GatheringPalletPhoto> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'GatheringPalletPhoto');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listPalletPhoto(storeOrderId: number, gatheringPalletId?: number): Observable<GatheringPalletPhoto[]> {
        this.loading = true;
        let params = new HttpParams().append('storeOrderId', storeOrderId.toString());
        params = params.append('gatheringPalletId', gatheringPalletId ? gatheringPalletId.toString() : null);
        return <Observable<GatheringPalletPhoto[]>> this.httpClient.get(this.baseRoute + 'ListPalletPhoto', { observe: 'body', responseType: 'json', params: params})
            .pipe(finalize(() => this.loading = false));
    }

    uploadPhoto(gatheringPalletPhoto: GatheringPalletPhoto) {
        this.loading = true;
        return this.httpClient.post(this.baseRoute + 'UploadPalletPhoto', gatheringPalletPhoto)
            .pipe(finalize(() => this.loading = false));
    }

    deletePhoto(gatheringPalletPhotoId: number) {
        this.loading = true;
        const params = new HttpParams().append('gatheringPalletPhotoId', gatheringPalletPhotoId.toString());
        return this.httpClient.delete(this.baseRoute + 'DeletePalletPhoto', {params: params})
            .pipe(finalize(() => this.loading = false));
    }

    getPhotoByIndex(storeOrderId: number, photoIndex: number, gatheringPalletId?: number) {
        this.loading = true;
        let params = new HttpParams().append('storeOrderId', storeOrderId.toString());
        params = params.append('photoIndex', photoIndex.toString());
        params = params.append('gatheringPalletId', gatheringPalletId ? gatheringPalletId.toString() : null);
        return <Observable<GatheringPalletPhoto>> this.httpClient.get(this.baseRoute + 'GetPhotoByIndex', { observe: 'body', responseType: 'json', params: params})
            .pipe(finalize(() => this.loading = false));
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
