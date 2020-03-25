import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { OTBase } from '@otcommon/ot-base';
import { Document } from '@document/model/document.model';
import { ImageServiceDescriptor } from '@otuicontrol/complex/image-gallery/image-service-descriptor.interface';
import { GrowlMessageService } from '@otservice/growl-message.service';

@Injectable()
export class ImageGalleryService extends OTBase {
    descriptor: ImageServiceDescriptor;

    constructor(
        private httpClient: HttpClient,
        private messageService: GrowlMessageService) {
        super();
    }

    listImages(modelId: number): Observable<Document[]> {
        let params = new HttpParams();
        params = params.append('modelId', modelId.toString());
        return this.httpClient.get<Document[]>(
            this.descriptor.baseUrl + (this.descriptor.listMethod || 'ListImages'),
            { observe: 'body', responseType: 'json', params: params }
        );
    }

    readImage(modelId: number, documentId: number): Observable<Blob> {
        let params = new HttpParams();
        params = params.append('modelId', modelId.toString());
        params = params.append('documentId', documentId.toString());
        return this.httpClient.get(
            this.descriptor.baseUrl + (this.descriptor.readMethod || 'ReadImage'),
            { observe: 'body', responseType: 'blob', params: params }
        );
    }

    addImage(modelId: number, folderId: number, file: File, thumbWidth: number, thumbHeight: number): Observable<number> {

        const formData = new FormData();
        formData.append('photo', file);

        let params = new HttpParams();
        params = params.append('modelId', modelId.toString());
        params = params.append('folderId', folderId.toString());
        params = params.append('thumbWidth', thumbWidth.toString());
        params = params.append('thumbHeight', thumbHeight.toString());

        const options = {
            params: params,
            reportProgress: true,
        };

        return this.httpClient.post<number>(
            this.descriptor.baseUrl + (this.descriptor.addMethod || 'AddImage'),
            formData,
            options
        );
    }
}
