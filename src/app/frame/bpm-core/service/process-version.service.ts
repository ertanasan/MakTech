// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProcessVersion } from '../model/process-version.model';
import { catchError } from 'rxjs/operators';
import { EMPTY } from 'rxjs';


/*Section="ClassHeader"*/
@Injectable()
export class ProcessVersionService extends CRUDLService<ProcessVersion> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'BPMCore', 'ProcessVersion');
    }

    listProcessVersion(masterId: number, action = 'ListProcessVersion' ) {
        const params = new HttpParams().set('masterId', masterId.toString());
        return this.httpClient.get<ProcessVersion[]>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error(`${err.error['ExceptionMessage']}`);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error(`${err.status} - ${err.error['ExceptionMessage']}`);
                }
                return EMPTY;
            }));
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
