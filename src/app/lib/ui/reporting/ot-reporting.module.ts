import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MomentModule } from 'angular2-moment';

import { OTControlModule } from './../control/ot-control-module';
import { OTContainerModule } from '@otuicontainer/ot-container.module';

import { PanelService } from '@reporting/service/panel.service';
import { ReportPanelComponent } from './report-panel/report-panel.component';
import { ReportFilterComponent } from './report-filter/report-filter.component';
import { GridReportComponent } from './grid-report/grid-report.component';
import { GenericReportService } from '@reporting/service/generic-report.service';
import { ReportScreenComponent } from './report-screen/report-screen.component';
import { OTCoreModule } from '@otcore/core.module';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';

@NgModule({
    declarations: [
        ReportPanelComponent,
        ReportFilterComponent,
        GridReportComponent,
        ReportScreenComponent,
    ],
    imports: [
        CommonModule,
        OTCoreModule,
        OTContainerModule,
        OTControlModule,
        GridModule,
        InputsModule,
        NgbModule,
        MomentModule,
        PartialsModule
    ],
    exports: [
        ReportPanelComponent,
    ],
    providers: [
        PanelService,
        GenericReportService,
    ]
})
export class OTReportingModule {
}
