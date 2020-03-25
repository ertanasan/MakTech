// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ExpenseType } from '@reconciliation/model/expense-type.model';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';
import { ExpenseTypeEditComponent } from '@reconciliation/screen/expense-type/expense-type-edit/expense-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-type-list',
    templateUrl: './expense-type-list.component.html',
    styleUrls: ['./expense-type-list.component.css', ]
})
export class ExpenseTypeListComponent extends ListScreenBase<ExpenseType> implements AfterViewInit {
    @ViewChild(ExpenseTypeEditComponent, {static: true}) editScreen: ExpenseTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExpenseTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Expense Type', RouterLink: '/reconciliation/expense-type'}];
    }

    createEmptyModel(): ExpenseType {
        return new ExpenseType();
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
