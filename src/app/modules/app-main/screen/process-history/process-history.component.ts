import { Component, OnInit, ViewChild, Input } from '@angular/core';

import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { UserService } from '@frame/security/service/user.service';
import { BpaActionStatus, BpmProcessStatus } from 'app/util/shared-enums.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { BPMHistory } from '@app-main/model/BPMHistory';
import { SharedService } from '@app-main/service/shared.service';

@Component({
  selector: 'ot-process-history',
  templateUrl: './process-history.component.html',
  styleUrls: ['./process-history.component.scss']
})
export class ProcessHistoryComponent implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @Input() set ProcessInstanceId(pId: number) {
    this.sharedService.ListBPMHistoryData(pId).subscribe(
      result => {
          // console.log(result);
          this.historyData = result;
          this.title = this.historyData[0].ProcessDefinitionName;
          if (this.historyData && this.historyData[0].ProcessStatusCode) {
            this.processStatus = this.bpmProcessStatus.filter((row) => row.value === this.historyData[0].ProcessStatusCode)[0].text;
          }
      }, error => {
          console.log(error);
          this.messageService.error(this.translateService.instant('An error occurred while getting history records'));
      }
    );
  }
  title: string;
  historyData: BPMHistory[] = [];
  bpaActionStatus = BpaActionStatus;
  bpmProcessStatus = BpmProcessStatus;
  processStatus: string;


  constructor(
    public userService: UserService,
    public sharedService: SharedService,
    protected messageService: GrowlMessageService,
    protected translateService: TranslateService,
  ) { }

  isValidDate(compareDate: Date) {
    const d1 = new Date(compareDate);
    if (d1.getFullYear() > 1900) {
      return true;
    } else {
      return false;
    }
  }

  ngOnInit() {
    if (!this.userService.completeList) {
      this.userService.listAll();
    }
  }

}
