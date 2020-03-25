import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';

import { OTDataEntryModule } from './dataentry/ot-dataentry.module';
import { OTMenuModule } from './menu/ot-menu-module';
import { OTCommandModule } from './command/ot-command.module';
import { ReactiveFormsModule } from '@angular/forms';
import { OTDataViewModule } from './dataview/ot-dataview.module';
import { OTComplexModule } from './complex/ot-complex.module';
import { OTDirectiveModule } from '@otui/directive/ot-directive.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        OTDataEntryModule,
        OTDataViewModule,
        OTMenuModule,
        OTCommandModule,
        SweetAlert2Module.forRoot()
    ],
    exports: [
        OTDataEntryModule,
        OTDataViewModule,
        OTCommandModule,
        OTComplexModule,
        OTDirectiveModule
    ]
})
export class OTControlModule {}
