import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';

import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { UserService } from '@frame/security/service/user.service';
import { BpaActionStatus, BpmProcessStatus } from 'app/util/shared-enums.component';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { BPMHistory } from '@app-main/model/BPMHistory';
import { SharedService } from '@app-main/service/shared.service';

@Component({
  selector: 'ot-approve-message-box',
  templateUrl: './approve-message-box.component.html',
  styleUrls: ['./approve-message-box.component.scss']
})
export class ApproveMessageBoxComponent implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @Input() public approveMessage: string;
  @Input() public approveTitle: string;
  @Output() public approved = new EventEmitter();  
  @Output() public cancelled = new EventEmitter();  

  constructor(
    protected messageService: GrowlMessageService,
    protected translateService: TranslateService,
  ) { }

  ngOnInit() {
  }

  approveOnClicked() {
    this.approved.emit();
    this.dialog.hide();
  }

  cancelOnClicked() {
    this.cancelled.emit();
    this.dialog.hide();
  }

  public show() {
    this.dialog.show();
  }
}
