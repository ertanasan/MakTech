import * as AuthActions from './auth.actions';

import { LoginResult } from '@otlib/auth/model/loginresult.model';

export interface State {
    token: string;
    refreshToken: string;
    authenticated: boolean;
    refreshingToken: boolean;
    loginFailed: boolean;
    userFullName: string;
    userName: string;
    userEmail: string;
    gender: string;
    passwordExpired: boolean;
    expirationDate: Date;
    refreshTokenExpirationDate: Date;
}

const initialState: State = {
    token: null,
    refreshToken: null,
    authenticated: false,
    refreshingToken: false,
    loginFailed: false,
    userFullName: '',
    userEmail: '',
    userName: '',
    gender: 'M',
    passwordExpired: false,
    expirationDate: new Date(),
    refreshTokenExpirationDate: new Date()
};

export function authReducer(state = initialState, action: AuthActions.AuthActions) {

    const storedUser = localStorage.getItem('ot-user');
    // console.log(storedUser);
    switch (action.type) {
        case (AuthActions.INITIAL_STATE):
            if (storedUser) {
                const userObject  = <LoginResult>JSON.parse(storedUser);
                if (!userObject.TokenDate) {
                    userObject.TokenDate = new Date();
                } else {
                    userObject.TokenDate = new Date(userObject.TokenDate);
                }
                if (!userObject.RefreshTokenExpireInSeconds) {
                    userObject.RefreshTokenExpireInSeconds = 100;
                }
                return {
                    ...state,
                    token: userObject.AccessToken,
                    refreshToken: userObject.RefreshToken,
                    authenticated: true,
                    loginFailed: false,
                    userFullName: userObject.UserFullName,
                    userName: userObject.UserName,
                    userEmail: userObject.UserEmail,
                    gender: userObject.Gender,
                    passwordExpired: false,
                    expirationDate: new Date(userObject.TokenDate.getTime() + 1000 * (userObject.ExpireInSeconds - 10)),
                    refreshTokenExpirationDate: new Date(userObject.TokenDate.getTime() + 1000 * (userObject.RefreshTokenExpireInSeconds - 100))
                };
            }
            return state;

        case (AuthActions.SIGNUP):
        case (AuthActions.SIGNIN):
            localStorage.removeItem('ot-user');
            return {
                ...state,
                authenticated: true,
                loginFailed: false
            };

        case (AuthActions.LOGOUT):
            localStorage.removeItem('ot-user');
            return {
                ...state,
                token: null,
                refreshToken: null,
                authenticated: false,
                loginFailed: false
            };

        case (AuthActions.SET_TOKEN):
            localStorage.setItem('ot-user', JSON.stringify(action.payload));
            return {
                ...state,
                token: action.payload.AccessToken,
                refreshToken: action.payload.RefreshToken,
                refreshingToken: false,
                loginFailed: false,
                userEmail: action.payload.UserEmail,
                userFullName: action.payload.UserFullName,
                userName: action.payload.UserName,
                gender: action.payload.Gender,
                passwordExpired: action.payload.PasswordExpired,
                expirationDate: new Date(action.payload.TokenDate.getTime() + 1000 * (action.payload.ExpireInSeconds - 10)),
                refreshTokenExpirationDate: new Date(action.payload.TokenDate.getTime() + 1000 * (action.payload.RefreshTokenExpireInSeconds - 100))
            };

        case (AuthActions.USE_REFRESHTOKEN):
            if (storedUser) {
                const userObject  = <LoginResult>JSON.parse(storedUser);
                if (!userObject.TokenDate) {
                    userObject.TokenDate = new Date();
                } else {
                    userObject.TokenDate = new Date(userObject.TokenDate);
                }

                return {
                    ...state,
                    token: userObject.RefreshToken,
                    refreshingToken: true,
                    loginFailed: false
                    };
            }
            return state;

        case (AuthActions.LOGIN_FAILURE):
            localStorage.removeItem('ot-user');
            return {
                ...state,
                token: null,
                refreshToken: null,
                authenticated: false,
                loginFailed: true
            };

        default:
            return state;
    }
}
