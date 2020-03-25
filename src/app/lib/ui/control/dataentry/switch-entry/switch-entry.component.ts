import { Component, OnInit, Input, Self, Optional, EventEmitter, Output } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

type bsColor = 'primary' | 'secondary' | 'success' | 'warning' | 'danger' | 'info' | 'light' | 'dark' | 'link';
type switchSize = 'sm' | 'md' | 'lg';
type switchShape = '' | 'pill';
type switchFill = '' | 'outline' | 'outline-alt';
type switchLabelStyle = '' | 'text' | 'check';

@Component({
    selector: 'ot-switch-entry',
    templateUrl: './switch-entry.component.html',
    styleUrls: ['./switch-entry.component.css'],
})
export class SwitchEntryComponent extends DataEntryBase<boolean> implements OnInit {
    private checkedText = '✓';
    private uncheckedText = '✕';
    private defaultLabelText = 'On,Off';
    private _labelStyle: switchLabelStyle = '';

    @Output() onSwitched = new EventEmitter<boolean>();

    @Input() caption: string;
    @Input() color: bsColor = 'secondary';
    @Input() hidden: boolean;
    @Input() disabled: boolean;
    @Input() size: switchSize = 'md';
    @Input() shape: switchShape = '';
    @Input() fill: switchFill = '';
    @Input() block = true;
    @Input() get labelStyle() {
        return this._labelStyle;
    }
    set labelStyle(value) {
        this._labelStyle = value;
        switch (this._labelStyle) {
            case 'text':
                if (this.labelText && this.labelText.indexOf(',') > 0) {
                    this.dataChecked = this.labelText.split(',', 2)[0];
                    this.dataUnchecked = this.labelText.split(',', 2)[1];
                } else {
                    this.dataChecked = this.defaultLabelText.split(',', 2)[0];
                    this.dataUnchecked = this.defaultLabelText.split(',', 2)[1];
                }
                break;
            case 'check':
                this.dataChecked = this.checkedText;
                this.dataUnchecked = this.uncheckedText;
                break;
            default:
                this.dataChecked = '';
                this.dataUnchecked = '';
        }
    }
    @Input() labelText = this.defaultLabelText;

    dataChecked = '';
    dataUnchecked = '';

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    getSwitchLabelClasses() {
        const classes = { 'switch': true };
        switch (this.fill) {
            case 'outline':
                classes['switch-outline-' + this.color] = true;
                break;
            case 'outline-alt':
                classes['switch-outline-' + this.color + '-alt'] = true;
                break;
            default:
                classes['switch-' + this.color] = true;
                break;
        }
        if (this.labelStyle) {
            classes['switch-label'] = true;
        }
        if (this.shape === 'pill') {
            classes['switch-pill'] = true;
        }
        if (this.size !== 'md') {
            classes['switch-' + this.size] = true;
        }
        return classes;
    }
    switchValueChange() {
        this.onSwitched.emit(this.value);
    }
}
