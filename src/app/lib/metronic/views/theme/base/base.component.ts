// Angular
import { Component, OnDestroy, OnInit, ViewEncapsulation, Input } from '@angular/core';
// RxJS
import { Observable, Subscription } from 'rxjs';
// Object-Path
import * as objectPath from 'object-path';
// Layout
import { LayoutConfigService, MenuConfigService, PageConfigService, MenuAsideService } from '../../../core/_base/layout';
import { HtmlClassService } from '../html-class.service';
import { MenuConfig } from '../../../core/_config/menu.config';
import { PageConfig } from '../../../core/_config/page.config';
import { MenuService } from '@otservice/menu.service';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store } from '@ngrx/store';

import * as fromApp from '@otlib/store/app.reducers';
import { BaseAppComponent } from '@otui/core/base-app/base-app.component';
import { LayoutConfig } from 'app/theme/layout.config';
import { TenantService } from '@otservice/tenant.service';
import { Organization } from '@organization/model/organization.model';
// User permissions

@Component({
	selector: 'kt-base',
	templateUrl: './base.component.html',
	styleUrls: ['./base.component.scss'],
	encapsulation: ViewEncapsulation.None
})
export class BaseComponent extends BaseAppComponent implements OnInit, OnDestroy {
	// Public variables
	selfLayout: string;
	asideDisplay: boolean;
	asideSecondary: boolean;
	subheaderDisplay: boolean;
	desktopHeaderDisplay: boolean;
	fitTop: boolean;
	fluid: boolean;

	contextState$: Observable<OTContext>;
	menuItems = [];
	organizations: Organization[] = [];
    menuLoading = false;
	// Private properties
	private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
	contextUserId = 0;
	contextLanguage = '';
	contextTenantKey = '';
	contextTenantId = 0;
	@Input() mainModule: string;
	@Input() showNotification = false;

	/**
	 * Component constructor
	 */
	constructor(
		private menuService: MenuService,
		private tenantService: TenantService,
		private layoutConfigService: LayoutConfigService,
		private menuConfigService: MenuConfigService,
		private pageConfigService: PageConfigService,
		private htmlClassService: HtmlClassService,
		private menuAsideService: MenuAsideService,
		private readonly store: Store<fromApp.AppState>) {
	    super();
		// register configs by demos
		this.layoutConfigService.loadConfigs(new LayoutConfig().configs);
		// this.menuConfigService.loadConfigs(new MenuConfig().configs);
		this.pageConfigService.loadConfigs(new PageConfig().configs);

		// setup element classes
		this.htmlClassService.setConfig(this.layoutConfigService.getConfig());

		const layoutConfigSubscription = this.layoutConfigService.onConfigUpdated$.subscribe(layoutConfig => {
			// reset body class based on global and page level layout config, refer to html-class.service.ts
			document.body.className = '';
			this.htmlClassService.setConfig(layoutConfig);
		});
		this.contextState$ = this.store.select('context');

		const menuSubscription = this.menuService.menuLoaded.subscribe(
			(items: any[]) => {
				this.menuItems = items;
				this.menuLoading = false;
				this.menuConfigService.loadConfigs(new MenuConfig().getConfigs(items));
				this.menuAsideService.loadMenu();
			}
		);
		const contextSubscription = this.contextState$.subscribe(
			context => {
				if (this.isContextChanged(context)) {
					this.contextUserId = context.User.Id;
					this.contextLanguage = context.UserLanguage;
					this.contextTenantKey = context.TenantKey;
					this.contextTenantId = context.TenantId;
					this.menuLoading = true;
					this.menuService.readForMetronic();
					this.tenantService.ListTenants();
				}
			}
		);

		this.unsubscribe.push(contextSubscription);
		this.unsubscribe.push(menuSubscription);
		this.unsubscribe.push(layoutConfigSubscription);
	}

	isContextChanged(context: OTContext): boolean {
		if (context.User.Id === 0) {
			return false;
		}
		if (this.contextUserId !== context.User.Id ||
			this.contextLanguage !== context.UserLanguage ||
			this.contextTenantKey !== context.TenantKey) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * @ Lifecycle sequences => https://angular.io/guide/lifecycle-hooks
	 */

	/**
	 * On init
	 */
	ngOnInit(): void {
		const config = this.layoutConfigService.getConfig();
		this.selfLayout = objectPath.get(config, 'self.layout');
		this.asideDisplay = objectPath.get(config, 'aside.self.display');
		this.subheaderDisplay = objectPath.get(config, 'subheader.display');
		this.desktopHeaderDisplay = objectPath.get(config, 'header.self.fixed.desktop');
		this.fitTop = objectPath.get(config, 'content.fit-top');
		this.fluid = objectPath.get(config, 'content.width') === 'fluid';

		// let the layout type change
		const layoutConfigSubscription = this.layoutConfigService.onConfigUpdated$.subscribe(cfg => {
			setTimeout(() => {
				this.selfLayout = objectPath.get(cfg, 'self.layout');
			});
		});

		this.unsubscribe.push(layoutConfigSubscription);
	}

	/**
	 * On destroy
	 */
	ngOnDestroy(): void {
		this.unsubscribe.forEach(sb => sb.unsubscribe());
	}

	loadMenuConfig(): void {
	}
}
