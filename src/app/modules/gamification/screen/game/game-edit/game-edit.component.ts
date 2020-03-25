// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Game } from '@gamification/model/game.model';
import { GameService } from '@gamification/service/game.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-edit',
    templateUrl: './game-edit.component.html',
    styleUrls: ['./game-edit.component.css', ]
})
export class GameEditComponent extends CRUDDialogScreenBase<Game> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Game>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: GameService,
    ) {
        super(messageService, translateService, dataService, 'Game');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            GameId: new FormControl(),
            GameName: new FormControl(),
            ErrorTolerance: new FormControl(),
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
