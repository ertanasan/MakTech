﻿import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';

import * as fromApp from '@otlib/store/app.reducers';

import { OTModuleComponentBase } from '@otcommon/app-base/module-component-base';

@Component({
    selector: 'ot-reconciliation',
    templateUrl: './reconciliation.component.html',
    encapsulation: ViewEncapsulation.None,
})
export class ReconciliationComponent extends OTModuleComponentBase implements OnInit {

    constructor(
        translateService: TranslateService,
        store: Store<fromApp.AppState>) {
        super(translateService, store);
    }

    ngOnInit() {
        super.ngOnInit();
    }
}
