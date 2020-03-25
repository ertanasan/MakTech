import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { DialogBaseComponent } from './dialog-base/dialog-base.component';
import { CustomDialogComponent } from './custom-dialog/custom-dialog.component';
import { InputDialogComponent } from './input-dialog/input-dialog.component';
import { MessageDialogComponent } from './message-dialog/message-dialog.component';
import { OTCoreModule } from '@otcore/core.module';
import { OTCommandModule } from '@otuicontrol/command/ot-command.module';

// Alert Component
import { AlertModule } from 'ngx-bootstrap/alert';

// Modal Component
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
    declarations: [
        DialogBaseComponent,
        CustomDialogComponent,
        InputDialogComponent,
        MessageDialogComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        OTCommandModule,
        AlertModule.forRoot(),
        ModalModule.forRoot(),
        OTCoreModule
    ],
    exports: [
        InputDialogComponent,
        MessageDialogComponent,
        CustomDialogComponent,
        DialogBaseComponent
    ]
})
export class OTDialogModule {}
