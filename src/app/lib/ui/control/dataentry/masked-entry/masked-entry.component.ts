import { Component, OnInit, Input, Output, EventEmitter, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-masked-entry',
    templateUrl: './masked-entry.component.html',
    styleUrls: ['./masked-entry.component.css'],
})
export class MaskedEntryComponent extends DataEntryBase<string> implements OnInit {

    @Input() mask: string;

    @Output() onChange: EventEmitter<any> = new EventEmitter();

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
}
