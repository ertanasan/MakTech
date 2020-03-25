import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { UserService } from '@frame/security/service/user.service';
import { BpaActionStatus, BpmProcessStatus } from 'app/util/shared-enums.component';
import { SuggestionHistory } from '@announcement/model/suggestion.model';

@Component({
  selector: 'ot-suggestion-history',
  templateUrl: './suggestion-history.component.html',
  styleUrls: ['./suggestion-history.component.scss']
})
export class SuggestionHistoryComponent implements OnInit {
  @ViewChild(CustomDialogComponent, {static: true}) dialog: CustomDialogComponent;
  @Input() historyData: SuggestionHistory[] = [];
  @Input() processStatus = '';
  @Input() suggestionStatus = '';
  @Input() title = '';

  actiontypes = BpaActionStatus;

  constructor(
    public userService: UserService,
  ) { }

  ngOnInit() {
  }

}
