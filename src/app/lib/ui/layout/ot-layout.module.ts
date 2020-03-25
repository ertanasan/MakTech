import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { EnterpriseLayoutComponent } from './enterprise-layout/enterprise-layout.component';

import { OTCommandModule } from '@otuicontrol/command/ot-command.module';
import { OTContainerModule } from '@otuicontainer/ot-container.module';
import { MenuService } from '@otservice/menu.service';
import { TenantService } from '@otservice/tenant.service';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ChartsModule } from 'ng2-charts';
import { LayoutHeaderSectionComponent } from './section/header/layout-header-section.component';
import { OTSidebarNavComponent } from './section/menu/ot-sidebar-nav.component';
import { OTCoreModule } from '@otcore/core.module';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

@NgModule({
    declarations: [
        EnterpriseLayoutComponent,
        LayoutHeaderSectionComponent,
        OTSidebarNavComponent
    ],
    imports: [
        OTCoreModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        OTCommandModule,
        OTContainerModule,
        PerfectScrollbarModule,
        ChartsModule,
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
    ],
    exports: [
        EnterpriseLayoutComponent,
        LayoutHeaderSectionComponent
    ],
    providers: [
        MenuService
    ]
})
export class OTLayoutModule {
}
