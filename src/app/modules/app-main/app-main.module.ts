import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ChartsModule } from '@progress/kendo-angular-charts';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { AppMainComponent } from './app-main.component';
import { AppMainRoutingModule } from './app-main-routing.module';

import { SalesService } from './../sale/service/sales.service';
import { ProfileScreenComponent } from './screen/profile/profile-screen.component';
import { ProfileService } from './service/profile.service';
import { DashboardComponent } from './screen/dashboard/dashboard.component';

import { environment } from 'environments/environment';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DashboardDetailComponent } from './screen/dashboard-details/dashboard-details.component';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { CategoryDetailComponent } from './screen/product-details/category-details.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DatePickerModule, DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ProductPriceService } from '@price/service/product-price.service';
import { ConfigurationService } from '@progress/kendo-angular-charts/dist/es2015/common/configuration.service';
import { PriceDetailComponent } from './screen/price-details/price-details.component';
import { StoreService } from '@store/service/store.service';
import { PriceLabelPrintService } from '@price/service/price-label-print.service';
import { PrintedLabelsComponent } from './screen/printed-labels/printed-labels.component';
import { CancelDetailComponent } from './screen/cancel-details/cancel-details.component';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { StoreDashboardComponent } from './screen/store-dashboard/store-dashboard.component';
import { StockoutProductDetailComponent } from './screen/store-dashboard/stockout-product-detail/stockout-product-detail.component';
import { StockTransactionDialogComponent } from './screen/store-dashboard/stock-transaction-dialog/stock-transaction-dialog.component';
import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { ProductStockDialogComponent } from './screen/store-dashboard/product-stock-dialog/product-stock-dialog.component';
import { NumericTextBoxModule } from '@progress/kendo-angular-inputs';
import { AuthorizationSummaryComponent } from './screen/authorization-summary/authorization-summary.component';
import { AuthenticationSummaryService } from './service/authentication-summary.service';
import { InboxComponent } from './screen/inbox/inbox.component';
import { OverStoreInboxService } from './service/overstore-inbox.service';
import { WorkqueueComponent } from './screen/inbox/workqueue.component';
import { CustomLoadingIconComponent } from './lib/shared/custom-loading-icon/custom-loading-icon.component';
import { DeviceDetectorModule } from 'ngx-device-detector';
import { GroupUserService } from '@frame/security/service/group-user.service';
import { GroupService } from '@frame/security/service/group.service';
import { DrillCountPerformanceComponent } from './screen/drill-count-performance/drill-count-performance.component';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { UserService } from '@frame/security/service/user.service';
import { SharedService } from './service/shared.service';
import { ProcessHistoryComponent } from './screen/process-history/process-history.component';
import { OverStoreScreenPropertyService } from './service/over-store-screen-property.service';
import { OverStoreScreenPropertyListComponent } from './screen/over-store-screen-property/over-store-screen-property-list/over-store-screen-property-list.component';
import { OverStoreScreenPropertyEditComponent } from './screen/over-store-screen-property/over-store-screen-property-edit/over-store-screen-property-edit.component';
import {OverStoreTaskListComponent} from '@app-main/screen/over-store-task/over-store-task-list/over-store-task-list.component';
import {OverStoreTaskEditComponent} from '@app-main/screen/over-store-task/over-store-task-edit/over-store-task-edit.component';
import {OverStoreTaskService} from '@app-main/service/over-store-task.service';
import {OverStoreTaskStatusService} from '@app-main/service/over-store-task-status.service';
import {OverStoreTaskTypeService} from '@app-main/service/over-store-task-type.service';
import {OverStoreTaskHistoryService} from '@app-main/service/over-store-task-history.service';
import {TaskDocumentService} from '@app-main/service/task-document.service';
import {TaskDocumentListComponent} from '@app-main/screen/task-document/task-document-list/task-document-list.component';
import {TaskDocumentEditComponent} from '@app-main/screen/task-document/task-document-edit/task-document-edit.component';
import { DocumentService } from '@frame/document/service/document.service';
import { OverStoreTaskTypeListComponent } from './screen/over-store-task-type/over-store-task-type-list/over-store-task-type-list.component';
import { OverStoreTaskTypeEditComponent } from './screen/over-store-task-type/over-store-task-type-edit/over-store-task-type-edit.component';
import { DashboardRouterComponent } from './lib/shared/dashboard-router/dashboard-router.component';
import { ApproveMessageBoxComponent } from './screen/approve-message-box/approve-message-box.component';
// import {QzTrayService} from '@app-main/service/qz-tray.service';

export function AppMainHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=app-main');
}

@NgModule({
    declarations: [
        ProfileScreenComponent,
        AppMainComponent,
        DashboardComponent,
        DashboardDetailComponent,
        CategoryDetailComponent,
        PriceDetailComponent,
        PrintedLabelsComponent,
        CancelDetailComponent,
        StoreDashboardComponent,
        StockoutProductDetailComponent,
        StockTransactionDialogComponent,
        ProductStockDialogComponent,
        AuthorizationSummaryComponent,
        InboxComponent,
        WorkqueueComponent,
        CustomLoadingIconComponent,
        DrillCountPerformanceComponent,
        ProcessHistoryComponent,
        ApproveMessageBoxComponent,
        OverStoreScreenPropertyListComponent,
        OverStoreScreenPropertyEditComponent,
        OverStoreTaskListComponent,
        OverStoreTaskEditComponent,
        TaskDocumentListComponent,
        TaskDocumentEditComponent,
        OverStoreTaskTypeListComponent,
        OverStoreTaskTypeEditComponent,
        DashboardRouterComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppMainRoutingModule,
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
        DeviceDetectorModule.forRoot(),
        ChartsModule,
        GridModule,
        ExcelModule,
        ButtonsModule,
        DatePickerModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: AppMainHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        OTCommonModule,
        DropDownsModule,
        NumericTextBoxModule,
        DateInputsModule
    ],
    exports: [
        ProfileScreenComponent,
        DashboardComponent,
        RouterModule,
        CustomLoadingIconComponent,
        ProcessHistoryComponent,
        DashboardRouterComponent,
        ApproveMessageBoxComponent,
    ],
    providers: [
        ProfileService,
        SalesService,
        ProductPriceService,
        DatePipe,
        StoreService,
        PriceLabelPrintService,
        SaleDetailService,
        StockTakingService,
        StockTakingScheduleService,
        AuthenticationSummaryService,
        // OverStoreInboxService,
        GroupUserService,
        GroupService,
        UserService,
        SharedService,
        OverStoreScreenPropertyService,
        OverStoreTaskService,
        OverStoreTaskStatusService,
        OverStoreTaskTypeService,
        OverStoreTaskHistoryService,
        TaskDocumentService,
        DocumentService,
        // QzTrayService,
    ]
})
export class AppMainModule {}
