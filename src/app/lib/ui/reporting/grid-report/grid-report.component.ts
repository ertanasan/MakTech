import { ReportPanelComponent } from './../report-panel/report-panel.component';
import { Component, OnInit, Input, OnDestroy } from '@angular/core';

import { Panel } from '@reporting/model/panel.model';
import { PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { GenericReportService } from '@reporting/service/generic-report.service';
import { Subscription } from 'rxjs';
import { OTUtilityService } from '@otcommon/service/utility.service';


@Component({
    selector: 'ot-grid-report',
    templateUrl: './grid-report.component.html',
    styleUrls: ['./grid-report.component.css']
})
export class GridReportComponent implements OnInit, OnDestroy {
    dataLoadedSubscription: Subscription;
    dataList: { data: any[], total: number } = { data: [], total: 0 };
    @Input() panel: Panel;
    @Input() reportService: GenericReportService;
    @Input() container: ReportPanelComponent;
    initialColumns: any[] = [];
    dateList: string[] = [];

    constructor(
        private util: OTUtilityService
    ) { }

    ngOnInit() {
        this.dataLoadedSubscription = this.reportService.dataLoaded.subscribe(
            dataResult => {
                this.dataList.data = this.processData(dataResult.data);
                this.dataList.total = dataResult.total;
            }
        );
        Object.assign(this.initialColumns, this.panel.Columns);
    }

    ngOnDestroy() {
        if (this.dataLoadedSubscription) {
            this.dataLoadedSubscription.unsubscribe();
        }
    }

    refreshList() {
        this.container.refreshList();
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.container.listParams.dateFields = this.dateList;
        this.container.listParams.skip = state.skip;
        this.container.listParams.take = state.take;
        if (state.sort) {
            this.container.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.container.listParams.filter = state.filter;
        }
        if (state.group) {
            this.container.listParams.group = state.group;
        }
        this.refreshList();
    }

    getColumns() {
        if (this.panel && this.panel.Columns) {
            this.panel.Columns.forEach(column => {
                column.additionalParameters = JSON.parse(column.AdditionalParameters || '{}');
            });
            return this.panel.Columns;
        } else {
            return [];
        }
    }

    processData(dataList: any[]): any[] {

        if (this.panel && this.panel.Columns) {
            this.dateList = [];
            this.panel.Columns.forEach(column => {
                column.additionalParameters = JSON.parse(column.AdditionalParameters || '{}');
                if (column.additionalParameters.isDate) {
                    this.dateList.push(column.FieldName);
                }
            });
        }
        if (this.panel && this.panel.Filters) {
            this.panel.Filters.forEach(element => {
                if (!element.additionalParameters) {
                    element.additionalParameters = JSON.parse(element.AdditionalParameters || '{}');
                }
            });
            if (this.initialColumns !== undefined) {
                Object.assign(this.panel.Columns, this.initialColumns);
            }
            this.panel.Filters.filter(f => f.TypeObject.IsParameter && f.additionalParameters.visible && f.filterValue).map(f => {
                f.additionalParameters.visible.forEach(v => {
                    this.panel.Columns = this.panel.Columns.filter((column) => {
                        if (eval(`${f.filterValue}${v['condition']}`) && v['columns'].includes(column.FieldName)) {
                            return false;
                        } else {
                             return true;
                            }
                    });

                });
            });
        }
        return dataList;
    }

}
