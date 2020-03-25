// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { GamePlayer } from '@gamification/model/game-player.model';
import { GamePlayerService } from '@gamification/service/game-player.service';
import { Branch } from '@organization/model/branch.model';
import { BranchService } from '@organization/service/branch.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-player-edit',
    templateUrl: './game-player-edit.component.html',
    styleUrls: ['./game-player-edit.component.css', ]
})
export class GamePlayerEditComponent extends CRUDDialogScreenBase<GamePlayer> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<GamePlayer>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GamePlayerService,
        public branchService: BranchService,
    ) {
        super(messageService, translateService, dataService, 'Game Player');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GamePlayerId: new FormControl(),
            PlayerName: new FormControl(),
            Branch: new FormControl(),
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
