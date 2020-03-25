import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { IntlModule } from '@progress/kendo-angular-intl';

import { GridModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { StoreUploadComponent } from '@store-upload/store-upload.component';

import { StatusService } from '@store-upload/service/status.service';
import { UploadTypeService } from '@store-upload/service/upload-type.service';
import { StatusListComponent } from '@store-upload/screen/status/status-list/status-list.component';
import { StatusEditComponent } from '@store-upload/screen/status/status-edit/status-edit.component';
import { UploadTypeListComponent } from '@store-upload/screen/upload-type/upload-type-list/upload-type-list.component';
import { UploadTypeEditComponent } from '@store-upload/screen/upload-type/upload-type-edit/upload-type-edit.component';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { environment } from 'environments/environment';

const routes: Routes = [
    {
        'path': '',
        'component': StoreUploadComponent,
        'children': [
            {
                'path': 'Status/Index',
                'component': StatusListComponent,
                'pathMatch': 'full'
            },
            {
                'path': 'UploadType/Index',
                'component': UploadTypeListComponent,
                'pathMatch': 'full'
            },
        ]
    },
];

export function StoreUploadHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=SUP');
}

@NgModule({
    declarations: [
        StatusEditComponent,
        StatusListComponent,
        UploadTypeEditComponent,
        UploadTypeListComponent,
        StoreUploadComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        GridModule,
        OTCommonModule,
        TranslateModule,
        IntlModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: StoreUploadHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
    ],
    exports: [
        RouterModule
    ],
    providers: [
        StatusService,
        UploadTypeService,
    ]
})
export class StoreUploadModule {}
