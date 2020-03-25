import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { AccountingComponent } from '@accounting/accounting.component';
import { BankPosTransactionsListComponent } from '@accounting/screen/bank-pos-transactions/bank-pos-transactions-list/bank-pos-transactions-list.component';
import { BankPosTransactionsEditComponent } from '@accounting/screen/bank-pos-transactions/bank-pos-transactions-edit/bank-pos-transactions-edit.component';
import { BankPosTransactionsService } from '@accounting/service/bank-pos-transactions.service';
import { BankService } from '@store/service/bank.service';
import { ExcelFileListComponent } from '@accounting/screen/excel-file/excel-file-list/excel-file-list.component';
import { ExcelFileEditComponent } from '@accounting/screen/excel-file/excel-file-edit/excel-file-edit.component';
import { ExcelFileService } from '@accounting/service/excel-file.service';
import { ExcelFileColumnsListComponent } from '@accounting/screen/excel-file-columns/excel-file-columns-list/excel-file-columns-list.component';
import { ExcelFileColumnsEditComponent } from '@accounting/screen/excel-file-columns/excel-file-columns-edit/excel-file-columns-edit.component';
import { ExcelFileColumnsService } from '@accounting/service/excel-file-columns.service';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { LoomisListComponent } from '@accounting/screen/loomis/loomis-list/loomis-list.component';
import { LoomisEditComponent } from '@accounting/screen/loomis/loomis-edit/loomis-edit.component';
import { LoomisService } from '@accounting/service/loomis.service';
import { StoreService } from '@store/service/store.service';
import { BankStatementListComponent } from '@accounting/screen/bank-statement/bank-statement-list/bank-statement-list.component';
import { BankStatementEditComponent } from '@accounting/screen/bank-statement/bank-statement-edit/bank-statement-edit.component';
import { BankStatementService } from '@accounting/service/bank-statement.service';
import { PayrollListComponent } from '@accounting/screen/payroll/payroll-list/payroll-list.component';
import { PayrollEditComponent } from '@accounting/screen/payroll/payroll-edit/payroll-edit.component';
import { PayrollService } from '@accounting/service/payroll.service';
import { AccountingDepartmentListComponent } from '@accounting/screen/accounting-department/accounting-department-list/accounting-department-list.component';
import { AccountingDepartmentEditComponent } from '@accounting/screen/accounting-department/accounting-department-edit/accounting-department-edit.component';
import { AccountingDepartmentService } from '@accounting/service/accounting-department.service';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { EmployeeService } from '@store/service/employee.service';
import { SaleInvoiceListComponent } from '@accounting/screen/sale-invoice/sale-invoice-list/sale-invoice-list.component';
import { SaleInvoiceEditComponent, LimitToDirective } from '@accounting/screen/sale-invoice/sale-invoice-edit/sale-invoice-edit.component';
import { SaleInvoiceService } from '@accounting/service/sale-invoice.service';
import { SalesService } from '@sale/service/sales.service';
import { EInvoiceClientService } from './service/e-invoice-client.service';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { ExpenseCenterListComponent } from '@accounting/screen/expense-center/expense-center-list/expense-center-list.component';
import { ExpenseCenterEditComponent } from '@accounting/screen/expense-center/expense-center-edit/expense-center-edit.component';
import { ExpenseCenterService } from '@accounting/service/expense-center.service';
import { RegionManagersService } from '@store/service/region-managers.service';
import { FirmTypeListComponent } from '@accounting/screen/firm-type/firm-type-list/firm-type-list.component';
import { FirmTypeEditComponent } from '@accounting/screen/firm-type/firm-type-edit/firm-type-edit.component';
import { FirmTypeService } from '@accounting/service/firm-type.service';
import { FirmContactListComponent } from '@accounting/screen/firm-contact/firm-contact-list/firm-contact-list.component';
import { FirmContactEditComponent } from '@accounting/screen/firm-contact/firm-contact-edit/firm-contact-edit.component';
import { FirmContactService } from '@accounting/service/firm-contact.service';
import { FirmListComponent } from '@accounting/screen/firm/firm-list/firm-list.component';
import { FirmEditComponent } from '@accounting/screen/firm/firm-edit/firm-edit.component';
import { FirmService } from '@accounting/service/firm.service';
import { AppMainModule } from '@app-main/app-main.module';

const routes: Routes = [
  {
    'path': '',
    'component': AccountingComponent,
    'children': [
      {
        'path': 'BankPosTransactions/Index',
        'component': BankPosTransactionsListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ExcelFile/Index',
        'component': ExcelFileListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ExcelFileColumns/Index',
        'component': ExcelFileColumnsListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Loomis/Index',
        'component': LoomisListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'BankStatement/Index',
        'component': BankStatementListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Payroll/Index',
        'component': PayrollListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'AccountingDepartment/Index',
        'component': AccountingDepartmentListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'SaleInvoice/Index',
        'component': SaleInvoiceListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ExpenseCenter/Index',
        'component': ExpenseCenterListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'FirmType/Index',
        'component': FirmTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'FirmContact/Index',
        'component': FirmContactListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Firm/Index',
        'component': FirmListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function AccountingHttpLoaderFactory(httpClient: HttpClient, translationService: OTTranslationService) {
    return new OTTranslateLoader(httpClient, translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=ACC');
}

@NgModule({
    declarations: [
        AccountingComponent,
        BankPosTransactionsEditComponent,
        BankPosTransactionsListComponent,
        ExcelFileEditComponent,
        ExcelFileListComponent,
        ExcelFileColumnsEditComponent,
        ExcelFileColumnsListComponent,
        LoomisEditComponent,
        LoomisListComponent,
        BankStatementEditComponent,
        BankStatementListComponent,
        PayrollEditComponent,
        PayrollListComponent,
        AccountingDepartmentEditComponent,
        AccountingDepartmentListComponent,
        SaleInvoiceEditComponent,
        SaleInvoiceListComponent,
        LimitToDirective,
        ExpenseCenterEditComponent,
        ExpenseCenterListComponent,
        FirmTypeEditComponent,
        FirmTypeListComponent,
        FirmContactEditComponent,
        FirmContactListComponent,
        FirmEditComponent,
        FirmListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        DatePickerModule,
        DropDownsModule,
        ButtonsModule,
        InputsModule,
        OTCommonModule,
        AppMainModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: AccountingHttpLoaderFactory,
                deps: [HttpClient, OTTranslationService]
            },
            isolate: true
        }),
    ],
    exports: [
        RouterModule
    ],
    providers: [
        BankService,
        BankPosTransactionsService,
        ExcelFileService,
        DatePipe,
        ExcelFileColumnsService,
        LoomisService,
        StoreService,
        BankStatementService,
        PayrollService,
        AccountingDepartmentService,
        EmployeeService,
        SaleInvoiceService,
        SalesService,
        SaleDetailService,
        EInvoiceClientService,
        ExpenseCenterService,
        RegionManagersService,
        FirmTypeService,
        FirmContactService,
        FirmService,
    ]
})
export class AccountingModule {}
