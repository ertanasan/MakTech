// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GamePlayer } from '@gamification/model/game-player.model';
import { GamePlayerService } from '@gamification/service/game-player.service';
import { GamePlayerEditComponent } from '@gamification/screen/game-player/game-player-edit/game-player-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-player-list',
    templateUrl: './game-player-list.component.html',
    styleUrls: ['./game-player-list.component.css', ]
})
export class GamePlayerListComponent extends ListScreenBase<GamePlayer> implements AfterViewInit {
    @ViewChild(GamePlayerEditComponent, {static: true}) editScreen: GamePlayerEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GamePlayerService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Game Player', RouterLink: '/gamification/game-player'}];
    }

    createEmptyModel(): GamePlayer {
        return new GamePlayer();
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
