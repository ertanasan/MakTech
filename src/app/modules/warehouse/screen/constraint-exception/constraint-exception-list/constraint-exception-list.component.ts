// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ConstraintException } from '@warehouse/model/constraint-exception.model';
import { ConstraintExceptionService } from '@warehouse/service/constraint-exception.service';
import { ConstraintExceptionEditComponent } from '@warehouse/screen/constraint-exception/constraint-exception-edit/constraint-exception-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { SubgroupService } from '@product/service/subgroup.service';
import { ProductCategoryService } from '@product/service/product-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-constraint-exception-list',
    templateUrl: './constraint-exception-list.component.html',
    styleUrls: ['./constraint-exception-list.component.css', ]
})
export class ConstraintExceptionListComponent extends ListScreenBase<ConstraintException> implements AfterViewInit, OnInit {
    @ViewChild(ConstraintExceptionEditComponent, {static: true}) editScreen: ConstraintExceptionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ConstraintExceptionService,
        public storeService: StoreService,
        public productService: ProductService,
        public categoryService: ProductCategoryService,
        public subGroupService: SubgroupService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Constraint Exception', RouterLink: '/warehouse/constraint-exception'}];
    }

    createEmptyModel(): ConstraintException {
        return new ConstraintException();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        if (!this.categoryService.completeList) {
            this.categoryService.listAll();
        }
        if (!this.subGroupService.completeList) {
            this.subGroupService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
