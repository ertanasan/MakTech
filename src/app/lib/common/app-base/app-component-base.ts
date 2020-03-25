import { registerLocaleData } from '@angular/common';
import { OnInit, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';

import * as fromApp from '@otlib/store/app.reducers';
import * as fromAuth from '@otlib/auth/store/auth.reducers';
import * as fromContext from '@otlib/auth/store/context.actions';

import * as AuthActions from '@otlib/auth/store/auth.actions';

import localeTr from '@angular/common/locales/tr';
import localeEn from '@angular/common/locales/en';
import localeDe from '@angular/common/locales/de';

import { OTContext } from '@otlib/auth/model/context.model';
import { IntlService, CldrIntlService } from '@progress/kendo-angular-intl';
import { OTKendoMessageService } from '../../service/kendo-message.service';
import { MessageService } from '@progress/kendo-angular-l10n';

export class OTAppComponentBase implements OnInit, OnDestroy {
    title = 'app';
    authState$: Observable<fromAuth.State>;
    contextState$: Observable<OTContext>;
    subcriptionList: Subscription = new Subscription();

    constructor(private translateService: TranslateService, public store: Store<fromApp.AppState>,
                public intlService: IntlService, private messageService: MessageService                ) {
        translateService.setDefaultLang('tr');
        this.authState$ = this.store.select('auth');
        this.contextState$ = this.store.select('context');
    }

    ngOnInit() {
       this.subcriptionList.add(this.contextState$.subscribe(context => {
            this.translateService.use(context.UserLanguage);

            switch (context.UserLanguage) {
                case 'tr':
                default:
                    registerLocaleData(localeTr);
                    (<OTKendoMessageService>this.messageService).language = 'tr';
                    (<CldrIntlService>this.intlService).localeId = 'tr';
                    break;
                case 'en':
                    registerLocaleData(localeEn);
                    (<OTKendoMessageService>this.messageService).language = 'en';
                    (<CldrIntlService>this.intlService).localeId = 'en-US';
                    break;
                case 'de':
                    registerLocaleData(localeDe);
                    (<OTKendoMessageService>this.messageService).language = 'de';
                    (<CldrIntlService>this.intlService).localeId = 'de-DE';
                    break;
            }
        }));
        this.subcriptionList.add(this.authState$.subscribe(auth => {
            if (auth.authenticated && auth.token && !auth.refreshingToken && auth.expirationDate.getTime() > new Date().getTime()) {
                this.store.dispatch(new fromContext.FetchContext());
            } else if (!auth.token) {
                this.store.dispatch(new fromContext.SetContext(new OTContext()));
             } // else if (!auth.refreshingToken && auth.expirationDate.getTime() < new Date().getTime()) {
            //     this.store.dispatch(new AuthActions.UseRefreshToken());
            //     this.store.dispatch(new AuthActions.RefreshToken());
            // }
        }));
    }
    ngOnDestroy() {
        this.subcriptionList.unsubscribe();
    }
}
