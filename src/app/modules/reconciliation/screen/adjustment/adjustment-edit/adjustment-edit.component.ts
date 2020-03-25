// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Adjustment } from '@reconciliation/model/adjustment.model';
import { AdjustmentService } from '@reconciliation/service/adjustment.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-adjustment-edit',
    templateUrl: './adjustment-edit.component.html',
    styleUrls: ['./adjustment-edit.component.css', ]
})
export class AdjustmentEditComponent extends CRUDDialogScreenBase<Adjustment> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Adjustment>;

    @Input() storeList:Store[];
    @Input() selectedStore:Store;
    @Input() authorized:boolean;
    
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: AdjustmentService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Adjustment');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            AdjustmentId: new FormControl(),
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
            Store: new FormControl(),
            Amount: new FormControl(),
            Description: new FormControl(),
            Date: new FormControl(),
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
