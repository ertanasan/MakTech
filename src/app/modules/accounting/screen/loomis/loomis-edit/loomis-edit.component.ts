// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Loomis } from '@accounting/model/loomis.model';
import { LoomisService } from '@accounting/service/loomis.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-loomis-edit',
    templateUrl: './loomis-edit.component.html',
    styleUrls: ['./loomis-edit.component.css', ]
})
export class LoomisEditComponent extends CRUDDialogScreenBase<Loomis> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Loomis>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: LoomisService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Loomis');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            LoomisId: new FormControl(),
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
            SaleDate: new FormControl(),
            Store: new FormControl(),
            SealNo: new FormControl(),
            DeclaredAmount: new FormControl(),
            ActualAmount: new FormControl(),
            FakeAmount: new FormControl(),
            Explanation: new FormControl(),
            MikroTime: new FormControl(),
            MikroStatusCode: new FormControl(),
            MikroTransactionCode: new FormControl(),
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
