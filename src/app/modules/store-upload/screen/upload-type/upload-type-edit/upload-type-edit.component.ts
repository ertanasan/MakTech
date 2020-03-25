// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { UploadType } from '@store-upload/model/upload-type.model';
import { UploadTypeService } from '@store-upload/service/upload-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-upload-type-edit',
    templateUrl: './upload-type-edit.component.html',
    styleUrls: ['./upload-type-edit.component.css', ]
})
export class UploadTypeEditComponent extends CRUDDialogScreenBase<UploadType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<UploadType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: UploadTypeService,
    ) {
        super(messageService, translateService, dataService, 'Upload Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            UploadTypeId: new FormControl(),
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
