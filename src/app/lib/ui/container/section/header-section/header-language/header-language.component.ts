import { Component, OnInit } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { Store } from '@ngrx/store';

import * as fromApp from '@otlib/store/app.reducers';
import * as ContextActions from '@otlib/auth/store/context.actions';
import { OTContext } from '@otlib/auth/model/context.model';

@Component({
    selector: '.ot-header-language',
    templateUrl: './header-language.component.html',
    styleUrls: ['./header-language.component.css']
})
export class HeaderLanguageComponent implements OnInit {

    languageSelected = new Subject<string>();
    contextState$: Observable<OTContext>;

    constructor(// private translateService: TranslateService,
        private readonly store: Store<fromApp.AppState>) {
        this.contextState$ = this.store.select('context');
    }

    ngOnInit() {
        this.languageSelected.subscribe(lang => {
            this.store.dispatch(new ContextActions.SetLanguage(lang));
        });
    }
}
