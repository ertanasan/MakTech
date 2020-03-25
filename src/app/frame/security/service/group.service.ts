// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Group } from '@security/model/group.model';

/*Section="ClassHeader"*/
@Injectable()
export class GroupService extends CRUDLService<Group> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Security', 'Group');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listByOrganization(organization: number): Observable<Group[]> {
        const params = new HttpParams().set('organization', organization.toString());
        return this.httpClient.get<Group[]>(this.baseRoute + 'ListByOrganization', { params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
