import { RouterModule } from '@angular/router';
import { SignRequestService } from './service/sign-request.service';
import { TranslateModule } from '@ngx-translate/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OTCommonModule } from '@otcommon/common.module';
import { DigitalSigningComponent } from './digital-signing.component';

@NgModule({
    declarations: [
        DigitalSigningComponent
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
        DigitalSigningComponent
    ],
    providers: [
        SignRequestService,
    ]
})
export class DigitalSigningModule { }
