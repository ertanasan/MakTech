// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreReconciliation } from '@reconciliation/model/store-reconciliation.model';
import { StoreReconciliationService } from '@reconciliation/service/store-reconciliation.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-reconciliation-edit',
    templateUrl: './store-reconciliation-edit.component.html',
    styleUrls: ['./store-reconciliation-edit.component.css', ]
})
export class StoreReconciliationEditComponent extends CRUDDialogScreenBase<StoreReconciliation> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreReconciliation>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreReconciliationService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Store Reconciliation');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreReconciliationId: new FormControl(),
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
            TransactionDate: new FormControl(),
            StoreID: new FormControl(),
            PreviousDayAmount: new FormControl(),
            SaleTotal: new FormControl(),
            CashTotal: new FormControl(),
            CardTotal: new FormControl(),
            ToBank: new FormControl(),
            Difference: new FormControl(),
            DifferenceExplanation: new FormControl(),
            Completed: new FormControl(),
            EodAdvance: new FormControl(),
            Reconciliated: new FormControl(),
            Approved: new FormControl(),
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
