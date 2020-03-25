// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GroupUser } from '@security/model/group-user.model';
import { GroupUserService } from '@security/service/group-user.service';
import { Group } from '@security/model/group.model';
import { GroupService } from '@security/service/group.service';
import { User } from '@security/model/user.model';
import { UserService } from '@security/service/user.service';
import { GroupUserListComponent } from '../group-user-list/group-user-list.component';
import { Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-group-user-edit',
    templateUrl: './group-user-edit.component.html',
    styleUrls: ['./group-user-edit.component.css']
})
export class GroupUserEditComponent extends CRUDDialogScreenBase<GroupUser> implements OnInit, OnDestroy {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<GroupUser>;
    @Input() userList: User[] = [];
    @Input() groupList: Group[] = [];
    @Input() activeUsers: User[] = [];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: GroupUserService,
        public groupService: GroupService,
        public userService: UserService,
    ) {
        super(messageService, translateService, dataService, 'Group User');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Group: new FormControl(),
            User: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
        this.unsubscribe.push(this.container.onShow.subscribe(item => {
            if (this.currentAction.name === 'Create') {
                this.container.rightRelationId = 0;
                this.container.mainForm.patchValue({User: 0});
            } else {
                this.container.rightRelationId = item.User;
            }
        }));
    }

    create() {
        // Determine crate REST controller action name
        let restAction = 'Create';
        if (this.container.leftRelationId > 0) {
            restAction = 'AddLeft';
        } else if (this.container.rightRelationId > 0) {
            restAction = 'AddRight';
        }

        this.dataService.create(this.currentItem, restAction).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.createSuccessMessage, { 0: this.translateService.instant(this.modelName) }));
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
                this.container.mainForm.reset();
            },
            error => {
                this.handleHttpError(error, this.createFailMessage, this.modelName);
            }
        );
    }

    delete() {
        this.dataService.delete(this.currentItem.getId()).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.deleteSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                this.mainScreen.refreshData();
                this.container.hide();
                this.container.mainForm.reset();

            },
            error => {
                this.handleHttpError(error, this.deleteFailMessage, this.modelName);
            }
        );
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnDestroy() {
        super.ngOnDestroy();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
