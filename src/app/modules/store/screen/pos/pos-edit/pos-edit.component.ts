// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Pos } from '@store/model/pos.model';
import { PosService } from '@store/service/pos.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-pos-edit',
    templateUrl: './pos-edit.component.html',
    styleUrls: ['./pos-edit.component.css', ]
})
export class PosEditComponent extends CRUDDialogScreenBase<Pos> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Pos>;

    public storeVisible = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PosService,
        public storeService: StoreService,
        public bankService: BankService,
    ) {
        super(messageService, translateService, dataService, 'Pos');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PosId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Store: new FormControl(),
            PosCode: new FormControl(),
            Bank: new FormControl(),
            CashRegisterCode: new FormControl(),
            BankCode: new FormControl(),
            Description: new FormControl(),
            MobilFlag: new FormControl(),
            OKCNumber: new FormControl(),
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
