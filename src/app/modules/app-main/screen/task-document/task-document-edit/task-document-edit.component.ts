// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { TaskDocument } from '@app-main/model/task-document.model';
import { TaskDocumentService } from '@app-main/service/task-document.service';
import { OverStoreTask } from '@app-main/model/over-store-task.model';
import { OverStoreTaskService } from '@app-main/service/over-store-task.service';
import { Document } from '@document/model/document.model';
import { DocumentService } from '@document/service/document.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-task-document-edit',
    templateUrl: './task-document-edit.component.html',
    styleUrls: ['./task-document-edit.component.css', ]
})
export class TaskDocumentEditComponent extends CRUDDialogScreenBase<TaskDocument> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<TaskDocument>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: TaskDocumentService,
        public overStoreTaskService: OverStoreTaskService,
        public documentService: DocumentService,
    ) {
        super(messageService, translateService, dataService, 'Task Document');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            OverStoreTask: new FormControl(),
            Document: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
