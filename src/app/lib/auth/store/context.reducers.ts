import * as ContextActions from './context.actions';
import { OTContext } from '../model/context.model';

const initialState = new OTContext();

export function contextReducer(state = initialState, action: ContextActions.ContextActions) {
    const storedContext = localStorage.getItem('ot-context');

    let newState: OTContext;
    switch (action.type) {
        case (ContextActions.INITIAL_STATE):
            if (storedContext) {
                return <OTContext>JSON.parse(storedContext);
            } else {
                return state;
            }

        case (ContextActions.SET_CONTEXT):
            newState = {
                ...action.payload,
                UserCulture: action.payload.UserCulture,
                UserCurrency: action.payload.UserCurrency,
                UserCurrencySymbol: action.payload.UserCurrencySymbol,
                UserLanguage: action.payload.UserLanguage
            };
            localStorage.setItem('ot-context', JSON.stringify(newState));
            return newState;

        case (ContextActions.SET_LANGUAGE):
            newState = {
                ...state,
                UserLanguage: action.payload
            };
            localStorage.setItem('ot-context', JSON.stringify(newState));
            return newState;

        case (ContextActions.SET_CURRENCY):
            newState = {
                ...state,
                UserCurrency: action.payload.currency,
                UserCurrencySymbol: action.payload.currencySymbol
            };
            localStorage.setItem('ot-context', JSON.stringify(newState));
            return newState;

        case (ContextActions.SET_TENANT):
            newState = {
                ...state,
                TenantId: action.payload.TenantId,
                TenantKey: action.payload.TenantKey
            };
            localStorage.setItem('ot-context', JSON.stringify(newState));
            return newState;

        case ContextActions.FETCH_FAILURE:
        default:
            return state;
    }
}
