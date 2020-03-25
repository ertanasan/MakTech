// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { GameLevel } from '@gamification/model/game-level.model';
import { GameLevelService } from '@gamification/service/game-level.service';
import { GameLevelEditComponent } from '@gamification/screen/game-level/game-level-edit/game-level-edit.component';
import { finalize } from 'rxjs/internal/operators/finalize';
import { process } from '@progress/kendo-data-query';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-game-level-list',
    templateUrl: './game-level-list.component.html',
    styleUrls: ['./game-level-list.component.css', ]
})
export class GameLevelListComponent extends ListScreenBase<GameLevel> implements AfterViewInit {
    @ViewChild(GameLevelEditComponent, {static: true}) editScreen: GameLevelEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: GameLevelService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listAllByMasterAsync(this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    // this.dataList = process(list.Data, this.listParams);
                    this.dataList = list;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Gamification' }, {Caption: 'Game Level', RouterLink: '/gamification/game-level'}];
    }

    createEmptyModel(): GameLevel {
        return new GameLevel();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.take = 200;
        this.listParams.skip = state.skip;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
