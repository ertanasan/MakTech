// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ProcessStatus } from '@bpm-core/model/process-status.model';


/*Section="ClassHeader"*/
@Injectable()
export class ProcessStatusService extends CRUDLService<ProcessStatus> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'BPMCore', 'ProcessStatus');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    public activityStatusList = [{ Name: 'Initial',   StatusId: 0 },
                                 { Name: 'Pending', StatusId: 1 },
                                 { Name: 'Active', StatusId: 2 },
                                 { Name: 'Idle', StatusId: 3 },
                                 { Name: 'Completed', StatusId: 4 },
                                 { Name: 'Canceled', StatusId: 5 },
                                 { Name: 'Failed', StatusId: 6 },
                                 { Name: 'Notified', StatusId: 7 },
                                 { Name: 'ReRun', StatusId: 8 },
                                 { Name: 'Suspended', StatusId: 9 },
                                 { Name: 'CancelRequested', StatusId: 10 },
                                 { Name: 'WorkSynchronously', StatusId: 11},
                                 { Name: 'ContinueSyncronously', StatusId: 12 },
                                 { Name: 'EventInitial', StatusId: 13 },
                                 { Name: 'EventActive', StatusId: 14 },
                                 { Name: 'EventFailed', StatusId: 15 }];

    //#endregion Customized

    /*Section="ClassFooter"*/
}
