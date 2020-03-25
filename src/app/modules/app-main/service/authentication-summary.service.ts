import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'environments/environment';

@Injectable()
export class AuthenticationSummaryService {

    constructor(private httpClient: HttpClient) {
    }

    listAllPrograms() {
        return this.httpClient.get<any>(environment.baseRoute + '/Store/Store/ListAllPrograms', { observe: 'body', responseType: 'json' });
    }

    listScreens (userId: number, programId: number) {
        let params = new HttpParams().append('userId', userId.toString());
        params = params.append('programId', programId.toString());  // MAKTECH ONLY FOR NOW
        return this.httpClient.get<any>(environment.baseRoute + '/Store/Store/ListScreenActionsByUser', { observe: 'body', responseType: 'json', params: params });
        // long userId, long programId
    }

    listUsers (screenId: number, programId: number) {
        let params = new HttpParams().append('screenId', screenId.toString());
        params = params.append('programId', programId.toString());  // MAKTECH ONLY FOR NOW
        return this.httpClient.get<any>(environment.baseRoute + '/Store/Store/ListUserPrivilegesByScreen', { observe: 'body', responseType: 'json', params: params });
    }
}
