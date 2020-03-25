// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Reconciliation, ZetImage } from '@reconciliation/model/reconciliation.model';
import { ZControlLog } from '@reconciliation/model/z-control-log.model';

/*Section="ClassHeader"*/
@Injectable()
export class ReconciliationService extends CRUDLService<Reconciliation> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Reconciliation', 'Reconciliation');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    ReconciliationDate(storeId) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        return  this.httpClient.get<Reconciliation>(this.baseRoute + 'ReconciliationDate', { observe: 'body', responseType: 'json', params: params });
    }

    NotReconStores(startDate, endDate) {
        let params = new HttpParams();
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return  this.httpClient.get<any>(this.baseRoute + 'NotReconStores', { observe: 'body', responseType: 'json', params: params });
    }

    ReconciliationStoreDate(storeId, startDate, endDate) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        params = params.append('startDate', startDate);
        params = params.append('endDate', endDate);
        return  this.httpClient.get<Reconciliation[]>(this.baseRoute + 'ReconciliationStoreDate', { observe: 'body', responseType: 'json', params: params });
    }

    ReadReconciliationDetails(storeId) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        return  this.httpClient.get<Reconciliation>(this.baseRoute + 'ReadReconciliationDetails', { observe: 'body', responseType: 'json', params: params });
    }

    SaveReconciliation(rec) {
        return this.httpClient.post(this.baseRoute + 'SaveReconciliation', rec);
    }

    ReCalculate(storeId) {
        let params = new HttpParams();
        params = params.append('storeId', storeId);
        return this.httpClient.put(this.baseRoute + 'Recalculate', params);
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    uploadZetImage(zetImage: ZetImage) {
        return this.httpClient.post(this.baseRoute + 'UploadZetImage', zetImage );
    }

    deleteZetImage(zetImage: ZetImage) {
        let params = new HttpParams();
        params = params.set('zetImageId', zetImage.ZetImageId.toString());
        params = params.set('documentId', zetImage.Document.toString());
        params = params.set('reconciliationId', zetImage.Reconciliation.toString());
        params = params.set('cashRegisterId', zetImage.CashRegister.toString());
        return this.httpClient.get(this.baseRoute + 'DeleteZetImage',  { observe: 'body', responseType: 'json', params: params } );
    }

    listZetImages(reconciliationId: number) {
        let params = new HttpParams();
        params = params.append('reconciliationId', reconciliationId.toString());
        return this.httpClient.get<ZetImage[]>(this.baseRoute + 'ListZetImages', { observe: 'body', responseType: 'json', params: params });
    }

    createZControlLog(dataObject: ZControlLog) {
        return this.httpClient.post(this.baseRoute + 'CreateZControlLog', dataObject );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
