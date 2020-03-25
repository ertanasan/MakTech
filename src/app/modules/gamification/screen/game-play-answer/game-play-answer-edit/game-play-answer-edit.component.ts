// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GamePlayAnswer } from '@gamification/model/game-play-answer.model';
import { GamePlayAnswerService } from '@gamification/service/game-play-answer.service';
import { GamePlay } from '@gamification/model/game-play.model';
import { GamePlayService } from '@gamification/service/game-play.service';
import { GameQuestion } from '@gamification/model/game-question.model';
import { GameQuestionService } from '@gamification/service/game-question.service';
import { QuestionChoice } from '@gamification/model/question-choice.model';
import { QuestionChoiceService } from '@gamification/service/question-choice.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-play-answer-edit',
    templateUrl: './game-play-answer-edit.component.html',
    styleUrls: ['./game-play-answer-edit.component.css', ]
})
export class GamePlayAnswerEditComponent extends CRUDDialogScreenBase<GamePlayAnswer> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<GamePlayAnswer>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GamePlayAnswerService,
        public gamePlayService: GamePlayService,
        public gameQuestionService: GameQuestionService,
        public questionChoiceService: QuestionChoiceService,
    ) {
        super(messageService, translateService, dataService, 'Game Play Answer');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GamePlayAnswerId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            Play: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            Question: new FormControl(),
            AnswerChoice: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            ResultFlag: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
