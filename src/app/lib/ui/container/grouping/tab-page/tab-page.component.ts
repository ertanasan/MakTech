import { Component, OnInit, Input, TemplateRef, ViewChild } from '@angular/core';

@Component({
    selector: 'ot-tab-page',
    templateUrl: './tab-page.component.html',
    styleUrls: ['./tab-page.component.css']
})
export class TabPageComponent implements OnInit {

    @Input() title: string;
    @Input() active: boolean;

    @ViewChild('tabContent', {static: true}) tabContent: TemplateRef<any>;

    constructor() { }

    ngOnInit() {
    }
}
