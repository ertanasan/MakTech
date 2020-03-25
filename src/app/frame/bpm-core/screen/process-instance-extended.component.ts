import { Component, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ProcessInstanceService } from '@bpm-core/service/process-instance.service';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ProcessInstanceExtended } from '@bpm-core/model/process-instance-extended.model';
import { ActivityTypeService } from '@bpm-core/service/activity-type.service';
import { ProcessStatusService } from '@bpm-core/service/process-status.service';

@Component({
    selector: 'ot-process-instance-extended',
    templateUrl: './process-instance-extended.component.html',
    styleUrls: ['./process-instance-extended.component.css']
})

export class ProcessInstanceExtendedComponent extends MainScreenBase implements OnInit {
    dataItem: ProcessInstanceExtended = new ProcessInstanceExtended();

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        private dataService: ProcessInstanceService,
        public activityTypeService: ActivityTypeService,
        public processStatusService: ProcessStatusService) {
        super(messageService, translateService);
    }

    ngOnInit() {
        if (!this.activityTypeService.completeList) {
            this.activityTypeService.listAll();
        }
        if (!this.processStatusService.completeList) {
            this.processStatusService.listAll();
        }
        super.ngOnInit();
    }

    getBreadcrumbItems(): MenuItem[] {
        return [];
    }

    refreshData(id?: number) {
        if (id && id !== 0) {
            this.dataService.read(id, 'ReadExtended').subscribe(res => {
                this.dataItem = res;
                console.log(this.dataItem);
            });
        }
    }

    createEmptyItem() { }

}
