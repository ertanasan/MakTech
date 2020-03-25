// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GamePlay } from '@gamification/model/game-play.model';
import { GamePlayService } from '@gamification/service/game-play.service';
import { Game } from '@gamification/model/game.model';
import { GameService } from '@gamification/service/game.service';
import { GamePlayer } from '@gamification/model/game-player.model';
import { GamePlayerService } from '@gamification/service/game-player.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-play-edit',
    templateUrl: './game-play-edit.component.html',
    styleUrls: ['./game-play-edit.component.css', ]
})
export class GamePlayEditComponent extends CRUDDialogScreenBase<GamePlay> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<GamePlay>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GamePlayService,
        public gameService: GameService,
        public gamePlayerService: GamePlayerService,
    ) {
        super(messageService, translateService, dataService, 'Game Play');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GamePlayId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            Game: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            Player: new FormControl(),
            StartTime: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            EndTime: new FormControl(),
            LastLevel: new FormControl(),
            QuestionCount: new FormControl(),
            Score: new FormControl(),
            DeviceInfo: new FormControl(),
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
