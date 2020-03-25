import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
@Component({
    selector: 'ot-drop-down-button',
    templateUrl: './drop-down-button.component.html',
    styleUrls: ['./drop-down-button.component.css'],
    encapsulation: ViewEncapsulation.Emulated
})
export class DropDownButtonComponent implements OnInit {
    @Input() caption: string;
    @Input() data: any[];
    @Input() icon: string;
    @Input() primary = false;
    @Input() look = '';
    @Input() externalData: any;

    @Output() onItemClick: EventEmitter<any> = new EventEmitter();

    constructor() { }

    ngOnInit() {
    }

    itemClickHandler(event) {
        event.ExternalData = this.externalData;
        this.onItemClick.emit(event.click());
    }
}
