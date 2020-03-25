import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';

import { MenuService } from '@otservice/menu.service';
import { OTMenuModule } from '@otuicontrol/menu/ot-menu-module';
import { SectionComponent } from './section/section.component';
import { HeaderNotificationComponent } from './header-section/header-notification/header-notification.component';
import { HeaderQuickactionsComponent } from './header-section/header-quickactions/header-quickactions.component';
import { HeaderLanguageComponent } from './header-section/header-language/header-language.component';
import { HeaderProfileComponent } from './header-section/header-profile/header-profile.component';
import { OTCoreModule } from '@otcore/core.module';
import { TenantService } from '@otservice/tenant.service';

@NgModule({
    declarations: [
        SectionComponent,
        HeaderNotificationComponent,
        HeaderQuickactionsComponent,
        HeaderLanguageComponent,
        HeaderProfileComponent,
    ],
    imports: [
        CommonModule,
        OTCoreModule,
        ReactiveFormsModule,
        RouterModule,
        OTMenuModule,
        BsDropdownModule.forRoot(),
        TabsModule.forRoot(),
    ],
    exports: [
        SectionComponent,
        HeaderProfileComponent,
        HeaderLanguageComponent,
        HeaderNotificationComponent
    ],
    providers: [
        MenuService
    ]
})
export class OTSectionModule {}
