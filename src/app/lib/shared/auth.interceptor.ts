
import { throwError as observableThrowError, Observable, BehaviorSubject } from 'rxjs';

import { take, catchError, filter, switchMap } from 'rxjs/operators';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducers';
import * as AuthActions from '../auth/store/auth.actions';
import * as fromAuth from '../auth/store/auth.reducers';
import { TranslateService } from '@ngx-translate/core';
import { OTContext } from '@otlib/auth/model/context.model';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    isRefreshingToken = false;
    tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>(null);
    userLanguage = 'tr';
    tenantKey = '';
    context$: Observable<OTContext>;
    skippUrls = [
        '/login$'
    ];

    constructor(private store: Store<fromApp.AppState>, private translateService: TranslateService) {
        this.context$ = this.store.select('context');
        this.context$.subscribe(
            context => {
                this.userLanguage = context.UserLanguage;
                this.tenantKey = context.TenantKey ? context.TenantKey : '';
            }
        );
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        for (const skippUrl of this.skippUrls) {
            if (new RegExp(skippUrl).test(req.url)) {
                return next.handle(req);
            }
        }

        return this.store.select('auth').pipe(
            take(1),
            switchMap((authState: fromAuth.State) => {
                if (authState.expirationDate.getTime() > new Date().getTime() || req.url.indexOf('refreshToken') > -1 || req.url.indexOf('loginwindows') > -1) {
                    const copiedReq = this.addAuthorizationToken(authState.token, req);
                    return next.handle(copiedReq).pipe(catchError(error => {
                        if (req.url.indexOf('refreshToken') > -1) {
                            return this.logoutUser(error);
                        }
                        if (error instanceof HttpErrorResponse) {
                            switch ((<HttpErrorResponse>error).status) {
                                case 400:
                                    return observableThrowError(error);
                                case 401:
                                    return this.handleTokenExpired(req, next, authState);
                                default:
                                    return observableThrowError(error);
                            }
                        } else {
                            return observableThrowError(error);
                        }
                    }));
                } else {
                    return this.handleTokenExpired(req, next, authState);
                }
            })
        );
    }

    addAuthorizationToken(token: string, req: HttpRequest<any>) {
        if (req.url.indexOf('loginwindows') > -1) {
            // console.log('Trying Windows Login!');
            return req.clone({
                withCredentials: true
            });
        } else {
            return req.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`,
                    OTLanguage: this.userLanguage,
                    TenantKey: this.tenantKey
                }
            });
        }
    }

    handleTokenExpired(req: HttpRequest<any>, next: HttpHandler, state: fromAuth.State) {
        if (req.url.indexOf('loginwindows') > -1) {
            return this.logoutUser('Windows Login Failed!');
        }
        if (state.refreshTokenExpirationDate.getTime() < new Date().getTime()) {
            return this.logoutRefreshUser('Refresh Token Expired');
        }
        if (!this.isRefreshingToken) {
            this.isRefreshingToken = true;
            // console.log(`Refreshing for ${req.url}`);
            // Reset here so that the following requests wait until the token
            // comes back from the refreshToken call.
            this.tokenSubject.next(null);
            this.store.dispatch(new AuthActions.UseRefreshToken());
            // console.log('Dispatching Refresh Token');
            this.store.dispatch(new AuthActions.RefreshToken());

            return this.store.select('auth').pipe(
                filter((authState: fromAuth.State) => authState.refreshingToken === false),
                take(1),
                switchMap((authState: fromAuth.State) => {
                    this.tokenSubject.next(authState.token);
                    this.isRefreshingToken = false;
                    const copiedReq = this.addAuthorizationToken(authState.token, req);
                    return next.handle(copiedReq);
                })
            );
        } else {
            // console.log(`Waiting to refresh for ${req.url}`);
            // console.log(this.tokenSubject);
            return this.tokenSubject.pipe(
                filter(token => token != null),
                take(1),
                switchMap(token => {
                    // console.log(`Waiting to refresh for ${req.url}, ${token}`);
                    const copiedReq = this.addAuthorizationToken(token, req);
                    return next.handle(copiedReq).pipe(catchError(error => {
                        return this.logoutUser(error);
                    }));
                })
            );
        }
    }

    logoutUser(error: any) {
        this.store.dispatch(new AuthActions.Logout());
        return observableThrowError(error);
    }

    logoutRefreshUser(error: any) {
        this.store.dispatch(new AuthActions.Logout('refresh'));
        return observableThrowError(error);
    }
}
