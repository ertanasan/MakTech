// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { AccountingDepartment } from '@accounting/model/accounting-department.model';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';
import { AccountingDepartmentEditComponent } from '@accounting/screen/accounting-department/accounting-department-edit/accounting-department-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-accounting-department-list',
    templateUrl: './accounting-department-list.component.html',
    styleUrls: ['./accounting-department-list.component.css', ]
})
export class AccountingDepartmentListComponent extends ListScreenBase<AccountingDepartment> implements AfterViewInit, OnInit {
    @ViewChild(AccountingDepartmentEditComponent, {static: true}) editScreen: AccountingDepartmentEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: AccountingDepartmentService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Accounting Department', RouterLink: '/accounting/accounting-department'}];
    }

    createEmptyModel(): AccountingDepartment {
        return new AccountingDepartment();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        super.ngOnInit();
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
