// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreCashRegister } from '@store/model/store-cash-register.model';
import { StoreScales } from '@store/model/store-scales.model';

/*Section="ClassHeader"*/
@Injectable()
export class StoreCashRegisterService extends CRUDMLService<StoreCashRegister> {

    userCashRegister: StoreCashRegister[];
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StoreCashRegister');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getUserCashRegister() {
        this.httpClient.get<StoreCashRegister[]>(this.baseRoute + 'GetUserCashRegister', { observe: 'body', responseType: 'json' }).subscribe(result => {
            result.forEach(row => {
                if (row.SerialNo && row.SerialNo !== null) {
                    row.CashRegisterLongName = row.Name + ' - ' + row.SerialNo;
                } else {
                    row.CashRegisterLongName = row.Name;
                }
            });
            this.userCashRegister = result;
        });
    }

    createCashRegister(model: StoreCashRegister) {
        return this.httpClient.post<StoreCashRegister>(this.baseRoute + 'CreateCashRegister', model);
    }

    updateCashRegister(model: StoreCashRegister) {
        return this.httpClient.put<StoreCashRegister>(this.baseRoute + 'UpdateCashRegister', model);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
