// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { WorkingHours } from '@store/model/working-hours.model';

/*Section="ClassHeader"*/
@Injectable()
export class WorkingHoursService extends CRUDLService<WorkingHours> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'WorkingHours');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    loadWorkingHoursFile(formData) {
        return this.httpClient.post(this.baseRoute + 'LoadWorkingHoursFile', formData, { responseType: 'text' });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
