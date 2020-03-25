import { Subject } from 'rxjs/Subject';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, EMPTY } from 'rxjs';

import { environment } from '../../../../environments/environment';

import { ListParams } from '@otmodel/list-params.model';
import { ServiceBase } from '@otservice/service-base';
import { DataResult } from '@otmodel/data-result.model.ts';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { Report } from '@reporting/model/report.model';

@Injectable()
export class GenericReportService extends ServiceBase {
    baseRoute: string;
    loading = false;
    activeList: DataResult = { data: [], total: 0 };
    dataLoaded: Subject<DataResult> = new Subject();

    constructor(protected httpClient: HttpClient,
                protected messageService: GrowlMessageService,
    ) {
        super();
        this.baseRoute = `${ environment.baseRoute }/Reporting/GenericReport/`;
    }

    findReport(reportName: string): Observable<Report> {
        const params = new HttpParams().append('reportName', reportName);
        return this.httpClient.get<Report>(this.baseRoute + 'FindReport' , { observe: 'body', responseType: 'json', params: params });
    }

    getGridData(listParams: ListParams, gridPanelId: number, filterValues: any[]) {
        this.loading = true;

        let params = new HttpParams();
        let page = 0;
        params = params.append('sort', this.extractSortings(listParams.sort));
        if (listParams.pageable && listParams.take) {
            params = params.append('pageSize', listParams.take.toString());
            page = (listParams.skip / listParams.take) + 1;
            params = params.append('page', page.toString());
        }
        params = params.append('group', '');
        params = params.append('filter', this.extractFilter(listParams.filter, listParams.dateFields));

        listParams.queryParams.forEach((value: any, key: string) => {
           params = params.append(key, value);
        });
        params = params.append('gridPanelId', gridPanelId.toString());
        params = params.append('filterValues', JSON.stringify(filterValues));

        this.httpClient.get<any>(this.baseRoute + 'GetReportGridData' , { observe: 'body', responseType: 'json', params: params }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    this.loading = false;
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error(`${err.error['ExceptionMessage']}`
                    );
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    this.loading = false;
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error(`${err.status} - ${err.error['ExceptionMessage']}`
                    );
                }
                return EMPTY;
            }))
            .subscribe(
                dataResult => {
                    this.activeList.data = dataResult.Data;
                    this.activeList.total = dataResult.Total;
                    this.dataLoaded.next(this.activeList);
                    this.loading = false;
                },
                error => {
                    this.loading = false;
                    this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
                }
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

    private toFilterExpression(filter: any, dateFields: any[]): string {

        if (dateFields.includes(filter.field)) {
            return `${filter.field}~${filter.operator}~'${new Date(filter.value).toJSON()}'`;
        } else {
            return `${filter.field}~${filter.operator}~'${filter.value}'`;
        }
    }

    exportReportData(panelId: number, filterValues: any[]): Observable<any> {
        let params = new HttpParams();
        params = params.append('panelId', panelId.toString());
        params = params.append('filterValues', JSON.stringify(filterValues));
        return this.httpClient.get(this.baseRoute + 'ExportReportData', { responseType: 'blob', headers: {'Accept': 'application/vnd.ms-excel'}, observe: 'body', params: params } );
    }

    getFilterData(filterId: number, filterValues: any[]) {
        let params = new HttpParams();
        params = params.append('filterId', filterId.toString());
        params = params.append('filterValues', JSON.stringify(filterValues));
        return this.httpClient.get<any>(this.baseRoute + 'GetReportFilterData' , { observe: 'body', responseType: 'json', params: params });
    }

}
