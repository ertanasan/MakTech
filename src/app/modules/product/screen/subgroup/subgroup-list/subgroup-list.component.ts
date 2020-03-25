// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Subgroup } from '@product/model/subgroup.model';
import { SubgroupService } from '@product/service/subgroup.service';
import { SubgroupEditComponent } from '@product/screen/subgroup/subgroup-edit/subgroup-edit.component';
import { ProductCategory } from '@product/model/product-category.model';
import { ProductCategoryService } from '@product/service/product-category.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-subgroup-list',
    templateUrl: './subgroup-list.component.html',
    styleUrls: ['./subgroup-list.component.css', ]
})
export class SubgroupListComponent extends ListScreenBase<Subgroup> implements AfterViewInit, OnInit {
    @ViewChild(SubgroupEditComponent, {static: true}) editScreen: SubgroupEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SubgroupService,
        public productCategoryService: ProductCategoryService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.subscribe(
                list => {
                    this.dataList = list;
                    this.dataLoading = false;
                },
                error => {
                    this.dataLoading = false;
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Subgroup', RouterLink: '/product/subgroup'}];
    }

    createEmptyModel(): Subgroup {
        return new Subgroup();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productCategoryService.completeList) {
            this.productCategoryService.listAll();
        }
        this.dataService.list(this.listParams);
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
