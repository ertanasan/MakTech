import { CRUDLService } from '@otservice/crudl.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { Injectable } from '@angular/core';
import { OverStoreInboxItem } from '@warehouse/model/overstore-inbox-item.model';
import { Observable, empty } from 'rxjs';
import { InboxSummary } from '@frame/bpm-core/model/inboxsummary.model';

@Injectable({
    providedIn: 'root'
})
export class OverStoreInboxService extends CRUDLService<OverStoreInboxItem> {
    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'OverStoreInbox');
        // super(httpClient, messageService, translateService, 'BPMCore', 'Inbox');
    }

    listInboxSummary(): Observable<InboxSummary> {
        return this.httpClient.get<InboxSummary>(this.baseRoute + 'ListInboxSummary', { observe: 'body', responseType: 'json'});
    }

    /*
    listCompleted(listParams: ListParams, action = 'ListCompleted') {
        if (this.loading) {
            return;
        }
        const listSubscription = this.listAsync(listParams, action);

        this.loading = true;
        listSubscription.subscribe(
            result => {
                this.activeList.data = result.Data;
                this.activeList.total = result.Total;
                this.activeListChanged.next(this.activeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
    }*/
}
