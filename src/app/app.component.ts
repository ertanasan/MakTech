import { Component, ViewEncapsulation, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationStart, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subscription } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromApp from '@otlib/store/app.reducers';
import { OTAppComponentBase } from '@otcommon/app-base/app-component-base';
import { ToasterConfig } from 'angular2-toaster/src/toaster-config';
import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { LayoutConfigService, SplashScreenService } from '@otlib/metronic/core/_base/layout';
import { LoadingScreenService } from '@otservice/loading-screen.service';
import {PrivilegeCacheService} from '@otservice/privilege-cache.service';
import {User} from '@security/model/user.model';
import {first, map} from 'rxjs/operators';
import { GroupUserService } from '@frame/security/service/group-user.service';
import { group } from '@angular/animations';
import { OTContext } from '@otlib/auth/model/context.model';

@Component({
    selector: 'body[kt-root]',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss', '../scss/vendors/toastr/toastr.scss'],
    encapsulation: ViewEncapsulation.None,
})

export class AppComponent extends OTAppComponentBase implements OnInit, OnDestroy {
    isRouted = false;
    public toasterconfig: ToasterConfig =
    new ToasterConfig({
        tapToDismiss: true,
        timeout: 5000,
        positionClass: 'toast-top-center',
        limit: 5
    });

    title = 'Maktech';
	loader: boolean;
	private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/

	/**
	 * Component constructor
	 *
	 */
    constructor(
        translateService: TranslateService,
        store: Store<fromApp.AppState>,
        intlService: IntlService,
        messageService: MessageService,
        private router: Router,
	    public layoutConfigService: LayoutConfigService,
        private splashScreenService: SplashScreenService,
        private loadingScreenService: LoadingScreenService,
        private privilegeCacheService: PrivilegeCacheService,
        ) {
        super(translateService, store, intlService, messageService);
        this.loadingScreenService.addSkipRoute('OverStoreMain/Dashboard');
        this.loadingScreenService.addSkipRoute('OverStoreMain/StoreDashboard');
        this.loadingScreenService.addSkipRoute('OverStoreMain/CategoryDetails');
        this.loadingScreenService.addSkipRoute('OverStoreMain/CancelDetails');
        this.loadingScreenService.addSkipRoute('OverStoreMain/DashboardDetails');
        this.loadingScreenService.addSkipRoute('OverStoreMain/PriceDetails');
        this.loadingScreenService.addSkipRoute('Warehouse/WarehouseDashboard');
        this.loadingScreenService.addSkipRoute('Helpdesk/HelpdeskDashboard');
        this.loadingScreenService.addSkipRoute('Warehouse/StockDashboard');

    }

    ngOnInit() {
        super.ngOnInit();
        // enable/disable loader
		this.loader = this.layoutConfigService.getConfig('loader.enabled');
        const authSubscription = this.authState$.subscribe(auth => {
            if (!auth.authenticated) {
                this.isRouted = false;
            } else if (!this.isRouted && auth.token && !auth.refreshingToken) {
                this.isRouted = true;

                this.privilegeCacheService.checkPrivilege('Open Home Page').subscribe( dashboardResult => {
                    if (!dashboardResult) {
                        this.privilegeCacheService.checkPrivilege('Open Warehouse Home Page').subscribe( warehouseResult => {
                            if (warehouseResult) {
                                this.router.navigateByUrl('/Warehouse/WarehouseDashboard/Index');
                            } else {
                                this.privilegeCacheService.checkPrivilege('Open Gathering Home Page').subscribe( gatheringResult => {
                                    if (gatheringResult) {
                                        this.router.navigateByUrl('/Warehouse/Gathering/Index');
                                    } else {
                                        this.privilegeCacheService.checkPrivilege('Open Control Home Page').subscribe( controlResult => {
                                            if (controlResult) {
                                                this.router.navigateByUrl('/Warehouse/GatheringControl/Index');
                                            } else {
                                                switch (auth.userName) {
                                                    case 'oyuncu':
                                                        this.router.navigateByUrl('/Gamification/GamePlay/Index');
                                                        break;
                                                    case 'makbul.bizim':
                                                        this.router.navigateByUrl('/Announcement/SuggestionAnonymous/Index');
                                                        break;
                                                    default:
                                                        this.router.navigateByUrl('/OverStoreMain/Inbox/Index'); 
                                                        break;
                                                }
                                            }
                                        });
                                    }
                                });
                            }
                        });
                    }
                });

            }
        });
        this.unsubscribe.push(authSubscription);

		const routerSubscription = this.router.events.subscribe(event => {
			if (event instanceof NavigationEnd) {
				// hide splash screen
				this.splashScreenService.hide();

				// scroll to top on every route change
				window.scrollTo(0, 0);

				// to display back the body content
				setTimeout(() => {
					document.body.classList.add('kt-page--loaded');
				}, 500);
			}
		});
		this.unsubscribe.push(routerSubscription);

    }

    ngOnDestroy() {
        this.unsubscribe.forEach(sb => sb.unsubscribe());
        super.ngOnDestroy();
	}
}
