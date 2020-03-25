import { NgModule } from '@angular/core';

import { ProfileScreenComponent } from './screen/profile/profile-screen.component';
import { Routes, RouterModule } from '@angular/router';
import { AppMainComponent } from './app-main.component';
import { DashboardComponent } from './screen/dashboard/dashboard.component';
import { ReportScreenComponent } from '@otui/reporting/report-screen/report-screen.component';
import { DashboardDetailComponent } from './screen/dashboard-details/dashboard-details.component';
import { CategoryDetailComponent } from './screen/product-details/category-details.component';
import { PriceDetailComponent } from './screen/price-details/price-details.component';
import { PrintedLabelsComponent } from './screen/printed-labels/printed-labels.component';
import { CancelDetailComponent } from './screen/cancel-details/cancel-details.component';
import { StoreDashboardComponent } from './screen/store-dashboard/store-dashboard.component';
import { AuthorizationSummaryComponent } from './screen/authorization-summary/authorization-summary.component';
import { InboxComponent } from './screen/inbox/inbox.component';
import { DrillCountPerformanceComponent } from './screen/drill-count-performance/drill-count-performance.component';
import { OverStoreScreenPropertyListComponent } from './screen/over-store-screen-property/over-store-screen-property-list/over-store-screen-property-list.component';
import {OverStoreTaskListComponent} from '@app-main/screen/over-store-task/over-store-task-list/over-store-task-list.component';
import {OverStoreTaskTypeListComponent} from '@app-main/screen/over-store-task-type/over-store-task-type-list/over-store-task-type-list.component';

const routes: Routes = [
    {
        'path': '',
        'component': AppMainComponent,
        'children': [
            {
                'path': 'Dashboard/Index',
                'component': DashboardComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Profile/Index',
                'component': ProfileScreenComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'GetReport/:reportDescriptor',
                'component': ReportScreenComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'DashboardDetails/:detailId',
                'component': DashboardDetailComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'CategoryDetails/:categoryName',
                'component': CategoryDetailComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'PriceDetails/:deviceName/:groupId',
                'component': PriceDetailComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'PrintedLabels',
                'component': PrintedLabelsComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'DrillCountPerformance',
                'component': DrillCountPerformanceComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'CancelDetails/:start/:end',
                'component': CancelDetailComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'StoreDashboard/:storeId',
                'component': StoreDashboardComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'AuthorizationSummary/Index',
                'component': AuthorizationSummaryComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'OverStoreScreenProperty/Index',
                'component': OverStoreScreenPropertyListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'OverStoreTask/Index',
                'component': OverStoreTaskListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'OverStoreTaskType/Index',
                'component': OverStoreTaskTypeListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'Inbox/Index',
                'component': InboxComponent,
                'pathMatch': 'full'
            },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class AppMainRoutingModule {}
