import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { GridModule } from '@progress/kendo-angular-grid';
import { ReportingComponent } from '@reporting/reporting.component';

import { ColumnService } from '@reporting/service/column.service';
import { FilterService } from '@reporting/service/filter.service';
import { FilterTypeService } from '@reporting/service/filter-type.service';
import { PanelService } from '@reporting/service/panel.service';
import { PanelTypeService } from '@reporting/service/panel-type.service';
import { ReportService } from '@reporting/service/report.service';
import { GenericReportService } from '@reporting/service/generic-report.service';
import { OTCommonModule } from '@otcommon/common.module';

const routes: Routes = [
    {
        'path': '',
        'component': ReportingComponent,
        'children': [
            // {
            //     'path': 'Column/Index',
            //     'component': ColumnListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'Filter/Index',
            //     'component': FilterListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'FilterType/Index',
            //     'component': FilterTypeListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'Panel/Index',
            //     'component': PanelListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'PanelType/Index',
            //     'component': PanelTypeListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'Report/Index',
            //     'component': ReportListComponent,
            //     'pathMatch': 'full'
            // },
            // {
            //     'path': 'ReportPanel/Index',
            //     'component': ReportPanelListComponent,
            //     'pathMatch': 'full'
            // },
        ]
    },
];

@NgModule({
    declarations: [
        ReportingComponent,
        // ColumnEditComponent,
        // ColumnListComponent,
        // FilterEditComponent,
        // FilterListComponent,
        // FilterTypeEditComponent,
        // FilterTypeListComponent,
        // PanelEditComponent,
        // PanelListComponent,
        // PanelTypeEditComponent,
        // PanelTypeListComponent,
        // ReportEditComponent,
        // ReportListComponent,
        // ReportPanelEditComponent,
        // ReportPanelListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        GridModule,
        OTCommonModule
    ],
    exports: [
        RouterModule
    ],
    providers: [
        ColumnService,
        FilterService,
        FilterTypeService,
        PanelService,
        PanelTypeService,
        ReportService,
        GenericReportService
    ]
})
export class ReportingModule {}
