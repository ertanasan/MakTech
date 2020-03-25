// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ExcelFileColumns } from '@accounting/model/excel-file-columns.model';
import { ExcelFileColumnsService } from '@accounting/service/excel-file-columns.service';
import { ExcelFileColumnsEditComponent } from '@accounting/screen/excel-file-columns/excel-file-columns-edit/excel-file-columns-edit.component';
import { finalize } from 'rxjs/operators';
import { process } from '@progress/kendo-data-query';
import { ExcelFileColumnType } from 'app/util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-excel-file-columns-list',
    templateUrl: './excel-file-columns-list.component.html',
    styleUrls: ['./excel-file-columns-list.component.css', ]
})
export class ExcelFileColumnsListComponent extends ListScreenBase<ExcelFileColumns> implements AfterViewInit {
    @ViewChild(ExcelFileColumnsEditComponent, {static: true}) editScreen: ExcelFileColumnsEditComponent;

    columntypes = ExcelFileColumnType;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExcelFileColumnsService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.listParams.take = 200;
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    this.dataList = process(list.Data, this.listParams);
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Excel File Columns', RouterLink: '/accounting/excel-file-columns'}];
    }

    createEmptyModel(): ExcelFileColumns {
        const model = new ExcelFileColumns();
        model.ExcelFile = this.masterId;
        return model;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    //#endregion Customized

    /*Section="ClassFooter"*/
}
