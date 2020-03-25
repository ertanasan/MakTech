import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { HelpdeskComponent } from '@helpdesk/helpdesk.component';
import { RequestGroupListComponent } from '@helpdesk/screen/request-group/request-group-list/request-group-list.component';
import { RequestGroupEditComponent } from '@helpdesk/screen/request-group/request-group-edit/request-group-edit.component';
import { RequestGroupService } from '@helpdesk/service/request-group.service';
import { RequestDefinitionListComponent } from '@helpdesk/screen/request-definition/request-definition-list/request-definition-list.component';
import { RequestDefinitionEditComponent } from '@helpdesk/screen/request-definition/request-definition-edit/request-definition-edit.component';
import { RequestDefinitionService } from '@helpdesk/service/request-definition.service';
import { RequestAttributeListComponent } from '@helpdesk/screen/request-attribute/request-attribute-list/request-attribute-list.component';
import { RequestAttributeEditComponent } from '@helpdesk/screen/request-attribute/request-attribute-edit/request-attribute-edit.component';
import { RequestAttributeService } from '@helpdesk/service/request-attribute.service';
import { AttributeChoiceListComponent } from '@helpdesk/screen/attribute-choice/attribute-choice-list/attribute-choice-list.component';
import { AttributeChoiceEditComponent } from '@helpdesk/screen/attribute-choice/attribute-choice-edit/attribute-choice-edit.component';
import { AttributeChoiceService } from '@helpdesk/service/attribute-choice.service';
import { AttributeTypeListComponent } from '@helpdesk/screen/attribute-type/attribute-type-list/attribute-type-list.component';
import { AttributeTypeEditComponent } from '@helpdesk/screen/attribute-type/attribute-type-edit/attribute-type-edit.component';
import { AttributeTypeService } from '@helpdesk/service/attribute-type.service';
import { ProcessDefinitionListComponent } from '@helpdesk/screen/process-definition/process-definition-list/process-definition-list.component';
import { ProcessDefinitionEditComponent } from '@helpdesk/screen/process-definition/process-definition-edit/process-definition-edit.component';
import { ProcessDefinitionService } from '@helpdesk/service/process-definition.service';
import { HelpdeskRequestListComponent } from '@helpdesk/screen/helpdesk-request/helpdesk-request-list/helpdesk-request-list.component';
import { HelpdeskRequestEditComponent } from '@helpdesk/screen/helpdesk-request/helpdesk-request-edit/helpdesk-request-edit.component';
import { HelpdeskRequestService } from '@helpdesk/service/helpdesk-request.service';
import { RequestDetailListComponent } from '@helpdesk/screen/request-detail/request-detail-list/request-detail-list.component';
import { RequestDetailEditComponent } from '@helpdesk/screen/request-detail/request-detail-edit/request-detail-edit.component';
import { RequestDetailService } from '@helpdesk/service/request-detail.service';
import { StoreScalesService } from '@store/service/store-scales.service';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { RedirectionGroupListComponent } from '@helpdesk/screen/redirection-group/redirection-group-list/redirection-group-list.component';
import { RedirectionGroupEditComponent } from '@helpdesk/screen/redirection-group/redirection-group-edit/redirection-group-edit.component';
import { RedirectionGroupService } from '@helpdesk/service/redirection-group.service';
import { StoreService } from '@store/service/store.service';
import { RequestStatusListComponent } from '@helpdesk/screen/request-status/request-status-list/request-status-list.component';
import { RequestStatusEditComponent } from '@helpdesk/screen/request-status/request-status-edit/request-status-edit.component';
import { RequestStatusService } from '@helpdesk/service/request-status.service';
// import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';
import { UserService } from '@frame/security/service/user.service';
import { SharedService } from '@app-main/service/shared.service';
import { AppModule } from 'app/app.module';
import { AppMainModule } from '@app-main/app-main.module';
import { RequestAdditionalInfoListComponent } from '@helpdesk/screen/request-additional-info/request-additional-info-list/request-additional-info-list.component';
import { RequestAdditionalInfoEditComponent } from '@helpdesk/screen/request-additional-info/request-additional-info-edit/request-additional-info-edit.component';
import { RequestAdditionalInfoService } from '@helpdesk/service/request-additional-info.service';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { AssignUserListComponent } from '@helpdesk/screen/assign-user/assign-user-list/assign-user-list.component';
import { AssignUserEditComponent } from '@helpdesk/screen/assign-user/assign-user-edit/assign-user-edit.component';
import { AssignUserService } from '@helpdesk/service/assign-user.service';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { HelpdeskDashboardComponent } from './screen/helpdesk-dashboard/helpdesk-dashboard.component';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { PartialsModule } from '@otlib/metronic/views/partials/partials.module';

