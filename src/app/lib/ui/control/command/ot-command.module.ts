import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ButtonsModule } from '@progress/kendo-angular-buttons';

import { ButtonComponent } from './button/button.component';
import { ButtonGroupComponent } from './button-group/button-group.component';
import { CommandComponent } from './command/command.component';
import { DialogButtonGroupComponent } from './dialog-button-group/dialog-button-group.component';
import { GridButtonComponent } from './grid-button/grid-button.component';
import { HeaderButtonComponent } from './header-button/header-button.component';
import { LinkComponent } from './link/link.component';
import { DropDownButtonComponent } from './drop-down-button/drop-down-button.component';
import { LightButtonComponent } from './light-button/light-button.component';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';
import { OTCoreModule } from '@otcore/core.module';
import { MatButtonModule } from '@angular/material';
import { NgbModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
    declarations: [
        ButtonComponent,
        ButtonGroupComponent,
        CommandComponent,
        DialogButtonGroupComponent,
        GridButtonComponent,
        HeaderButtonComponent,
        LinkComponent,
        DropDownButtonComponent,
        LightButtonComponent,
        LoadingScreenComponent
    ],
    imports: [
        CommonModule,
        OTCoreModule,
        ReactiveFormsModule,
        ButtonsModule,
        MatButtonModule,
        NgbModule,
        NgbDropdownModule
    ],
    exports: [
        ButtonComponent,
        DropDownButtonComponent,
        LightButtonComponent,
        LoadingScreenComponent
    ]
})
export class OTCommandModule {

}
