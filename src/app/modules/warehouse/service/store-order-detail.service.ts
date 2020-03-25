// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreOrderDetail, WarehouseProductUnit } from '@warehouse/model/store-order-detail.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class StoreOrderDetailService extends CRUDLService<StoreOrderDetail> {

    warehouseProductUnits: WarehouseProductUnit[];
    orderDetails: { data: StoreOrderDetail[], total: number } = { data: [], total: 0 };
    deletedDetails: StoreOrderDetail[] = [];
    originalData: StoreOrderDetail[];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StoreOrderDetail');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    listWarehouseProductUnits(action = 'ListAll') {
        const obsWarehouseProductUnits = this.httpClient.get<WarehouseProductUnit[]>(this.baseRoute + 'ListWarehouseProductUnits', { observe: 'body', responseType: 'json' });
        obsWarehouseProductUnits.pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error( `An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error( `Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }))
            .subscribe(
                list => {
                    this.warehouseProductUnits = list;
                },
                error => {
                    this.messageService.error(error.message);
                }
            );
        return obsWarehouseProductUnits;
    }


    listStoreOrderDetails(orderId) {
        const params = new HttpParams().append('storeOrderId', orderId);
        const obsOrderDetails = this.httpClient.get<StoreOrderDetail[]>(this.baseRoute + 'StoreOrderDetails', { observe: 'body', responseType: 'json', params: params });
        obsOrderDetails.pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error( `An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error( `Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }));
        return obsOrderDetails;
    }

    public assignValues(target: any, source: any): void {
        Object.assign(target, source);
    }

    public PostStoreOrderDetails() {

        const updatedRows = [];
        this.originalData.forEach((r) => {

            if ( r.OldOrderQuantity !== r.OrderQuantity ||
                 r.OldRevisedQuantity !== r.RevisedQuantity ||
                 r.OldShippedQuantity !== r.ShippedQuantity ||
                 r.OldIntakeQuantity !== r.IntakeQuantity) {
                updatedRows.push(r);
            }
        });

        if (updatedRows.length > 0) {
            return this.httpClient.put(this.baseRoute + 'PostStoreOrderDetails', updatedRows);
        } else {
            return 0;
        }
    }

    getStoreOrderDetail(storeOrderId: number, productType: string) {
        let params = new HttpParams();
        params = params.append('storeOrderId', storeOrderId.toString());
        params = params.append('productType', productType);
        return this.httpClient.get<StoreOrderDetail[]>(this.baseRoute + 'GetStoreOrderDetailsForGathering', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}

