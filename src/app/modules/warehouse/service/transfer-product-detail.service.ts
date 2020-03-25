// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { TransferProductDetail } from '@warehouse/model/transfer-product-detail.model';
import { TransferProduct } from '@warehouse/model/transfer-product.model';
import { Subject, Observable } from 'rxjs';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
@Injectable()
export class TransferProductDetailService extends CRUDLService<TransferProductDetail> {
    public obsData: Subject<TransferProductDetail[]> = new Subject<TransferProductDetail[]>();
    initialItem: TransferProductDetail[] = new Array<TransferProductDetail>();
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'TransferProductDetail');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    createAll(model: TransferProductDetail[], action = 'CreateAll') {

        return this.httpClient.put<TransferProductDetail[]>(this.baseRoute + action, model);
    }
    updateAll(model: TransferProductDetail[], action = 'UpdateAll') {
        return this.httpClient.put<TransferProductDetail[]>(this.baseRoute + action, model);
    }

    deleteAll(id: number[] | RelationId, action = 'DeleteAll') {
        return this.httpClient.put<TransferProductDetail[]>(this.baseRoute + action, id);
    }


    //#endregion Customized

    /*Section="ClassFooter"*/
}
