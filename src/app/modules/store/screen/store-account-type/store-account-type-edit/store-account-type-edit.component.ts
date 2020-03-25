// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreAccountType } from '@store/model/store-account-type.model';
import { StoreAccountTypeService } from '@store/service/store-account-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-account-type-edit',
    templateUrl: './store-account-type-edit.component.html',
    styleUrls: ['./store-account-type-edit.component.css', ]
})
export class StoreAccountTypeEditComponent extends CRUDDialogScreenBase<StoreAccountType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreAccountType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreAccountTypeService,
    ) {
        super(messageService, translateService, dataService, 'Store Account Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreAccountTypeId: new FormControl(),
            AccountTypeName: new FormControl(),
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
