import { OnInit, OnDestroy, ViewEncapsulation, Component } from '@angular/core';
import { ToasterConfig } from 'angular2-toaster';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { AlertService } from '../service';
import { Router, ActivatedRoute } from '@angular/router';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { AuthService } from '../service/auth.service';
import { Store } from '@ngrx/store';

import * as fromApp from '../../store/app.reducers';
import * as AuthActions from '../store/auth.actions';

@Component({
    selector: 'app-dashboard',
    templateUrl: '../../../modules/app-main/screen/change-password/change-password.component.html',
    encapsulation: ViewEncapsulation.None,
})

export class ChangePasswordComponent implements OnInit, OnDestroy {

    regex = /^(?=.*\d)(?=.*[A-Za-z]).{8,}/;
    public changePasswordForm: FormGroup;
    public toasterconfig: ToasterConfig =
        new ToasterConfig({
            tapToDismiss: true,
            timeout: 5000,
            positionClass: 'toast-top-center',
            limit: 5
        });
    constructor(private authService: AuthService,
        private messageService: GrowlMessageService,
        private formBuilder: FormBuilder,
        private translateService: TranslateService,
        private store: Store<fromApp.AppState>) {
    }
    ngOnInit() {
        this.createForm();
    }

    createForm() {
        this.changePasswordForm = this.formBuilder.group({
            currentPassword: new FormControl(null, { updateOn: 'blur', validators: Validators.required }),
            newPassword: new FormControl(null, { updateOn: 'blur', validators: [Validators.required, this.passwordStrengthValidator.bind(this)] }),
            confirmPassword: new FormControl(null, { updateOn: 'blur', validators: [Validators.required, this.passwordMatchValidator.bind(this)] })
        });
    }

    change() {
        if (this.changePasswordForm.valid) {
            this.authService.ChangePassword(this.changePasswordForm.value).subscribe(
                result => {
                    this.messageService.success(this.translateService.instant('Password changed succesfully!'));
                    this.changePasswordForm.patchValue({ currentPassword: '', newPassword: '', confirmPassword: '' });
                    this.store.dispatch(new AuthActions.RefreshToken());
                }
            );
        }
    }

    passwordMatchValidator(control: AbstractControl): { [s: string]: string } {
        if (control.value) {
            if (this.changePasswordForm.value.newPassword !== control.value) {
                return { 'isPasswordDoNotMatch': this.translateService.instant('Passwords do not match!') };
            }
        }
        return null;
    }

    passwordStrengthValidator(control: AbstractControl): { [s: string]: string } {
        if (control.value) {
            if (!this.regex.test(control.value)) {
                return { 'isPasswordStrength': this.translateService.instant('The password must be at least 8 characters in length and contain at least one number and letter.') };
            }
        }
        return null;
    }

    ngOnDestroy() {
    }
}
