import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SigninComponent } from './signin/signin.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

const authRoutes: Routes = [
    { path: 'login', component: SigninComponent },
    { path: 'resetPassword', component: ResetPasswordComponent },
    { path: 'changePassword', component: ChangePasswordComponent}
];

@NgModule({
    imports: [
        RouterModule.forRoot(authRoutes),
    ],
    exports: [RouterModule]
})
export class AuthRoutingModule {

 }
