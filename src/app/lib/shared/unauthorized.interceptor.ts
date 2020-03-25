
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { throwError as observableThrowError,  Observable ,  BehaviorSubject } from 'rxjs';
import { catchError, take, switchMap } from 'rxjs/operators';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducers';
import * as fromAuth from '../auth/store/auth.reducers';
import * as AuthActions from '../auth/store/auth.actions';

@Injectable()
export class UnAuthorizedInterceptor implements HttpInterceptor {

    isRefreshingToken = false;
    tokenSubject: BehaviorSubject<string> = new BehaviorSubject<string>(null);

    constructor(private store: Store<fromApp.AppState>) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const copiedReq = req.clone();
    return next.handle(copiedReq).pipe(
        catchError(error => {
            if (error.status === 401) {
                this.store.dispatch(new AuthActions.RefreshToken());

                return this.store.select('auth').pipe(
                    take(1),
                    switchMap((authState: fromAuth.State) => {
                        const request = req.clone({
                            setHeaders: {
                                Authorization: `Bearer ${authState.token}`
                            }
                        });
                        return next.handle(request);
                    }));
            }
            return observableThrowError(error);
        }));
   }
}
