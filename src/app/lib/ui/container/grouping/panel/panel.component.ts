import { Component, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';

import { ContainerComponent } from '@otui/core/container/container.component';

@Component({
    selector: 'ot-panel',
    templateUrl: './panel.component.html',
    styleUrls: ['./panel.component.css']
})
export class PanelComponent extends ContainerComponent implements OnInit {
    @Input() toggleable: boolean;
    @Input() caption: string;
    @Input() collapsed = false;
    @Input() style: any;
    @Input() styleClass: string;
    @Input() expandIcon = 'fa-plus';
    @Input() collapseIcon = 'fa-minus';
    @Input() showHeader = true;
    @Input() hideTools = false;
    @Input() width = 12;
    @Input() widthBS: string;

    @Output() collapsedChange: EventEmitter<any> = new EventEmitter();
    @Output() onBeforeToggle: EventEmitter<any> = new EventEmitter();
    @Output() onAfterToggle: EventEmitter<any> = new EventEmitter();

    constructor(private elementRef: ElementRef) {
        super();
    }

    ngOnInit() {
    }
}
