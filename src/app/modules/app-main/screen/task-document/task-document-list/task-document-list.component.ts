// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { TaskDocument } from '@app-main/model/task-document.model';
import { TaskDocumentService } from '@app-main/service/task-document.service';
import { TaskDocumentEditComponent } from '@over-store-main/screen/task-document/task-document-edit/task-document-edit.component';
import { OverStoreTask } from '@app-main/model/over-store-task.model';
import { OverStoreTaskService } from '@app-main/service/over-store-task.service';
import { Document } from '@document/model/document.model';
import { DocumentService } from '@document/service/document.service';
import {finalize} from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-task-document-list',
    templateUrl: './task-document-list.component.html',
    styleUrls: ['./task-document-list.component.css', ]
})
export class TaskDocumentListComponent extends ListScreenBase<TaskDocument> implements AfterViewInit, OnInit {
    @ViewChild(TaskDocumentEditComponent, { static: true }) editScreen: TaskDocumentEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: TaskDocumentService,
        public overStoreTaskService: OverStoreTaskService,
        public documentService: DocumentService,
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.dataLoading = true;
        this.dataService.listAsync(this.listParams).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            listResult => {
                this.dataList = listResult.Data;
            },
            error => {
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'OverStoreMain' }, {Caption: 'Task Document', RouterLink: '/over-store-main/task-document'}];
    }

    createEmptyModel(): TaskDocument {
        const taskDocument = new TaskDocument();
        if (this.leftRelationId > 0) {
            taskDocument.OverStoreTask = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            taskDocument.Document = this.rightRelationId;
        }
        return taskDocument;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId && !this.overStoreTaskService.completeList) {
            this.overStoreTaskService.listAll();
        }
        if (!this.rightRelationId && !this.documentService.completeList) {
            this.documentService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
