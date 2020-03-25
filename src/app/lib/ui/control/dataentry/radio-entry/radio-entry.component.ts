import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl, RadioControlValueAccessor } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { RadioItem} from './radio-item';
import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-radio-entry',
    templateUrl: './radio-entry.component.html',
    styleUrls: ['./radio-entry.component.css'],
})
export class RadioEntryComponent extends DataEntryBase<string> implements OnInit {

    @Input() items: RadioItem[] = [];
    @Input() optionName: string;
    @Input() textField = 'text';
    @Input() valueField = 'value';
    @Input() choice: any;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onOptionClick(item: RadioItem) {
        this.value = item[this.valueField];
    }

    getControlClasses() {
        const classes = super.getControlClasses();
        classes['form-check-input'] = true;
        return classes;
    }
}
