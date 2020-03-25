// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CardDistribution } from '@reconciliation/model/card-distribution.model';
import { CardDistributionService } from '@reconciliation/service/card-distribution.service';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-card-distribution-edit',
    templateUrl: './card-distribution-edit.component.html',
    styleUrls: ['./card-distribution-edit.component.css', ]
})
export class CardDistributionEditComponent extends CRUDDialogScreenBase<CardDistribution> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CardDistribution>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: CardDistributionService,
        public reconciliationService: ReconciliationService,
    ) {
        super(messageService, translateService, dataService, 'Card Distribution');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CardDistributionId: new FormControl(),
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
            CardGroupCode: new FormControl(),
            CardZetAmount: new FormControl(),
            StoreRec: new FormControl(),
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
