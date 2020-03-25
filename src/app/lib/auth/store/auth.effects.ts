import { tap, map, switchMap, mergeMap, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Router, ActivatedRoute } from '@angular/router';
import { from as fromPromise } from 'rxjs';

import { Login } from '@otlib/auth/model/login.model';
import { LoginResult } from '@otlib/auth/model/loginresult.model';
import { AuthService } from '@otlib/auth/service/auth.service';

import * as AuthActions from './auth.actions';
import * as fromApp from '@otlib/store/app.reducers';
import { Store } from '@ngrx/store';

@Injectable()
export class AuthEffects {

    @Effect()
    authSignup = this.actions$.pipe(
        ofType(AuthActions.TRY_SIGNUP),
        map((action: AuthActions.TrySignup) => {
            return action.payload;
        }),
        switchMap((authData: { username: string, password: string }) => {
            return null;
        }),
        switchMap(() => {
            return null;
        }),
        mergeMap((token: string) => {
            return [
                {
                    type: AuthActions.SIGNUP
                },
                {
                    type: AuthActions.SET_TOKEN,
                    payload: token
                }
            ];
        }),
    );

    @Effect()
    authSignin = this.actions$.pipe(
        ofType(AuthActions.TRY_SIGNIN),
        map((action: AuthActions.TrySignin) => {
            return action.payload;
        }),
        switchMap((authData: Login) => {
            return fromPromise(this.authService.TryLogin(authData)).pipe(catchError(
                err => {
                  return [{UserId: 0}];
                }
            ));
        }),
        mergeMap((result: LoginResult) => {
            // console.log(result);
            if (result.UserId > 0) {
                result.TokenDate = new Date();
                const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                this.router.navigate([returnUrl]);
                return [
                    {
                        type: AuthActions.SIGNIN
                    },
                    {
                        type: AuthActions.SET_TOKEN,
                        payload: result
                    }
                ];
            } else {
                return [{ type: AuthActions.LOGIN_FAILURE }];
            }
        }),
        catchError(error => {
            return [{ type: AuthActions.LOGIN_FAILURE }];
        }),
    );

    @Effect()
    authWindowsSignin = this.actions$.pipe(
        ofType(AuthActions.TRY_WINDOWSSIGNIN),
        map((action: AuthActions.TryWindowsSignin) => {
            return null;
        }),
        switchMap(() => {
            return fromPromise(this.authService.TryWindowsLogin()).pipe(catchError(
                err => {
                  return [{UserId: 0}];
                }
            ));
        }),
        mergeMap((result: LoginResult) => {
            if (result.UserId > 0) {
                result.TokenDate = new Date();
                const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
                return [
                    {
                        type: AuthActions.SIGNIN
                    },
                    {
                        type: AuthActions.SET_TOKEN,
                        payload: result
                    },
                    {
                        type: AuthActions.REDIRECT,
                        payload: returnUrl
                    }
                ];
            } else {
                return [{ type: AuthActions.LOGIN_FAILURE }];
            }
        }),
        catchError(error => {
            return [{ type: AuthActions.LOGIN_FAILURE }];
        }),
    );

    @Effect()
    authRefreshToken = this.actions$.pipe(
        ofType(AuthActions.REFRESH_TOKEN),
        map((action: AuthActions.RefreshToken) => {

            return null;
        }),
        switchMap(() => {
            // console.log('Refresh Token Effect');
            return fromPromise(this.authService.RefreshToken()).pipe(catchError(
                err => {
                   console.log(err);
                  return [{UserId: 0}];
                }
            ));
        }),
        mergeMap((result: LoginResult) => {
            // console.log(result);
            if (result.UserId > 0) {
                result.TokenDate = new Date();
                const returnUrl = this.route.snapshot.queryParams['returnUrl'];
                if (returnUrl) {
                    return [
                        {
                            type: AuthActions.SET_TOKEN,
                            payload: result
                        },
                        {
                            type: AuthActions.REDIRECT,
                            payload: returnUrl
                        }
                    ];

                } else {
                    return [
                        {
                            type: AuthActions.SET_TOKEN,
                            payload: result
                        }
                    ];
                }
            }
            return [ {type: AuthActions.LOGOUT} ];
        }),
    );

    @Effect({ dispatch: false })
    authLogout = this.actions$.pipe(
               ofType(AuthActions.LOGOUT),
                tap((a: AuthActions.Logout) => {
                    this.router.navigate(['login'], { queryParams: { action: a.payload } });
                }));

    @Effect({ dispatch: false })
    authRedirect = this.actions$.pipe(
        ofType(AuthActions.REDIRECT),
        tap((action: AuthActions.Redirect) => {
            this.router.navigate([action.payload], { queryParams: { } });
        }));
    constructor(private actions$: Actions, private router: Router, private authService: AuthService, private route: ActivatedRoute, private store: Store<fromApp.AppState>) {
    }
}
