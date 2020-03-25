import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, DatePipe, CurrencyPipe } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { ReconciliationComponent } from '@reconciliation/reconciliation.component';

import { StoreReconciliationService } from '@reconciliation/service/store-reconciliation.service';
import { StoreReconciliationEditComponent } from '@reconciliation/screen/store-reconciliation/store-reconciliation-edit/store-reconciliation-edit.component';
import { StoreReconciliationListComponent } from './screen/store-reconciliation/store-reconciliation-list/store-reconciliation-list.component';
import { StoreService } from '@store/service/store.service';
import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { environment } from 'environments/environment';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { StoreReconciliationEntry } from './screen/store-reconciliation/store-reconciliation-entry/store-reconciliation-entry.component';
import { ReconciliationReportComponent } from './screen/store-reconciliation/store-reconciliation-report/store-reconciliation-report';
import { ChartModule, ChartsModule } from '@progress/kendo-angular-charts';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { SaleDailySummaryService } from '@sale/service/sale-daily-summary.service';
import { ExpenseTypeListComponent } from '@reconciliation/screen/expense-type/expense-type-list/expense-type-list.component';
import { ExpenseTypeEditComponent } from '@reconciliation/screen/expense-type/expense-type-edit/expense-type-edit.component';
import { ExpenseTypeService } from '@reconciliation/service/expense-type.service';
import { ExpenseListComponent } from '@reconciliation/screen/expense/expense-list/expense-list.component';
import { ExpenseEditComponent } from '@reconciliation/screen/expense/expense-edit/expense-edit.component';
import { ExpenseService } from '@reconciliation/service/expense.service';
import { BanknoteListComponent } from '@reconciliation/screen/banknote/banknote-list/banknote-list.component';
import { BanknoteEditComponent } from '@reconciliation/screen/banknote/banknote-edit/banknote-edit.component';
import { BanknoteService } from '@reconciliation/service/banknote.service';
import { ReconciliationListComponent } from '@reconciliation/screen/reconciliation/reconciliation-list/reconciliation-list.component';
import { ReconciliationEditComponent } from '@reconciliation/screen/reconciliation/reconciliation-edit/reconciliation-edit.component';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { CashDistributionListComponent } from '@reconciliation/screen/cash-distribution/cash-distribution-list/cash-distribution-list.component';
import { CashDistributionEditComponent } from '@reconciliation/screen/cash-distribution/cash-distribution-edit/cash-distribution-edit.component';
import { CashDistributionService } from '@reconciliation/service/cash-distribution.service';
import { DiffReasonListComponent } from '@reconciliation/screen/diff-reason/diff-reason-list/diff-reason-list.component';
import { DiffReasonEditComponent } from '@reconciliation/screen/diff-reason/diff-reason-edit/diff-reason-edit.component';
import { DiffReasonService } from '@reconciliation/service/diff-reason.service';
import { CardDistributionListComponent } from '@reconciliation/screen/card-distribution/card-distribution-list/card-distribution-list.component';
import { CardDistributionEditComponent } from '@reconciliation/screen/card-distribution/card-distribution-edit/card-distribution-edit.component';
import { CardDistributionService } from '@reconciliation/service/card-distribution.service';
import { ReconciliationViewComponent } from './screen/reconciliation/reconciliation-view/reconciliation-view.component';
import { AdjustmentListComponent } from '@reconciliation/screen/adjustment/adjustment-list/adjustment-list.component';
import { AdjustmentEditComponent } from '@reconciliation/screen/adjustment/adjustment-edit/adjustment-edit.component';
import { AdjustmentService } from '@reconciliation/service/adjustment.service';
import { ZetImageComponent } from '@reconciliation/screen/zet-image/zet-image.component';
import { ZetImageViewComponent } from '@reconciliation/screen/zet-image-view/zet-image-view.component';
import { DaysOffListComponent } from '@reconciliation/screen/days-off/days-off-list/days-off-list.component';
import { DaysOffEditComponent } from '@reconciliation/screen/days-off/days-off-edit/days-off-edit.component';
import { DaysOffService } from '@reconciliation/service/days-off.service';
import { ExpenseTransferListComponent } from './screen/expense-transfer/expense-transfer-list/expense-transfer-list.component';
import { ExpenseTransferEditComponent } from './screen/expense-transfer/expense-transfer-edit/expense-transfer-edit.component';
import { RegionManagersService } from '@store/service/region-managers.service';
import { AppMainModule } from '@app-main/app-main.module';
import { ExpenseDetailComponent } from './screen/expense-detail/expense-detail.component';
import { UsersStoresService } from '@store/service/users-stores.service';
import { UserService } from '@frame/security/service/user.service';
import { ExpenseTransferPreviewComponent } from './screen/expense-transfer/expense-transfer-preview/expense-transfer-preview.component';
import { VatGroupService } from './service/vat-group.service';
import { ExpenseGridItemComponent } from './screen/expense-detail/expense-grid-item/expense-grid-item.component';
import { ExpenseChartItemComponent } from './screen/expense-detail/expense-chart-item/expense-chart-item.component';
import { CancelReasonService } from '@sale/service/cancel-reason.service';
import { SaleInvoiceService } from '@accounting/service/sale-invoice.service';
import { PortletModule } from '@otlib/metronic/views/partials/content/general/portlet/portlet.module';

