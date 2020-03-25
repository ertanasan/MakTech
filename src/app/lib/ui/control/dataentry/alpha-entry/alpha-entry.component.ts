import { Component, OnInit, Optional, Input, Self, ViewChild, ElementRef } from '@angular/core';
import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { TranslateService } from '@ngx-translate/core';
import { NgControl } from '@angular/forms';


@Component({
    selector: 'ot-alpha-entry',
    templateUrl: './alpha-entry.component.html',
    styleUrls: ['./alpha-entry.component.css'],
})
export class AlphaEntryComponent extends DataEntryBase<string> implements OnInit {

    @ViewChild('textbox', {static: false}) tbox: ElementRef;
    @Input() isPassword = false;
    @Input() hint = '';
    @Input() isDigitOnly = false;
    @Input() maxlength: number;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    public focus() {
        this.tbox.nativeElement.focus();
    }

}
