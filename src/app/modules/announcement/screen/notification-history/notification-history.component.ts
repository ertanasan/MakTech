import { Component, OnInit, ViewChild } from '@angular/core';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService } from '@announcement/service/notification.service';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { Notification } from '@announcement/model/notification.model';
import { NotificationTypeService } from '@announcement/service/notification-type.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

@Component({
  selector: 'ot-notification-history',
  templateUrl: './notification-history.component.html',
  styleUrls: ['./notification-history.component.css']
})
export class NotificationHistoryComponent extends ListScreenBase<Notification> implements OnInit {
  @ViewChild('notificationTextDialog', {static: true}) notificationTextDialog: CustomDialogComponent;
  selectedNotificationText = '';
  isSystemNotificationsIncluded = false;

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public notificationService: NotificationService
  ) {
    super(messageService, translateService);
  }

  refreshList() {
    this.notificationService.getUserNotifications(this.listParams, this.isSystemNotificationsIncluded);
  }

  getBreadcrumbItems(): MenuItem[] {
      return [{Caption: 'Announcement' }, {Caption: 'Notification', RouterLink: '/Announcement/NotificationHistory'}];
  }

  createEmptyModel() {
    return null;
}

  ngOnInit() {
    super.ngOnInit();
  }

  handleDataStateChange(state: DataStateChangeEvent) {
    this.listParams.dateFields = ['CreateDate'];
    super.handleDataStateChange(state);
  }

  showNotificationDialog(notificationText: string) {
    this.selectedNotificationText = notificationText;
    this.notificationTextDialog.show();
  }
}
