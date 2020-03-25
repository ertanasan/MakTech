import { Component, OnInit, ViewChild, OnDestroy, Input } from '@angular/core';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { InboxService } from '@frame/bpm-core/service/inbox.service';
import { Router } from '@angular/router';
import { Subscription, Subject } from 'rxjs';

@Component({
  selector: 'ot-taskalert',
  templateUrl: './taskalert.component.html',
  styleUrls: ['./taskalert.component.css']
})
export class TaskalertComponent extends MainScreenBase implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  onShow: Subject<any> = new Subject();
  showSubscription: Subscription;
  isTaskAlertDialogOpen = false;

  newTasksText = '';
  waitingTasksText = '';
  unreadNotificationsText = '';
  dialogTitle = '';

  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    public inboxService: InboxService,
    public router: Router,
  ) {
        super(messageService, translateService);
        // this.dialogTitle = translateService.instant('Task Notification');
        this.dialogTitle = 'Görev Bildirimi';   // TRANSLATION PROBLEM COULD NOT BE FIXED
  }

  getBreadcrumbItems(): MenuItem[] {
    return null;
  }

  createEmptyItem() {
    return null;
    // throw new Error('Method not suported.');
  }

  refreshData() {
  }

  ngOnInit() {
    this.showSubscription = this.onShow.subscribe( a => {
      this.isTaskAlertDialogOpen = true;

      /*   // TRANSLATION PROBLEM COULD NOT BE FIXED
      this.newTasksText = a.numberOfNewTasks > 0 ? this.translateService.instant(`You have ${a.numberOfNewTasks} new task(s)`) : '';
      this.waitingTasksText =  a.numberOfTasks > 0 ? this.translateService.instant(`There are ${a.numberOfTasks} tasks waiting`) : '';
      this.unreadNotificationsText = a.numberOfUnreadNotifications > 0 ? this.translateService.instant(`${a.numberOfUnreadNotifications} notifications must be read`) : '';   */
      this.newTasksText = a.numberOfNewTasks > 0 ? `Tarafınıza ${a.numberOfNewTasks} Adet Yeni Görev Atanmıştır.` : '';
      this.waitingTasksText =  a.numberOfTasks > 0 ? `Bekleyen ${a.numberOfTasks} Adet Göreviniz Bulunmaktadır.` : '';
      this.unreadNotificationsText = a.numberOfUnreadNotifications > 0 ? `Sizin İçin Yayımlanmış ${a.numberOfUnreadNotifications} Adet Duyurunun Okunması Gerekmektedir.` : '';
    });
  }

  onStayLastPage() {
    this.isTaskAlertDialogOpen = false;
    this.dialog.hide();
  }

  onGoToTasks() {
    this.router.navigateByUrl('/OverStoreMain/Inbox/Index');
    this.isTaskAlertDialogOpen = false;
    this.dialog.hide();
  }

  onAlertClose(event) {
    this.isTaskAlertDialogOpen = false;
    this.dialog.hide();
  }

}
