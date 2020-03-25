// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StorageCondition } from '@product/model/storage-condition.model';
import { StorageConditionService } from '@product/service/storage-condition.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-storage-condition-edit',
    templateUrl: './storage-condition-edit.component.html',
    styleUrls: ['./storage-condition-edit.component.css', ]
})
export class StorageConditionEditComponent extends CRUDDialogScreenBase<StorageCondition> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StorageCondition>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: StorageConditionService,
    ) {
        super(messageService, translateService, dataService, 'Storage Condition');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StorageConditionId: new FormControl(),
            Condition: new FormControl(),
            Comment: new FormControl(),
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
