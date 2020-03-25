// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StorageZones } from '@warehouse/model/storage-zones.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class StorageZonesService extends CRUDLService<StorageZones> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'StorageZones');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    zoneList;

    public getZoneList(zoneType: number) {
        if (this.loading) {
            return;
        }

        this.loading = true;
        const params = new HttpParams().append('store', zoneType.toString());
        this.httpClient.get<StorageZones[]>(this.baseRoute + 'List', { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                }
                this.messageService.error(this.translateService.instant(this.fetchFailMessage));
                return empty();
            })).subscribe (list => {
                this.zoneList = list;
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
