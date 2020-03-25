// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GameLevel } from '@gamification/model/game-level.model';
import { GameLevelService } from '@gamification/service/game-level.service';
import { Game } from '@gamification/model/game.model';
import { GameService } from '@gamification/service/game.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-level-edit',
    templateUrl: './game-level-edit.component.html',
    styleUrls: ['./game-level-edit.component.css', ]
})
export class GameLevelEditComponent extends CRUDDialogScreenBase<GameLevel> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<GameLevel>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GameLevelService,
        public gameService: GameService,
    ) {
        super(messageService, translateService, dataService, 'Game Level');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GameLevelId: new FormControl(),
            Game: new FormControl(),
            LevelName: new FormControl(),
            QuestionCount: new FormControl(),
            MinDifficultyLevel: new FormControl(),
            MaxDifficultyLevel: new FormControl(),
            Duration: new FormControl(),
            LevelErrorTolerance: new FormControl(),
            PointofRightAnswer: new FormControl(),
            LevelCode: new FormControl(),
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
