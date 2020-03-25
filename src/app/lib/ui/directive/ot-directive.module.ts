import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { OTTooltipDirective } from './ot-tooltip.directive';
import { OTPrivilegeDirective } from './ot-privilege.directive';
import { OTScreenActionDirective } from './ot-screen-action.directive';
import { OTFolderRequiredDirective } from './ot-folder-required.directive';
import { OTNumberOnlyDirective } from './ot-numberonly.directive';

@NgModule({
    imports: [
        CommonModule,
        NgbModule
    ],
    declarations: [
        OTTooltipDirective,
        OTPrivilegeDirective,
        OTScreenActionDirective,
        OTFolderRequiredDirective,
        OTNumberOnlyDirective
    ],
    exports: [
        OTTooltipDirective,
        OTPrivilegeDirective,
        OTScreenActionDirective,
        OTFolderRequiredDirective,
        OTNumberOnlyDirective
    ]
})
export class OTDirectiveModule { }
