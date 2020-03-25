// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GameQuestion } from '@gamification/model/game-question.model';
import { GameQuestionService } from '@gamification/service/game-question.service';
import { GameQuestionEditComponent } from '@gamification/screen/game-question/game-question-edit/game-question-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-question-list',
    templateUrl: './game-question-list.component.html',
    styleUrls: ['./game-question-list.component.css', ]
})
export class GameQuestionListComponent extends ListScreenBase<GameQuestion> implements AfterViewInit {
    @ViewChild(GameQuestionEditComponent, {static: true}) editScreen: GameQuestionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GameQuestionService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Game Question', RouterLink: '/gamification/game-question'}];
    }

    createEmptyModel(): GameQuestion {
        return new GameQuestion();
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
