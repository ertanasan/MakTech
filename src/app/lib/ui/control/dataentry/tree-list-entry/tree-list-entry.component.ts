import { Component, OnInit, Input, ViewChild, ElementRef, AfterViewChecked, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';

@Component({
    selector: 'ot-tree-list-entry',
    templateUrl: './tree-list-entry.component.html',
    styleUrls: ['./tree-list-entry.component.css'],
})
export class TreeListEntryComponent extends DataEntryBase<number> implements OnInit, AfterViewChecked {
    popupVisible = false;
    displayText: string;
    nativeWidth: string;

    @ViewChild('popupAnchor', {static: true}) popupAnchor: ElementRef;

    @Input() nodes: any[];
    @Input() idField: string;
    @Input() textField: string;
    @Input() parentIdField: string;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    ngAfterViewChecked() {
        if (!this.nativeWidth && this.nativeWidth !== this.popupAnchor.nativeElement.clientWidth) {
            this.nativeWidth = this.popupAnchor.nativeElement.clientWidth;
        }
    }

    dropDownClicked() {
        this.popupVisible = !this.popupVisible;
    }

    selectionChanged(selection: any) {
        this.displayText = selection.dataItem[this.textField];
        this.value = selection.dataItem[this.idField];
        this.popupVisible = false;
    }
}
