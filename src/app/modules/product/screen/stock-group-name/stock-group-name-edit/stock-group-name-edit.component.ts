// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StockGroupName } from '@product/model/stock-group-name.model';
import { StockGroupNameService } from '@product/service/stock-group-name.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-group-name-edit',
    templateUrl: './stock-group-name-edit.component.html',
    styleUrls: ['./stock-group-name-edit.component.css', ]
})
export class StockGroupNameEditComponent extends CRUDDialogScreenBase<StockGroupName> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StockGroupName>;

    usageTypeList = [{value: 1, text: 'Stok Hesabı'}, {value: 2, text: 'Raporlama'}];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StockGroupNameService,
    ) {
        super(messageService, translateService, dataService, 'Stock Group Name');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StockGroupNameId: new FormControl(),
            StockGroupName: new FormControl(),
            UsageType: new FormControl(),
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
