// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductionContent } from '@warehouse/model/production-content.model';
import { ProductionContentService } from '@warehouse/service/production-content.service';
import { ProductionContentEditComponent } from '@warehouse/screen/production-content/production-content-edit/production-content-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-content-list',
    templateUrl: './production-content-list.component.html',
    styleUrls: ['./production-content-list.component.css', ]
})
export class ProductionContentListComponent extends ListScreenBase<ProductionContent> implements AfterViewInit, OnInit {
    @ViewChild(ProductionContentEditComponent, {static: true}) editScreen: ProductionContentEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductionContentService,
        public productService: ProductService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (!this.isEmbedded) {
            this.dataService.list(this.listParams);
        } else {
            const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
            if (result) {
                this.dataLoading = true;
                result.subscribe(
                    list => {
                        this.dataList = list;
                    },
                    error => {
                        this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                    },
                    () => this.dataLoading = false
                );
            }
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Production Content', RouterLink: '/warehouse/production-content'}];
    }

    createEmptyModel(): ProductionContent {
        const model = new ProductionContent();
        model.Production = this.masterId;
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
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
