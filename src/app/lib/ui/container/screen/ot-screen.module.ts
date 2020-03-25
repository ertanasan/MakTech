import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { GridModule } from '@progress/kendo-angular-grid';

import { EditScreenContainerComponent } from './edit-screen-container/edit-screen-container.component';
import { FormScreenContainerComponent } from './form-screen-container/form-screen-container.component';
import { ListScreenContainerComponent } from './list-screen-container/list-screen-container.component';
import { ViewScreenContainerComponent } from './view-screen-container/view-screen-container.component';
import { BaseScreenContainerComponent } from './base-screen-container/base-screen-container.component';
import { OTControlModule } from '../../control/ot-control-module';
import { OTDialogModule } from '@otuicontainer/dialog/ot-dialog.module';
import { TranslateModule } from '@ngx-translate/core';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';

@NgModule({
    declarations: [
        BaseScreenContainerComponent,
        EditScreenContainerComponent,
        FormScreenContainerComponent,
        ListScreenContainerComponent,
        ViewScreenContainerComponent,
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        OTDialogModule,
        OTControlModule,
        RouterModule,
        GridModule,
        TranslateModule,
        PartialsModule
    ],
    exports: [
        BaseScreenContainerComponent,
        EditScreenContainerComponent,
        FormScreenContainerComponent,
        ListScreenContainerComponent,
        ViewScreenContainerComponent,
    ]
})
export class OTScreenModule {}
