import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { environment } from 'environments/environment';

import { GridModule } from '@progress/kendo-angular-grid';

import { OTCommonModule } from '@otcommon/common.module';
import { OTTranslateLoader } from '@frame/parameter/service/ot-translateloader';
import { OTTranslationService } from '@frame/parameter/service/ot-translation.service';
import { GamificationComponent } from '@gamification/gamification.component';
import { GamePlayAnswerListComponent } from '@gamification/screen/game-play-answer/game-play-answer-list/game-play-answer-list.component';
import { GamePlayAnswerEditComponent } from '@gamification/screen/game-play-answer/game-play-answer-edit/game-play-answer-edit.component';
import { GamePlayAnswerService } from '@gamification/service/game-play-answer.service';
import { QuestionChoiceListComponent } from '@gamification/screen/question-choice/question-choice-list/question-choice-list.component';
import { QuestionChoiceEditComponent } from '@gamification/screen/question-choice/question-choice-edit/question-choice-edit.component';
import { QuestionChoiceService } from '@gamification/service/question-choice.service';
import { GameListComponent } from '@gamification/screen/game/game-list/game-list.component';
import { GameEditComponent } from '@gamification/screen/game/game-edit/game-edit.component';
import { GameService } from '@gamification/service/game.service';
import { GameLevelListComponent } from '@gamification/screen/game-level/game-level-list/game-level-list.component';
import { GameLevelEditComponent } from '@gamification/screen/game-level/game-level-edit/game-level-edit.component';
import { GameLevelService } from '@gamification/service/game-level.service';
import { GamePlayListComponent } from '@gamification/screen/game-play/game-play-list/game-play-list.component';
import { GamePlayEditComponent } from '@gamification/screen/game-play/game-play-edit/game-play-edit.component';
import { GamePlayService } from '@gamification/service/game-play.service';
import { GamePlayerListComponent } from '@gamification/screen/game-player/game-player-list/game-player-list.component';
import { GamePlayerEditComponent } from '@gamification/screen/game-player/game-player-edit/game-player-edit.component';
import { GamePlayerService } from '@gamification/service/game-player.service';
import { GameQuestionListComponent } from '@gamification/screen/game-question/game-question-list/game-question-list.component';
import { GameQuestionEditComponent } from '@gamification/screen/game-question/game-question-edit/game-question-edit.component';
import { GameQuestionService } from '@gamification/service/game-question.service';
import { OrganizationService } from '@frame/organization/service/organization.service';
import { BranchService } from '@frame/organization/service/branch.service';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

const routes: Routes = [
  {
    'path': '',
    'component': GamificationComponent,
    'children': [
      {
        'path': 'GamePlayAnswer/Index',
        'component': GamePlayAnswerListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'QuestionChoice/Index',
        'component': QuestionChoiceListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'Game/Index',
        'component': GameListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'GameLevel/Index',
        'component': GameLevelListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'GamePlay/Index',
        'component': GamePlayListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'GamePlayer/Index',
        'component': GamePlayerListComponent,
        'pathMatch': 'full'
      },
      {
        'path': 'GameQuestion/Index',
        'component': GameQuestionListComponent,
        'pathMatch': 'full'
      }
    ]
  }
];

export function GamificationHttpLoaderFactory(httpClient: HttpClient, translationService: OTTranslationService) {
    return new OTTranslateLoader(httpClient, translationService, environment.baseRoute + '/Parameter/Translation/Read/', '?module=GAM');
}

@NgModule({
    declarations: [
        GamificationComponent,
        GamePlayAnswerEditComponent,
        GamePlayAnswerListComponent,
        QuestionChoiceEditComponent,
        QuestionChoiceListComponent,
        GameEditComponent,
        GameListComponent,
        GameLevelEditComponent,
        GameLevelListComponent,
        GamePlayEditComponent,
        GamePlayListComponent,
        GamePlayerEditComponent,
        GamePlayerListComponent,
        GameQuestionEditComponent,
        GameQuestionListComponent,
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        TranslateModule,
        GridModule,
        OTCommonModule,
        DropDownsModule,
        FormsModule,
        TranslateModule.forChild({
            loader: {
                provide: TranslateLoader,
                useFactory: GamificationHttpLoaderFactory,
                deps: [HttpClient, OTTranslationService]
            },
            isolate: true
        }),
    ],
    exports: [
        RouterModule
    ],
    providers: [
        GamePlayAnswerService,
        QuestionChoiceService,
        GameService,
        GameLevelService,
        GamePlayService,
        GamePlayerService,
        GameQuestionService,
        OrganizationService,
        BranchService,
    ]
})
export class GamificationModule {}
