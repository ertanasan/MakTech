import { Component, Input, OnInit } from '@angular/core';

type bsColor = 'primary' | 'info'| 'warning' | 'danger' | 'success' | 'brand';

@Component({
	selector: 'kt-widget24',
	templateUrl: './widget24.component.html',
	styleUrls: ['./widget24.component.scss']
})
export class Widget24Component implements OnInit {

	@Input() value: string | number;
    @Input() caption: string;
    @Input() icon: string;
    @Input() color: bsColor;

	constructor() {
	}

	ngOnInit() {
	}

}
