// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { NotificationUser } from '@announcement/model/notification-user.model';
import { UserService } from '@frame/security/service/user.service';
import { StoreService } from '@store/service/store.service';
import { User } from '@frame/security/model/user.model';
import { finalize } from 'rxjs/operators';
import { Store } from '@store/model/store.model';

/*Section="ClassHeader", IsCustomized=true*/
@Injectable()
export class NotificationUserService extends CRUDLService<NotificationUser> {
    activeStores: Store[];
    activeUsers: User[];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public userService: UserService,
        public storeService: StoreService
    ) {
        super(httpClient, messageService, translateService, 'Announcement', 'NotificationUser');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    getNotificationUser(notificationId: number, userId: number) {
        let params = new HttpParams().set('notificationId', notificationId.toString());
        params = params.set('userId', userId.toString());
        return this.httpClient.get<NotificationUser>(this.baseRoute + 'GetNotificationUser', { observe: 'body', responseType: 'json', params: params });
    }

    listActiveUsers() {
        this.userService.loading = true;
        this.userService.listAllAsync()
        .pipe(finalize(() => this.userService.loading = false))
        .subscribe(list => this.activeUsers = list.filter(u => !u.Deleted && u.Active && (u.Description === null || !u.Description.includes('#GenericUser'))));
    }

    listActiveStores() {
        this.storeService.loading = true;
        this.storeService.listAllAsync()
        .pipe(finalize(() => this.storeService.loading = false))
        .subscribe(list => this.activeStores = list.filter(s => !s.Deleted && s.ActiveFlag));
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
