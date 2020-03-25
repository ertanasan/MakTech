import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { OTCommonModule } from '@otcommon/common.module';
import { ProductComponent } from '@product/product.component';

import { ProductBarcodeService } from '@product/service/product-barcode.service';
import { BarcodeTypeService } from '@product/service/barcode-type.service';
import { BarcodeTypeIntService } from '@product/service/barcode-type-int.service';
import { ProductCategoryService } from '@product/service/product-category.service';
import { PackageService } from '@product/service/package.service';
import { ProductService } from '@product/service/product.service';
import { ProductPropertyService } from '@product/service/product-property.service';
import { PropertyTypeService } from '@product/service/property-type.service';
import { SeasonTypeService } from '@product/service/season-type.service';
import { ProductCampaignService } from '@product/service/product-campaign.service';
import { StorageConditionService } from '@product/service/storage-condition.service';
import { SubgroupService } from '@product/service/subgroup.service';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { UnitService } from '@product/service/unit.service';
import { WarningService } from '@product/service/warning.service';
import { ProductBarcodeListComponent } from '@product/screen/product-barcode/product-barcode-list/product-barcode-list.component';
import { ProductBarcodeEditComponent } from '@product/screen/product-barcode/product-barcode-edit/product-barcode-edit.component';
import { BarcodeTypeListComponent } from '@product/screen/barcode-type/barcode-type-list/barcode-type-list.component';
import { BarcodeTypeEditComponent } from '@product/screen/barcode-type/barcode-type-edit/barcode-type-edit.component';
import { BarcodeTypeIntListComponent } from '@product/screen/barcode-type-int/barcode-type-int-list/barcode-type-int-list.component';
import { BarcodeTypeIntEditComponent } from '@product/screen/barcode-type-int/barcode-type-int-edit/barcode-type-int-edit.component';
import { ProductCategoryListComponent } from '@product/screen/product-category/product-category-list/product-category-list.component';
import { ProductCategoryEditComponent } from '@product/screen/product-category/product-category-edit/product-category-edit.component';
import { PackageListComponent } from '@product/screen/package/package-list/package-list.component';
import { PackageEditComponent } from '@product/screen/package/package-edit/package-edit.component';
import { ProductListComponent } from '@product/screen/product/product-list/product-list.component';
import { ProductEditComponent } from '@product/screen/product/product-edit/product-edit.component';
import { ProductPropertyListComponent } from '@product/screen/product-property/product-property-list/product-property-list.component';
import { ProductPropertyEditComponent } from '@product/screen/product-property/product-property-edit/product-property-edit.component';
import { PropertyTypeListComponent } from '@product/screen/property-type/property-type-list/property-type-list.component';
import { PropertyTypeEditComponent } from '@product/screen/property-type/property-type-edit/property-type-edit.component';
import { SeasonTypeListComponent } from '@product/screen/season-type/season-type-list/season-type-list.component';
import { SeasonTypeEditComponent } from '@product/screen/season-type/season-type-edit/season-type-edit.component';
import { StorageConditionListComponent } from '@product/screen/storage-condition/storage-condition-list/storage-condition-list.component';
import { StorageConditionEditComponent } from '@product/screen/storage-condition/storage-condition-edit/storage-condition-edit.component';
import { SubgroupListComponent } from '@product/screen/subgroup/subgroup-list/subgroup-list.component';
import { SubgroupEditComponent } from '@product/screen/subgroup/subgroup-edit/subgroup-edit.component';
import { SuperGroup1ListComponent } from '@product/screen/super-group1/super-group1-list/super-group1-list.component';
import { SuperGroup1EditComponent } from '@product/screen/super-group1/super-group1-edit/super-group1-edit.component';
import { SuperGroup2ListComponent } from '@product/screen/super-group2/super-group2-list/super-group2-list.component';
import { SuperGroup2EditComponent } from '@product/screen/super-group2/super-group2-edit/super-group2-edit.component';
import { SuperGroup3ListComponent } from '@product/screen/super-group3/super-group3-list/super-group3-list.component';
import { SuperGroup3EditComponent } from '@product/screen/super-group3/super-group3-edit/super-group3-edit.component';
import { UnitListComponent } from '@product/screen/unit/unit-list/unit-list.component';
import { UnitEditComponent } from '@product/screen/unit/unit-edit/unit-edit.component';
import { WarningListComponent } from '@product/screen/warning/warning-list/warning-list.component';
import { WarningEditComponent } from '@product/screen/warning/warning-edit/warning-edit.component';
import { ProductCampaignEditComponent } from './screen/product-campaign/product-campaign-edit/product-campaign-edit.component';
import { ProductCampaignListComponent } from './screen/product-campaign/product-campaign-list/product-campaign-list.component';
import { CountryService } from './service/country.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { environment } from 'environments/environment';
import { IntlModule } from '@progress/kendo-angular-intl';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { WarehouseModule } from '@warehouse/warehouse.module';
import { StockGroupNameListComponent } from '@product/screen/stock-group-name/stock-group-name-list/stock-group-name-list.component';
import { StockGroupNameEditComponent } from '@product/screen/stock-group-name/stock-group-name-edit/stock-group-name-edit.component';
import { StockGroupNameService } from '@product/service/stock-group-name.service';
import { ProductStockGroupListComponent } from '@product/screen/product-stock-group/product-stock-group-list/product-stock-group-list.component';
import { ProductStockGroupEditComponent } from '@product/screen/product-stock-group/product-stock-group-edit/product-stock-group-edit.component';
import { ProductStockGroupService } from '@product/service/product-stock-group.service';
import { FixtureListComponent } from '@product/screen/fixture/fixture-list/fixture-list.component';
import { FixtureEditComponent } from '@product/screen/fixture/fixture-edit/fixture-edit.component';
import { FixtureService } from '@product/service/fixture.service';
import { FixtureBrandListComponent } from '@product/screen/fixture-brand/fixture-brand-list/fixture-brand-list.component';
import { FixtureBrandEditComponent } from '@product/screen/fixture-brand/fixture-brand-edit/fixture-brand-edit.component';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { FixtureModelListComponent } from '@product/screen/fixture-model/fixture-model-list/fixture-model-list.component';
import { FixtureModelEditComponent } from '@product/screen/fixture-model/fixture-model-edit/fixture-model-edit.component';
import { FixtureModelService } from '@product/service/fixture-model.service';

