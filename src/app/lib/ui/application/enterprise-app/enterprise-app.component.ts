import { Component, OnInit, Input } from '@angular/core';

import { BaseAppComponent } from '@otui/core/base-app/base-app.component';

@Component({
    selector: 'ot-enterprise-app',
    templateUrl: './enterprise-app.component.html',
    styleUrls: ['./enterprise-app.component.css']
})
export class EnterpriseAppComponent extends BaseAppComponent implements OnInit {
    @Input() hasCustomHeader = false;
    @Input() hasCustomToolbar = false;

    constructor() {
        super();
    }

    ngOnInit() {
    }
}
