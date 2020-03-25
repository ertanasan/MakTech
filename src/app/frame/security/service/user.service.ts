// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { User } from '@security/model/user.model';
import { Observable } from 'rxjs';

/*Section="ClassHeader"*/
@Injectable()
export class UserService extends CRUDLService<User> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Security', 'User');
    }

    genders =
        [
            { 'Text': 'Male', 'Value': 'M' },
            { 'Text': 'Female', 'Value': 'F' }
        ];
    statusList =
        [
            { 'Text': 'Active', 'Value': true },
            { 'Text': 'Passive', 'Value': false }
        ];

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listByOrganization(organization: number, group: number): Observable<User[]> {
        const params = new HttpParams().set('organization', organization.toString()).append('group', group.toString());
        return this.httpClient.get<User[]>(this.baseRoute + 'ListByOrganization', { params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