const routes: Routes = [
  {
    'path': '',
    'component': ProductComponent,
    'children': [
      {
        'path': 'ProductBarcode/Index',
        'component': ProductBarcodeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'BarcodeType/Index',
        'component': BarcodeTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'BarcodeTypeInt/Index',
        'component': BarcodeTypeIntListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProductCategory/Index',
        'component': ProductCategoryListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Package/Index',
        'component': PackageListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Product/Index',
        'component': ProductListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProductProperty/Index',
        'component': ProductPropertyListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PropertyType/Index',
        'component': PropertyTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SeasonType/Index',
        'component': SeasonTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StorageCondition/Index',
        'component': StorageConditionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Subgroup/Index',
        'component': SubgroupListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SuperGroup1/Index',
        'component': SuperGroup1ListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SuperGroup2/Index',
        'component': SuperGroup2ListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SuperGroup3/Index',
        'component': SuperGroup3ListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Unit/Index',
        'component': UnitListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Warning/Index',
        'component': WarningListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProductCampaign/Index',
        'component': ProductCampaignListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StockGroupName/Index',
        'component': StockGroupNameListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProductStockGroup/Index',
        'component': ProductStockGroupListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Fixture/Index',
        'component': FixtureListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'FixtureBrand/Index',
        'component': FixtureBrandListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'FixtureModel/Index',
        'component': FixtureModelListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function ProductHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
  return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=PRD');
}

@NgModule({
    declarations: [
        ProductComponent,
        ProductBarcodeEditComponent,
        ProductBarcodeListComponent,
        BarcodeTypeEditComponent,
        BarcodeTypeListComponent,
        BarcodeTypeIntEditComponent,
        BarcodeTypeIntListComponent,
        ProductCategoryEditComponent,
        ProductCategoryListComponent,
        PackageEditComponent,
        PackageListComponent,
        ProductEditComponent,
        ProductListComponent,
        ProductPropertyEditComponent,
        ProductPropertyListComponent,
        PropertyTypeEditComponent,
        PropertyTypeListComponent,
        SeasonTypeEditComponent,
        SeasonTypeListComponent,
        StorageConditionEditComponent,
        StorageConditionListComponent,
        SubgroupEditComponent,
        SubgroupListComponent,
        SuperGroup1EditComponent,
        SuperGroup1ListComponent,
        SuperGroup2EditComponent,
        SuperGroup2ListComponent,
        SuperGroup3EditComponent,
        SuperGroup3ListComponent,
        UnitEditComponent,
        UnitListComponent,
        WarningEditComponent,
        WarningListComponent,
        ProductCampaignListComponent,
        ProductCampaignEditComponent,
        StockGroupNameEditComponent,
        StockGroupNameListComponent,
        ProductStockGroupEditComponent,
        ProductStockGroupListComponent,
        FixtureEditComponent,
        FixtureListComponent,
        FixtureBrandEditComponent,
        FixtureBrandListComponent,
        FixtureModelEditComponent,
        FixtureModelListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        ExcelModule,
        OTCommonModule,
        IntlModule,
        DateInputsModule,
        TranslateModule.forChild({
          loader: {
              provide: TranslateLoader,
              useFactory: ProductHttpLoaderFactory,
              deps: [HttpBackend, OTTranslationService]
          },
          isolate: true
      }),
      WarehouseModule
    ],
    exports: [
        RouterModule
    ],
    providers: [
        ProductBarcodeService,
        BarcodeTypeService,
        BarcodeTypeIntService,
        ProductCategoryService,
        PackageService,
        ProductService,
        ProductPropertyService,
        PropertyTypeService,
        SeasonTypeService,
        StorageConditionService,
        ProductCampaignService,
        SubgroupService,
        SuperGroup1Service,
        SuperGroup2Service,
        SuperGroup3Service,
        UnitService,
        WarningService,
        CountryService,
        StockGroupNameService,
        ProductStockGroupService,
        FixtureService,
        FixtureBrandService,
        FixtureModelService,
    ]
})
export class ProductModule {}
