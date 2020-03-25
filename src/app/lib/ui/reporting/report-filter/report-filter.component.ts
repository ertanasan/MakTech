import { GenericReportService } from '@reporting/service/generic-report.service';
import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

import { Filter } from '@reporting/model/filter.model';

@Component({
    selector: 'ot-report-filter',
    templateUrl: './report-filter.component.html',
    styleUrls: ['./report-filter.component.css']
})
export class ReportFilterComponent implements OnInit {

    @Input() filter: Filter;

    items = [];

    constructor(
        public genericReportService: GenericReportService
    ) { }

    ngOnInit() {
        if (!this.filter.additionalParameters) {
            this.filter.additionalParameters = JSON.parse(this.filter.AdditionalParameters || '{}');
        }
        this.refreshItems();

    }

    refreshItems() {
        switch (this.filter.TypeObject.Name) {
            case 'Static List':
                this.items = this.filter.additionalParameters.Items;
                this.filter.additionalParameters.defaultItem = JSON.parse(this.filter.DefaultValue);
                break;
            case 'Dynamic List':
                this.genericReportService.getFilterData(this.filter.FilterId, []).subscribe(
                    filterData => {
                        this.items = filterData;
                    }
                );
                break;
        }
    }
}
