import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { OTBaseComponent } from './base/ot-base.component';
import { BaseAppComponent } from './base-app/base-app.component';
import { BaseControlComponent } from './base-control/base-control.component';
import { ContainerComponent } from './container/container.component';

@NgModule({
    declarations: [
        OTBaseComponent,
        BaseAppComponent,
        BaseControlComponent,
        ContainerComponent

    ],
    imports: [
        CommonModule,
        ReactiveFormsModule
    ]
})
export class OTUICoreModule {

}
