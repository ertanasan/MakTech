import { Component, OnInit, Output, EventEmitter, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-button-entry',
    templateUrl: './button-entry.component.html',
    styleUrls: ['./button-entry.component.css'],
})
export class ButtonEntryComponent extends DataEntryBase<string> implements OnInit {

    @Output() onButtonClick: EventEmitter<any> = new EventEmitter();

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

}
