import { Component, ComponentFactoryResolver, OnInit, ViewChild, ViewContainerRef, ViewEncapsulation, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';

import { Store, ActionsSubject } from '@ngrx/store';
import * as fromApp from '../../store/app.reducers';
import * as AuthActions from '../store/auth.actions';

import { ScriptLoaderService } from '@otcommon/service/script-loader.service';
import { AlertService } from '@otlib/auth/service';
import { AlertComponent } from '@otlib/auth/directives';
import { environment } from 'environments/environment';
import { Refresh } from '@ngrx/store-devtools/src/actions';
import { AuthService } from '../service/auth.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ToasterConfig } from 'angular2-toaster';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: '.kt-grid.kt-grid--ver.kt-grid--root',
    styleUrls: ['signin.component.css'],
    templateUrl: '../../../modules/app-main/screen/signin/signin.component.html',
    encapsulation: ViewEncapsulation.None,
})

export class SigninComponent implements OnInit, OnDestroy {
    model: any = {};
    loading = false;
    spinnerLoading = false;
    private dispatcherSubscription: Subscription;
    showLoginForm = true;
    isRemember = true;
    lastAlertTarget: ViewContainerRef;

    @ViewChild('alertSignin',
        { read: ViewContainerRef, static: false }) alertSignin: ViewContainerRef;
    @ViewChild('alertSignup',
        { read: ViewContainerRef, static: false }) alertSignup: ViewContainerRef;
    @ViewChild('alertForgotPass',
        { read: ViewContainerRef, static: false }) alertForgotPass: ViewContainerRef;

    public toasterconfig: ToasterConfig =
        new ToasterConfig({
            tapToDismiss: true,
            timeout: 5000,
            positionClass: 'toast-top-center',
            limit: 5
        });

    constructor(
        private _route: ActivatedRoute,
        private _alertService: AlertService,
        private cfr: ComponentFactoryResolver,
        private store: Store<fromApp.AppState>,
        private dispatcher: ActionsSubject,
        private authService: AuthService,
        private translateService: TranslateService,
        private messageService: GrowlMessageService) {
    }

    ngOnInit() {
        this.dispatcherSubscription = this.dispatcher.pipe(filter(action => action.type === AuthActions.LOGIN_FAILURE))
            .subscribe(() => {
                this.showAlert(this.alertSignin, this.translateService.instant('Login Failed!'));
                this.loading = false;
                this.showLoginForm = true;
            });

        if (environment.useWindowsAuthentication) {
            this._route.queryParams.subscribe(params => {
                if (params['action'] !== 'logout') {
                    this.showLoginForm = false;
                    this.store.dispatch(new AuthActions.TryWindowsSignin());
                }
            });
        }
        this.model.remember = true;
    }

    ngOnDestroy() {
        if (this.dispatcherSubscription) {
            this.dispatcherSubscription.unsubscribe();
        }
    }

    signin() {
        this.loading = true;
        if (this.lastAlertTarget) {
            this.clearAlert();
            setTimeout(() => {
                this.store.dispatch(new AuthActions.TrySignin({ Username: this.model.email, Password: this.model.password, RememberMe: true, Language: 1 }));
            }, 500);
        } else {
            this.store.dispatch(new AuthActions.TrySignin({ Username: this.model.email, Password: this.model.password, RememberMe: true, Language: 1 }));
        }
    }

    signup() {
        this.loading = true;
    }

    forgotPass() {
        this.loading = true;
    }

    showAlert(alertTarget: ViewContainerRef, alert: string) {
        this.lastAlertTarget = alertTarget;
        const factory = this.cfr.resolveComponentFactory(AlertComponent);
        const ref = alertTarget.createComponent(factory);
        ref.changeDetectorRef.detectChanges();
        this._alertService.error(alert);
    }

    forgetPassword() {
        this.isRemember = false;
        this.model.email = '';
    }

    backToForm() {
        this.isRemember = true;
    }

    passwordPage() {
        this.authService.ForgotPassword(this.model.email).subscribe(result => {
            if (result === '') {
                this.messageService.success(this.translateService.instant('Message sent to your email address.'));
            } else {
                this.messageService.warning(result.toString());
            }
            this.model.email = '';
        });
    }

    clearAlert() {
        if (this.lastAlertTarget) {
            this.lastAlertTarget.clear();
            this.lastAlertTarget = null;
        }
    }
}
