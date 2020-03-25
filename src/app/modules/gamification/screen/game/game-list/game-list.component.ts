// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Game } from '@gamification/model/game.model';
import { GameService } from '@gamification/service/game.service';
import { GameEditComponent } from '@gamification/screen/game/game-edit/game-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-list',
    templateUrl: './game-list.component.html',
    styleUrls: ['./game-list.component.css', ]
})
export class GameListComponent extends ListScreenBase<Game> implements AfterViewInit {
    @ViewChild(GameEditComponent, {static: true}) editScreen: GameEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GameService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Game', RouterLink: '/gamification/game'}];
    }

    createEmptyModel(): Game {
        return new Game();
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
