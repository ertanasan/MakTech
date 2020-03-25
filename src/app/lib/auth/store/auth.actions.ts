import { Action } from '@ngrx/store';

import { Login } from '@otlib/auth/model/login.model';
import { LoginResult } from '@otlib/auth/model/loginresult.model';

export const TRY_SIGNUP = 'TRY_SIGNUP';
export const SIGNUP = 'SIGNUP';
export const TRY_SIGNIN = 'TRY_SIGNIN';
export const TRY_WINDOWSSIGNIN = 'TRY_WINDOWSSIGNIN';
export const SIGNIN = 'SIGNIN';
export const LOGOUT = 'LOGOUT';
export const SET_TOKEN = 'SET_TOKEN';
export const REFRESH_TOKEN = 'REFRESH_TOKEN';
export const USE_REFRESHTOKEN = 'USE_REFRESHTOKEN';
export const LOGIN_FAILURE = 'LOGIN_FAILURE';
export const REDIRECT = 'REDIRECT';
export const INITIAL_STATE = '@ngrx/store/init';
export class TrySignup implements Action {
    readonly type = TRY_SIGNUP;

    constructor(public payload: { username: string, password: string }) { }
}

export class TrySignin implements Action {
    readonly type = TRY_SIGNIN;

    constructor(public payload: Login) { }
}

export class TryWindowsSignin implements Action {
    readonly type = TRY_WINDOWSSIGNIN;
}

export class Signup implements Action {
    readonly type = SIGNUP;
}

export class Signin implements Action {
    readonly type = SIGNIN;
}

export class Logout implements Action {
    readonly type = LOGOUT;
    constructor(public payload: string = 'logout') { }
}
export class RefreshToken implements Action {
    readonly type = REFRESH_TOKEN;
}
export class UseRefreshToken implements Action {
    readonly type = USE_REFRESHTOKEN;
}

export class InitialState implements Action {
    readonly type = INITIAL_STATE;
}

export class LoginFailure implements Action {
    readonly type = LOGIN_FAILURE;
}

export class SetToken implements Action {
    readonly type = SET_TOKEN;

    constructor(public payload: LoginResult) { }
}

export class Redirect implements Action {
    readonly type = REDIRECT;

    constructor(public payload: string) { }
}

export type AuthActions = InitialState | Signup | Signin |
    Logout | SetToken | TrySignup | TrySignin | TryWindowsSignin |
    RefreshToken | UseRefreshToken | LoginFailure | Redirect;
