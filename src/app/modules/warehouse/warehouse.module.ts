import { NgModule } from '@angular/core';

import { CommonModule, DatePipe, DecimalPipe } from '@angular/common';
import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import '@progress/kendo-angular-intl/locales/en/all';
import '@progress/kendo-angular-intl/locales/tr/all';
import { ScrollViewModule } from '@progress/kendo-angular-scrollview';
import { InputsModule } from '@progress/kendo-angular-inputs';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { GetNamePipe } from '@otcommon/pipe/get-name.pipe';
import { AppMainModule } from '@app-main/app-main.module';
import { WarehouseComponent } from '@warehouse/warehouse.component';
import { ShipmentScheduleListComponent } from '@warehouse/screen/shipment-schedule/shipment-schedule-list/shipment-schedule-list.component';
import { ShipmentScheduleEditComponent } from '@warehouse/screen/shipment-schedule/shipment-schedule-edit/shipment-schedule-edit.component';
import { ShipmentScheduleService } from '@warehouse/service/shipment-schedule.service';
import { ShipmentUnitListComponent } from '@warehouse/screen/shipment-unit/shipment-unit-list/shipment-unit-list.component';
import { ShipmentUnitEditComponent } from '@warehouse/screen/shipment-unit/shipment-unit-edit/shipment-unit-edit.component';
import { ShipmentUnitService } from '@warehouse/service/shipment-unit.service';
import { StoreOrderListComponent } from '@warehouse/screen/store-order/store-order-list/store-order-list.component';
import { StoreOrderEditComponent } from '@warehouse/screen/store-order/store-order-edit/store-order-edit.component';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrderDetailListComponent } from '@warehouse/screen/store-order-detail/store-order-detail-list/store-order-detail-list.component';
import { StoreOrderDetailEditComponent } from '@warehouse/screen/store-order-detail/store-order-detail-edit/store-order-detail-edit.component';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { StoreOrderHistoryListComponent } from '@warehouse/screen/store-order-history/store-order-history-list/store-order-history-list.component';
import { StoreOrderHistoryEditComponent } from '@warehouse/screen/store-order-history/store-order-history-edit/store-order-history-edit.component';
import { StoreOrderHistoryService } from '@warehouse/service/store-order-history.service';
import { StoreOrderStatusListComponent } from '@warehouse/screen/store-order-status/store-order-status-list/store-order-status-list.component';
import { StoreOrderStatusEditComponent } from '@warehouse/screen/store-order-status/store-order-status-edit/store-order-status-edit.component';
import { StoreOrderPrintComponent } from '@warehouse/screen/store-order-detail/store-order-print/store-order-print.component';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { ShipmentPackageTypeListComponent } from '@warehouse/screen/shipment-package-type/shipment-package-type-list/shipment-package-type-list.component';
import { ShipmentPackageTypeEditComponent } from '@warehouse/screen/shipment-package-type/shipment-package-type-edit/shipment-package-type-edit.component';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';
import { ShipmentTypeListComponent } from '@warehouse/screen/shipment-type/shipment-type-list/shipment-type-list.component';
import { ShipmentTypeEditComponent } from '@warehouse/screen/shipment-type/shipment-type-edit/shipment-type-edit.component';
import { ShipmentTypeService } from '@warehouse/service/shipment-type.service';
import { ProductShipmentUnitListComponent } from '@warehouse/screen/product-shipment-unit/product-shipment-unit-list/product-shipment-unit-list.component';
import { ProductShipmentUnitEditComponent } from '@warehouse/screen/product-shipment-unit/product-shipment-unit-edit/product-shipment-unit-edit.component';
import { ProductShipmentUnitService } from '@warehouse/service/product-shipment-unit.service';
import { OTPrintingService } from '@otservice/printing.service';
import { StockTakingListComponent } from '@warehouse/screen/stock-taking/stock-taking-list/stock-taking-list.component';
import { StockTakingEditComponent } from '@warehouse/screen/stock-taking/stock-taking-edit/stock-taking-edit.component';
import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { StorageZonesListComponent } from '@warehouse/screen/storage-zones/storage-zones-list/storage-zones-list.component';
import { StorageZonesEditComponent } from '@warehouse/screen/storage-zones/storage-zones-edit/storage-zones-edit.component';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { OrderSaleDashboardComponent } from './screen/order-sale-dashboard/order-sale-dashboard.component';
import { ConstraintTheoryComponent } from './screen/constraint-theory/constraint-theory.component';
import { SalesService } from '@sale/service/sales.service';
import { StoreOrderHistoryComponent } from './screen/store-order/store-order-history/store-order-history.component';
import { StockTakingScheduleListComponent } from '@warehouse/screen/stock-taking-schedule/stock-taking-schedule-list/stock-taking-schedule-list.component';
import { StockTakingScheduleEditComponent } from '@warehouse/screen/stock-taking-schedule/stock-taking-schedule-edit/stock-taking-schedule-edit.component';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { StockTrackingService } from '@warehouse/service/stock-tracking.service';
import { CountingStatusListComponent } from '@warehouse/screen/counting-status/counting-status-list/counting-status-list.component';
import { CountingStatusEditComponent } from '@warehouse/screen/counting-status/counting-status-edit/counting-status-edit.component';
import { CountingStatusService } from '@warehouse/service/counting-status.service';
import { CountingTypeListComponent } from '@warehouse/screen/counting-type/counting-type-list/counting-type-list.component';
import { CountingTypeEditComponent } from '@warehouse/screen/counting-type/counting-type-edit/counting-type-edit.component';
import { CountingTypeService } from '@warehouse/service/counting-type.service';
import { ConstraintExceptionListComponent } from '@warehouse/screen/constraint-exception/constraint-exception-list/constraint-exception-list.component';
import { ConstraintExceptionEditComponent } from '@warehouse/screen/constraint-exception/constraint-exception-edit/constraint-exception-edit.component';
import { ConstraintExceptionService } from '@warehouse/service/constraint-exception.service';
import { ProductCategoryService } from '@product/service/product-category.service';
import { SubgroupService } from '@product/service/subgroup.service';
import { StoreOrderGroupPrintComponent } from '@warehouse/screen/store-order/store-order-group-print/store-order-group-print.component';
import { CurrentStockReportComponent } from './screen/current-stock-report/current-stock-report.component';
import { BarcodeScannerComponent } from './screen/stock-taking/barcode-scanner/barcode-scanner';
import { BarecodeScannerLivestreamModule } from 'ngx-barcode-scanner';
import { ProductBarcodeService } from '@product/service/product-barcode.service';
import { ReturnReasonListComponent } from '@warehouse/screen/return-reason/return-reason-list/return-reason-list.component';
import { ReturnReasonEditComponent } from '@warehouse/screen/return-reason/return-reason-edit/return-reason-edit.component';
import { ReturnReasonService } from '@warehouse/service/return-reason.service';
import { ReturnStatusListComponent } from '@warehouse/screen/return-status/return-status-list/return-status-list.component';
import { ReturnStatusEditComponent } from '@warehouse/screen/return-status/return-status-edit/return-status-edit.component';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { ReturnDestinationListComponent } from '@warehouse/screen/return-destination/return-destination-list/return-destination-list.component';
import { ReturnDestinationEditComponent } from '@warehouse/screen/return-destination/return-destination-edit/return-destination-edit.component';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';
import { ProductReturnListComponent } from '@warehouse/screen/product-return/product-return-list/product-return-list.component';
import { ProductReturnEditComponent } from '@warehouse/screen/product-return/product-return-edit/product-return-edit.component';
import { ProductReturnService } from '@warehouse/service/product-return.service';
import { ReturnOrderListComponent } from '@warehouse/screen/return-order/return-order-list/return-order-list.component';
import { ReturnOrderEditComponent } from '@warehouse/screen/return-order/return-order-edit/return-order-edit.component';
import { ReturnOrderService } from '@warehouse/service/return-order.service';
import { ReturnOrderDialogComponent } from './screen/return-order/return-order-dialog/return-order-dialog.component';
import { OrderStatusHistoryService } from './service/order-status-history.service';
import { StockTrackingComponent } from './screen/stock-tracking/stock-tracking.component';
import { StockTrackingDialogComponent } from './screen/stock-tracking/stock-tracking-dialog/stock-tracking-dialog.component';
import { IntakeStatusListComponent } from '@warehouse/screen/intake-status/intake-status-list/intake-status-list.component';
import { IntakeStatusEditComponent } from '@warehouse/screen/intake-status/intake-status-edit/intake-status-edit.component';
import { IntakeStatusService } from '@warehouse/service/intake-status.service';
import { IntakeStatusTypeListComponent } from '@warehouse/screen/intake-status-type/intake-status-type-list/intake-status-type-list.component';
import { IntakeStatusTypeEditComponent } from '@warehouse/screen/intake-status-type/intake-status-type-edit/intake-status-type-edit.component';
import { IntakeStatusTypeService } from '@warehouse/service/intake-status-type.service';
import { SupplierListComponent } from './screen/supplier/supplier-list/supplier-list.component';
import { SupplierService } from './service/supplier.service';
import { SupplierTypeService } from './service/supplier-type.service';
import { SupplierEditComponent } from './screen/supplier/supplier-edit/supplier-edit.component';
import { ConsignmentGoodPurchaseListComponent } from '@warehouse/screen/consignment-good-purchase/consignment-good-purchase-list/consignment-good-purchase-list.component';
import { ConsignmentGoodPurchaseEditComponent } from '@warehouse/screen/consignment-good-purchase/consignment-good-purchase-edit/consignment-good-purchase-edit.component';
import { ConsignmentGoodPurchaseService } from '@warehouse/service/consignment-good-purchase.service';
import { DrillProductListComponent } from '@warehouse/screen/drill-product/drill-product-list/drill-product-list.component';
import { DrillProductEditComponent } from '@warehouse/screen/drill-product/drill-product-edit/drill-product-edit.component';
import { DrillProductService } from '@warehouse/service/drill-product.service';
import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';
import { TransferProductListComponent } from '@warehouse/screen/transfer-product/transfer-product-list/transfer-product-list.component';
import { TransferProductEditComponent } from '@warehouse/screen/transfer-product/transfer-product-edit/transfer-product-edit.component';
import { TransferProductService } from '@warehouse/service/transfer-product.service';
import { TransferProductDetailListComponent } from '@warehouse/screen/transfer-product-detail/transfer-product-detail-list/transfer-product-detail-list.component';
import { TransferProductDetailEditComponent } from '@warehouse/screen/transfer-product-detail/transfer-product-detail-edit/transfer-product-detail-edit.component';
import { TransferProductDetailService } from '@warehouse/service/transfer-product-detail.service';
import { TransferProductStatusService } from './service/transfer-product-status.service';
import { FakeOrderListComponent } from '@warehouse/screen/fake-order/fake-order-list/fake-order-list.component';
import { FakeOrderEditComponent } from '@warehouse/screen/fake-order/fake-order-edit/fake-order-edit.component';
import { FakeOrderService } from '@warehouse/service/fake-order.service';
import { ProductionListComponent } from '@warehouse/screen/production/production-list/production-list.component';
import { ProductionEditComponent } from '@warehouse/screen/production/production-edit/production-edit.component';
import { ProductionService } from '@warehouse/service/production.service';
import { ProductionContentListComponent } from '@warehouse/screen/production-content/production-content-list/production-content-list.component';
import { ProductionContentEditComponent } from '@warehouse/screen/production-content/production-content-edit/production-content-edit.component';
import { ProductionContentService } from '@warehouse/service/production-content.service';
import { ProductionOrderListComponent } from '@warehouse/screen/production-order/production-order-list/production-order-list.component';
import { ProductionOrderEditComponent } from '@warehouse/screen/production-order/production-order-edit/production-order-edit.component';
import { ProductionOrderService } from '@warehouse/service/production-order.service';
import { GatheringComponent } from './screen/gathering/gathering/gathering.component';
import { GatheringService } from './service/gathering.service';
import { GatheringDetailService } from './service/gathering-detail.service';
import { GatheringGridViewComponent } from './screen/gathering/gathering/gathering-grid-view/gathering-grid-view.component';
import { GatheringTabletViewComponent } from './screen/gathering/gathering/gathering-tablet-view/gathering-tablet-view.component';
import { GatheringControlComponent } from './screen/gathering/gathering-control/gathering-control.component';
import { GatheringAdminComponent } from './screen/gathering/gathering-admin/gathering-admin.component';
import { GatheringTypeService } from './service/gathering-type.service';
import { GatheringStats } from './model/gathering.model';
import { GatheringStatusService } from './service/gathering-status.service';
import { UserService } from '@frame/security/service/user.service';
import { GatheringAdminEditComponent } from './screen/gathering/gathering-admin/gathering-admin-edit/gathering-admin-edit.component';
import { ProductReturnHistoryComponent } from './screen/product-return/product-return-history/product-return-history.component';
import { GatheringPalletService } from './service/gathering-pallet.service';
import { GatheringPalletPhotoService } from '@warehouse/service/gathering-pallet-photo.service';
import { PalletPhotoComponent } from './screen/gathering/gathering-control/pallet-photo/pallet-photo.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { PrintPalletComponent } from './screen/gathering/gathering/print-pallet/print-pallet.component';
import { NgxQRCodeModule } from 'ngx-qrcode2';
import { WaybillPrintoutComponent } from './screen/gathering/gathering-admin/waybill-printout/waybill-printout.component';
import { MaterialCategoryListComponent } from '@warehouse/screen/material-category/material-category-list/material-category-list.component';
import { MaterialCategoryEditComponent } from '@warehouse/screen/material-category/material-category-edit/material-category-edit.component';
import { MaterialCategoryService } from '@warehouse/service/material-category.service';
import { MaterialListComponent } from '@warehouse/screen/material/material-list/material-list.component';
import { MaterialEditComponent } from '@warehouse/screen/material/material-edit/material-edit.component';
import { MaterialService } from '@warehouse/service/material.service';
import { MaterialOrderListComponent } from '@warehouse/screen/material-order/material-order-list/material-order-list.component';
import { MaterialOrderEditComponent } from '@warehouse/screen/material-order/material-order-edit/material-order-edit.component';
import { MaterialOrderService } from '@warehouse/service/material-order.service';
import { GatheringGridEntryComponent } from './screen/gathering/gathering/gathering-grid-entry/gathering-grid-entry.component';
import { ControlGridEntryComponent } from './screen/gathering/gathering-control/control-grid-entry/control-grid-entry.component';
import { LoadOrderListComponent } from './screen/load-order/load-order-list/load-order-list.component';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { MaterialInfoListComponent } from '@warehouse/screen/material-info/material-info-list/material-info-list.component';
import { MaterialInfoEditComponent } from '@warehouse/screen/material-info/material-info-edit/material-info-edit.component';
import { MaterialInfoService } from '@warehouse/service/material-info.service';
import { WarehouseDashboardComponent } from './screen/warehouse-dashboard/warehouse-dashboard.component';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';
import { WdashboardOrderComponent } from './screen/warehouse-dashboard/wdashboard-order/wdashboard-order.component';;
import { WdashboardHeavyComponent } from './screen/warehouse-dashboard/wdashboard-heavy/wdashboard-heavy.component'
import { WdashboardLightComponent } from './screen/warehouse-dashboard/wdashboard-light/wdashboard-light.component'
import { StockDashboardComponent } from './screen/stock-dashboard/stock-dashboard.component';
import { ContextMenuModule } from '@progress/kendo-angular-menu';
// import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';


