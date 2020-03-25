import { TranslateModule } from '@ngx-translate/core';
import { NgModule } from '@angular/core';
import { ToasterModule } from 'angular2-toaster';

@NgModule({
    declarations: [

    ],
    imports: [
        ToasterModule.forRoot(),
    ],
    exports: [
        ToasterModule,
        TranslateModule,
    ],
    providers: [
    ]
})
export class OTCoreModule { }
