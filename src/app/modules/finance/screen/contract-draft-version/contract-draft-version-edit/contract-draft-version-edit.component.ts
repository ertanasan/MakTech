// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ContractDraftVersion } from '@finance/model/contract-draft-version.model';
import { ContractDraftVersionService } from '@finance/service/contract-draft-version.service';
import { Document } from '@document/model/document.model';
import { DocumentService } from '@document/service/document.service';
import {environment} from '../../../../../../environments/environment';
import {DocumentHandle} from '@otmodel/document-handle.model';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-contract-draft-version-edit',
    templateUrl: './contract-draft-version-edit.component.html',
    styleUrls: ['./contract-draft-version-edit.component.css', ]
})
export class ContractDraftVersionEditComponent extends CRUDDialogScreenBase<ContractDraftVersion> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<ContractDraftVersion>;

    deleteUrl = '';
    downloadUrl = '';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ContractDraftVersionService,
        public documentService: DocumentService,
    ) {
        super(messageService, translateService, dataService, 'Contract Draft Version');
        this.deleteUrl = environment.baseRoute + '/Finance/ContractDraftVersion/DeleteDocument';
        this.downloadUrl = environment.baseRoute + '/Finance/ContractDraftVersion/DownloadDocument';
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ContractDraftVersionId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            DocumentId: new FormControl(),
            ChangeDetails: new FormControl(),
            DraftDocument: new FormControl(new DocumentHandle()),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.container.actionName === 'Create' && this.container.currentItem.DraftDocument.isEmpty) {
            this.messageService.error(this.translateService.instant('Document must be added, progress halted') + '.');
            return;
        }
        super.onSubmit();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
