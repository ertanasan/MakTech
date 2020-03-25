import { Action } from '@ngrx/store';
import { OTContext } from '../model/context.model';

export const SET_CONTEXT = 'SET_CONTEXT';
export const FETCH_CONTEXT = 'FETCH_CONTEXT';
export const FETCH_FAILURE = 'FETCH_FAILURE';
export const SET_LANGUAGE = 'SET_LANGUAGE';
export const SET_CURRENCY = 'SET_CURRENCY';
export const SET_TENANT = 'SET_TENANT';
export const INITIAL_STATE = '@ngrx/store/init';

export class InitialState implements Action {
  readonly type = INITIAL_STATE;
}
export class SetContext implements Action {
  readonly type = SET_CONTEXT;

  constructor(public payload: OTContext) { }
}
export class SetLanguage implements Action {
  readonly type = SET_LANGUAGE;

  constructor(public payload: string) { }
}
export class SetTenant implements Action {
  readonly type = SET_TENANT;

  constructor(public payload: { TenantId: number, TenantKey: string }) { }
}
export class SetCurrency implements Action {
  readonly type = SET_CURRENCY;

  constructor(public payload: { currency: string, currencySymbol: string }) { }
}
export class FetchContext implements Action {
  readonly type = FETCH_CONTEXT;
}
export class FetchFailure implements Action {
  readonly type = FETCH_FAILURE;
}

export type ContextActions = InitialState | SetContext | FetchContext | FetchFailure | SetCurrency | SetLanguage | SetTenant;
