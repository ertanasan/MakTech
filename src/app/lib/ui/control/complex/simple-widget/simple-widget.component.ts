import { Component, OnInit, Input } from '@angular/core';

type bsColor = 'primary' | 'info'| 'warning' | 'danger' | 'success' | 'brand';

@Component({
    selector: 'ot-simple-widget',
    templateUrl: './simple-widget.component.html',
    styleUrls: ['./simple-widget.component.css']
})
export class SimpleWidgetComponent implements OnInit {

    @Input() color: bsColor = 'primary';
    @Input() padding = 3;
    @Input() icon = 'cogs';
    @Input() iconPadding = 3;
    @Input() text = 'Empty';
    @Input() caption = 'Empty';
    @Input() largeIcon = false;

    constructor() { }

    ngOnInit() {
    }

    getCardClasses() {
        const cardClasses = {};
        cardClasses['p-' + this.padding] = true;
        return cardClasses;
    }

    getTextClasses() {
        const textClasses = {};
        textClasses['text-' + this.color] = true;
        return textClasses;
    }

    getIconClasses() {
        // fa fa-cogs bg-primary p-3
        const iconClasses = {};
        iconClasses[this.icon] = true;
        iconClasses['kt-font-' + this.color] = true;
        iconClasses['p-' + this.iconPadding] = true;
        if (this.largeIcon) {
            iconClasses['px-5'] = true;
        }
        return iconClasses;
    }

}
