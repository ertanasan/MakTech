// Angular
import { Component, HostBinding, OnInit, Input } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
// RxJS
import { filter } from 'rxjs/operators';
// Translate
import { Subject, Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import * as ContextActions from '@otlib/auth/store/context.actions';

interface LanguageFlag {
	lang: string;
	name: string;
	flag: string;
	active?: boolean;
	code: string;
}

@Component({
	selector: 'kt-language-selector',
	templateUrl: './language-selector.component.html',
})
export class LanguageSelectorComponent implements OnInit {
	// Public properties
	@HostBinding('class') classes = '';
	@Input() iconType: '' | 'brand';

	language: LanguageFlag;
	languages: LanguageFlag[] = [
		{
			lang: 'en',
			name: 'English',
			flag: './assets/media/flags/012-uk.svg',
			code: 'EN'
		},
		{
			lang: 'tr',
			name: 'Türkçe',
			flag: './assets/media/flags/006-turkey.svg',
			code: 'TR'
		},
	];

	languageSelected = new Subject<string>();
	contextState$: Observable<OTContext>;

	constructor(private readonly store: Store<fromApp.AppState>) {
		this.contextState$ = this.store.select('context');
		this.setLanguage('tr');
	}

	/**
	 * @ Lifecycle sequences => https://angular.io/guide/lifecycle-hooks
	 */

	/**
	 * On init
	 */
	ngOnInit() {
		this.languageSelected.subscribe(lang => {
			this.store.dispatch(new ContextActions.SetLanguage(lang));
			this.setLanguage(lang);
		});
		this.contextState$.subscribe(context => this.setLanguage(context.UserLanguage));
	}

	/**
	 * Set language
	 *
	 * @param lang: any
	 */
	setLanguage(lang) {
		this.languages.forEach((language: LanguageFlag) => {
			if (language.lang === lang) {
				language.active = true;
				this.language = language;
			} else {
				language.active = false;
			}
		});
	}
}
