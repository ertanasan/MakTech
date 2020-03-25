import { Component, OnInit, Input, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TaskalertComponent } from '@app-main/screen/taskalert/taskalert.component';
import { OverStoreInboxService } from '@app-main/service/overstore-inbox.service';
import { NgbDropdown } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'ot-header-notification-overstore',
  templateUrl: './header-notification-overstore.component.html',
  styleUrls: ['./header-notification-overstore.component.scss']
})
export class HeaderNotificationOverstoreComponent implements OnInit, OnDestroy {
  @ViewChild(TaskalertComponent, {static: true}) taskalertScreen: TaskalertComponent;

  @Input() mainModule: string;
// Show dot on top of the icon
@Input() dot: string;

// Show pulse on icon
@Input() pulse: boolean;

@Input() pulseLight: boolean;

// Set icon class name
@Input() icon = 'flaticon2-bell-alarm-symbol';
@Input() iconType: '' | 'success';

// Set true to icon as SVG or false as icon class
@Input() useSVG: boolean;

// Set bg image path
@Input() bgImage: string;

// Set skin color, default to light
@Input() skin: 'light' | 'dark' = 'light';

@Input() type: 'brand' | 'success' = 'success';

  numberOfTasks = 0;
  numberOfNewTasks = 0;
  numberOfUnreadNotifications = 0;
  mostRecentActionTime: number = new Date().getTime();
  isProgramOpenedFirstTime = true;

  inboxSubscription: Subscription;
  refreshSubscription: Subscription;
  @ViewChild(NgbDropdown, { static: true }) dropdown: NgbDropdown;
  private unsubscribe: Subscription[] = [];
  constructor(
    public inboxService: OverStoreInboxService,
    protected messageService: GrowlMessageService,
    protected translateService: TranslateService,
    private router: Router
  ) {
    this.unsubscribe.push(
			router.events.subscribe(e => {
				this.dropdown.close();
			})
		);
  }

  ngOnInit() {
    this.unsubscribe.push(timer(0, 60000).pipe(
       switchMap(() => this.inboxService.listInboxSummary())
    ).subscribe(result => {
      if (result.Count) {
        this.numberOfTasks = result.Count;
        this.numberOfUnreadNotifications = result.InboxItemList.filter( i => i.ProcessDefinitionName === 'SubeDuyuruSureci').length;

        if (this.isProgramOpenedFirstTime) {
          this.isProgramOpenedFirstTime = false;
          this.mostRecentActionTime = result.InboxItemList.map(i => new Date(i.ActionStartDate).getTime()).reduce((a, b) => Math.max(a, b));
          if (!this.taskalertScreen.isTaskAlertDialogOpen) {
            this.showTaskAlert();
          }
        } else {
          this.numberOfNewTasks = result.InboxItemList.filter( i => new Date(i.ActionStartDate).getTime() > this.mostRecentActionTime).length;
          if (this.numberOfNewTasks > 0) {
            this.mostRecentActionTime = result.InboxItemList.map(i => new Date(i.ActionStartDate).getTime()).reduce((a, b) => Math.max(a, b));
            if (this.taskalertScreen.isTaskAlertDialogOpen) {
              this.taskalertScreen.dialog.hide();
            }
            this.showTaskAlert();
          }
        }
      }
    }));

    this.unsubscribe.push(this.inboxService.activeListChanged.subscribe( result => this.numberOfTasks = result.total));
  }

  ngOnDestroy() {
    this.unsubscribe.forEach(sb => sb.unsubscribe());
  }

  showTaskAlert() {
    this.taskalertScreen.onShow.next({'numberOfNewTasks': this.numberOfNewTasks,
                                      'numberOfTasks': this.numberOfTasks - this.numberOfUnreadNotifications,
                                      'numberOfUnreadNotifications': this.numberOfUnreadNotifications });
    this.taskalertScreen.dialog.show();
  }

  backGroundStyle(): string {
		if (!this.bgImage) {
			return 'none';
		}

		return 'url(' + this.bgImage + ')';
	}

}
