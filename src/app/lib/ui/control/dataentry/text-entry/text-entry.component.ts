import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-text-entry',
    templateUrl: './text-entry.component.html',
    styleUrls: ['./text-entry.component.css'],
})
export class TextEntryComponent extends DataEntryBase<string> implements OnInit {
    @Input() rows = 3;

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
