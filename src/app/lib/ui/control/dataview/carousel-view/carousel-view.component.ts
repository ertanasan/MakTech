import { Component, OnInit, Input, TemplateRef, ContentChild, Output, EventEmitter } from '@angular/core';
import { ItemChangedEvent } from '@progress/kendo-angular-scrollview/dist/es2015/change-event-args';

@Component({
    selector: 'ot-carousel-view',
    templateUrl: './carousel-view.component.html',
    styleUrls: ['./carousel-view.component.css']
})
export class CarouselViewComponent implements OnInit {

    constructor() { }

    ngOnInit() {
    }

    @ContentChild("itemTemplate", {static: true}) itemTemplate: TemplateRef<any>;

    @Input() items: any[];
    @Input() width: string;
    @Input() height: string;
    @Input() arrowsVisible: boolean;
    @Input() pageable: boolean;

    @Output() onItemChange: EventEmitter<number> = new EventEmitter();

    handleItemChange(event: ItemChangedEvent) {
        this.onItemChange.emit(event.index);
    }

}
