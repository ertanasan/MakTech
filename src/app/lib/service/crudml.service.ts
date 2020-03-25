
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

import { ModelBase } from '@otmodel/model-base';
import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ListParams } from '@otmodel/list-params.model';

export abstract class CRUDMLService<T extends ModelBase> extends CRUDLService<T> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        module: string,
        screen: string,
    ) {
        super(httpClient, messageService, translateService, module, screen);
    }

    listByMaster(listParams: ListParams, masterId: number = 0, action = 'ListByMaster') {
        if (this.loading) {
            return;
        }
        const resultSubscription = this.listByMasterAsync(listParams, masterId, action);

        this.loading = true;
        resultSubscription.subscribe(
            list => {
                if (masterId > 0) {
                    this.activeList.data = list.Data;
                    this.activeList.total = list.Total;
                    this.activeListChanged.next(this.activeList);
                } else {
                    this.completeList = list;
                    this.completeListChanged.next(this.completeList);
                }
            },
            error => {
                let message = '';
                if (error.message) {
                    message = error.message;
                }
            },
            () => this.loading = false
        );
    }

    listByMasterAsync(listParams: ListParams, masterId: number = 0, action = 'ListByMaster') {
        if (masterId === 0 && action === 'ListByMaster') {
            action = 'ListAll';
        }

        let params = this.prepareListParams(listParams);
        params = params.append('masterId', masterId.toString());

        return this.httpClient.get<any>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params }).pipe(
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
                return EMPTY;
            })
        );
    }

    listAllByMaster(masterId: number = 0, action = 'ListAllByMaster') {
        if (this.loading) {
            return;
        }

        const resultSubscription = this.listAllByMasterAsync(masterId, action);
        this.loading = true;

        resultSubscription.subscribe(
            list => {
                this.completeList = list;
                this.completeListChanged.next(this.completeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
    }

    listAllByMasterAsync( masterId: number = 0, action = 'ListAllByMaster') {
        if (masterId === 0 && (action === 'ListByMaster' || action === 'ListAllByMaster')) {
            action = 'ListAll';
        }

        let params = new HttpParams();
        params = params.append('masterId', masterId.toString());

        return this.httpClient.get<any>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params }).pipe(
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
                return EMPTY;
            })
        );
    }
}
