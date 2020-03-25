// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Notification } from '@announcement/model/notification.model';
import { ListParams } from '@otmodel/list-params.model';

/*Section="ClassHeader"*/
@Injectable()
export class NotificationService extends CRUDLService<Notification> {
    userNotifications: Notification[] = [];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Announcement', 'Notification');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    publishNotification(notification: Notification) {
        return this.httpClient.put(this.baseRoute + 'PublishNotification', notification);
    }

    getUserNotifications(listParams: ListParams, isSystemNotificationsIncluded: boolean) {
        let params = this.prepareListParams(listParams);
        params = params.append('isSystemNotificationsIncluded', isSystemNotificationsIncluded ? 'Y' : 'N');
        this.httpClient.get<Notification[]>(this.baseRoute + 'GetUserNotifications', { observe: 'body', responseType: 'json', params: params }).subscribe(
            result => this.userNotifications = result
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
