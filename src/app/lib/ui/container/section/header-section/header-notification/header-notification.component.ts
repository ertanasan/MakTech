import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { InboxService } from '@bpm-core/service/inbox.service';
import { Subscription, timer } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: '.ot-header-notification',
  templateUrl: './header-notification.component.html',
  styleUrls: ['./header-notification.component.css']
})
export class HeaderNotificationComponent implements OnInit, OnDestroy {

  @Input() InboxUrl: string;
  @Input() WorkqueueUrl: string;
  @Input() mainModule: string;
  numberOfTasks = 0;
  inboxSubscription: Subscription;
  refreshSubscription: Subscription;
  constructor(public inboxService: InboxService) { }

  ngOnInit() {
    this.inboxSubscription = timer(0, 60000).pipe(
       switchMap(() => this.inboxService.listInboxSummary())
    ).subscribe(result => this.numberOfTasks = result.Count);

    this.refreshSubscription = this.inboxService.activeListChanged.subscribe( result => {
          this.numberOfTasks = result.total;
        }
    );
  }

  ngOnDestroy() {
    if (this.inboxSubscription) {
      this.inboxSubscription.unsubscribe();
    }

    if (this.refreshSubscription) {
      this.refreshSubscription.unsubscribe();
    }
  }

}
