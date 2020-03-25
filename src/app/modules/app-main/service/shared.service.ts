import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';

@Injectable()
export class SharedService {

    constructor(private httpClient: HttpClient) {
    }


    ListBPMHistoryData (processInstanceId: number) {
        const params = new HttpParams().append('processInstanceId', processInstanceId.toString());
        return this.httpClient.get<any>(environment.baseRoute + '/Store/OverstoreShared/ListBPMHistoryData', { observe: 'body', responseType: 'json', params: params });
    }

}