const routes: Routes = [
    {
        'path': '',
        'component': WarehouseComponent,
        'children': [
            {
                'path': 'ShipmentSchedule/Index',
                'component': ShipmentScheduleListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ShipmentUnit/Index',
                'component': ShipmentUnitListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StoreOrder/Index',
                'component': StoreOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StoreOrderDetail/:orderid/:fromStore',
                'component': StoreOrderDetailListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StoreOrderHistory/Index',
                'component': StoreOrderHistoryListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StoreOrderStatus/Index',
                'component': StoreOrderStatusListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ShipmentPackageType/Index',
                'component': ShipmentPackageTypeListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ShipmentType/Index',
                'component': ShipmentTypeListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ProductShipmentUnit/Index',
                'component': ProductShipmentUnitListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StockTaking/:scheduleid/:fromStore',
                'component': StockTakingListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'BarcodeScanner/Index',
                'component': BarcodeScannerComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StorageZones/Index',
                'component': StorageZonesListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'OrderSaleDashboard/Index',
                'component': OrderSaleDashboardComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'CurrentStockReport/Index',
                'component': CurrentStockReportComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ConstraintTheory/Index',
                'component': ConstraintTheoryComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StockTakingSchedule/Index',
                'component': StockTakingScheduleListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'CountingStatus/Index',
                'component': CountingStatusListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'CountingType/Index',
                'component': CountingTypeListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ConstraintException/Index',
                'component': ConstraintExceptionListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ReturnReason/Index',
                'component': ReturnReasonListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ReturnStatus/Index',
                'component': ReturnStatusListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ReturnDestination/Index',
                'component': ReturnDestinationListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ProductReturn/:returnOrderId',
                'component': ProductReturnListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ReturnOrder/Index',
                'component': ReturnOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StockTracking/Index',
                'component': StockTrackingComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'IntakeStatus/Index',
                'component': IntakeStatusListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'IntakeStatusType/Index',
                'component': IntakeStatusTypeListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'DrillProduct/Index',
                'component': DrillProductListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Supplier/Index',
                'component': SupplierListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ConsignmentGoodPurchase/Index',
                'component': ConsignmentGoodPurchaseListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'TransferProduct/Index',
                'component': TransferProductListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'TransferProductDetail/Index',
                'component': TransferProductDetailListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'FakeOrder/Index',
                'component': FakeOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Production/Index',
                'component': ProductionListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ProductionContent/Index',
                'component': ProductionContentListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'ProductionOrder/Index',
                'component': ProductionOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Gathering/Index',
                'component': GatheringComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'GatheringControl/Index',
                'component': GatheringControlComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'GatheringControl/:controlPalletId',
                'component': GatheringControlComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'GatheringAdmin/Index',
                'component': GatheringAdminComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'MaterialCategory/Index',
                'component': MaterialCategoryListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Material/Index',
                'component': MaterialListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'MaterialOrder/Index',
                'component': MaterialOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'LoadOrder/Index',
                'component': LoadOrderListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'MaterialInfo/Index',
                'component': MaterialInfoListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'WarehouseDashboard/Index',
                'component': WarehouseDashboardComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'WdashboardOrder',
                'component': WdashboardOrderComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'WdashboardHeavy',
                'component': WdashboardHeavyComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'WdashboardLight',
                'component': WdashboardLightComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StockDashboard/Index',
                'component': StockDashboardComponent,
                'pathMatch': 'full'
            }
        ]
    }
];

