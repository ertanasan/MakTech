// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { OverStoreTask } from '@app-main/model/over-store-task.model';
import { OverStoreTaskService } from '@over-store-main/service/over-store-task.service';
import { OverStoreTaskEditComponent } from '@over-store-main/screen/over-store-task/over-store-task-edit/over-store-task-edit.component';
import { OverStoreTaskStatus } from '@app-main/model/over-store-task-status.model';
import { OverStoreTaskStatusService } from '@over-store-main/service/over-store-task-status.service';
import { OverStoreTaskType } from '@app-main/model/over-store-task-type.model';
import { OverStoreTaskTypeService } from '@over-store-main/service/over-store-task-type.service';
import {DialogScreenBase} from '@otscreen-base/dialog-screen-base';
import {Observable} from 'rxjs';
import {OTContext} from '@otlib/auth/model/context.model';
import {Store} from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';
import {first} from 'rxjs/operators';
import {ProcessHistoryComponent} from '@app-main/screen/process-history/process-history.component';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-over-store-task-list',
    templateUrl: './over-store-task-list.component.html',
    styleUrls: ['./over-store-task-list.component.css', ]
})
export class OverStoreTaskListComponent extends ListScreenBase<OverStoreTask> implements AfterViewInit, OnInit {
    @ViewChild(OverStoreTaskEditComponent, { static: true }) editScreen: OverStoreTaskEditComponent;
    @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;
    public contextState$: Observable<OTContext>;
    public contextInfo: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: OverStoreTaskService,
        public overStoreTaskStatusService: OverStoreTaskStatusService,
        public overStoreTaskTypeService: OverStoreTaskTypeService,
        private store: Store<fromApp.AppState>,
    ) {
        super(messageService, translateService);
        this.contextState$ = this.store.select('context');
        this.translateService.setDefaultLang('tr');
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'OverStoreMain' }, {Caption: 'OverStoreTask', RouterLink: '/over-store-main/over-store-task'}];
    }

    createEmptyModel(): OverStoreTask {
        const model = new OverStoreTask();
        model.CreateUser = this.contextInfo.User.Id;
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.overStoreTaskStatusService.completeList) {
            this.overStoreTaskStatusService.listAll();
        }
        if (!this.overStoreTaskTypeService.completeList) {
            this.overStoreTaskTypeService.listAll();
        }
        this.contextState$.pipe(first()).subscribe(context => this.contextInfo = context);

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const taskId = this.modeContext.id;
            this.dataService.read(taskId).subscribe(task => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), task);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: OverStoreTask) {
        if (actionName === 'ShowHistory') {
            this.historyScreen.ProcessInstanceId = dataItem.ProcessInstance;
            this.historyScreen.dialog.show();
        } else {
            if (actionName !== 'Create') {
                this.editScreen.responsibleTypeStr = dataItem.ResponsibleType.toString();
                dataItem.DeadlineFlag = dataItem.Deadline !== null;
            }
            super.showDialog(target, actionName, dataItem);
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['Deadline', 'CreateDate'];
        super.handleDataStateChange(state);
    }

    readDataItem(dataItem: OverStoreTask) {
        return this.dataService.read(dataItem.OverStoreTaskId);
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
