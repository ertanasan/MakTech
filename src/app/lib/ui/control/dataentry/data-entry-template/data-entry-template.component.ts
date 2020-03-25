import { Component, Input } from '@angular/core';
import { BaseControlComponent } from '@otui/core/base-control/base-control.component';

@Component({
    selector: 'ot-data-entry-template',
    templateUrl: './data-entry-template.component.html',
    styleUrls: ['./data-entry-template.component.css']
})
export class DataEntryTemplateComponent extends BaseControlComponent {

    @Input() showCaption = true;
    @Input() captionWidth = 'md-3';
    @Input() editorWidth = 'md-9';
    @Input() captionBS: string;
    @Input() editorBS: string;
    @Input() public caption: string;
    @Input() hasFormControl = true;
    @Input() optionName = '';

    @Input() hasError = false;
    @Input() validationMessages: Array<string>;

    constructor() {
        super();
    }

    getCaptionClasses() {
        const classes = {};
        if (this.captionBS) {
            classes[this.captionBS] = true;
        } else {
            classes['col-sm-' + this.captionWidth] = true;
        }
        return classes;
    }

    getEditorClasses() {
        const classes = {};
        if (this.editorBS) {
            classes[this.editorBS] = true;
        } else {
            classes['col-sm-' + this.editorWidth] = true;
        }
        return classes;
    }
}
