// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { PageChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ProductEditComponent } from '@product/screen/product/product-edit/product-edit.component';
import { Subgroup } from '@product/model/subgroup.model';
import { SubgroupService } from '@product/service/subgroup.service';
import { SuperGroup1 } from '@product/model/super-group1.model';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup2 } from '@product/model/super-group2.model';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup3 } from '@product/model/super-group3.model';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';
import { BarcodeTypeInt } from '@product/model/barcode-type-int.model';
import { BarcodeTypeIntService } from '@product/service/barcode-type-int.service';
import { SeasonType } from '@product/model/season-type.model';
import { SeasonTypeService } from '@product/service/season-type.service';
import { Country } from '@product/model/country.model';
import { CountryService } from '@product/service/country.service';
import { Warning } from '@product/model/warning.model';
import { WarningService } from '@product/service/warning.service';
import { StorageCondition } from '@product/model/storage-condition.model';
import { StorageConditionService } from '@product/service/storage-condition.service';
import { ProductCampaign } from '@product/model/product-campaign.model';
import { ProductCampaignService } from '@product/service/product-campaign.service';
import { process, SortDescriptor, aggregateBy } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { Observable } from 'rxjs/Observable';
import { switchMap, map } from 'rxjs/operators';
import { of } from 'rxjs';
import { KendoGridCommandColumnWidth } from 'app/util/shared-enums.component';
import { ProductCategoryService } from '@product/service/product-category.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-list',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css', ]
})
export class ProductListComponent extends ListScreenBase<Product> implements AfterViewInit, OnInit {
    @ViewChild(ProductEditComponent, {static: true}) editScreen: ProductEditComponent;

    parentProducts: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductService,
        public categoryService: ProductCategoryService,
        public subgroupService: SubgroupService,
        public superGroup1Service: SuperGroup1Service,
        public superGroup2Service: SuperGroup2Service,
        public superGroup3Service: SuperGroup3Service,
        public unitService: UnitService,
        public barcodeTypeIntService: BarcodeTypeIntService,
        public seasonTypeService: SeasonTypeService,
        public countryService: CountryService,
        public warningService: WarningService,
        public storageConditionService: StorageConditionService,
        public productCampaignService: ProductCampaignService,
    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Product', RouterLink: '/product/product'}];
    }

    createEmptyModel(): Product {
        return new Product();
    }

    ngOnInit() {
        this.commandColumnWidth = KendoGridCommandColumnWidth.ThreeButton;
        // Fill reference lists
        if (!this.subgroupService.completeList) {
            this.subgroupService.listAll();
        }
        if (!this.superGroup1Service.completeList) {
            this.superGroup1Service.listAll();
        }
        if (!this.superGroup2Service.completeList) {
            this.superGroup2Service.listAll();
        }
        if (!this.superGroup3Service.completeList) {
            this.superGroup3Service.listAll();
        }
        if (!this.unitService.completeList) {
            this.unitService.listAll();
        }
        if (!this.barcodeTypeIntService.completeList) {
            this.barcodeTypeIntService.listAll();
        }
        if (!this.seasonTypeService.completeList) {
            this.seasonTypeService.listAll();
        }
        if (!this.countryService.completeList) {
            this.countryService.listAll();
        }
        if (!this.warningService.completeList) {
            this.warningService.listAll();
        }
        if (!this.storageConditionService.completeList) {
            this.storageConditionService.listAll();
        }
        if (!this.productCampaignService.completeList) {
            this.productCampaignService.listAll();
        }
        if (!this.categoryService.completeList) {
            this.categoryService.listAll();
        }
        super.ngOnInit();

        if (!this.dataService.completeList) {
            this.dataService.listAllAsync().subscribe(list => {
                this.parentProducts = list.filter(t => t.SuperGroup3 === 1);
                this.editScreen.parentProducts = this.parentProducts;
            });
        }
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }


    public allData = (): Observable<GridDataResult> => {
        const state = Object.assign({}, this.listParams);
        delete state.skip;
        delete state.take;
       return this.dataService.listAsync(state).pipe(
        map(response => (<GridDataResult>{
            data: response.Data,
            total: response.Total
        }))
        );
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (dataItem) {
            const subgroup = this.subgroupService.completeList.filter(row => row.SubgroupID === dataItem.Subgroup);
            if (subgroup.length > 0) {
                this.editScreen.selectedSubGroup = dataItem.Subgroup;
                this.editScreen.selectedCategory = subgroup[0].Category;
            } else {
                this.editScreen.selectedCategory = undefined;
                this.editScreen.selectedSubGroup = undefined;
            }
        } else {
            this.editScreen.selectedCategory = undefined;
            this.editScreen.selectedSubGroup = undefined;
        }

        super.showDialog(target, actionName, dataItem);
    }
}
