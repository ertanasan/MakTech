import { Input, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

import { OTBase } from '@otcommon/ot-base';

export class ValueAccessorBase<T> extends OTBase implements ControlValueAccessor {
    protected innerValue: T;
    public isDisabled = false;

    protected changed = new Array<(value: T) => void>();
    private touched = new Array<() => void>();

    @Output() valueChange = new EventEmitter<T>();

    constructor(
        public ngControl: NgControl
    ) {
        super();
        if (this.ngControl) {
            this.ngControl.valueAccessor = this;
        }
    }

    get value(): T {
        return this.getValue();
    }

    getValue(): T {
        return this.innerValue;
    }

    @Input() set value(value: T) {
        this.setValue(value);
    }

    setValue(value: T) {
        if (this.innerValue !== value) {
            this.innerValue = value;
            this.changed.forEach(f => f(value));
            this.valueChange.emit(this.innerValue);
        }
    }

    touch() {
        this.touched.forEach(f => f());
    }

    writeValue(value: T) {
        this.innerValue = value;
    }

    registerOnChange(fn: (value: T) => void) {
        this.changed.push(fn);
    }

    registerOnTouched(fn: () => void) {
        this.touched.push(fn);
    }

    setDisabledState(isDisabled: boolean) {
        this.isDisabled = isDisabled;
    }
}
