// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { SupplierType } from '@warehouse/model/supplier-type.model';
import { SupplierTypeService } from '@warehouse/service/supplier-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-supplier-edit',
    templateUrl: './supplier-edit.component.html',
    styleUrls: ['./supplier-edit.component.css', ]
})
export class SupplierEditComponent extends CRUDDialogScreenBase<Supplier> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Supplier>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SupplierService,
        public supplierTypeService: SupplierTypeService,
    ) {
        super(messageService, translateService, dataService, 'Supplier');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SupplierId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            SupplierName: new FormControl(),
            SupplierType: new FormControl(),
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
