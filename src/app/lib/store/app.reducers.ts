import { ActionReducerMap } from '@ngrx/store';

import * as fromAuth from '../auth/store/auth.reducers';
import * as fromContext from '../auth/store/context.reducers';
import { OTContext } from '@otlib/auth/model/context.model';

export interface AppState {
    auth: fromAuth.State;
    context: OTContext;
}

export const reducers: ActionReducerMap<AppState> = {
    auth: fromAuth.authReducer,
    context: fromContext.contextReducer
};
