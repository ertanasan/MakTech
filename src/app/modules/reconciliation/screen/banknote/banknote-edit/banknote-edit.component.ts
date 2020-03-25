// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Banknote } from '@reconciliation/model/banknote.model';
import { BanknoteService } from '@reconciliation/service/banknote.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-banknote-edit',
    templateUrl: './banknote-edit.component.html',
    styleUrls: ['./banknote-edit.component.css', ]
})
export class BanknoteEditComponent extends CRUDDialogScreenBase<Banknote> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Banknote>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: BanknoteService,
    ) {
        super(messageService, translateService, dataService, 'Banknote');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            BanknoteId: new FormControl(),
            BanknoteAmount: new FormControl(),
            CoinFlag: new FormControl(),
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
