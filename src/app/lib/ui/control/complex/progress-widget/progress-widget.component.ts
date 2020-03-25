import { Component, OnInit, Input } from '@angular/core';

type bsColor = 'primary' | 'info'| 'warning' | 'danger' | 'brand' | 'dark' | 'light';

@Component({
    selector: 'ot-progress-widget',
    templateUrl: './progress-widget.component.html',
    styleUrls: ['./progress-widget.component.css']
})
export class ProgressWidgetComponent implements OnInit {
    @Input() title: string;
    @Input() titleAlternative: string;
    @Input() description: string;
    @Input() progressCaption: string;
    @Input() progressPercent = '0';
    @Input() color: bsColor = 'primary';
    @Input() inverted = false;
    @Input() progressMin = 0;
    @Input() progressMax = 100;
    @Input() progressValue: number;
    @Input() coloredTitle = false;
    @Input() coloredTitleAlternative = false;

    constructor() { }

    ngOnInit() {
    }

    hasAlternativeTitle() {
        return this.titleAlternative && this.titleAlternative != null && this.titleAlternative !== '';
    }

    getCardClasses() {
        if (this.inverted) {
            const cssClasses = {
                'text-white': true
            };
            cssClasses['bg-' + this.color] = true;
            return cssClasses;
        }
    }

    getProgressClasses() {
        let cssClasses;
        if (this.inverted) {
            cssClasses = {
                'progress-white': true
            };
        } else {
            cssClasses = {};
            cssClasses['bg-' + this.color] = true;
        }
        return cssClasses;
    }

    calculatePercent() {
        return (this.progressValue - this.progressMin) / (this.progressMax - this.progressMin) * 100;
    }
}
