import { NotificationListComponent } from '@announcement/screen/notification/notification-list/notification-list.component';
import { SuggestionListComponent } from '@announcement/screen/suggestion/suggestion-list/suggestion-list.component';
import { TransferProductListComponent } from '@warehouse/screen/transfer-product/transfer-product-list/transfer-product-list.component';
import { ProductReturnListComponent } from '@warehouse/screen/product-return/product-return-list/product-return-list.component';
import { ProductionOrderListComponent } from '@warehouse/screen/production-order/production-order-list/production-order-list.component';
import { HelpdeskRequestListComponent } from '@helpdesk/screen/helpdesk-request/helpdesk-request-list/helpdesk-request-list.component';
import { SaleInvoiceListComponent } from '@accounting/screen/sale-invoice/sale-invoice-list/sale-invoice-list.component';
import {OverStoreTaskListComponent} from '@app-main/screen/over-store-task/over-store-task-list/over-store-task-list.component';

export const componentMap = {
  'ProductReturnListComponent': ProductReturnListComponent,
  'NotificationListComponent': NotificationListComponent,
  'SuggestionListComponent': SuggestionListComponent,
  'TransferProductListComponent': TransferProductListComponent,
  'ProductionOrderListComponent': ProductionOrderListComponent,
  'HelpdeskRequestListComponent': HelpdeskRequestListComponent,
  'SaleInvoiceListComponent': SaleInvoiceListComponent,
  'OverStoreTaskListComponent': OverStoreTaskListComponent,
};
