// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { QuestionChoice } from '@gamification/model/question-choice.model';
import { QuestionChoiceService } from '@gamification/service/question-choice.service';
import { GameQuestion } from '@gamification/model/game-question.model';
import { GameQuestionService } from '@gamification/service/game-question.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-question-choice-edit',
    templateUrl: './question-choice-edit.component.html',
    styleUrls: ['./question-choice-edit.component.css', ]
})
export class QuestionChoiceEditComponent extends CRUDDialogScreenBase<QuestionChoice> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<QuestionChoice>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: QuestionChoiceService,
        public gameQuestionService: GameQuestionService,
    ) {
        super(messageService, translateService, dataService, 'Question Choice');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            QuestionChoiceId: new FormControl(),
            Question: new FormControl(),
            ChoiceText: new FormControl(),
            RightAnswer: new FormControl(),
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
