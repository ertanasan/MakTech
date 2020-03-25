import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { OTUtilityService } from '@otcommon/service/utility.service';

type bsColor = 'primary' | 'info'| 'warning' | 'danger';

@Component({
    selector: 'ot-radial-gauge-widget',
    templateUrl: './radial-gauge-widget.component.html',
    styleUrls: ['./radial-gauge-widget.component.css']
})
export class RadialGaugeWidgetComponent implements OnInit {
    // CONTAINER PROPERTIES
    @Input() title: string;
    @Input() description: string;
    @Input() color: bsColor = 'primary';
    @Input() inverted = false;
    @Input() gaugeArea: any;
    @Input() titleClasses: string[] = ['text-center', 'h-10'];
    @Input() progressClasses: string[] = ['h-20'];
    @Input() descriptionClasses: string[] = ['font-weight-light', 'small', 'text-center', 'h-70'];

    // POINTER PROPERTIES
    @Input() pointers:  { 'value': number, 'length': number, 'color': string }[];

    // SCALE PROPERTIES
    @Input() scaleMin = 0;
    @Input() scaleMax = 100;
    @Input() scaleBands: { 'from': number, 'to': number, 'color': string }[];
    @Input() minorUnit = 5;
    @Input() majorUnit = 20;

    // SCALE LABEL PROPERTIES
    @Input() labelFormat = 'n';  // c: currency ,  p:percentage,  n:numeric...  second char is for decimal (ie.'p2')
    @Input() showLabels = true;
    @Input() showMajorTicks = true;
    @Input() showMinorTicks = true;
    @Input() labelsColor: string;
    @Input() majorTicksColor: string;
    @Input() minorTicksColor: string;

    // SHAPE PROPERTIES
    @Input() reverse = false;
    @Input() startAngle: number;
    @Input() endAngle: number;
    @Input() rangeSize: number;
    // @Input() rangeLineCap = 'round';    // butt, round, square
    @Input() rangePlaceholderColor: string;

    @Output() onGaugeClick: EventEmitter<any> = new EventEmitter();

    constructor(
        utilityService: OTUtilityService,
    ) {
        this.scaleBands = [ { 'from': 0,    'to': 40,   'color': utilityService.getColor('danger') },
                            { 'from': 40,   'to': 80,   'color': '' },
                            { 'from': 80,   'to': 100,  'color': utilityService.getColor('success')  } ];

        this.pointers = [];
    }

    ngOnInit() {
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
        const cssClasses = {};
        this.progressClasses.forEach( c =>
            cssClasses[c] = true
        );
        return cssClasses;
    }

    getTitleClasses() {
        const cssClasses = {};
        this.titleClasses.forEach( c =>
            cssClasses[c] = true
        );
        return cssClasses;
    }

    getDescriptionClasses() {
        const cssClasses = {};
        this.descriptionClasses.forEach( c =>
            cssClasses[c] = true
        );
        return cssClasses;
    }
}
