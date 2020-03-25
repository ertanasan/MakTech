// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ExpenseCenter } from '@accounting/model/expense-center.model';
import { ExpenseCenterService } from '@accounting/service/expense-center.service';
import { ExpenseCenterEditComponent } from '@accounting/screen/expense-center/expense-center-edit/expense-center-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { RegionManagersService } from '@store/service/region-managers.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-center-list',
    templateUrl: './expense-center-list.component.html',
    styleUrls: ['./expense-center-list.component.css', ]
})
export class ExpenseCenterListComponent extends ListScreenBase<ExpenseCenter> implements AfterViewInit, OnInit {
    @ViewChild(ExpenseCenterEditComponent, { static: true }) editScreen: ExpenseCenterEditComponent;

    CenterGroupList = [{value: 1, text: 'Merkez'}, {value: 2, text: 'Bölge'}, {value: 3, text: 'Mağaza'}];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ExpenseCenterService,
        public storeService: StoreService,
        public regionManagerService: RegionManagersService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Expense Center', RouterLink: '/accounting/expense-center'}];
    }

    createEmptyModel(): ExpenseCenter {
        const m:ExpenseCenter = new ExpenseCenter();
        m.ActiveFlag = true;
        return m;
    }

    ngOnInit() {
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.regionManagerService.completeList) {
            this.regionManagerService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        super.showDialog(target, actionName, dataItem);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
