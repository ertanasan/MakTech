// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Branch } from '@organization/model/branch.model';
import { Subject } from 'rxjs/Subject';
import { catchError } from 'rxjs/operators';
import { EMPTY } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable({ providedIn: 'root'})
export class BranchService extends CRUDLService<Branch> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Organization', 'Branch');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    branchTreeList: Branch[];
    branchTreeListChanged = new Subject<Branch[]>();
    getBranchTree(action = 'GetBranchTree', queryParameters = null) {
        const resultSubscription = this.getBranchTreeAsync(action, queryParameters);
        this.loading = true;

        resultSubscription.subscribe(
            list => {
                this.branchTreeList = list;
                this.branchTreeListChanged.next(this.branchTreeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
        return null;
    }

    getBranchTreeAsync(action = 'GetBranchTree', queryParameters = null) {
        return this.httpClient.get<Branch[]>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: queryParameters }).pipe(
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

    //#endregion Customized

    /*Section="ClassFooter"*/
}
