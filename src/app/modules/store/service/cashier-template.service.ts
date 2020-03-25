// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { environment } from 'environments/environment';
import { CashierTemplate } from '@store/model/cashier-template.model';
import { catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class CashierTemplateService extends CRUDLService<CashierTemplate> {
    res;
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService
    ) {
        super(httpClient, messageService, translateService, 'Store', 'CashierTemplate');
    }


    listTitle(){ 
        
        this.httpClient.get<any>(environment.baseRoute+'/Security/Title/API/List').pipe(
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
            })).subscribe(result=> {this.res= result; console.log(this.res);});
            
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
