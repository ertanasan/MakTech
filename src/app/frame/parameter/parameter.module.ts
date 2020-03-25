import { NgModule } from '@angular/core';
import { OTTranslationService } from './service/ot-translation.service';
import { ParameterComponent } from './parameter.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { OTCommonModule } from '@otcommon/common.module';

@NgModule({
    declarations: [
        ParameterComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        OTCommonModule,
    ],
    exports: [
        ParameterComponent
    ],
    providers: [
        OTTranslationService
    ]
})
export class ParameterModule { }
