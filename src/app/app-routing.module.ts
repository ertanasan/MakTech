import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '@otlib/auth/service/auth-guard.service';
import { EnterpriseLayoutComponent } from '@otui/layout/enterprise-layout/enterprise-layout.component';

const rootRoutes: Routes = [
    { path: '', redirectTo: '/OverStoreMain/Dashboard/Index', pathMatch: 'full' }
];


@NgModule({
    imports: [
        RouterModule.forRoot(rootRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {

}
