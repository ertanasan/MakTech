import { Component, OnInit, Input, AfterViewInit, ChangeDetectionStrategy } from '@angular/core';
import { BaseScreenContainerComponent } from '../base-screen-container/base-screen-container.component';

import { MenuItem } from '@otuicontrol/menu/menuitem';

@Component({
    selector: 'ot-list-screen-container',
    templateUrl: './list-screen-container.component.html',
    styleUrls: ['./list-screen-container.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListScreenContainerComponent extends BaseScreenContainerComponent implements OnInit, AfterViewInit  {
    @Input() showAsDetail = false;
    @Input() header: string;
    @Input() breadcrumbItems: MenuItem[];
    @Input() hasCustomHeader = false;

    constructor() {
        super();
    }

    ngOnInit() {
    }

    ngAfterViewInit() {
    }

}
