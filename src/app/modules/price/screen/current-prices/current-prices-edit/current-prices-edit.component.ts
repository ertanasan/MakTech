// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { CurrentPrices } from '@price/model/current-prices.model';
import { CurrentPricesService } from '@price/service/current-prices.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { TranslateService } from '@ngx-translate/core';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-current-prices-edit',
    templateUrl: './current-prices-edit.component.html',
    styleUrls: ['./current-prices-edit.component.css', ]
})
export class CurrentPricesEditComponent extends CRUDDialogScreenBase<CurrentPrices> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<CurrentPrices>;

    constructor(
        messageService: GrowlMessageService,
        dataService: CurrentPricesService,
        public storeService: StoreService,
        public translateService: TranslateService
    ) {
        super(messageService, translateService, dataService, 'Current Prices');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            CurrentPricesId: new FormControl(),
            StoreID: new FormControl(),
            ProductCodeName: new FormControl(),
            ProductName: new FormControl(),
            Barcode: new FormControl(),
            ProductUnit: new FormControl(),
            SalePrice: new FormControl(),
            SaleVAT: new FormControl(),
            VersionTime: new FormControl(),
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
