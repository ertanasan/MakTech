import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'ot-field-set',
    templateUrl: './field-set.component.html',
    styleUrls: ['./field-set.component.css']
})
export class FieldSetComponent implements OnInit {

    @Input() caption: string;

    constructor() { }

    ngOnInit() {
    }
}
