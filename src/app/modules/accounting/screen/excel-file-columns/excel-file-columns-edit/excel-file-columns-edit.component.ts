// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ExcelFileColumns } from '@accounting/model/excel-file-columns.model';
import { ExcelFileColumnsService } from '@accounting/service/excel-file-columns.service';
import { ExcelFile } from '@accounting/model/excel-file.model';
import { ExcelFileService } from '@accounting/service/excel-file.service';
import { ExcelFileColumnType } from 'app/util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-excel-file-columns-edit',
    templateUrl: './excel-file-columns-edit.component.html',
    styleUrls: ['./excel-file-columns-edit.component.css', ]
})
export class ExcelFileColumnsEditComponent extends CRUDDialogScreenBase<ExcelFileColumns> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ExcelFileColumns>;

    columntypes = ExcelFileColumnType;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExcelFileColumnsService,
        public excelFileService: ExcelFileService,
    ) {
        super(messageService, translateService, dataService, 'Excel File Columns');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ExcelFileColumnsId: new FormControl(),
            ExcelFile: new FormControl(),
            ColumnName: new FormControl(),
            ColumnIndex: new FormControl(),
            ColumnType: new FormControl(),
            ColumnFormat: new FormControl(),
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
