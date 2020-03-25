import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { Profile } from '../model/profile.model';
import { environment } from 'environments/environment';

@Injectable()
export class ProfileService {

    constructor(private httpClient: HttpClient) {
    }

    GetUserProfile() {
        return this.httpClient.get<Profile>(environment.baseRoute + '/account/profile', {
            observe: 'body',
            responseType: 'json'
        });
    }

    SaveUserProfile(profile: Profile) {
        return this.httpClient.post<Profile>(environment.baseRoute + '/api/account/profile', {
            observe: 'body',
            responseType: 'json'
        });
    }
}
