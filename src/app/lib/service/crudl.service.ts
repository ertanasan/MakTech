import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Subject, EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

import { process } from '@progress/kendo-data-query';

import { ModelBase } from '@otmodel/model-base';
import { ListParams } from '@otmodel/list-params.model';
import { CRUDService } from '@otservice/crud.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

export abstract class CRUDLService<T extends ModelBase> extends CRUDService<T> {
    protected fetchFailMessage = 'Server data fetch failed.';

    completeList: T[];
    completeListChanged = new Subject<T[]>();
    activeList: { data: T[], total: number } = { data: [], total: 0 };
    activeListChanged = new Subject<{ data: T[], total: number }>();
    loading = false;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        module: string,
        screen: string,
    ) {
        super(httpClient, messageService, translateService, module, screen);
    }

    listAll(listParams: ListParams = null, action = 'ListAll') {
        if (this.loading) {
            return;
        }

        const resultSubscription = this.listAllAsync(action);
        this.loading = true;

        resultSubscription.subscribe(
            list => {
                this.completeList = list;
                this.completeListChanged.next(this.completeList);
                if (listParams) {
                    this.activeList = process(list, listParams);
                    this.activeListChanged.next(this.activeList);
                }
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
        return null;
    }

    listAllAsync(action = 'ListAll', queryParameters = null) {
        return this.httpClient.get<T[]>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: queryParameters }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['Message']);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['Message']}`);
                }
                this.messageService.error(this.translateService.instant(this.fetchFailMessage));
                return EMPTY;
            }));
    }

    search(filters: any[], action: string) {
        let params = new HttpParams();
        filters.forEach((element, index, array) => {
            params = params.append(element.key, element.value);
        });

        const searchSubscription = this.httpClient.get<any>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred in service search method:', err.error['Message']);
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['Message']}`);
                }
                this.messageService.error(this.translateService.instant(this.fetchFailMessage));
                return EMPTY;
            })
        );

        this.loading = true;
        searchSubscription.subscribe(
            list => {
                this.activeList.data = list.Data;
                this.activeList.total = list.Total;
                this.activeListChanged.next(this.activeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
    }

    list(listParams: ListParams, action = 'List') {
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

    listAsync(listParams: ListParams, action = 'List') {
        const params = this.prepareListParams(listParams);
        return this.httpClient.get<any>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['Message']);
                    this.messageService.error(`${err.error['Message']}`);
                } else {
                    console.log(params);
                    console.log(this.baseRoute + action);
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['Message']}`);
                    this.messageService.error(`${err.status} - ${err.error['Message']}`);
                }
                return EMPTY;
            })
        );
    }

    private extractSortings(sorts: any[]): string {
        if (!sorts || sorts.length === 0) {
            return '';
        }
        let result = '';
        sorts.forEach((element, index, array) => {

            if (element.dir) {
                if (result === '') {
                    result = `${element.field}-${element.dir}`;
                } else {
                    result += `~${element.field}-${element.dir}`;
                }
            }

        });
        return result;
    }

    private extractFilter(filter: any, dateFields: any[]): string {
        if (!filter.filters || filter.filters.length === 0) {
            return '';
        }
        if (filter.filters.length === 1) {
            return this.toFilterExpression(filter.filters[0], dateFields);
        } else {
            let result = '';

            filter.filters.forEach((element, index, array) => {
                if (index === 0) {
                    result = this.toFilterExpression(element, dateFields);
                } else {
                    result += `~${filter.logic}~${this.toFilterExpression(element, dateFields)}`;
                }
            });
            return result;
        }
    }
    private extractGroupings(groups: any[]): string {
        if (!groups || groups.length === 0) {
            return '';
        }
        let result = '';
        groups.forEach((element, index, array) => {

            if (element.dir) {
                if (result === '') {
                    result = `${element.field}-${element.dir}`;
                } else {
                    result += `~${element.field}-${element.dir}`;
                }
            } else {
                if (result === '') {
                    result = `${element.field}-asc`;
                } else {
                    result += `~${element.field}-asc`;
                }
            }

        });
        return result;
    }


    private toFilterExpression(filter: any, dateFields: any[]): string {

        if (dateFields.includes(filter.field)) {
            return `${filter.field}~${filter.operator}~'${new Date(filter.value).toJSON()}'`;
        } else {
            return `${filter.field}~${filter.operator}~'${filter.value}'`;
        }
    }

    protected prepareListParams(listParams: ListParams): HttpParams {
        let params = new HttpParams();
        if (listParams) {
            let page = 0;
            params = params.append('sort', this.extractSortings(listParams.sort));
            if (listParams.pageable && listParams.take) {
                params = params.append('pageSize', listParams.take.toString());
                page = (listParams.skip / listParams.take) + 1;
                params = params.append('page', page.toString());
            }
            params = params.append('group', this.extractGroupings(listParams.group));
            params = params.append('filter', this.extractFilter(listParams.filter, listParams.dateFields));

            listParams.queryParams.forEach((value: any, key: string) => {
                params = params.append(key, value);
            });
        }

        return params;
    }
}
