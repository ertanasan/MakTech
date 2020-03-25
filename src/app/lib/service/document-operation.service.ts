import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import { DocumentHandle } from '@otmodel/document-handle.model';
import { ServiceBase } from './service-base';

@Injectable({
    providedIn: 'root'
})
export class DocumentOperationService extends ServiceBase {
    baseRoute: string;

    constructor(
        private httpClient: HttpClient,
    ) {
        super();
        this.baseRoute = `${ environment.baseRoute }/Document/DocumentOperation/`;
    }

    UploadTempDocument(document: File, folderId = 0): Observable<number> {
        const formData = new FormData();
        formData.append('document', document);

        const options = {
            reportProgress: true,
        };

        return this.httpClient.post<number>(this.baseRoute + 'UploadTempDocument/' + folderId, formData, options);
    }

    RemoveTempDocument(tempDocumentId: number, folderId: number): Observable<any> {
        const params = new HttpParams()
            .append('documentId', tempDocumentId.toString())
            .append('folderId', folderId.toString());

        return this.httpClient.delete(
            this.baseRoute + 'RemoveTempDocument', { params: params }
        );
    }

    CreateTempFolder() {
        return this.httpClient.post<number>(this.baseRoute + 'CreateTempFolder', null);
    }
}
