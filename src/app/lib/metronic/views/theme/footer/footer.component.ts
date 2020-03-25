// Angular
import { Component, OnInit } from '@angular/core';
// Layout
import { LayoutConfigService } from '../../../core/_base/layout';
// Object-Path
import * as objectPath from 'object-path';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs/Observable';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import { Subscription } from 'rxjs';

@Component({
	selector: 'kt-footer',
	templateUrl: './footer.component.html',
})
export class FooterComponent implements OnInit {
	// Public properties
	today: number = Date.now();
	fluid: boolean;
	environment = environment;
	contextState$: Observable<OTContext>;
	subcriptionList: Subscription = new Subscription();

	/**
	 * Component constructor
	 *
	 * @param layoutConfigService: LayouConfigService
	 */
	constructor(private layoutConfigService: LayoutConfigService,  private readonly store: Store<fromApp.AppState>) {
		this.contextState$ = this.store.select('context');
	}

	/**
	 * @ Lifecycle sequences => https://angular.io/guide/lifecycle-hooks
	 */

	/**
	 * On init
	 */
	ngOnInit(): void {
		const config = this.layoutConfigService.getConfig();

		// footer width fluid
		this.fluid = objectPath.get(config, 'footer.self.width') === 'fluid';
	}
}
