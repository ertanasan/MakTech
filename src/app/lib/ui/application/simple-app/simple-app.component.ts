import { Component, OnInit, Input } from '@angular/core';

import { BaseAppComponent } from '@otui/core/base-app/base-app.component';

@Component({
    selector: 'ot-simple-app',
    templateUrl: './simple-app.component.html',
    styleUrls: ['./simple-app.component.css']
})
export class SimpleAppComponent extends BaseAppComponent implements OnInit {

    @Input() logo: string;
    @Input() mainModule: string;

    constructor() {
        super();
    }

    ngOnInit() {
    }

    handleClick() {
        alert('click');
    }
}
