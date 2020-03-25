// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ExpenseCenter } from '@accounting/model/expense-center.model';
import { ExpenseCenterService } from '@accounting/service/expense-center.service';
import { RegionManagers } from '@store/model/region-managers.model';
import { RegionManagersService } from '@store/service/region-managers.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-expense-center-edit',
    templateUrl: './expense-center-edit.component.html',
    styleUrls: ['./expense-center-edit.component.css', ]
})
export class ExpenseCenterEditComponent extends CRUDDialogScreenBase<ExpenseCenter> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<ExpenseCenter>;
    
    CenterGroupList = [{value: 1, text: 'Merkez'}, {value: 2, text: 'Bölge'}, {value: 3, text: 'Mağaza'}];
    centerGroup: number;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ExpenseCenterService,
        public regionManagerService: RegionManagersService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Expense Center');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ExpenseCenterId: new FormControl(),
            ExpenseCenterName: new FormControl(),
            ExpenseCenterCode: new FormControl(),
            ExpenseCenterGroup: new FormControl(),
            RegionManager: new FormControl(),
            Store: new FormControl(),
            ActiveFlag: new FormControl(),
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
