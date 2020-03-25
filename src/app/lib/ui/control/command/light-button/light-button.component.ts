import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { OTBase } from '@otcommon/ot-base';

@Component({
    selector: 'ot-light-button',
    templateUrl: './light-button.component.html',
    styleUrls: ['./light-button.component.css']
})
export class LightButtonComponent extends OTBase implements OnInit {
    @Input() type = 'button';
    @Input() color = 'secondary';
    @Input() disabled: boolean;
    @Input() icon = 'fas fa-search';

    @Output() onClick: EventEmitter<any> = new EventEmitter();

    constructor() {
        super();
    }

    ngOnInit() {
    }

}
