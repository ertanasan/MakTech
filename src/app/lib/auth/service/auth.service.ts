
import { EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpBackend } from '@angular/common/http';

import { environment } from '../../../../environments/environment';

import { Login } from '@otlib/auth/model/login.model';
import { LoginResult } from '@otlib/auth/model/loginresult.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTContext } from '../model/context.model';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private loginHttpClient: HttpClient;
    private interceptedHttpClient: HttpClient;
    constructor(private httpClient: HttpClient, private handler: HttpBackend,
                protected messageService: GrowlMessageService) {
                    this.loginHttpClient = new HttpClient(handler);
                    this.interceptedHttpClient = httpClient;
    }

    TryLogin(login: Login) {

        return this.interceptedHttpClient.post<LoginResult>(environment.baseRoute + '/Authenticate/login', login, {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`);
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error( `${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return null;
        })).toPromise();
    }

    TryWindowsLogin() {
        return this.httpClient.get<LoginResult>(environment.baseRoute + '/Authenticate/loginwindows', {
            observe: 'body',
            responseType: 'json',
            withCredentials: true
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`);
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error( `${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return null;
        })).toPromise();
    }

    FetchContext() {
        return this.httpClient.get<OTContext>(environment.baseRoute + '/Authenticate/fetchContext', {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`
                );
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error(`${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return null;
        })).toPromise();
    }

    RefreshToken() {
        // console.log('Auth Service Refresh Token');
        return this.httpClient.get<LoginResult>(environment.baseRoute + '/Authenticate/refreshToken', {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`
                );
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error(`${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return null;
        })).toPromise();
    }

    ChangePassword(changePasswordFormValue: any) {
        return this.httpClient.post(environment.baseRoute + '/Authenticate/changePassword', changePasswordFormValue, {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`);
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error( `${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return EMPTY;
        }));
    }

    ForgotPassword(forgotPasswordValue: string) {
        return this.loginHttpClient.post(environment.baseRoute + '/Authenticate/forgotUserPassword', { userName: forgotPasswordValue, email : 'nothing@nothing.com'  } , {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`);
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error( `${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return EMPTY;
        }));
    }

    Resetpassword(resetPasswordFromValue: any ) {
        return this.loginHttpClient.post(environment.baseRoute + '/Authenticate/resetUserPassword', resetPasswordFromValue  , {
            observe: 'body',
            responseType: 'json'
        }).pipe(catchError((err: HttpErrorResponse) => {
            if (err.error instanceof Error) {
                // A client-side or network error occurred. Handle it accordingly.
                console.error('An error occurred:', err.error['ExceptionMessage']);
                this.messageService.error( `${err.error['ExceptionMessage']}`);
            } else {
                // The backend returned an unsuccessful response code.
                // The response body may contain clues as to what went wrong,
                console.error(`Backend returned code ${err.status}, body was: ${err.error['ExceptionMessage']}`);
                this.messageService.error( `${err.status} - ${err.error['ExceptionMessage']}`
                );
            }
            return EMPTY;
        }));
    }

}
