// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Cashier } from '@store/model/cashier.model';
import { CashierService } from '@store/service/cashier.service';
import { StoreService } from '@store/service/store.service';
import { CashierTemplateService } from '@store/service/cashier-template.service';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cashier-edit',
    templateUrl: './cashier-edit.component.html',
    styleUrls: ['./cashier-edit.component.css', ]
})
export class CashierEditComponent extends CRUDDialogScreenBase<Cashier> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Cashier>;

    workingTypeList = [ {WorkingTypeId: 0, WorkingTypeName: 'Saatlik'},
                        {WorkingTypeId: 1, WorkingTypeName: 'Günlük'},
                        {WorkingTypeId: 2, WorkingTypeName: 'Haftalık'},
                        {WorkingTypeId: 3, WorkingTypeName: 'Aylık'} ];
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CashierService,
        public storeService: StoreService,
        public cashierTemplateService: CashierTemplateService,
    ) {
        super(messageService, translateService, dataService, 'Cashier');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CashierId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Store: new FormControl(),
            CashierName: new FormControl(),
            CashierTemplateNumber: new FormControl(),
            CashierTitleNumber: new FormControl(),
            Password: new FormControl(),
            CashierFlag: new FormControl(),
            IsActive: new FormControl(),
            Salesman: new FormControl(),
            WorkingType: new FormControl(),
            Note: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    create() {
       super.create();
    }
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
