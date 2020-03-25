import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { SigninComponent } from './signin/signin.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { AuthRoutingModule } from './auth-routing.routing';
import { AuthService } from './service/auth.service';
import { AuthGuard } from './service/auth-guard.service';

import { AlertComponent } from './directives';
import { AlertService } from './service';
import { OTCoreModule } from '@otcore/core.module';
import { OTCommonModule } from '@otcommon/common.module';
import { ChangePasswordComponent } from './change-password/change-password.component';

@NgModule({
    declarations: [
        SigninComponent,
        AlertComponent,
        ResetPasswordComponent,
        ChangePasswordComponent
    ],
    imports: [
        CommonModule,
        OTCoreModule,
        OTCommonModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        AuthRoutingModule,
    ],
    exports: [
        ResetPasswordComponent,
        ChangePasswordComponent
    ],
    providers: [
        AuthService, AuthGuard, AlertService
    ]
    ,
    entryComponents: [AlertComponent],
})
export class AuthModule { }
