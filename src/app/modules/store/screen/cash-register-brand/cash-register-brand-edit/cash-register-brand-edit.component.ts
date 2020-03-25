// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CashRegisterBrand } from '@store/model/cash-register-brand.model';
import { CashRegisterBrandService } from '@store/service/cash-register-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-register-brand-edit',
    templateUrl: './cash-register-brand-edit.component.html',
    styleUrls: ['./cash-register-brand-edit.component.css', ]
})
export class CashRegisterBrandEditComponent extends CRUDDialogScreenBase<CashRegisterBrand> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CashRegisterBrand>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: CashRegisterBrandService,
    ) {
        super(messageService, translateService, dataService, 'Cash Register Brand');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CashRegisterBrandId: new FormControl(),
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
