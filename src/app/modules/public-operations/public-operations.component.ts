import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { OTModuleComponentBase } from '@otcommon/app-base/module-component-base';
import { TranslateService } from '@ngx-translate/core';
import { Store } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';

@Component({
    selector: 'ot-public-operations',
    templateUrl: './public-operations.component.html',
    encapsulation: ViewEncapsulation.None,
})
export class PublicOperationsComponent extends OTModuleComponentBase implements OnInit {
    constructor(
        translateService: TranslateService,
        store: Store<fromApp.AppState>) {
        super(translateService, store);
    }

    ngOnInit() {
        super.ngOnInit();
    }
}