export function WarehouseHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=WHS');
}

@NgModule({
    declarations: [
        WarehouseComponent,
        ShipmentScheduleEditComponent,
        ShipmentScheduleListComponent,
        ShipmentUnitEditComponent,
        ShipmentUnitListComponent,
        StoreOrderEditComponent,
        StoreOrderListComponent,
        StoreOrderDetailEditComponent,
        StoreOrderDetailListComponent,
        StoreOrderHistoryEditComponent,
        StoreOrderHistoryListComponent,
        StoreOrderStatusEditComponent,
        StoreOrderPrintComponent,
        StoreOrderGroupPrintComponent,
        StoreOrderStatusListComponent,
        ShipmentPackageTypeEditComponent,
        ShipmentPackageTypeListComponent,
        ShipmentTypeEditComponent,
        ShipmentTypeListComponent,
        ProductShipmentUnitEditComponent,
        ProductShipmentUnitListComponent,
        StockTakingEditComponent,
        StockTakingListComponent,
        StorageZonesEditComponent,
        StorageZonesListComponent,
        CurrentStockReportComponent,
        OrderSaleDashboardComponent,
        StoreOrderHistoryComponent,
        StockTakingScheduleEditComponent,
        StockTakingScheduleListComponent,
        CountingStatusEditComponent,
        CountingStatusListComponent,
        CountingTypeEditComponent,
        CountingTypeListComponent,
        ConstraintExceptionEditComponent,
        ConstraintExceptionListComponent,
        ConstraintTheoryComponent,
        BarcodeScannerComponent,
        ReturnReasonEditComponent,
        ReturnReasonListComponent,
        ReturnStatusEditComponent,
        ReturnStatusListComponent,
        ReturnDestinationEditComponent,
        ReturnDestinationListComponent,
        ProductReturnEditComponent,
        ProductReturnListComponent,
        ReturnOrderEditComponent,
        ReturnOrderListComponent,
        ReturnOrderDialogComponent,
        StockTrackingComponent,
        StockTrackingDialogComponent,
        IntakeStatusEditComponent,
        IntakeStatusListComponent,
        IntakeStatusTypeEditComponent,
        IntakeStatusTypeListComponent,
        DrillProductEditComponent,
        DrillProductListComponent,
        SupplierListComponent,
        SupplierEditComponent,
        ConsignmentGoodPurchaseEditComponent,
        ConsignmentGoodPurchaseListComponent,
        TransferProductEditComponent,
        TransferProductListComponent,
        TransferProductDetailEditComponent,
        TransferProductDetailListComponent,
        FakeOrderEditComponent,
        FakeOrderListComponent,
        GatheringComponent,
        GatheringGridViewComponent,
        GatheringGridEntryComponent,
        GatheringTabletViewComponent,
        ProductionEditComponent,
        ProductionListComponent,
        ProductionContentEditComponent,
        ProductionContentListComponent,
        ProductionOrderEditComponent,
        ProductionOrderListComponent,
        GatheringControlComponent,
        GatheringAdminComponent,
        GatheringAdminEditComponent,
        ProductReturnHistoryComponent,
        PalletPhotoComponent,
        PrintPalletComponent,
        WaybillPrintoutComponent,
        // ProcessHistoryComponent,
        MaterialCategoryEditComponent,
        MaterialCategoryListComponent,
        MaterialEditComponent,
        MaterialListComponent,
        MaterialOrderEditComponent,
        MaterialOrderListComponent,
        ControlGridEntryComponent,
        LoadOrderListComponent,
        MaterialInfoEditComponent,
        MaterialInfoListComponent,
        WarehouseDashboardComponent,
        WdashboardOrderComponent,
        WdashboardHeavyComponent,
        WdashboardLightComponent,
        StockDashboardComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        FormsModule,
        TranslateModule,
        GridModule,
        ExcelModule,
        DropDownsModule,
        ContextMenuModule, 
        LayoutModule,
        OTCommonModule,
        ButtonsModule,
        ChartsModule,
        TreeViewModule,
        ZXingScannerModule,
        BarecodeScannerLivestreamModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: WarehouseHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        DateInputsModule,
        AppMainModule,
        ScrollViewModule,
        InputsModule,
        NgxQRCodeModule,
        PartialsModule,
    ],
    exports: [
        RouterModule,
        ShipmentScheduleEditComponent,
        ShipmentScheduleListComponent,
        ProductShipmentUnitListComponent,
        ProductShipmentUnitEditComponent
    ],
    providers: [
        ShipmentScheduleService,
        ShipmentUnitService,
        StoreOrderService,
        StoreOrderDetailService,
        StoreOrderHistoryService,
        StoreOrderStatusService,
        StoreService,
        ProductService,
        ShipmentPackageTypeService,
        ShipmentTypeService,
        ProductShipmentUnitService,
        DatePipe,
        OTPrintingService,
        StockTakingService,
        StorageZonesService,
        SalesService,
        StockTakingScheduleService,
        StockTrackingService,
        CountingStatusService,
        CountingTypeService,
        ConstraintExceptionService,
        ProductCategoryService,
        SubgroupService,
        ProductBarcodeService,
        ReturnReasonService,
        ReturnStatusService,
        ReturnDestinationService,
        ProductReturnService,
        ReturnOrderService,
        OrderStatusHistoryService,
        IntakeStatusService,
        IntakeStatusTypeService,
        DrillProductService,
        SupplierService,
        SupplierTypeService,
        ConsignmentGoodPurchaseService,
        UnitService,
        TransferProductService,
        TransferProductDetailService,
        TransferProductStatusService,
        FakeOrderService,
        ProductionService,
        ProductionContentService,
        ProductionOrderService,
        GatheringService,
        GatheringDetailService,
        GatheringTypeService,
        GatheringStatusService,
        GatheringPalletService,
        GatheringPalletPhotoService,
        UserService,
        GetNamePipe,
        MaterialCategoryService,
        MaterialService,
        MaterialOrderService,
        SuperGroup1Service,
        SuperGroup2Service,
        SuperGroup3Service,
        MaterialInfoService,
        DecimalPipe,
    ]
})
export class WarehouseModule {
}
