import { ContextEffects } from './lib/auth/store/context.effects';
import { OTCommonModule } from '@otcommon/common.module';
import { BrowserModule, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { environment } from './../environments/environment';
import { AppComponent } from './app.component';
import { reducers } from './lib/store/app.reducers';
import { AuthEffects } from './lib/auth/store/auth.effects';
import { AuthModule } from './lib/auth/auth.module';
import { AppRoutingModule } from './app-routing.module';
import { AuthRoutingModule } from './lib/auth/auth-routing.routing';
import { LazyRoutingModule } from './lazy-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import 'hammerjs';
import '@progress/kendo-angular-intl/locales/en/all';
import '@progress/kendo-angular-intl/locales/tr/all';
import { ThemeComponent } from './theme/theme.component';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { IntlModule, CldrIntlService, IntlService } from '@progress/kendo-angular-intl';
import { GaugesModule } from '@progress/kendo-angular-gauges';
import { MessageService } from '@progress/kendo-angular-l10n';
import { OTKendoMessageService } from '@otservice/kendo-message.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HeaderNotificationOverstoreComponent } from './theme/header-notification-overstore/header-notification-overstore.component';
import { TaskalertComponent } from '@app-main/screen/taskalert/taskalert.component';
import { OverstoreCommonMethods } from './util/common-methods.service';
import * as typescript from 'highlight.js/lib/languages/typescript';
import * as scss from 'highlight.js/lib/languages/scss';
import * as xml from 'highlight.js/lib/languages/xml';
import * as json from 'highlight.js/lib/languages/json';
import { PerfectScrollbarConfigInterface, PERFECT_SCROLLBAR_CONFIG, PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { HighlightLanguage, HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';
import { MatProgressSpinnerModule, GestureConfig, MatTabsModule } from '@angular/material';
import { InlineSVGModule } from 'ng-inline-svg';
import { OTMetronicModule } from '@otlib/metronic/metronic.module';
import { OverlayModule } from '@angular/cdk/overlay';
import { NgbDropdownModule, NgbTabsetModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import {PartialsModule} from '@otlib/metronic/views/partials/partials.module';
import { GroupUserService } from '@frame/security/service/group-user.service';


export function HttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=');
}
// tslint:disable-next-line:class-name
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
	wheelSpeed: 0.5,
	swipeEasing: true,
	minScrollbarLength: 40,
	maxScrollbarLength: 300,
};



export function hljsLanguages(): HighlightLanguage[] {
	return [
		{name: 'typescript', func: typescript},
		{name: 'scss', func: scss},
		{name: 'xml', func: xml},
		{name: 'json', func: json}
	];
}


@NgModule({
    declarations: [
        AppComponent,
        ThemeComponent,
        HeaderNotificationOverstoreComponent,
        TaskalertComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        BrowserModule,
        HttpClientModule,
        OTCommonModule,
        FormsModule,
        AuthModule,
        AppRoutingModule,
        AuthRoutingModule,
        LazyRoutingModule,
        StoreModule.forRoot(reducers),
        EffectsModule.forRoot([AuthEffects, ContextEffects]),
        StoreRouterConnectingModule.forRoot(),
        !environment.production ? StoreDevtoolsModule.instrument() : [],
        BrowserAnimationsModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            }
        }),
        AngularFontAwesomeModule,
        DropDownsModule,
        IntlModule,
        GaugesModule,
        BsDropdownModule,
        FontAwesomeModule,
        IntlModule,
        MatProgressSpinnerModule,
		InlineSVGModule.forRoot(),
        OTMetronicModule,
        OverlayModule,
        MatTabsModule,
            // ng-bootstrap modules
        PerfectScrollbarModule,
		NgbDropdownModule,
		NgbTabsetModule,
		NgbTooltipModule,
        PartialsModule,
    ],
    providers: [
        CldrIntlService,
        {
            provide: IntlService,
            useExisting: CldrIntlService
        },
        {
            provide: MessageService,
            useClass: OTKendoMessageService
        },
		{
			provide: PERFECT_SCROLLBAR_CONFIG,
			useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
		},
		{
			provide: HAMMER_GESTURE_CONFIG,
			useClass: GestureConfig
		},
		{
			provide: HIGHLIGHT_OPTIONS,
			useValue: {languages: hljsLanguages}
		},
        OverstoreCommonMethods,
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
