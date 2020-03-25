// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import {Landlord, LandlordMikro} from '@finance/model/landlord.model';
import {Observable} from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class LandlordService extends CRUDLService<Landlord> {
    mikroLandlordList: LandlordMikro[] = [];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Finance', 'Landlord');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listAllLandlordsFromMikro(): void {
       this.httpClient.get<LandlordMikro[]>(this.baseRoute + 'ListAllLandlordsFromMikro', { observe: 'body', responseType: 'json' })
           .subscribe(result => this.mikroLandlordList = result);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
