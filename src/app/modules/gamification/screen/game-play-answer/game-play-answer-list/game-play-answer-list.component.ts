// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GamePlayAnswer } from '@gamification/model/game-play-answer.model';
import { GamePlayAnswerService } from '@gamification/service/game-play-answer.service';
import { GamePlayAnswerEditComponent } from '@gamification/screen/game-play-answer/game-play-answer-edit/game-play-answer-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-play-answer-list',
    templateUrl: './game-play-answer-list.component.html',
    styleUrls: ['./game-play-answer-list.component.css', ]
})
export class GamePlayAnswerListComponent extends ListScreenBase<GamePlayAnswer> implements AfterViewInit {
    @ViewChild(GamePlayAnswerEditComponent, {static: true}) editScreen: GamePlayAnswerEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GamePlayAnswerService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Game Play Answer', RouterLink: '/gamification/game-play-answer'}];
    }

    createEmptyModel(): GamePlayAnswer {
        return new GamePlayAnswer();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
