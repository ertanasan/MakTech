import { OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';

import * as fromApp from '@otlib/store/app.reducers';
import * as fromAuth from '@otlib/auth/store/auth.reducers';
import * as fromContext from '@otlib/auth/store/context.actions';

import { OTContext } from '@otlib/auth/model/context.model';

export class OTModuleComponentBase implements OnInit {
    contextState$: Observable<OTContext>;

    constructor(private translateService: TranslateService, private store: Store<fromApp.AppState>) {
        translateService.setDefaultLang('tr');
        this.contextState$ = this.store.select('context');
    }

    ngOnInit() {
        this.contextState$.subscribe(context => {
            this.translateService.use(context.UserLanguage);
        });
    }
}
