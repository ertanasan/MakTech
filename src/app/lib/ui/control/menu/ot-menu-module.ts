import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseMenuComponent } from './base-menu/base-menu.component';
import { VerticalMenuComponent } from './vertical-menu/vertical-menu.component';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        BaseMenuComponent,
        VerticalMenuComponent,
    ],
    imports: [
        RouterModule,
        CommonModule
    ],
    exports: [
        BaseMenuComponent,
        VerticalMenuComponent,
    ]
})
export class OTMenuModule {}
