import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OTCommonModule } from '@otcommon/common.module';
import { OrganizationComponent } from './organization.component';

import { OrganizationService } from './service/organization.service';
import { DepartmentService } from './service/department.service';
import { BranchService } from './service/branch.service';

@NgModule({
    declarations: [
        OrganizationComponent
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
        OrganizationComponent
    ],
    providers: [
        BranchService,
        DepartmentService,
        OrganizationService
    ]
})
export class OrganizationModule { }