// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GameQuestion } from '@gamification/model/game-question.model';
import { GameQuestionService } from '@gamification/service/game-question.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-question-edit',
    templateUrl: './game-question-edit.component.html',
    styleUrls: ['./game-question-edit.component.css', ]
})
export class GameQuestionEditComponent extends CRUDDialogScreenBase<GameQuestion> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<GameQuestion>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GameQuestionService,
    ) {
        super(messageService, translateService, dataService, 'Game Question');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GameQuestionId: new FormControl(),
            QuestionText: new FormControl(),
            DifficultyLevel: new FormControl(),
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
