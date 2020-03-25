// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ExcelFile } from '@accounting/model/excel-file.model';
import { ExcelFileService } from '@accounting/service/excel-file.service';
import { ExcelFileEditComponent } from '@accounting/screen/excel-file/excel-file-edit/excel-file-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-excel-file-list',
    templateUrl: './excel-file-list.component.html',
    styleUrls: ['./excel-file-list.component.css', ]
})
export class ExcelFileListComponent extends ListScreenBase<ExcelFile> implements AfterViewInit {
    @ViewChild(ExcelFileEditComponent, {static: true}) editScreen: ExcelFileEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExcelFileService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Excel File', RouterLink: '/accounting/excel-file'}];
    }

    createEmptyModel(): ExcelFile {
        return new ExcelFile();
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
