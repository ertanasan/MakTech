// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { HelpdeskRequest } from '@helpdesk/model/helpdesk-request.model';
import { PackagePerformance } from '@price/model/package-performans-model';
import { InboxItem } from '@frame/bpm-core/model/inboxitem.model';
import { RequestBPM } from '@helpdesk/model/request-bpm.model';

/*Section="ClassHeader"*/
@Injectable()
export class HelpdeskRequestService extends CRUDLService<HelpdeskRequest> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Helpdesk', 'HelpdeskRequest');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listFiltered(openFlag, startDate, endDate) {
        let params = new HttpParams().append('OpenFlag', openFlag);
        params = params.append('StartDate', startDate);
        params = params.append('EndDate', endDate);
        return this.httpClient.get<HelpdeskRequest[]>(this.baseRoute + 'ListFiltered', { observe: 'body', responseType: 'json', params: params });
    }

    UserTask(processInstanceId) {
        const params = new HttpParams().append('ProcessInstanceId', processInstanceId);
        return this.httpClient.get<RequestBPM>(this.baseRoute + 'UserTask', { observe: 'body', responseType: 'json', params: params });
    }

    helpdeskDashboard() {
        return this.httpClient.get<any>(this.baseRoute + 'TaskDashboard', { observe: 'body', responseType: 'json'});
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
