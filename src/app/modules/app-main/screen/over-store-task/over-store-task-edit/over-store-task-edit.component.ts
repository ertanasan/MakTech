// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { OverStoreTask } from '@app-main/model/over-store-task.model';
import { OverStoreTaskService } from '@over-store-main/service/over-store-task.service';
import { OverStoreTaskStatus } from '@app-main/model/over-store-task-status.model';
import { OverStoreTaskStatusService } from '@over-store-main/service/over-store-task-status.service';
import { OverStoreTaskType } from '@app-main/model/over-store-task-type.model';
import { OverStoreTaskTypeService } from '@over-store-main/service/over-store-task-type.service';
import {OverstoreCommonMethods} from '../../../../../util/common-methods.service';
import {UserService} from '@security/service/user.service';
import {GroupService} from '@security/service/group.service';
import {BranchService} from '@organization/service/branch.service';
import {first} from 'rxjs/operators';
import {User} from '@security/model/user.model';
import {Group} from '@security/model/group.model';
import {Branch} from '@organization/model/branch.model';
import {RadioItem} from '@otuidataentry/radio-entry/radio-item';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {environment} from '../../../../../../environments/environment';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-over-store-task-edit',
    templateUrl: './over-store-task-edit.component.html',
    styleUrls: ['./over-store-task-edit.component.css', ]
})
export class OverStoreTaskEditComponent extends CRUDDialogScreenBase<OverStoreTask> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<OverStoreTask>;
    @ViewChild('forwardProcessDialog', { static: true }) forwardProcessDialog: CustomDialogComponent;
    isForwardDialogOpen = false;

    responsibleTypeStr = '1';
    activeUserList: User[] = [];
    activeGroupList: Group[] = [];
    activeBranchList: Branch[] = [];
    responsibleTypeItems: RadioItem[] = [{'text': this.translateService.instant('User'), 'value': '1'},
                                         {'text': this.translateService.instant('Group'), 'value': '2'},
                                         {'text': this.translateService.instant('Department'), 'value': '3'}];

    forwardedUser: number;
    forwardedGroup: number;
    forwardedBranch: number;

    downloadDocumentUrl = '';
    deleteDocumentUrl = '';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: OverStoreTaskService,
        public overStoreTaskStatusService: OverStoreTaskStatusService,
        public overStoreTaskTypeService: OverStoreTaskTypeService,
        public commonMethods: OverstoreCommonMethods,
        public userService: UserService,
        public groupService: GroupService,
        public branchService: BranchService,
    ) {
        super(messageService, translateService, dataService, 'OverStoreTask');
        this.downloadDocumentUrl = environment.baseRoute + '/OverStoreMain/OverStoreTask/DownloadDocument';
        this.deleteDocumentUrl = environment.baseRoute + '/OverStoreMain/OverStoreTask/DeleteDocument';
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            OverStoreTaskId: new FormControl(),
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
            Status: new FormControl(),
            Type: new FormControl(),
            Content: new FormControl(),
            Deadline: new FormControl(),
            DeadlineFlag: new FormControl(),
            ResponsibleType: new FormControl(),
            ResponsibleUser: new FormControl(),
            ResponsibleGroup: new FormControl(),
            ResponsibleBranch: new FormControl(),
            ProcessInstance: new FormControl(),
            ForwardableFlag: new FormControl(),
            PreviousActionComment: new FormControl(),
            ActionComment: new FormControl(),
            Folder: new FormControl(),
            FolderHandle: new FormControl(),
        });
    }

    ngOnInit() {
        if (!this.userService.completeList) {
            this.userService.listAll();
            this.userService.completeListChanged.pipe(first()).subscribe(list => this.activeUserList = list.filter(u => !u.Deleted && u.Active && (u.Description === null || !u.Description.includes('#GenericUser')) ));
        } else {
            this.activeUserList = this.userService.completeList.filter(u => !u.Deleted && u.Active);
        }

        if (!this.groupService.completeList) {
            this.groupService.listAll();
            this.groupService.completeListChanged.pipe(first()).subscribe(list => this.activeGroupList = list.filter(g => !g.Deleted));
        } else {
            this.activeGroupList = this.groupService.completeList.filter(g => !g.Deleted);
        }

        if (!this.branchService.completeList) {
            this.branchService.listAll();
            this.branchService.completeListChanged.pipe(first()).subscribe(list => this.activeBranchList = list.filter(b => !b.Deleted));
        } else {
            this.activeBranchList = this.branchService.completeList.filter(b => !b.Deleted);
        }

        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    review() {
        if (this.currentItem.actionChoice === 'Yönlendir') {
            if (!this.container.currentItem.ForwardableFlag) {
                this.messageService.error(this.translateService.instant('This process is not forwardable'));
                return;
            } else if (!this.isForwardDialogOpen) {
                this.container.hideProgress();
                this.isForwardDialogOpen = true;
                this.forwardProcessDialog.show();
                return;
            } else {
                this.hideForwardDialog();
            }
        }
        super.review();
    }

    onForwardProcess() {
        switch (this.responsibleTypeStr) {
            case '1':
                if (!this.forwardedUser) {
                    this.messageService.error(this.translateService.instant('Forward User must be selected'));
                    return;
                }
                this.container.currentItem.ResponsibleType = +this.responsibleTypeStr;
                this.container.currentItem.ResponsibleUser = this.forwardedUser;
                break;
            case '2':
                if (!this.forwardedGroup) {
                    this.messageService.error(this.translateService.instant('Forward Group must be selected'));
                    return;
                }
                this.container.currentItem.ResponsibleType = +this.responsibleTypeStr;
                this.container.currentItem.ResponsibleGroup = this.forwardedGroup;
                break;
            case '3':
                if (!this.forwardedBranch) {
                    this.messageService.error(this.translateService.instant('Forward Department must be selected'));
                    return;
                }
                this.container.currentItem.ResponsibleType = +this.responsibleTypeStr;
                this.container.currentItem.ResponsibleBranch = this.forwardedBranch;
                break;
            default:
                return;
        }
        this.review();
    }

    hideForwardDialog() {
        this.isForwardDialogOpen = false;
        this.forwardProcessDialog.hide();
    }

    onSubmit() {
        if (this.container.actionName !== 'Review') {

            // Deadline Validation
            if (!this.container.currentItem.DeadlineFlag) {
                this.container.currentItem.Deadline = null;
            } else if (!this.container.currentItem.Deadline) {
                this.messageService.error(this.translateService.instant('Deadline must be filled while the deadline flag being checked') + '!');
                return;
            } else {
                this.container.currentItem.Deadline = this.commonMethods.addHours(this.container.currentItem.Deadline, 3);
            }

            // Responsible Type Validation
            switch (this.responsibleTypeStr) {
                case '1':
                    if (!this.container.currentItem.ResponsibleUser) {
                        this.messageService.error(this.translateService.instant('Responsible User must be selected'));
                        return;
                    }
                    break;
                case '2':
                    if (!this.container.currentItem.ResponsibleGroup) {
                        this.messageService.error(this.translateService.instant('Responsible Group must be selected'));
                        return;
                    }
                    break;
                case '3':
                    if (!this.container.currentItem.ResponsibleBranch) {
                        this.messageService.error(this.translateService.instant('Responsible Department must be selected'));
                        return;
                    }
                    break;
                default:
                    return;
            }
            this.container.currentItem.ResponsibleType = +this.responsibleTypeStr;
        }
        super.onSubmit();
    }

    onResponsibleTypeChange(newType: string) {
        this.responsibleTypeStr = newType;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
