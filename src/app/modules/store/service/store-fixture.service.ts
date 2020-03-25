// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreFixture } from '@store/model/store-fixture.model';
import { StoreCashRegister } from '@store/model/store-cash-register.model';

/*Section="ClassHeader"*/
@Injectable()
export class StoreFixtureService extends CRUDMLService<StoreFixture> {

    userFixture: StoreFixture[];
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StoreFixture');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getUserFixture() {
        this.httpClient.get<StoreFixture[]>(this.baseRoute + 'GetUserFixture', { observe: 'body', responseType: 'json' }).subscribe(result => {
            result.forEach(row => {
                if (row.SerialNo && row.SerialNo !== null) {
                    row.FixtureLongName = row.FixtureName + ' - ' + row.SerialNo;
                } else {
                    row.FixtureLongName = row.FixtureName;
                }
            });
            this.userFixture = result;
        });
    }

    createFixture(model: StoreFixture) {
        return this.httpClient.post<StoreFixture>(this.baseRoute + 'CreateFixture', model);
    }

    updateFixture(model: StoreFixture) {
        return this.httpClient.put<StoreFixture>(this.baseRoute + 'UpdateFixture', model);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
