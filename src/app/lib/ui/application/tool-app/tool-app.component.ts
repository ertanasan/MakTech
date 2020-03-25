import { Component, OnInit } from '@angular/core';

import { BaseAppComponent } from '@otui/core/base-app/base-app.component';

@Component({
    selector: 'ot-tool-app',
    templateUrl: './tool-app.component.html',
    styleUrls: ['./tool-app.component.css']
})
export class ToolAppComponent extends BaseAppComponent implements OnInit {

    constructor() {
        super();
    }

    ngOnInit() {
    }
}
