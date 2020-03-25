import { PanelService } from '@reporting/service/panel.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription, Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { GrowlMessageService } from '@otservice/growl-message.service';
import { GenericReportService } from '@reporting/service/generic-report.service';
import { Report } from '@reporting/model/report.model';
import { ReportPanel } from '@reporting/model/report-panel.model';

@Component({
    selector: 'ot-report-screen',
    templateUrl: './report-screen.component.html',
    styleUrls: ['./report-screen.component.css']
})
export class ReportScreenComponent implements OnInit, OnDestroy {
    reportName: string;
    report: Report;
    routerSubscription: Subscription;
    reportPanels: ReportPanel[];

    constructor(
        private route: ActivatedRoute,
        private messageService: GrowlMessageService,
        private translateService: TranslateService,
        public genericReportService: GenericReportService,
        public panelService: PanelService
    ) { }

    ngOnInit() {
        this.routerSubscription = this.route.params.subscribe(
            params => {
                const reportDescriptor = params['reportDescriptor'];
                this.reportName = reportDescriptor.split('_')[1];

                // Find the result with this name
                this.genericReportService.findReport(this.reportName).subscribe(
                    report => {
                        this.report = report;
                    }
                );
            }
        );
    }

    ngOnDestroy() {
        if (this.routerSubscription) {
            this.routerSubscription.unsubscribe();
        }
    }

}
