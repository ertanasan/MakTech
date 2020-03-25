// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProcessDefinition } from '@bpm-core/model/process-definition.model';
import { ProcessVersion } from '@bpm-core/model/process-version.model';

import * as FileSaver from 'file-saver';




/*Section="ClassHeader"*/
@Injectable()
export class ProcessDefinitionService extends CRUDLService<ProcessDefinition> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'BPMCore', 'ProcessDefinition');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    readProcessVersion(processDefinitionId) {
        const params = new HttpParams().set('id', processDefinitionId.toString());
        return this.httpClient.get<ProcessVersion>(this.baseRoute + 'ReadProcessVersion', { observe: 'body', responseType: 'json', params: params });
    }

    createProcessVersion(definitionFile: File) {
        const formData = new FormData();
        formData.append('definitionFile', definitionFile);

        const options = {
            reportProgress: true,
        };
        return this.httpClient.post<ProcessVersion>(this.baseRoute + 'CreateProcessVersion', formData, options);
    }

    uploadProcessVersion(definitionFile: File, processDefinitionId: number) {
        const formData = new FormData();
        formData.append('definitionFile', definitionFile);

        const params = new HttpParams().append('id', processDefinitionId.toString());

        const options = {
            reportProgress: true,
            params: params,
        };
        return this.httpClient.post<ProcessVersion>(this.baseRoute + 'UploadProcessVersion', formData, options);
    }

    downloadProcessVersion (processDefinitionId: number) {
        const params = new HttpParams().set('id', processDefinitionId.toString());
        return this.httpClient.get(this.baseRoute + 'DownloadProcessVersion', { responseType: 'blob', headers: {'Accept': 'application/zip'}, observe: 'body', params: params } );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
