import { TranslateModule } from '@ngx-translate/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { OTCommonModule } from '@otcommon/common.module';
import { DocumentComponent } from './document.component';

import { RepositoryService } from './service/repository.service';
import { RepositoryTypeService } from './service/repository-type.service';
import { FolderService } from './service/folder.service';
import { DocumentService } from './service/document.service';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        DocumentComponent
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
        DocumentComponent
    ],
    providers: [
        DocumentService,
        FolderService,
        RepositoryTypeService,
        RepositoryService
    ]
})
export class DocumentModule { }
