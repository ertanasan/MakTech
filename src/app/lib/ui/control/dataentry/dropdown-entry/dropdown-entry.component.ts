import { Component, OnInit, Input, Self, Optional, ViewChild, ElementRef } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';


import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { DropDownFilterSettings, DropDownListComponent } from '@progress/kendo-angular-dropdowns';

@Component({
    selector: 'ot-dropdown-entry',
    templateUrl: './dropdown-entry.component.html',
    styleUrls: ['./dropdown-entry.component.css'],
})
export class DropdownEntryComponent extends DataEntryBase<number> implements OnInit {
    @ViewChild('input', { static: true }) inputComponent: DropDownListComponent;

    filterSettings: DropDownFilterSettings = {
        caseSensitive: false,
        // operator: 'startsWith'
        operator: 'contains'
    };

    @Input() items: any[];

    @Input() textField: string;
    @Input() valueField: string;
    @Input() usePrimitiveValue: boolean;
    @Input() useAsync = true;
    @Input() loadingMessage = 'List loading please wait.';
    @Input() loading = false;
    @Input() defaultItem: any;

    @Input() get itemList(): any[] {
        return this.items;
    }

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    toggle(openState: boolean) {
        this.inputComponent.toggle(openState);
        if (openState) {
            this.inputComponent.focus();
        }
    }

    focus() {
        this.inputComponent.focus();
    }
}
