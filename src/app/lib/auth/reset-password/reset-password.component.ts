import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { ToasterConfig } from 'angular2-toaster';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AlertService } from '../service';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { TranslateService } from '@ngx-translate/core';
import { LoadingScreenService } from '@otservice/loading-screen.service';

@Component({
    selector: 'app-dashboard',
    templateUrl: '../../../modules/app-main/screen/reset-password/reset-password.component.html',
    encapsulation: ViewEncapsulation.None,
})

export class ResetPasswordComponent implements OnInit, OnDestroy {

    code: any;
    model: any = {};
    regex = /^(?=.*\d)(?=.*[A-Za-z]).{8,}/;
    public resetPasswordForm: FormGroup;
    public toasterconfig: ToasterConfig =
        new ToasterConfig({
            tapToDismiss: true,
            timeout: 5000,
            positionClass: 'toast-top-center',
            limit: 5
        });
    constructor(private authService: AuthService,
        private messageService: GrowlMessageService,
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _alertService: AlertService,
        private formBuilder: FormBuilder,
        private loadingService: LoadingScreenService,
        private translateService: TranslateService) {
    }

    ngOnInit() {
        this.translateService.use('tr');
        this.createForm();
        this._activatedRoute.queryParams.subscribe(params => {
        this.code = params.code;
        });
    }


    createForm() {
        this.resetPasswordForm = this.formBuilder.group({
            userName: new FormControl(null, { updateOn: 'blur', validators: Validators.required }),
            password: new FormControl(null, { updateOn: 'blur', validators: [Validators.required, this.passwordStrengthValidator.bind(this)] }),
            confirmPassword: new FormControl(null, { updateOn: 'blur', validators: [Validators.required, this.passwordMatchValidator.bind(this)] }),
            code: new FormControl(null)
        });
    }

    ngOnDestroy() {
    }

    reset() {
        const formValue = this.resetPasswordForm.value;
        formValue['code'] = this.code;
        this.loadingService.startLoading();
        this.authService.Resetpassword(formValue).subscribe(result => {
            if (result.toString() === 'OK') {
                this.messageService.success(this.translateService.instant('Your password has been changed successfully!'));
                this.resetPasswordForm.patchValue({ userName: '', password: '', confirmPassword: '', code: '' });
                this._router.navigate(['login'], { queryParams: { action: 'logout' } });
            } else {
                this.messageService.warning(result.toString());
                this.resetPasswordForm.patchValue({ password: '', confirmPassword: '', code: '' });
            }
            this.loadingService.stopLoading();
        });
    }

    passwordMatchValidator(control: AbstractControl): { [s: string]: string } {
        if (control.value) {
            if (this.resetPasswordForm.value.password !== control.value) {
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

    refreshData(id?: number) {
    }

    createEmptyItem() {
        throw new Error('Method not implemented.');
    }

    getBreadcrumbItems(): import('../../ui/control/menu/menuitem').MenuItem[] {
        throw new Error('Method not implemented.');
    }
}
