// Angular
import { Component, Input, OnInit } from '@angular/core';
// RxJS
import { Observable } from 'rxjs';
// NGRX
import {  Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import * as fromAuth from '@otlib/auth/store/auth.reducers';
import * as AuthActions from '@otlib/auth/store/auth.actions';
import { take } from 'rxjs/operators';


@Component({
	selector: 'kt-user-profile3',
	templateUrl: './user-profile3.component.html',
})
export class UserProfile3Component implements OnInit {
	// Public properties
	user$: Observable<any>;

	@Input() badge: boolean;
	@Input() icon: boolean;
	@Input() mainModule: string;

	/**
	 * Component constructor
	 *
	 * @param store: Store<AppState>
	 */
	constructor(private store: Store<fromApp.AppState>) {
	}

	/**
	 * @ Lifecycle sequences => https://angular.io/guide/lifecycle-hooks
	 */

	/**
	 * On init
	 */
	ngOnInit(): void {
		this.user$ = this.store.select('auth').pipe(take(1));
	}

	/**
	 * Log out
	 */
	logout() {
		this.store.dispatch(new AuthActions.Logout());
	}
}
