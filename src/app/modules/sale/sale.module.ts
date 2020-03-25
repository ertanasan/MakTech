import { NgModule } from '@angular/core';
import { DatePipe } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { OTCommonModule } from '@otcommon/common.module';
import { SaleComponent } from '@sale/sale.component';
import { SalesService } from '@sale/service/sales.service';
import { SalesListComponent } from '@sale/screen/sales/sales-list/sales-list.component';
import { SalesEditComponent } from '@sale/screen/sales/sales-edit/sales-edit.component';
import { StoreService } from '@store/service/store.service';
import { TransactionTypeService } from './service/transaction-type.service';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { SaleDailySummaryListComponent } from '@sale/screen/sale-daily-summary/sale-daily-summary-list/sale-daily-summary-list.component';
import { SaleDailySummaryEditComponent } from '@sale/screen/sale-daily-summary/sale-daily-summary-edit/sale-daily-summary-edit.component';
import { SaleDailySummaryService } from '@sale/service/sale-daily-summary.service';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { SaleDetailListComponent } from '@sale/screen/sale-detail/sale-detail-list/sale-detail-list.component';
import { SaleDetailEditComponent } from '@sale/screen/sale-detail/sale-detail-edit/sale-detail-edit.component';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { UnitService } from '@product/service/unit.service';
import { SaleSummaryDashboardComponent } from '@sale/screen/sale-summary-dashboard/sale-summary-dashboard.component';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { environment } from 'environments/environment';
import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { StockOutComponent } from './screen/stock-out/stock-out.component';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { ProductCategoryService } from '@product/service/product-category.service';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { ProductService } from '@product/service/product.service';
import { SaleIdDate } from './service/sale-id-date.service';
import { MikroTransferComponent } from './screen/mikro-transfer/mikro-transfer.component';
import { MikroTransferService } from './service/mikro-transfer.service';
import { CancelReasonListComponent } from './screen/cancel-reason/cancel-reason-list/cancel-reason-list.component';
import { CancelReasonEditComponent } from './screen/cancel-reason/cancel-reason-edit/cancel-reason-edit.component';
import { CancelReasonService } from './service/cancel-reason.service';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { SaleCustomerListComponent } from '@sale/screen/sale-customer/sale-customer-list/sale-customer-list.component';
import { SaleCustomerEditComponent } from '@sale/screen/sale-customer/sale-customer-edit/sale-customer-edit.component';
import { SaleCustomerService } from '@sale/service/sale-customer.service';
import { UserService } from '@frame/security/service/user.service';



const routes: Routes = [
  {
    'path': '',
    'component': SaleComponent,
    'children': [
      {
        'path': 'Sales/Index',
        'component': SalesListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Sales/:transactionDate/:storeId',
        'component': SalesListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SaleDailySummary/Index',
        'component': SaleDailySummaryListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StockOutReport/Index',
        'component': StockOutComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SaleSummaryDashboard/Index',
        'component': SaleSummaryDashboardComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SaleDetail/:saleId',
        'component': SaleDetailListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'MikroTransfer/Index',
        'component': MikroTransferComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CancelReason/Index',
        'component': CancelReasonListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SaleCustomer/Index',
        'component': SaleCustomerListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function SaleHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
  return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=SLS');
}

@NgModule({
    declarations: [
        SaleComponent,
        SalesEditComponent,
        SalesListComponent,
        SaleDailySummaryEditComponent,
        SaleDailySummaryListComponent,
        SaleDetailEditComponent,
        SaleDetailListComponent,
        SaleSummaryDashboardComponent,
        StockOutComponent,
        MikroTransferComponent,
        CancelReasonEditComponent,
        CancelReasonListComponent,
        SaleCustomerEditComponent,
        SaleCustomerListComponent,
    ],
    imports: [
        FormsModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        GridModule,
        ExcelModule,
        ChartsModule,
        InputsModule,
        OTCommonModule,
        TranslateModule,
        DatePickerModule,
        ExcelModule,
        TranslateModule.forChild({
          loader: {
              provide: TranslateLoader,
              useFactory: SaleHttpLoaderFactory,
              deps: [HttpBackend, OTTranslationService]
          },
          isolate: true
      }),
    ],
    exports: [
        RouterModule
    ],
    providers: [
        SalesService,
        StoreService,
        TransactionTypeService,
        StoreCashRegisterService,
        SaleDailySummaryService,
        DatePipe,
        SaleDetailService,
        ProductCategoryService,
        UnitService,
        StoreOrderService,
        ProductService,
        SaleIdDate,
        MikroTransferService,
        CancelReasonService,
        ReconciliationService,
        SaleCustomerService,
        UserService,
    ]
})
export class SaleModule {}
