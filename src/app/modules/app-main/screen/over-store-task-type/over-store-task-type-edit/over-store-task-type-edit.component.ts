import {Component, OnInit, ViewChild} from '@angular/core';
import {EditScreenContainerComponent} from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import {NotificationType} from '@announcement/model/notification-type.model';
import {GrowlMessageService} from '@otservice/growl-message.service';
import {TranslateService} from '@ngx-translate/core';
import {OTUtilityService} from '@otcommon/service/utility.service';
import {NotificationTypeService} from '@announcement/service/notification-type.service';
import {FormControl} from '@angular/forms';
import {OverStoreTaskType} from '@app-main/model/over-store-task-type.model';
import {CRUDDialogScreenBase} from '@otscreen-base/crud-dialog-screen-base';
import {OverStoreTaskTypeService} from '@app-main/service/over-store-task-type.service';

@Component({
  selector: 'ot-over-store-task-type-edit',
  templateUrl: './over-store-task-type-edit.component.html',
  styleUrls: ['./over-store-task-type-edit.component.scss']
})
export class OverStoreTaskTypeEditComponent extends CRUDDialogScreenBase<OverStoreTaskType> implements OnInit {

  @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<OverStoreTaskType>;

  constructor(
      messageService: GrowlMessageService,
      translateService: TranslateService,
      public utilityService: OTUtilityService,
      dataService: OverStoreTaskTypeService,
  ) {
    super(messageService, translateService, dataService, 'OverStoreTaskType');
    this.hasAutomaticIdentity = false;
  }

  createForm() {
    this.container.mainForm = this.container.formBuilder.group({
      OverStoreTaskTypeId: new FormControl(),
      TaskType: new FormControl(),
    });
  }

  ngOnInit() {
    super.ngOnInit();
  }

}
