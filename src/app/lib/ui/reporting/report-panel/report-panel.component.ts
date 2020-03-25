import { Component, OnInit, Input, ViewChild, TemplateRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import * as moment from 'moment';
import { saveAs } from 'file-saver';

import { ListParams } from '@otmodel/list-params.model';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { Panel } from '@reporting/model/panel.model';
import { PanelService } from '@reporting/service/panel.service';
import { GenericReportService } from '@reporting/service/generic-report.service';
import { ReportPanel } from '@reporting/model/report-panel.model';
import { Filter } from '@reporting/model/filter.model';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';

@Component({
    selector: 'ot-report-panel',
    templateUrl: './report-panel.component.html',
    styleUrls: ['./report-panel.component.css']
})
export class ReportPanelComponent implements OnInit {
    panel: Panel;

    @Input() reportPanel: ReportPanel;
    @Input() reportName: string;
    @Input() panelName: string;
    @Input() panelId: number;

    @ViewChild('gridReport', {static: false}) gridReport: TemplateRef<any>;
    @ViewChild('chartReport', {static: false}) chartReport: TemplateRef<any>;
    panelContent: TemplateRef<any>;
    showFrame = true;
    additionalParameters: any;
    listParams = new ListParams();
    filterCollapsed = false;

    contextState$: Observable<OTContext>;

    constructor(
        private panelService: PanelService,
        private messageService: GrowlMessageService,
        private translateService: TranslateService,
        public genericReportService: GenericReportService
    ) { }

    panelOnInit() {
        if (this.panelId) {
            this.readPanelDetails();
        } else {
            this.panelService.find(this.reportName, this.panelName).subscribe(
                reportPanel => {
                    this.reportPanel = reportPanel;
                    this.panelId = reportPanel.Panel;
                    this.readPanelDetails();
                },
                error => {
                    console.log(error.message);
                    this.messageService.error(`${this.translateService.instant('An error occurred')}`);
                }
            );
        }
    }

    ngOnInit() {
        this.panelOnInit();
    }

    readPanelDetails() {
        this.panelService.readDetails(this.panelId).subscribe(
            panel => {
                this.panel = panel;
                this.additionalParameters = panel.additionalParameters = JSON.parse(panel.AdditionalParameters || '{}');
                this.showFrame = this.additionalParameters.ShowFrame;

                this.processFilterDefaults(panel.Filters);

                this.reloadData();

                this.panelContent = this.gridReport;
            },
            error => {
                console.error(error);
                this.messageService.error(`${this.translateService.instant('An error occurred')}`);
            }
        );
    }

    reloadData() {
        this.listParams.skip = 0;
        this.refreshList();
    }

    refreshList() {
        const filterValues = this.panel.Filters.filter(f => f.TypeObject.IsParameter).map(f => ({FilterName: f.ParameterName , Value: f.filterValue}));
        this.genericReportService.getGridData(this.listParams, this.panel.PanelId, filterValues);
    }

    handleRawPageChange(event: PageChangeEvent) {
        this.listParams.skip = event.skip;
        this.refreshList();
    }

    handleRawDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = 0;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    handleRawSortChange(sort: SortDescriptor[]) {
        if (sort) {
            this.listParams.sort = sort;
        }
        this.refreshList();
    }

    exportReportData() {
        const filterValues = this.panel.Filters.filter(f => f.TypeObject.IsParameter).map(f => ({FilterName: f.ParameterName , Value: f.filterValue}));
        this.genericReportService.exportReportData(this.panel.PanelId, filterValues).subscribe(
            blob => {
                saveAs(blob, this.panel.Name + '.xlsx');
                this.messageService.success(this.translateService.instant('Report export completed.'));
            },
            error => {
                this.messageService.error(`${this.translateService.instant('Report export failed')}`);
                console.log('ReportPanelComponent:exportReportData', error);
            }
        );
    }

    processFilterDefaults(filters: any[]) {
        filters.map(f => <Filter>f).forEach(filter => {
            filter.additionalParameters = JSON.parse(filter.AdditionalParameters || '{}');
            switch (filter.TypeObject.Name) {
                case 'Date':
                case 'DateTime':
                    filter.filterValue = new Date();
                    if (filter.additionalParameters.DefaultValue) {
                        if (filter.additionalParameters.DefaultValue.Scale) {
                            filter.filterValue = moment(filter.filterValue)
                                .add(filter.additionalParameters.DefaultValue.Offset, filter.additionalParameters.DefaultValue.Scale.toLowerCase() + 's');
                            if (filter.additionalParameters.DefaultValue.RangePosition === 'End') {
                                moment(filter.filterValue).endOf(filter.additionalParameters.DefaultValue.Scale.toLowerCase());
                            } else {
                                moment(filter.filterValue).startOf(filter.additionalParameters.DefaultValue.Scale.toLowerCase());
                            }
                        }
                    }
                    break;
                case 'Text':
                default:
                    filter.filterValue = filter.additionalParameters.DefaultValue;
            }
        });
    }
}
