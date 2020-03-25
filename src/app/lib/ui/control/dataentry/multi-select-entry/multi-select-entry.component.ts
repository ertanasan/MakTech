import { NgControl } from '@angular/forms';
import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { DropDownFilterSettings } from '@progress/kendo-angular-dropdowns';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-multi-select-entry',
    templateUrl: './multi-select-entry.component.html',
    styleUrls: ['./multi-select-entry.component.css'],
})
export class MultiSelectEntryComponent extends DataEntryBase<string> implements OnInit {

    @Input() items: any[];
    @Input() get itemList(): any[] {
        return this.items;
    }
    @Input() textField: string;
    @Input() valueField: string;
    @Input() usePrimitiveValue: boolean;
    @Input() useAsync = false;
    @Input() loadingMessage = 'List loading please wait.';
    @Input() loading = false;
    @Input() summaryLimit = 10;
    @Input() autoClose = false;

    public filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        operator: 'startsWith'
    };

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
