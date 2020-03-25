// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Status } from '@store-upload/model/status.model';
import { StatusService } from '@store-upload/service/status.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-status-edit',
    templateUrl: './status-edit.component.html',
    styleUrls: ['./status-edit.component.css', ]
})
export class StatusEditComponent extends CRUDDialogScreenBase<Status> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Status>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: StatusService,
    ) {
        super(messageService, translateService, dataService, 'Status');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StatusId: new FormControl(),
            Name: new FormControl(),
            Description: new FormControl(),
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
