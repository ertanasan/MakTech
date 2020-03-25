import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { OTCommandModule } from '@otuicontrol/command/ot-command.module';
import { OTContainerModule } from '@otuicontainer/ot-container.module';

import { EnterpriseAppComponent } from '@otui/application/enterprise-app/enterprise-app.component';
import { SimpleAppComponent } from '@otui/application/simple-app/simple-app.component';
import { ToolAppComponent } from '@otui/application/tool-app/tool-app.component';
import { OTLayoutModule } from '@otui/layout/ot-layout.module';
import { OTCommonModule } from '@otcommon/common.module';

@NgModule({
    declarations: [
        EnterpriseAppComponent,
        SimpleAppComponent,
        ToolAppComponent,
    ],
    imports: [
        OTCommonModule,
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        AngularFontAwesomeModule,
        OTCommandModule,
        OTContainerModule,
        OTLayoutModule
    ],
    exports: [
        EnterpriseAppComponent,
        SimpleAppComponent,
        ToolAppComponent
    ]
})
export class OTApplicationModule {
}
