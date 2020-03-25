import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { TabStripModule } from "@progress/kendo-angular-layout";

import { PanelComponent } from "./panel/panel.component";
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { TabStripComponent } from './tab-strip/tab-strip.component';
import { TabPageComponent } from './tab-page/tab-page.component';
import { FieldSetComponent } from './field-set/field-set.component';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';

@NgModule({
    declarations: [
        PanelComponent,
        HeaderComponent,
        FooterComponent,
        TabStripComponent,
        TabPageComponent,
        FieldSetComponent
    ],
    imports: [
        CommonModule,
        TabStripModule,
        PartialsModule
    ],
    exports: [
        PanelComponent,
        TabStripComponent,
        TabPageComponent,
        FieldSetComponent
    ]
})
export class OTGroupingModule {}