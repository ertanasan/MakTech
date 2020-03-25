import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-date-entry',
    templateUrl: './date-entry.component.html',
    styleUrls: ['./date-entry.component.css'],
})
export class DateEntryComponent extends DataEntryBase<string> implements OnInit {
    innerDateValue: Date;

    @Input() format: string;
    @Input() placeholder: string;
    @Input() formatPattern: string;
    @Input() min?: Date;
    @Input() max?: Date;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    writeValue(value: string) {
        this.innerDateValue = value ? new Date(value) : null;
        super.writeValue(value);
    }

    get dateValue(): Date {
        return this.innerDateValue;
    }

    set dateValue(value: Date) {
        if (value) {
            this.innerDateValue = value;
            this.value = value ? value.toISOString() : null;
        }
    }

    setValue(value: string) {
        super.setValue(value);
        this.innerDateValue = new Date(value);
    }
}
