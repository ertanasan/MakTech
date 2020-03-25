import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { BaseControlComponent } from '@otui/core/base-control/base-control.component';

type bsColor = 'primary' | 'secondary' | 'success' | 'warning' | 'danger' | 'info' | 'light' | 'dark' | 'link';
type btnType = 'button' | 'submit' | 'reset';
type btnSize = 'sm' | 'md' | 'lg';
type btnShape = '' | 'square' | 'pill';
type btnFill = '' | 'outline' | 'ghost';

@Component({
    selector: 'ot-button',
    templateUrl: './button.component.html',
    styleUrls: ['./button.component.css']
})
export class ButtonComponent extends BaseControlComponent implements OnInit {

    @Input() caption: string;
    @Input() actionType: btnType = 'button';
    @Input() color: bsColor = 'secondary';
    @Input() hidden: boolean;
    @Input() disabled: boolean;
    @Input() icon: string;
    @Input() size: btnSize = 'md';
    @Input() shape: btnShape = '';
    @Input() fill: btnFill = '';
    @Input() block = false;
    @Input() outline = false;

    @Output() onClick: EventEmitter<any> = new EventEmitter();

    constructor() {
        super();
    }

    ngOnInit() {
    }

    onClickHandler(event) {
        if (!this.disabled) {
            this.onClick.emit(event);
        }
    }

    getButtonClasses() {
        const classes = { 'btn': true };
        if (this.block) {
            classes['btn-block'] = true;
        }
        if (this.fill) {
            classes['btn-' + this.fill + '-' + this.color] = true;
        } else {
            if (this.outline) {
                classes['btn-outline-' + this.color] = true;
            } else {
                classes['btn-' + this.color] = true;
            }
        }
        if (this.size !== 'md') {
            classes['btn-' + this.size] = true;
        }
        if (this.shape) {
            classes['btn-' + this.shape] = true;
        }
        return classes;
    }
}
