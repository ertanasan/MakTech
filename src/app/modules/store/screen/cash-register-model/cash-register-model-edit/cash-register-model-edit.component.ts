// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CashRegisterModel } from '@store/model/cash-register-model.model';
import { CashRegisterModelService } from '@store/service/cash-register-model.service';
import { CashRegisterBrand } from '@store/model/cash-register-brand.model';
import { CashRegisterBrandService } from '@store/service/cash-register-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-register-model-edit',
    templateUrl: './cash-register-model-edit.component.html',
    styleUrls: ['./cash-register-model-edit.component.css', ]
})
export class CashRegisterModelEditComponent extends CRUDDialogScreenBase<CashRegisterModel> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CashRegisterModel>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: CashRegisterModelService,
        public cashRegisterBrandService: CashRegisterBrandService,
    ) {
        super(messageService, translateService, dataService, 'Cash Register Model');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CashRegisterModelId: new FormControl(),
            Brand: new FormControl(),
            Name: new FormControl(),
            Description: new FormControl(),
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
