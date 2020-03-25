// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ConstraintException } from '@warehouse/model/constraint-exception.model';
import { ConstraintExceptionService } from '@warehouse/service/constraint-exception.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ProductCategoryService } from '@product/service/product-category.service';
import { SubgroupService } from '@product/service/subgroup.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-constraint-exception-edit',
    templateUrl: './constraint-exception-edit.component.html',
    styleUrls: ['./constraint-exception-edit.component.css', ]
})
export class ConstraintExceptionEditComponent extends CRUDDialogScreenBase<ConstraintException> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ConstraintException>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ConstraintExceptionService,
        public storeService: StoreService,
        public productService: ProductService,
        public categoryService: ProductCategoryService,
        public subGroupService: SubgroupService
    ) {
        super(messageService, translateService, dataService, 'Constraint Exception');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ConstraintExceptionId: new FormControl(),
            Store: new FormControl(),
            StartDate: new FormControl(),
            EndDate: new FormControl(),
            Category: new FormControl(),
            SubGroup: new FormControl(),
            Product: new FormControl(),
            Coefficient: new FormControl(),
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
