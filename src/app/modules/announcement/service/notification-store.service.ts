// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { NotificationStore } from '@announcement/model/notification-store.model';

/*Section="ClassHeader"*/
@Injectable()
export class NotificationStoreService extends CRUDLService<NotificationStore> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Announcement', 'NotificationStore');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    getNotificationStore(notificationId: number, storeId: number) {
        let params = new HttpParams().set('notificationId', notificationId.toString());
        params = params.set('storeId', storeId.toString());
        return this.httpClient.get<NotificationStore>(this.baseRoute + 'GetNotificationStore', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
