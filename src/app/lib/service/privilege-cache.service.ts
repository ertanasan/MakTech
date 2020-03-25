import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { retry, map, share, multicast } from 'rxjs/operators';
import { of } from 'rxjs';
import { Store } from '@ngrx/store';

import { ServiceBase } from './service-base';
import { OTContext } from '@otlib/auth/model/context.model';
import * as fromApp from '@otlib/store/app.reducers';

import { environment } from './../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class PrivilegeCacheService extends ServiceBase {
    private privilegeCache = [];
    private screenActionCache = [];
    private contextState$: Observable<OTContext>;
    private targetUserId = -1;

    baseRoute: string;

    constructor(
        private httpClient: HttpClient,
        private readonly store: Store<fromApp.AppState>
    ) {
        super();
        this.baseRoute = `${environment.baseRoute}/Security/Privilege/`;

        this.contextState$ = this.store.select('context');
        this.contextState$.subscribe(
            context => {
                if (context.User.Id !== this.targetUserId) {
                    // Context user is changed. Clear the caches.
                    this.privilegeCache = [];
                    this.screenActionCache = [];
                    this.targetUserId = context.User.Id;
                }
            }
        );
    }

    addPrivilegeCache(privilegeName: string, privilege: boolean) {
        const item = {
            name: privilegeName,
            privilege: privilege,
            loading: false,
            result: null
        };

        const index = this.privilegeCache.findIndex(p => p.name === privilegeName);
        if (index === -1) {
            this.privilegeCache.push(item);
        } else {
            this.privilegeCache[index] = item;
        }
    }

    addScreenActionCache(moduleName: string, screenName: string, actionName: string, privilege: boolean) {
        const item = {
            moduleName: moduleName,
            screenName: screenName,
            actionName: actionName,
            privilege: privilege,
            loading: false,
            result: null
        };

        const index = this.screenActionCache.findIndex(sa => sa.moduleName === moduleName && sa.screenName === screenName && sa.actionName === actionName);
        if (index === -1) {
            this.screenActionCache.push(item);
        } else {
            this.screenActionCache[index] = item;
        }
    }

    checkPrivilege(privilegeName: string): Observable<boolean> {
        // Get from cache
        const index = this.privilegeCache.findIndex(p => p.name === privilegeName);
        if (index !== -1) {
            if (this.privilegeCache[index].loading) {
                return this.privilegeCache[index].result;
            } else {
                return of<boolean>(this.privilegeCache[index].privilege);
            }
        } else {
                // Cache mismatch read from server
            const params = new HttpParams()
                .append('privilegeName', privilegeName);
            const result = this.httpClient.get<boolean>(this.baseRoute + 'CheckPrivilege', { observe: 'body', responseType: 'json', params: params }).pipe(
                retry(3),
                map(privilege => {
                    this.addPrivilegeCache(privilegeName, privilege);
                    return privilege;
                }),
                share()
            );
            this.privilegeCache.push(
                {
                    name: privilegeName,
                    privilege: false,
                    loading: true,
                    result: result
                }
            );
            return result;
        }
    }

    checkScreenAction(moduleName: string, screenName: string, actionName: string) {
        // Get from cache
        const index = this.screenActionCache.findIndex(sa => sa.moduleName === moduleName && sa.screenName === screenName && sa.actionName === actionName);
        if (index !== -1) {
            if (this.screenActionCache[index].loading) {
                return this.screenActionCache[index].result;
            } else {
                return of<boolean>(this.screenActionCache[index].privilege);
            }
        } else {

            // Cache mismatch read from server
            const params = new HttpParams()
                .append('moduleName', moduleName)
                .append('screenName', screenName)
                .append('actionName', actionName);
            const result = this.httpClient.get<boolean>(this.baseRoute + 'CheckScreenAction', { observe: 'body', responseType: 'json', params: params }).pipe(
                retry(3),
                map(privilege => {
                    this.addScreenActionCache(moduleName, screenName, actionName, privilege);
                    return privilege;
                }),
                share()
            );
            this.screenActionCache.push(
                {
                    moduleName: moduleName,
                    screenName: screenName,
                    actionName: actionName,
                    privilege: false,
                    loading: true,
                    result: result
                }
            );
            return result;
        }
    }
}
