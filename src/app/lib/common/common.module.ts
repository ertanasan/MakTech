import { NgModule, Injector } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { SharedModule } from '../shared/shared.module';
import { AuthInterceptor } from '../shared/auth.interceptor';
import { LoadingScreenInterceptor } from '../shared/loading.interceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { OTDialogModule } from '../ui/container/dialog/ot-dialog.module';
import { OTScreenModule } from '../ui/container/screen/ot-screen.module';
import { OTCommandModule } from '../ui/control/command/ot-command.module';
import { OTDataEntryModule } from '../ui/control/dataentry/ot-dataentry.module';
import { OTDataViewModule } from '../ui/control/dataview/ot-dataview.module';
import { OTComplexModule } from '../ui/control/complex/ot-complex.module';
import { OTControlModule } from '../ui/control/ot-control-module';
import { OTContainerModule } from '../ui/container/ot-container.module';
import { ScriptLoaderService } from './service/script-loader.service';
import { GlobalErrorHandler } from './service/error-handler.service';
import { GetNamePipe } from '@otcommon/pipe/get-name.pipe';
import { GetHierarchyPath } from '@otcommon/pipe/get-hierarchy-path.pipe';
import { OTCurrencyPipe } from '@otcommon/pipe/ot-currency.pipe';
import { ToasterService } from 'angular2-toaster';
import { OTReportingModule } from '@otui/reporting/ot-reporting.module';
import { OTCoreModule } from '@otcore/core.module';

export let OTInjector: Injector;

@NgModule({
    declarations: [
        GetNamePipe,
        GetHierarchyPath,
        OTCurrencyPipe,
    ],
    imports: [
        NgbModule,
    ],
    exports: [
        SharedModule,
        OTCoreModule,
        OTContainerModule,
        OTControlModule,
        OTReportingModule,
        GetNamePipe,
        GetHierarchyPath,
        OTCurrencyPipe,
    ],
    providers: [
        ScriptLoaderService,
        GlobalErrorHandler,
        ToasterService,
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: LoadingScreenInterceptor, multi: true }
    ]
})
export class OTCommonModule {
    constructor(private injector: Injector) {
        OTInjector = this.injector;
    }
}
