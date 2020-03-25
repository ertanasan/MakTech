// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { GatheringDetail, PostList } from '@warehouse/model/gathering-detail.model';
import { finalize, map } from 'rxjs/operators';
import { Subject } from 'rxjs';
import {ListParams} from '@otmodel/list-params.model';
import {process} from '@progress/kendo-data-query';
import { Product } from '@product/model/product.model';

/*Section="ClassHeader"*/
@Injectable()
export class GatheringDetailService extends CRUDLService<GatheringDetail> {
    gatheringDetailLoading = false;
    gatheringDetailList: GatheringDetail[] = [];
    controlDetailList: GatheringDetail[] = [];
    addableGatheringDetailList: Product[] = [];
    gatheringDetailActiveList: any;
    controlDetailActiveList: any;

    activeGatheringDetail: GatheringDetail;
    palletList = [];
    initialTime: Date;
    initialQuantity: number;

    onUpdate = new Subject();
    onGatheringDetailListChanged = new Subject();
    onControlDetailListChanged = new Subject();
    onGridViewShow = new Subject();

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'GatheringDetail');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listGatheringDetail(gatheringId: number, listParams: ListParams = null) {
        const params = new HttpParams().append('gatheringId', gatheringId.toString());
        return this.httpClient.get<GatheringDetail[]>(this.baseRoute + 'ListGatheringDetail', { observe: 'body', responseType: 'json', params: params }).pipe(
            map(result => {
                this.gatheringDetailList = result;
                this.onGatheringDetailListChanged.next(result);
                this.calculatePalletCount();
                this.gatheringDetailList.forEach(gd => {
                    gd.GatheredQuantity || gd.GatheredQuantity === 0 ? gd.Proceed = true : gd.Proceed = false;
                });
                if (!listParams) {
                    listParams = new ListParams();
                }
                this.prepareActiveGatheringDetailList(listParams);
            }),
            finalize(() => this.gatheringDetailLoading = false)
        );
    }

    prepareActiveGatheringDetailList (listParams) {
        this.gatheringDetailActiveList = process(this.gatheringDetailList, listParams);
    }

    listControlDetail(gatheringId: number, palletNo: number, listParams: ListParams = null) {
        const params = new HttpParams().append('gatheringId', gatheringId.toString());
        return this.httpClient.get<GatheringDetail[]>(this.baseRoute + 'ListGatheringDetail', { observe: 'body', responseType: 'json', params: params }).pipe(
            map(result => {
                this.controlDetailList = result.filter(row => (row.PalletNo === palletNo));
                this.onControlDetailListChanged.next(result);
                this.controlDetailList.forEach(gd => {
                    (gd.ControlQuantity || gd.ControlQuantity === 0) ? gd.Proceed = true : gd.Proceed = false;
                });
                if (!listParams) {
                    listParams = new ListParams();
                }
                this.prepareActiveControlDetailList(listParams);
            }),
            finalize(() => this.gatheringDetailLoading = false)
        );
    }

    prepareActiveControlDetailList (listParams) {
        this.controlDetailActiveList = process(this.controlDetailList, listParams);
    }

    prepareAddableControlDetailList(gatheringId: number, palletNo: number) {
        let params = new HttpParams().append('GatheringId', gatheringId.toString());
        params = params.append('PalletNo', palletNo.toString());
        this.httpClient.get<Product[]>(this.baseRoute + 'ListGatheringControlAddProduct', { observe: 'body', responseType: 'json', params: params }).subscribe(result => {
            this.addableGatheringDetailList = result;
        });
    }

    addProductToControlList(gatheringId, palletNo, productId) {
        const m: PostList = new PostList();
        m.GatheringId = gatheringId;
        m.PalletNo = palletNo;
        m.ProductId = productId;
        return this.httpClient.post<any>(this.baseRoute + 'AddProducttoControlList', m);
    }

    calculatePalletCount () {
        this.palletList = [...new Set(this.gatheringDetailList.map(gd => gd.PalletNo))];
        this.palletList.sort(function(a, b) { return b - a; } );
    }

    palletChange(value?: number, indexOfItem?: number) {
        if (!value) {
            this.gatheringDetailList.forEach((gd, ind) => {
                if (!gd.Proceed) { gd.PalletNo = this.palletList[0] + 1; }
                this.update(gd).subscribe();
            });
            this.calculatePalletCount();
        } else if (indexOfItem || indexOfItem === 0) {
            const gd = this.gatheringDetailList[indexOfItem];
            gd.PalletNo = +value;
            this.update(gd).subscribe();
        } else {
            this.messageService.error('Neither pallet number, nor the gathring index number retrieved; pallet change failed');
        }
    }

    logControlZero(gatheringPalletId: number, gatheringDetailId: number, previousQuantity?: number) {
        let params = new HttpParams().append('GatheringPalletId', gatheringPalletId.toString());
        params = params.append('GatheringDetailId', gatheringDetailId.toString());
        params = params.append('PreviousQuantity', previousQuantity.toString());
        this.httpClient.get<any>(this.baseRoute + 'LogControlZero', { observe: 'body', responseType: 'json', params: params }).subscribe();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
