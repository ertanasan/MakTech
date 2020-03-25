import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClient, HttpHandler, HttpBackend } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { UserService } from '@frame/security/service/user.service';
import { StoreService } from '@store/service/store.service';
import { AnnouncementComponent } from '@announcement/announcement.component';
import { SuggestionListComponent } from '@announcement/screen/suggestion/suggestion-list/suggestion-list.component';
import { SuggestionEditComponent } from '@announcement/screen/suggestion/suggestion-edit/suggestion-edit.component';
import { SuggestionService } from '@announcement/service/suggestion.service';
import { NotificationListComponent } from './screen/notification/notification-list/notification-list.component';
import { NotificationEditComponent } from './screen/notification/notification-edit/notification-edit.component';
import { NotificationStatusListComponent } from './screen/notification-status/notification-status-list/notification-status-list.component';
import { NotificationStatusEditComponent } from './screen/notification-status/notification-status-edit/notification-status-edit.component';
import { NotificationTypeListComponent } from './screen/notification-type/notification-type-list/notification-type-list.component';
import { NotificationTypeEditComponent } from './screen/notification-type/notification-type-edit/notification-type-edit.component';
import { NotificationStoreListComponent } from './screen/notification-store/notification-store-list/notification-store-list.component';
import { NotificationStoreEditComponent } from './screen/notification-store/notification-store-edit/notification-store-edit.component';
import { NotificationService } from './service/notification.service';
import { NotificationTypeService } from './service/notification-type.service';
import { NotificationStatusService } from './service/notification-status.service';
import { NotificationStoreService } from './service/notification-store.service';
import { NotificationUserListComponent } from './screen/notification-user/notification-user-list/notification-user-list.component';
import { NotificationUserEditComponent } from './screen/notification-user/notification-user-edit/notification-user-edit.component';
import { NotificationUserService } from './service/notification-user.service';
import { SuggestionStatusService } from './service/suggestion-status.service';
import { SuggestionTypeService } from './service/suggestion-type.service';
import { RatingEntryComponent } from './lib/rating-entry/rating-entry.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { OTDataEntryModule } from '@otuidataentry/ot-dataentry.module';
import { NotificationHistoryComponent } from './screen/notification-history/notification-history.component';
import { NotificationGroupListComponent } from './screen/notification-group/notification-group-list/notification-group-list.component';
import { NotificationGroupEditComponent } from './screen/notification-group/notification-group-edit/notification-group-edit.component';
import { NotificationGroupUserListComponent } from './screen/notification-group-user/notification-group-user-list/notification-group-user-list.component';
import { NotificationGroupUserEditComponent } from './screen/notification-group-user/notification-group-user-edit/notification-group-user-edit.component';
import { NotificationGroupService } from './service/notification-group.service';
import { NotificationGroupUserService } from './service/notification-group-user.service';
import { SuggestionHistoryComponent } from './screen/suggestion/suggestion-history/suggestion-history.component';
import { GetNamePipe } from '@otcommon/pipe/get-name.pipe';
import { AppMainModule } from '@app-main/app-main.module';
import { SuggestionAnonymousEntryComponent } from './screen/suggestion/suggestion-anonymous-entry/suggestion-anonymous-entry.component';

const routes: Routes = [
  {
    'path': '',
    'component': AnnouncementComponent,
    'children': [
      {
        'path': 'Suggestion/Index/:from',
        'component': SuggestionListComponent,
        'pathMatch': 'full'
      },
      {
        'path' : 'Suggestion/Index',
        'redirectTo' : 'Suggestion/Index/'
      },
        {
            'path': 'SuggestionAnonymous/Index',
            'component': SuggestionAnonymousEntryComponent,
            'pathMatch': 'full'
        },
      {
        'path': 'Notification/Index',
        'component': NotificationListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'NotificationStatus/Index',
        'component': NotificationStatusListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'NotificationType/Index',
        'component': NotificationTypeListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'NotificationHistory/Index',
        'component': NotificationHistoryComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'NotificationGroup/Index',
        'component': NotificationGroupListComponent,
        'pathMatch': 'full'
      },
    ]
  }
];

export function AnnouncementHttpLoaderFactory(http: HttpBackend, translationService: OTTranslationService) {
    return new OTTranslateLoader(new HttpClient(http), translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=ANN');
}

@NgModule({
    declarations: [
        AnnouncementComponent,
        SuggestionEditComponent,
        SuggestionListComponent,
        NotificationListComponent,
        NotificationEditComponent,
        NotificationStatusListComponent,
        NotificationStatusEditComponent,
        NotificationTypeListComponent,
        NotificationTypeEditComponent,
        NotificationStoreListComponent,
        NotificationStoreEditComponent,
        NotificationUserListComponent,
        NotificationUserEditComponent,
        RatingEntryComponent,
        NotificationHistoryComponent,
        NotificationGroupListComponent,
        NotificationGroupEditComponent,
        NotificationGroupUserListComponent,
        NotificationGroupUserEditComponent,
        SuggestionHistoryComponent,
        SuggestionAnonymousEntryComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        ExcelModule,
        OTCommonModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: AnnouncementHttpLoaderFactory,
                deps: [HttpBackend, OTTranslationService]
            },
            isolate: true
        }),
        OTDataEntryModule,
        AngularFontAwesomeModule,
        FontAwesomeModule,
        AppMainModule
    ],
    exports: [
        RouterModule
    ],
    providers: [
        SuggestionService,
        NotificationService,
        NotificationStatusService,
        NotificationTypeService,
        NotificationStoreService,
        NotificationUserService,
        UserService,
        StoreService,
        DatePipe,
        SuggestionStatusService,
        SuggestionTypeService,
        NotificationGroupService,
        NotificationGroupUserService,
        GetNamePipe,
    ]
})
export class AnnouncementModule {}
