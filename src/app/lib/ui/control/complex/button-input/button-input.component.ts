import { ValueAccessorBase } from './../../../../common/data-entry-base/value-accessor-base';
import { Component, OnInit, Input, Output, EventEmitter, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'ot-button-input',
    templateUrl: './button-input.component.html',
    styleUrls: ['./button-input.component.css'],
})
export class ButtonInputComponent extends ValueAccessorBase<string> implements OnInit {
    @Input() readonly: boolean;
    @Input() disabled: boolean;
    @Output() onBlur: EventEmitter<any> = new EventEmitter();
    @Output() onButtonClick: EventEmitter<any> = new EventEmitter();
    @Input() icon = 'fa fa-search';
    @Input() buttonText = '';
    constructor(
        @Optional() @Self() ngControl: NgControl,
        private translateService: TranslateService,
    ) {
        super(ngControl);
    }

    ngOnInit() {
    }
}
