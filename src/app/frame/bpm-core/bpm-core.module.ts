import { NgModule } from '@angular/core';
import { ProcessInstanceExtendedComponent } from './screen/process-instance-extended.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProcessInstanceService } from './service/process-instance.service';
import { ActivityTypeService } from './service/activity-type.service';
import { ProcessStatusService } from './service/process-status.service';
import { OTCommonModule } from '@otcommon/common.module';
import { ProcessAreaService } from './service/process-area.service';
import { DelegateActionComponent } from './screen/delegate-action/delegate-action.component';
import { UserService } from '@frame/security/service/user.service';

@NgModule({
  declarations: [
      ProcessInstanceExtendedComponent,
      DelegateActionComponent
  ],
  imports: [
      CommonModule,
      ReactiveFormsModule,
      GridModule,
      OTCommonModule,
      FormsModule
  ],
  exports: [
    ProcessInstanceExtendedComponent,
    DelegateActionComponent
  ],
  providers: [
    ProcessInstanceService,
    ActivityTypeService,
    ProcessStatusService,
    UserService
  ]
})
export class BpmCoreModule {}
