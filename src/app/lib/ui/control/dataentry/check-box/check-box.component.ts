import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-check-box',
    templateUrl: './check-box.component.html',
    styleUrls: ['./check-box.component.css'],
})
export class CheckBoxComponent extends DataEntryBase<boolean> implements OnInit {
    @Input() disabled = false;
    @Input() optionName = `checkbox_${ Math.floor((Math.random() * 10000) + 1) }`;
    @Input() color = 'primary';
    @Input() label = '';

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onOptionClick() {
        if (this.isReadOnly) {
            return false;
        }
    }

    getLabelClasses() {
        const classes = {};
        if (this.inGrid) {
            classes['in-grid'] = true;
        }
        return classes;
    }
}
