// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { NotificationGroupUser } from '@announcement/model/notification-group-user.model';

/*Section="ClassHeader"*/
@Injectable()
export class NotificationGroupUserService extends CRUDLService<NotificationGroupUser> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Announcement', 'NotificationGroupUser');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listAllGroupUsers() {
        this.httpClient.get<NotificationGroupUser[]>(this.baseRoute + 'ListAllGroupUsers', { observe: 'body', responseType: 'json' }).subscribe(
            result => this.completeList = result
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
