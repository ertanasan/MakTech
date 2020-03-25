// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ExcelFile } from '@accounting/model/excel-file.model';
import { ExcelFileService } from '@accounting/service/excel-file.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-excel-file-edit',
    templateUrl: './excel-file-edit.component.html',
    styleUrls: ['./excel-file-edit.component.css', ]
})
export class ExcelFileEditComponent extends CRUDDialogScreenBase<ExcelFile> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ExcelFile>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExcelFileService,
    ) {
        super(messageService, translateService, dataService, 'Excel File');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ExcelFileId: new FormControl(),
            TransferName: new FormControl(),
            SheetNo: new FormControl(),
            RowStartNo: new FormControl(),
            ColumnStartNo: new FormControl(),
            NumberOfColumns: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    //#endregion Customized

    /*Section="ClassFooter"*/
}
