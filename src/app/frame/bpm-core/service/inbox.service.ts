import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { WorkqueueItem } from '@bpm-core/model/workqueueitem.model';

import { InboxItem } from '../model/inboxitem.model';
import { InboxFilter } from '../model/inboxfilter.model';
import { InboxSummary } from '../model/inboxsummary.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ActionDelegate } from '@bpm-core/model/actiondelegate.model';
import { ListParams } from '@otmodel/list-params.model';

@Injectable({
    providedIn: 'root'
})
export class InboxService extends CRUDLService<InboxItem> {

    workqueueList: any[] = [];
    workqueueItems: WorkqueueItem[] = [];

    taskLists =
    [
        { 'Value': '1', 'Text': 'Görevlerim' },
        { 'Value': '2', 'Text': 'Bekleyenler' },
        { 'Value': '3', 'Text': 'Atananlar' },
        { 'Value': '4', 'Text': 'Tamamlananlar' }
    ];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'BPMCore', 'Inbox');
    }

    readActionInfo<T>(id: number): Observable<T> {
        const params = new HttpParams().set('id', id.toString());
        return this.httpClient.get<T>(this.baseRoute + 'GetActionInfo', { observe: 'body', responseType: 'json', params: params});
    }

    readDelegateMessage(id: number): Observable<string> {
        const params = new HttpParams().set('id', id.toString());
        return this.httpClient.get<string>(this.baseRoute + 'ReadDelagateMessage', { observe: 'body', responseType: 'json', params: params});
    }

    listInboxSummary(): Observable<InboxSummary> {
        return this.httpClient.get<InboxSummary>(this.baseRoute + 'ListInboxSummary', { observe: 'body', responseType: 'json'});
    }

    filterWorkqueueItems(filter: InboxFilter) {
        this.httpClient.post<WorkqueueItem[]>(this.baseRoute + 'ListWorkqueueItems', filter, { observe: 'body', responseType: 'json' }).pipe(
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
            })).subscribe(
            list => {
                this.workqueueItems = list;
            },
            error => {
                let message = '';
                if (error.message) {
                    message = error.message;
                }
                this.messageService.error(message);
            }
        );

    }

    listWorkqueues() {
        this.httpClient.get<any[]>(this.baseRoute + 'ListWorkqueues', { observe: 'body', responseType: 'json' }).pipe(
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
        })
        ).subscribe(
            list => {
                this.workqueueList = list;
            },
            error => {
                let message = '';
                if (error.message) {
                    message = error.message;
                }
                this.messageService.error( message );
            }
        );

    }
    delegateAction(model: ActionDelegate, action = 'DelegateAction') {
        return this.httpClient.post<any>(this.baseRoute + action, model);
    }

    listCompleted(listParams: ListParams, action = 'ListCompleted') {
        if (this.loading) {
            return;
        }
        const listSubscription = this.listAsync(listParams, action);

        this.loading = true;
        listSubscription.subscribe(
            result => {
                this.activeList.data = result.Data;
                this.activeList.total = result.Total;
                this.activeListChanged.next(this.activeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
    }

    getCompletedCount(startDate: Date, endDate: Date) {
        let params = new HttpParams().set('startDate', startDate.toJSON());
        params = params.append('endDate', endDate.toJSON());
        return this.httpClient.get<number>(this.baseRoute + 'CompletedCount', { observe: 'body', responseType: 'json', params: params });
    }

}

