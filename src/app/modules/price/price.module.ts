import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ReactiveFormsModule, NgControl, FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { IntlModule } from '@progress/kendo-angular-intl';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { UserService } from '@frame/security/service/user.service';
import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { OTPrintingService } from '@otservice/printing.service';
import { environment } from 'environments/environment';

import { PriceComponent } from '@price/price.component';
import { PriceLabelService } from '@price/service/price-label.service';
import { PricePackageService } from '@price/service/price-package.service';
import { PackageTypeService } from '@price/service/package-type.service';
import { PackageVersionService } from '@price/service/package-version.service';
import { ProductPriceService } from '@price/service/product-price.service';
import { StorePackageService } from '@price/service/store-package.service';
import { PriceLabelListComponent } from '@price/screen/price-label/price-label-list/price-label-list.component';
import { PriceLabelEditComponent } from '@price/screen/price-label/price-label-edit/price-label-edit.component';
import { PriceLabelPrintComponent } from '@price/screen/price-label/price-label-print/price-label-print.component';
import { PriceLabelPrintBigComponent } from '@price/screen/price-label/price-label-print-big/price-label-print-big.component';
import { PricePackageListComponent } from '@price/screen/price-package/price-package-list/price-package-list.component';
import { PricePackageEditComponent } from '@price/screen/price-package/price-package-edit/price-package-edit.component';
import { PackageTypeListComponent } from '@price/screen/package-type/package-type-list/package-type-list.component';
import { PackageTypeEditComponent } from '@price/screen/package-type/package-type-edit/package-type-edit.component';
import { PackageVersionListComponent } from '@price/screen/package-version/package-version-list/package-version-list.component';
import { PackageVersionEditComponent } from '@price/screen/package-version/package-version-edit/package-version-edit.component';
import { ProductPriceListComponent } from '@price/screen/product-price/product-price-list/product-price-list.component';
import { ProductPriceEditComponent } from '@price/screen/product-price/product-price-edit/product-price-edit.component';
import { StorePackageListComponent } from '@price/screen/store-package/store-package-list/store-package-list.component';
import { StorePackageEditComponent } from '@price/screen/store-package/store-package-edit/store-package-edit.component';
import { ProductService } from '@product/service/product.service';
import { StoreService } from '@store/service/store.service';
import { CurrentPricesService } from '@price/service/current-prices.service';
import { CurrentPricesListComponent } from '@price/screen/current-prices/current-prices-list/current-prices-list.component';
import { CurrentPricesEditComponent } from '@price/screen/current-prices/current-prices-edit/current-prices-edit.component';
import { PriceLabelPrintService } from '@price/service/price-label-print.service';
import { PriceSaleDashboardComponent } from '@price/screen/price-sale-dashboard/price-sale-dashboard.component';
import { PromotionTypeListComponent } from '@price/screen/promotion-type/promotion-type-list/promotion-type-list.component';
import { PromotionTypeEditComponent } from '@price/screen/promotion-type/promotion-type-edit/promotion-type-edit.component';
import { PromotionTypeService } from '@price/service/promotion-type.service';
import { PackagePromotionListComponent } from '@price/screen/package-promotion/package-promotion-list/package-promotion-list.component';
import { PackagePromotionEditComponent } from '@price/screen/package-promotion/package-promotion-edit/package-promotion-edit.component';
import { PackagePromotionService } from '@price/service/package-promotion.service';
import { PricePackagePrintComponent } from '@price/screen/price-package/price-package-print/price-package-print.component';
import { ProductPricePrintComponent } from '@price/screen/product-price/product-price-print/product-price-print.component';
import { CampaignPerformanceComponent } from '@price/screen/campaign-performance/campaign-performance.component';
import {DocumentService} from '@document/service/document.service';
import {NgxQRCodeModule} from 'ngx-qrcode2';

const routes: Routes = [
  {
    'path': '',
    'component': PriceComponent,
    'children': [
      {
        'path': 'PriceLabel/Index',
        'component': PriceLabelListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PricePackage/Index',
        'component': PricePackageListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PackageType/Index',
        'component': PackageTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PackageVersion/Index',
        'component': PackageVersionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProductPrice/Index',
        'component': ProductPriceListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StorePackage/Index',
        'component': StorePackageListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CurrentPrices/Index',
        'component': CurrentPricesListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PriceSaleDashboard/Index',
        'component': PriceSaleDashboardComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PromotionType/Index',
        'component': PromotionTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'PackagePromotion/Index',
        'component': PackagePromotionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CampaignPerformance/Index',
        'component': CampaignPerformanceComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function PriceHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=PRC');
}

@NgModule({
    declarations: [
        PriceComponent,
        PriceLabelPrintComponent,
        PriceLabelPrintBigComponent,
        PriceLabelEditComponent,
        PriceLabelListComponent,
        PricePackageEditComponent,
        PricePackageListComponent,
        PackageTypeEditComponent,
        PackageTypeListComponent,
        PackageVersionEditComponent,
        PackageVersionListComponent,
        ProductPriceEditComponent,
        ProductPriceListComponent,
        StorePackageEditComponent,
        StorePackageListComponent,
        CurrentPricesListComponent,
        CurrentPricesEditComponent,
        PriceSaleDashboardComponent,
        PromotionTypeEditComponent,
        PromotionTypeListComponent,
        PackagePromotionListComponent,
        PackagePromotionEditComponent,
        PricePackagePrintComponent,
        ProductPricePrintComponent,
        CampaignPerformanceComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        NgbModule,
        GridModule,
        ChartsModule,
        ExcelModule,
        OTCommonModule,
        TranslateModule,
        IntlModule,
        DateInputsModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: PriceHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        FormsModule,  // Imported for NgControl two way binding operator
        NgxQRCodeModule,
    ],
    exports: [
        RouterModule
    ],
    providers: [
        PriceLabelService,
        PricePackageService,
        PriceLabelPrintService,
        PackageTypeService,
        PackageVersionService,
        ProductPriceService,
        StorePackageService,
        ProductService,
        StoreService,
        CurrentPricesService,
        DatePipe,
        PromotionTypeService,
        PackagePromotionService,
        OTPrintingService,
        UserService,
        DocumentService,
    ]
})
export class PriceModule {}
