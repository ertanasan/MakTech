import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductInfoComponent } from './screen/product-info/product-info.component';
import {RouterModule, Routes} from '@angular/router';
import {ProductComponent} from '@product/product.component';
import {ProductBarcodeListComponent} from '@product/screen/product-barcode/product-barcode-list/product-barcode-list.component';
import {BarcodeTypeListComponent} from '@product/screen/barcode-type/barcode-type-list/barcode-type-list.component';
import {BarcodeTypeIntListComponent} from '@product/screen/barcode-type-int/barcode-type-int-list/barcode-type-int-list.component';
import {ProductCategoryListComponent} from '@product/screen/product-category/product-category-list/product-category-list.component';
import {PackageListComponent} from '@product/screen/package/package-list/package-list.component';
import {ProductListComponent} from '@product/screen/product/product-list/product-list.component';
import {ProductPropertyListComponent} from '@product/screen/product-property/product-property-list/product-property-list.component';
import {PropertyTypeListComponent} from '@product/screen/property-type/property-type-list/property-type-list.component';
import {SeasonTypeListComponent} from '@product/screen/season-type/season-type-list/season-type-list.component';
import {StorageConditionListComponent} from '@product/screen/storage-condition/storage-condition-list/storage-condition-list.component';
import {SubgroupListComponent} from '@product/screen/subgroup/subgroup-list/subgroup-list.component';
import {SuperGroup1ListComponent} from '@product/screen/super-group1/super-group1-list/super-group1-list.component';
import {SuperGroup2ListComponent} from '@product/screen/super-group2/super-group2-list/super-group2-list.component';
import {SuperGroup3ListComponent} from '@product/screen/super-group3/super-group3-list/super-group3-list.component';
import {UnitListComponent} from '@product/screen/unit/unit-list/unit-list.component';
import {WarningListComponent} from '@product/screen/warning/warning-list/warning-list.component';
import {ProductCampaignListComponent} from '@product/screen/product-campaign/product-campaign-list/product-campaign-list.component';
import {StockGroupNameListComponent} from '@product/screen/stock-group-name/stock-group-name-list/stock-group-name-list.component';
import {ProductStockGroupListComponent} from '@product/screen/product-stock-group/product-stock-group-list/product-stock-group-list.component';
import {FixtureListComponent} from '@product/screen/fixture/fixture-list/fixture-list.component';
import {HttpBackend, HttpClient} from '@angular/common/http';
import {OTTranslationService} from '@parameter/service/ot-translation.service';
import {OTTranslateLoader} from '@parameter/service/ot-translateloader';
import {environment} from '../../../environments/environment';
import {PublicOperationsComponent} from './public-operations.component';
import { PublicProductService } from './service/public-product.service';
import {OTCommonModule} from '@otcommon/common.module';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {AppMainModule} from '@app-main/app-main.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {GridModule} from '@progress/kendo-angular-grid';

const routes: Routes = [
  {
    'path': '',
    'component': PublicOperationsComponent,
    'children': [
      {
        'path': 'ProductInfo/:productId',
        'component': ProductInfoComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function POPHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
  return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=POP');
}


@NgModule({
  declarations: [
      PublicOperationsComponent,
      ProductInfoComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    GridModule,
    OTCommonModule,
    FormsModule,
    AppMainModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: POPHttpLoaderFactory,
        deps: [HttpBackend, OTTranslationService]
      },
      isolate: true
    }),
  ],
  exports: [
    RouterModule
  ],
  providers: [
      PublicProductService
  ]
})
export class PublicOperationsModule { }
