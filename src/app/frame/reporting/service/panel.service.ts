// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Panel } from '@reporting/model/panel.model';
import { ReportPanel } from '../model/report-panel.model';

/*Section="ClassHeader"*/
@Injectable()
export class PanelService extends CRUDLService<Panel> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Reporting', 'Panel');
    }

    find(reportName: string, panelName: string, action = 'Find'): Observable<ReportPanel> {
        const params = new HttpParams().set('reportName', reportName).set('panelName', panelName);
        return this.httpClient.get<ReportPanel>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params });
    }

    readDetails(panelId: number, action = 'ReadPanelDetail'): Observable<Panel> {
        const params = new HttpParams().set('panelId', panelId.toString());
        return this.httpClient.get<Panel>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params });
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
