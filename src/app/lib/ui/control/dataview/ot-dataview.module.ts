import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";

import { ScrollViewModule } from '@progress/kendo-angular-scrollview';

import { DataViewComponent } from "./data-view/data-view.component";
import { DocumentViewerComponent } from "./document-viewer/document-viewer.component";
import { GridComponent } from "./grid/grid.component";
import { ImageViewerComponent } from "./image-viewer/image-viewer.component";
import { CarouselViewComponent } from './carousel-view/carousel-view.component';

@NgModule({
    declarations: [
        DataViewComponent,
        DocumentViewerComponent,
        GridComponent,
        ImageViewerComponent,
        CarouselViewComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ScrollViewModule
    ],
    exports: [
        CarouselViewComponent
    ]
})
export class OTDataViewModule {}