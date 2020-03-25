import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { map, take } from 'rxjs/operators';
import { Store } from '@ngrx/store';

import * as fromApp from '../../store/app.reducers';
import * as fromAuth from './../store/auth.reducers';

import { environment } from 'environments/environment';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private store: Store<fromApp.AppState>, private router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.store.select('auth').pipe(
            take(1),
            map((authState: fromAuth.State) => {
                if (!authState.authenticated) {
                    this.router.navigate(['login'], { queryParams: { returnUrl: state.url } });
                }
                if (authState.passwordExpired) {
                    this.router.navigate(['changePassword'], { queryParams: { returnUrl: state.url } });
                }
                return authState.authenticated;
        }));
    }
}
