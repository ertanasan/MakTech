// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CashDistribution } from '@reconciliation/model/cash-distribution.model';
import { CashDistributionService } from '@reconciliation/service/cash-distribution.service';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { Banknote } from '@reconciliation/model/banknote.model';
import { BanknoteService } from '@reconciliation/service/banknote.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-distribution-edit',
    templateUrl: './cash-distribution-edit.component.html',
    styleUrls: ['./cash-distribution-edit.component.css', ]
})
export class CashDistributionEditComponent extends CRUDDialogScreenBase<CashDistribution> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CashDistribution>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CashDistributionService,
        public reconciliationService: ReconciliationService,
        public banknoteService: BanknoteService,
    ) {
        super(messageService, translateService, dataService, 'Cash Distribution');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CashDistributionId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            StoreReconciliation: new FormControl(),
            Banknote: new FormControl(),
            Quantity: new FormControl(),
            GroupCode: new FormControl(),
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
