import { Component, OnInit, Output, EventEmitter, Input, Self, Optional, ViewChild, ElementRef, ContentChild } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { NumericTextBoxComponent } from '@progress/kendo-angular-inputs';

@Component({
    selector: 'ot-numeric-entry',
    templateUrl: './numeric-entry.component.html',
    styleUrls: ['./numeric-entry.component.css'],
})
export class NumericEntryComponent extends DataEntryBase<number> implements OnInit {
    @ViewChild('kendoInput', {static: false}) input: NumericTextBoxComponent;
    @ViewChild('inputInGrid', {static: false}) inputInGrid: NumericTextBoxComponent;

    @Output() onChange: EventEmitter<any> = new EventEmitter();
    @Output() onBlur: EventEmitter<any> = new EventEmitter();
    @Input() buttonsVisible = true;
    @Input() format: any;
    @Input() step = 1;
    @Input() min?: number;
    @Input() max?: number;
    @Input() autoCorrect = false;
    @Input() decimals: any = null;
    @Input() useNumericInput = true;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onChangeHandler(event) {
        this.onChange.emit(event);
    }

    touch() {
        this.onBlur.emit(this.inGrid ? this.inputInGrid.value : this.input.value);
    }

    focus() {
        this.input.focus();
    }
}
