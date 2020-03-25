import { Component, OnInit, Input, AfterViewInit, ViewChild, ElementRef, OnDestroy, Self, Optional } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { NgControl } from '@angular/forms';
import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { TranslateService } from '@ngx-translate/core';


@Component({
    selector: 'ot-rich-edit',
    templateUrl: './rich-edit.component.html',
    styleUrls: ['./rich-edit.component.css'],
})
export class RichEditComponent extends DataEntryBase<string> implements OnInit, AfterViewInit, OnDestroy {
    @ViewChild('editor', {static: true}) editorElement: ElementRef;
    editor: any;

    @Input() height = '250px';
    @Input() config: any;
    content: string;

    public Editor = ClassicEditor;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
    }

    ngAfterViewInit() {

    }

    ngOnDestroy() {
    }

}
