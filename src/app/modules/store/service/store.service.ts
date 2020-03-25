// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Store } from '@store/model/store.model';
import { catchError, finalize } from 'rxjs/operators';
import { empty } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';

/*Section="ClassHeader"*/
@Injectable()
export class StoreService extends CRUDLService<Store> {
    productionList: any;
    userStores: any;
    titles: any;
    storeListWithWarehouses: Store[] = [];
    contextInfo: OTContext;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'Store');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listProduction(action = 'ListAll') {
        this.loading = true;
        this.httpClient.get<Store[]>(this.baseRoute + 'ListProduction', { observe: 'body', responseType: 'json' }).pipe(
            catchError((err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                    // A client-side or network error occurred. Handle it accordingly.
                    console.error('An error occurred:', err.error['ExceptionMessage']);
                    this.messageService.error( `An error occurred: ${err.error['ExceptionMessage']}`
                    );
                } else {
                    // The backend returned an unsuccessful response code.
                    // The response body may contain clues as to what went wrong,
                    console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                    this.messageService.error( `Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`
                    );
                }
                return empty();
            }))
            .subscribe(
                list => {
                    this.productionList = list;
                    this.loading = false;
                },
                error => {
                    this.loading = false;
                    this.messageService.error(error.message);
                }
            );
    }

    listUserStores(action = 'ListAll') {
        const obsUserStores = this.httpClient.get<Store[]>(this.baseRoute + 'ListUserStores', { observe: 'body', responseType: 'json' });
        obsUserStores.pipe(
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
                    this.userStores = list;

                    // // StoreFilter List Generation
                    // this.userStores.forEach(str => {
                    //     const tempStore = new Store();
                    //     Object.assign(tempStore, str);
                    //     this.userStoresForFilters.push(tempStore);
                    // });
                    // const allStoresRow = new Store;
                    // allStoresRow.Name = 'TÜM MAĞAZALAR';
                    // allStoresRow.StoreId = -1;
                    // this.userStoresForFilters.unshift(allStoresRow);
                },
                error => {
                    this.messageService.error(error.message);
                }
            );
        return obsUserStores;
    }

    public listAllTitles() {
        this.httpClient.get(this.baseRoute + 'ListAllTitles', { observe: 'body', responseType: 'json' }).subscribe( list => {
            this.titles = list;
        });
    }

    public addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    getDashboardOutdatedCodeStore() {
        return this.httpClient.get<any>(this.baseRoute + 'GetDashboardOutdatedCodeStore', { observe: 'body', responseType: 'json' });
    }

    public listStoresAndWarehouses() {
        if (this.loading) {
            return;
        }
        this.loading = true;
        this.listAllAsync()
        .pipe(
            finalize(() => this.loading = false)
        )
        .subscribe(
            list => {
                this.completeList = list;
                this.storeListWithWarehouses = JSON.parse(JSON.stringify(list));

                const warehouse = new Store();
                warehouse.StoreId = 999;
                warehouse.Name = 'MERKEZ DEPO';
                this.storeListWithWarehouses.unshift(warehouse);
            },
            error => this.messageService.error(error.message)
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}