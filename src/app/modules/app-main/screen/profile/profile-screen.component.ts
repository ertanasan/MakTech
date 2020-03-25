import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, FormsModule, AbstractControl, Validators } from '@angular/forms';

import { Profile } from '@app-main/model/profile.model';
import { ProfileService } from '@app-main/service/profile.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { MenuItem } from '@otui/control/menu/menuitem';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from '@otlib/auth/service/auth.service';
import { _ } from '@biesbjerg/ngx-translate-extract/dist/utils/utils';

@Component({
  selector: 'ot-app-main-profile-screen',
  templateUrl: './profile-screen.component.html',
  styleUrls: ['./profile-screen.component.css'],
})
export class ProfileScreenComponent extends MainScreenBase implements OnInit {


  updatePersonalInformationForm: FormGroup;
  changePasswordForm: FormGroup;
  isDataLoaded: boolean;
  userProfile: Profile;
  genders: any[];

  userName: string;

  getBreadcrumbItems(): MenuItem[] {
    return [{Caption: 'Profile', RouterLink: '/profile'}];
  }

  refreshData(id?: number) {
    throw new Error('Method not implemented.');
  }

  createEmptyItem() {
    throw new Error('Method not implemented.');
  }
  constructor(
    messageService: GrowlMessageService,
    translateService: TranslateService,
    private formBuilder: FormBuilder,
    private authService: AuthService,

  ) {
    super(messageService, translateService);

  }

  ngOnInit() {
    this.createForm();
  }


  createForm() {
    this.changePasswordForm = this.formBuilder.group({
      currentPassword: new FormControl(null, {updateOn: 'blur',  validators: Validators.required}),
      newPassword: new FormControl(null, {updateOn: 'blur',  validators: Validators.required}),
      confirmPassword: new FormControl(null, {updateOn: 'blur',  validators: [Validators.required, this.passwordMatchValidator.bind(this)]} )
    });
  }

  onUpdatePassword() {
    if (this.changePasswordForm.valid) {
        this.authService.ChangePassword(this.changePasswordForm.value).subscribe(result => {
          this.messageService.success(this.translateService.instant(_('Password changed succesfully!')));
          this.changePasswordForm.patchValue({ currentPassword: '', newPassword: '', confirmPassword: '' });
      });
    }

  }
  passwordMatchValidator(control: AbstractControl): { [s: string]: string } {
    if (control.value) {
        if (this.changePasswordForm.value.newPassword !== control.value) {
            return { 'isPasswordDoNotMatch': 'Passwords do not match!' };
        }
    }
    return null;
}
}