const routes: Routes = [
  {
    'path': '',
    'component': ReconciliationComponent,
    'children': [
      {
        'path': '',
        'component': StoreReconciliationEditComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ReconciliationList/Index',
        'component': StoreReconciliationListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Reconciliation/Index',
        'component': StoreReconciliationEntry,
        'pathMatch': 'full'
      },
      {
        'path': 'ExpenseType/Index',
        'component': ExpenseTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Expense/Index',
        'component': ExpenseListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ExpenseTransfer/Index',
        'component': ExpenseTransferListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Banknote/Index',
        'component': BanknoteListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreReconciliation/Index',
        'component': ReconciliationListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'StoreReconciliationView/Index',
        'component': ReconciliationViewComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CashDistribution/Index',
        'component': CashDistributionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'DiffReason/Index',
        'component': DiffReasonListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'CardDistribution/Index',
        'component': CardDistributionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Adjustment/Index',
        'component': AdjustmentListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ZetImage/Index',
        'component': ZetImageComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'DaysOff/Index',
        'component': DaysOffListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ExpenseDetail/Index',
        'component': ExpenseDetailComponent,
        'pathMatch': 'full'
      }
    ]
  }
];
export function ReconciliationHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=RCL');
}
@NgModule({
    declarations: [
        ReconciliationComponent,
        StoreReconciliationEditComponent,
        StoreReconciliationListComponent,
        StoreReconciliationEntry,
        ReconciliationReportComponent,
        ExpenseTypeEditComponent,
        ExpenseTypeListComponent,
        ExpenseEditComponent,
        ExpenseListComponent,
        ExpenseTransferEditComponent,
        ExpenseTransferListComponent,
        BanknoteEditComponent,
        BanknoteListComponent,
        ReconciliationEditComponent,
        ReconciliationListComponent,
        ReconciliationViewComponent,
        CashDistributionEditComponent,
        CashDistributionListComponent,
        DiffReasonEditComponent,
        DiffReasonListComponent,
        CardDistributionEditComponent,
        CardDistributionListComponent,
        AdjustmentEditComponent,
        AdjustmentListComponent,
        ZetImageComponent,
        ZetImageViewComponent,
        DaysOffEditComponent,
        DaysOffListComponent,
        ExpenseDetailComponent,
        ExpenseGridItemComponent,
        ExpenseChartItemComponent,
        ExpenseTransferPreviewComponent,
      ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        GridModule,
        ChartsModule,
        ExcelModule,
        InputsModule,
        DateInputsModule,
        FormsModule,
        ButtonsModule,
        PortletModule,
        OTCommonModule,
        DateInputsModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: ReconciliationHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        AppMainModule
    ],
    exports: [
        RouterModule
    ],
    providers: [
        StoreService,
        UsersStoresService,
        UserService,
        StoreReconciliationService,
        DatePipe,
        CurrencyPipe,
        ExpenseTypeService,
        ExpenseService,
        BanknoteService,
        ReconciliationService,
        CashDistributionService,
        SaleDailySummaryService,
        DiffReasonService,
        CardDistributionService,
        AdjustmentService,
        StoreCashRegisterService,
        DaysOffService,
        RegionManagersService,
        VatGroupService,
        CancelReasonService,
        SaleInvoiceService,
    ]
})
export class ReconciliationModule {}
