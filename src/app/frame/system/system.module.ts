import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { SystemComponent } from '@system/system.component';
import { ChannelService } from '@system/service/channel.service';

const routes: Routes = [
  {
    'path': '',
    'component': SystemComponent,
    'children': [
    ]
  }
];

export function SystemHttpLoaderFactory(httpClient: HttpClient, translationService: OTTranslationService) {
    return new OTTranslateLoader(httpClient, translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=SYS');
}

@NgModule({
    declarations: [
        SystemComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        OTCommonModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: SystemHttpLoaderFactory,
                deps: [HttpClient, OTTranslationService]
            },
            isolate: true
        }),
    ],
    exports: [
        RouterModule
    ],
    providers: [
        ChannelService,
    ]
})
export class SystemModule {}
