import { RouterModule } from '@angular/router';
import { GroupListComponent } from './screen/group/group-list/group-list.component';
import { GroupEditComponent } from '@security/screen/group/group-edit/group-edit.component';
import { TranslateModule } from '@ngx-translate/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OTCommonModule } from '@otcommon/common.module';
import { SecurityComponent } from './security.component';

import { UserListComponent } from './screen/user/user-list/user-list.component';
import { UserEditComponent } from './screen/user/user-edit/user-edit.component';
import { UserService } from './service/user.service';
import { TitleService } from './service/title.service';
import { ProfessionService } from './service/profession.service';
import { LocationService } from './service/location.service';
import { GroupService } from './service/group.service';
import { GroupUserListComponent } from './screen/group-user/group-user-list/group-user-list.component';
import { GroupUserEditComponent } from './screen/group-user/group-user-edit/group-user-edit.component';
import { GroupUserService } from './service/group-user.service';

@NgModule({
    declarations: [
        SecurityComponent,
        UserEditComponent,
        UserListComponent,
        GroupEditComponent,
        GroupListComponent,
        GroupUserListComponent,
        GroupUserEditComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        GridModule,
        OTCommonModule,
        TranslateModule,
        FormsModule
    ],
    exports: [
        SecurityComponent,
        GroupListComponent,
        GroupUserListComponent,
    ],
    providers: [
        GroupService,
        LocationService,
        ProfessionService,
        TitleService,
        UserService,
        GroupUserService
    ]
})
export class SecurityModule { }
