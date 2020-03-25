import { Component, OnInit, ViewChild } from '@angular/core';
import { Gathering } from '@warehouse/model/gathering.model';
import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { GatheringService } from '@warehouse/service/gathering.service';
import { GatheringDetailService } from '@warehouse/service/gathering-detail.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { GatheringStatusService } from '@warehouse/service/gathering-status.service';
import { UserService } from '@frame/security/service/user.service';
import { GatheringTypeService } from '@warehouse/service/gathering-type.service';
import { DatePipe } from '@angular/common';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'ot-gathering-admin-edit',
  templateUrl: './gathering-admin-edit.component.html',
  styleUrls: ['./gathering-admin-edit.component.css']
})
export class GatheringAdminEditComponent extends CRUDDialogScreenBase<Gathering> implements OnInit {
  @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Gathering>;

  constructor(messageService: GrowlMessageService,
    translateService: TranslateService,
    gatheringService: GatheringService,
    public gatheringDetailService: GatheringDetailService,
    public utilityService: OverstoreCommonMethods,
    public gatheringStatusService: GatheringStatusService,
    public gatheringTypeService: GatheringTypeService,
    public userService: UserService,
    public datePipe: DatePipe) {
      super(messageService, translateService, gatheringService, 'Gathering');
  }

  createForm() {
    this.container.mainForm = this.container.formBuilder.group({
      GatheringId: new FormControl(),
      Event: new FormControl(),
      Organization: new FormControl(),
      Deleted: new FormControl(),
      CreateDate: new FormControl(),
      UpdateDate: new FormControl(),
      CreateUser: new FormControl(),
      UpdateUser: new FormControl(),
      CreateChannel: new FormControl(),
      CreateBranch: new FormControl(),
      CreateScreen: new FormControl(),
      StoreOrder: new FormControl(),
      GatheringUser: new FormControl(),
      ControllerUser: new FormControl(),
      GatheringStartTime: new FormControl(),
      GatheringEndTime: new FormControl(),
      ControlStartTime: new FormControl(),
      ControlEndTime: new FormControl(),
      GatheringStatus: new FormControl(),
      GatheringType: new FormControl(),
      StoreName: new FormControl(),
      Priority: new FormControl()
    });
  }

  ngOnInit() {
    super.ngOnInit();
  }

}
