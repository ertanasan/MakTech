import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { InputsModule } from '@progress/kendo-angular-inputs';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { ScrollViewModule } from '@progress/kendo-angular-scrollview';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { SortableModule } from '@progress/kendo-angular-sortable';
import { GaugesModule } from '@progress/kendo-angular-gauges';

import { OTCommandModule } from '../command/ot-command.module';
import { ProgressWidgetComponent } from './progress-widget/progress-widget.component';
import { ComplexComponent } from './complex/complex.component';
import { ButtonInputComponent } from './button-input/button-input.component';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { ImageGalleryComponent } from './image-gallery/image-gallery.component';
import { SimpleWidgetComponent } from './simple-widget/simple-widget.component';
import { TreeListComponent } from './tree-list/tree-list.component';
import { SortableListComponent } from './sortable-list/sortable-list.component';
import { RadialGaugeWidgetComponent } from './radial-gauge-widget/radial-gauge-widget.component';
import { DateRangeComponent } from './date-range/date-range.component';
import { OTCoreModule } from '@otcore/core.module';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';

@NgModule({
    declarations: [
        ComplexComponent,
        ProgressWidgetComponent,
        ButtonInputComponent,
        ImageUploadComponent,
        ImageGalleryComponent,
        SimpleWidgetComponent,
        TreeListComponent,
        SortableListComponent,
        RadialGaugeWidgetComponent,
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        OTCommandModule,
        ButtonModule,
        InputsModule,
        ScrollViewModule,
        TreeViewModule,
        SortableModule,
        GaugesModule,
        OTCoreModule,
        PartialsModule
    ],
    exports: [
        ProgressWidgetComponent,
        SimpleWidgetComponent,
        ButtonInputComponent,
        ImageUploadComponent,
        ImageGalleryComponent,
        TreeListComponent,
        SortableListComponent,
        RadialGaugeWidgetComponent,
    ]
})
export class OTComplexModule {}
