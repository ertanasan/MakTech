import { Effect, Actions, ofType } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import { catchError, mergeMap, switchMap, map } from 'rxjs/operators';
import { from as fromPromise } from 'rxjs';


import { AuthService } from './../service/auth.service';
import * as ContextActions from './context.actions';
import { OTContext } from '../model/context.model';

@Injectable()
export class ContextEffects {
    @Effect()
    fetchContext = this.actions$.pipe(
        ofType(ContextActions.FETCH_CONTEXT),
        map((action: ContextActions.FetchContext) => {
            return null;
        }),
        switchMap(() => {
            return fromPromise(this.authService.FetchContext()).pipe(catchError(
                err => {
                    return [new OTContext()];
                }
            ));
        }),
        mergeMap((result: OTContext) => {
            if (result.User.Id > 0) {
                return [
                    {
                        type: ContextActions.SET_CONTEXT,
                        payload: result
                    }
                ];
            } else {
                return [{ type: ContextActions.FETCH_FAILURE }];
            }
        }),
        catchError(error => {
            return [{ type: ContextActions.FETCH_FAILURE }];
        }),
    );
    constructor(private actions$: Actions, private authService: AuthService) {
    }

}
