import {Component, OnInit, ViewChild} from '@angular/core';
import {CRUDDialogScreenBase} from '@otscreen-base/crud-dialog-screen-base';
import {Suggestion} from '@announcement/model/suggestion.model';
import {GrowlMessageService} from '@otservice/growl-message.service';
import {TranslateService} from '@ngx-translate/core';
import {SuggestionService} from '@announcement/service/suggestion.service';
import {FormControl} from '@angular/forms';
import {EditScreenContainerComponent} from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import {SuggestionStatusService} from '@announcement/service/suggestion-status.service';
import {MessageDialogComponent} from '@otuicontainer/dialog/message-dialog/message-dialog.component';

@Component({
  selector: 'ot-suggestion-anonymous-entry',
  templateUrl: './suggestion-anonymous-entry.component.html',
  styleUrls: ['./suggestion-anonymous-entry.component.scss']
})
export class SuggestionAnonymousEntryComponent implements OnInit {
  // extends CRUDDialogScreenBase<Suggestion>
  // @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Suggestion>;
  // dataItem = new Suggestion();
  // suggestionId: string;

  @ViewChild(MessageDialogComponent, {static: true}) msgDialog: MessageDialogComponent;
  suggestionText = '';
  savedSuggestionId: number;

  dialogColor;
  dialogCaption = '';
  dialogMessage = '';

  constructor(public messageService: GrowlMessageService,
              public translateService: TranslateService,
              public dataService: SuggestionService,
              public suggestionStatusService: SuggestionStatusService
  ) {
    // super(messageService, translateService, dataService, 'Suggestion');
  }

  saveSuggestion() {
    if (this.suggestionText.length) {
      const suggestion = new Suggestion();
      suggestion.SuggestionText = this.suggestionText;
      this.dataService.create(suggestion).subscribe(
          result => {
            this.savedSuggestionId = result.SuggestionId;
            this.dialogColor = 'success';
            this.dialogCaption = this.translateService.instant('Succesfully Saved');
            this.dialogMessage = this.translateService.instant('Your suggestion has ben succesfully saved') + '. ' + this.translateService.instant('SuggestionId is ') + this.savedSuggestionId.toString();
            this.msgDialog.show();
          }, error => {
            this.dialogColor = 'error';
            this.dialogCaption = this.translateService.instant('Error');
            this.dialogMessage = this.translateService.instant('Ann error occured while saving the suggestion') + '!';
            this.msgDialog.show();
          }
      );
    }
  }

  ngOnInit() {
    // super.ngOnInit();
    // const actionName = 'Create';
    // this.currentAction = this.actions.find(a => a.name === actionName);
    this.suggestionStatusService.listAll();
  }

  createForm() {
    // this.container.mainForm = this.container.formBuilder.group({
    //   SuggestionId: new FormControl(),
    //   Event: new FormControl(),
    //   Organization: new FormControl(),
    //   Deleted: new FormControl(),
    //   CreateDate: new FormControl(),
    //   UpdateDate: new FormControl(),
    //   CreateUser: new FormControl(),
    //   UpdateUser: new FormControl(),
    //   CreateChannel: new FormControl(),
    //   CreateBranch: new FormControl(),
    //   CreateScreen: new FormControl(),
    //   SuggestionText: new FormControl(),
    //   ProcessInstance: new FormControl(),
    //   BranchName: new FormControl(),
    //   Status: new FormControl(),
    //   Type: new FormControl(),
    //   InnovativenessRating: new FormControl(),
    //   FeasibilityRating: new FormControl(),
    //   AddedValueRating: new FormControl(),
    //   PreviousActionComment: new FormControl(),
    //   ActionComment: new FormControl(),
    // });
  }

  // showFormContainer(actionName: string) {
  //   this.currentAction = this.actions.find(a => a.name === actionName);
  //   this.container.actionName = actionName;
  //   this.container.isAcceptable = this.currentAction.isAcceptable;
  //   this.container.title = this.translateService.instant(actionName + ' Suggestion');
  //   this.container.isIdentityHidden = this.currentAction.isIdentityHidden;
  //   this.container.isIdentityEditable = this.currentAction.isIdentityEditable;
  //   this.container.isReadOnly = this.currentAction.controlsDisabled;
  //   if (actionName === 'Create') {
  //     this.dataItem = new Suggestion();
  //   }
  //   this.container.show(this.dataItem);
  // }
  //
  // getSuggestionById() {
  //   this.dataService.read(+this.suggestionId).subscribe(
  //       suggestion => {
  //           this.dataItem = Object.assign(new Suggestion(), suggestion);
  //           this.showFormContainer('Read');
  //       }, error => this.messageService.error(this.translateService.instant('No record found for that id') + '!')
  //   );
  // }

}
