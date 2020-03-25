import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

import { ContainerComponent } from '@otui/core/container/container.component';
import { OTScreenBase } from '@otscreen-base/ot-screen-base';

@Component({
    selector: 'ot-base-screen-container',
    templateUrl: './base-screen-container.component.html',
    styleUrls: ['./base-screen-container.component.css']
})
export class BaseScreenContainerComponent extends ContainerComponent implements OnInit {
    parent: OTScreenBase;

    constructor() {
        super();
    }

    ngOnInit() {
    }
}
