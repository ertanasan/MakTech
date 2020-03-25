import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '@otlib/auth/service/auth-guard.service';
import { ThemeComponent } from './theme/theme.component';
import { DynamicComponentManifest } from '@otui/dynamic-component-loader/dynamic-component-manifest';
import { DynamicComponentLoaderModule } from '@otui/dynamic-component-loader/dynamic-component-loader.module';

const childRoutes: Routes = [
  {
      'path': '',
      'component': ThemeComponent,
      'canActivate': [AuthGuard],
      'children': [
        {
            'path': 'OverStoreMain',
            'loadChildren': '.\/modules\/app-main\/app-main.module#AppMainModule'
        },
        {
            'path': 'Store',
            'loadChildren': '.\/modules\/store\/store.module#StoreModule'
        },
        {
            'path': 'StoreUpload',
            'loadChildren': '.\/modules\/store-upload\/store-upload.module#StoreUploadModule'
        },
        {
            'path': 'Product',
            'loadChildren': '.\/modules\/product\/product.module#ProductModule'
        },
        {
            'path': 'Reconciliation',
            'loadChildren': '.\/modules\/reconciliation\/reconciliation.module#ReconciliationModule'
        },
        {
            'path': 'Sale',
            'loadChildren': '.\/modules\/sale\/sale.module#SaleModule'
        },
        {
            'path': 'Price',
            'loadChildren': '.\/modules\/price\/price.module#PriceModule'
        },
        {
            'path': 'Warehouse',
            'loadChildren': '.\/modules\/warehouse\/warehouse.module#WarehouseModule'
        },
        {
            'path': 'Announcement',
            'loadChildren': '.\/modules\/announcement\/announcement.module#AnnouncementModule'
        },
        {
            'path': 'Accounting',
            'loadChildren': '.\/modules\/accounting\/accounting.module#AccountingModule'
        },
        {
            'path': 'Gamification',
            'loadChildren': '.\/modules\/gamification\/gamification.module#GamificationModule'
        },
        {
            'path': 'Helpdesk',
            'loadChildren': '.\/modules\/helpdesk\/helpdesk.module#HelpdeskModule'
        },
        {
            'path': 'Finance',
            'loadChildren': '.\/modules\/finance\/finance.module#FinanceModule'
        },
        {
            'path': 'DynamicReport',
            'loadChildren': '.\/modules\/app-main\/app-main.module#AppMainModule'
        }
        //   {
        //       'path': '404',
        //       'loadChildren': '.\/theme\/pages\/default\/not-found\/not-found.module#NotFoundModule'
        //   }
      ]
  },
    {
        'path': 'PublicOperations',
        'loadChildren': '.\/modules\/public-operations\/public-operations.module#PublicOperationsModule'
    },
  {
      'path': '**',
      'redirectTo': '404',
      'pathMatch': 'full'
  }
];
const manifests: DynamicComponentManifest[] = [
    {
        componentId: 'Warehouse',
        path: 'dynamic-Warehouse', // some globally-unique identifier, used internally by the router
        loadChildren: './modules/warehouse/warehouse.module#WarehouseModule',
    },
    {
        componentId: 'Announcement',
        path: 'dynamic-Announcement', // some globally-unique identifier, used internally by the router
        loadChildren: './modules/announcement/announcement.module#AnnouncementModule',
    },
    {
        componentId: 'Helpdesk',
        path: 'dynamic-Helpdesk', // some globally-unique identifier, used internally by the router
        loadChildren: './modules/helpdesk/helpdesk.module#HelpdeskModule',
    },
    {
        componentId: 'Accounting',
        path: 'dynamic-Accounting', // some globally-unique identifier, used internally by the router
        loadChildren: './modules/accounting/accounting.module#AccountingModule',
    },
    {
        componentId: 'AppMainModule',
        path: 'dynamic-AppMainModule', // some globally-unique identifier, used internally by the router
        loadChildren: './modules/app-main/app-main.module#AppMainModule',
    },
  ];

@NgModule({
    imports: [RouterModule.forChild(childRoutes),
                DynamicComponentLoaderModule.forRoot(manifests)],
    exports: [RouterModule]
})
export class LazyRoutingModule { }
