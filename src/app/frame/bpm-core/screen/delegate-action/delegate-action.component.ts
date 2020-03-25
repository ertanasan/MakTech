import { Component, OnInit, ViewChild } from '@angular/core';
import { EditDialogScreenBase } from '@otscreen-base/edit-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { TranslateService } from '@ngx-translate/core';
import { InboxService } from '@bpm-core/service/inbox.service';
import { ActionDelegate } from '@bpm-core/model/actiondelegate.model';
import { finalize } from 'rxjs/operators';
import { _ } from '@biesbjerg/ngx-translate-extract/dist/utils/utils';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';
import { FormScreenContainerComponent } from '@otuiscreen/form-screen-container/form-screen-container.component';
import { FormControl } from '@angular/forms';
import { GroupService } from '@security/service/group.service';
import { UserService } from '@security/service/user.service';

@Component({
  selector: 'ot-delegate-action',
  templateUrl: './delegate-action.component.html',
  styleUrls: ['./delegate-action.component.css']
})
export class DelegateActionComponent extends EditDialogScreenBase implements OnInit {

  @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ActionDelegate>;

  defaultItemGroup = { GroupId: 0, Name: 'Select item...'};
  defaultItemUser = { UserId: 0, Name: 'Select item...'};
  currentItem: ActionDelegate;
  constructor(private inboxService: InboxService, messageService: GrowlMessageService,
    translateService: TranslateService, public groupService: GroupService, public userService: UserService ) {
      super( messageService, translateService, 'Action Delegate');
  }

  ngOnInit() {
    this.groupService.listAll();
    this.userService.listAll();
    super.ngOnInit();
    this.actions.push(
        {
            name: 'Delegate',
            isAcceptable: true,
            title: 'Delegate Action',
            isIdentityHidden: true,
            isIdentityEditable: false,
            submitCallback: () => this.delegate(),
        }
    );
  }

  createForm() {
    this.container.mainForm = this.container.formBuilder.group({
        ActionId: new FormControl(),
        Group: new FormControl(),
        User: new FormControl(),
        ProcessDefinitionName: new FormControl(),
        ActivityName: new FormControl(),
        Comment: new FormControl()
    });
  }

  delegate() {
      if (this.container.mainForm.value.Group !== 0 || this.container.mainForm.value.User !== 0) {
        this.inboxService.delegateAction(this.currentItem).pipe(
            finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(_('Action Delegated Succesfully!!')));
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.messageService.error(this.translateService.instant('Delegate Action Failed! Error: {{0}}', { 0: error }));
                }
                );
      } else {
          this.messageService.warning('Please Select a Group or User');
          this.container.hideProgress();
      }
    }

    onSubmit() {
        this.currentItem = this.container.currentItem;
        this.container.showProgress();
            // Find current action
        const currentAction = this.actions.find(a => a.name === this.container.actionName);
        if (currentAction) {
            currentAction.submitCallback();
        }
    }

    valueChange(e: string) {
        if (e === 'group' &&  this.container.mainForm.value.Group !== 0) {
            this.container.mainForm.get('User').setValue(this.defaultItemUser.UserId);
        }
        if (e === 'user' && this.container.mainForm.value.User !== 0) {
            this.container.mainForm.get('Group').setValue(this.defaultItemGroup.GroupId);
        }
    }
}
