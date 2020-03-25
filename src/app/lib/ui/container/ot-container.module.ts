import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OTGroupingModule } from './grouping/ot-grouping.module';
import { OTDialogModule } from './dialog/ot-dialog.module';
import { OTScreenModule } from './screen/ot-screen.module';
import { OTSectionModule } from './section/ot-section.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        OTGroupingModule,
        OTDialogModule,
        OTScreenModule,
        OTSectionModule,

    ],
    exports: [
        OTGroupingModule,
        OTDialogModule,
        OTScreenModule,
        OTSectionModule
    ]
})
export class OTContainerModule {}