const routes: Routes = [
  {
    'path': '',
    'component': HelpdeskComponent,
    'children': [
      {
        'path': 'RequestGroup/Index',
        'component': RequestGroupListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RequestDefinition/Index',
        'component': RequestDefinitionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RequestAttribute/Index',
        'component': RequestAttributeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'AttributeChoice/Index',
        'component': AttributeChoiceListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'AttributeType/Index',
        'component': AttributeTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'ProcessDefinition/Index',
        'component': ProcessDefinitionListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'HelpdeskDashboard/Index',
        'component': HelpdeskDashboardComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'HelpdeskRequest/Index',
        'component': HelpdeskRequestListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RequestDetail/Index',
        'component': RequestDetailListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RedirectionGroup/Index',
        'component': RedirectionGroupListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RequestStatus/Index',
        'component': RequestStatusListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'RequestAdditionalInfo/Index',
        'component': RequestAdditionalInfoListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'AssignUser/Index',
        'component': AssignUserListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function HelpdeskHttpLoaderFactory(httpClient: HttpClient, translationService: OTTranslationService) {
    return new OTTranslateLoader(httpClient, translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=HDK');
}

@NgModule({
    declarations: [
        HelpdeskComponent,
        RequestGroupEditComponent,
        RequestGroupListComponent,
        RequestDefinitionEditComponent,
        RequestDefinitionListComponent,
        RequestAttributeEditComponent,
        RequestAttributeListComponent,
        AttributeChoiceEditComponent,
        AttributeChoiceListComponent,
        AttributeTypeEditComponent,
        AttributeTypeListComponent,
        ProcessDefinitionEditComponent,
        ProcessDefinitionListComponent,
        HelpdeskRequestEditComponent,
        HelpdeskRequestListComponent,
        RequestDetailEditComponent,
        RequestDetailListComponent,
        RedirectionGroupEditComponent,
        RedirectionGroupListComponent,
        RequestStatusEditComponent,
        RequestStatusListComponent,
        // ProcessHistoryComponent,
        RequestAdditionalInfoEditComponent,
        RequestAdditionalInfoListComponent,
        AssignUserEditComponent,
        AssignUserListComponent,
        HelpdeskDashboardComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        OTCommonModule,
        DatePickerModule,
        ButtonsModule,
        DropDownsModule,
        ExcelModule,
        ChartsModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: HelpdeskHttpLoaderFactory,
                deps: [HttpClient, OTTranslationService]
            },
            isolate: true
        }),
        AppMainModule,
        PartialsModule,
    ],
    exports: [
        RouterModule
    ],
    providers: [
        RequestGroupService,
        RequestDefinitionService,
        RequestAttributeService,
        AttributeChoiceService,
        AttributeTypeService,
        ProcessDefinitionService,
        HelpdeskRequestService,
        RequestDetailService,
        StoreScalesService,
        StoreCashRegisterService,
        StoreFixtureService,
        RedirectionGroupService,
        StoreService,
        RequestStatusService,
        UserService,
        SharedService,
        DatePipe,
        RequestAdditionalInfoService,
        AssignUserService,
    ]
})
export class HelpdeskModule {}
