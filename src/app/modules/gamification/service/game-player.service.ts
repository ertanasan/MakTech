// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { GamePlayer } from '@gamification/model/game-player.model';

/*Section="ClassHeader"*/
@Injectable()
export class GamePlayerService extends CRUDLService<GamePlayer> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Gamification', 'GamePlayer');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    readPlayerId(userId, organization, userName) {
        let params = new HttpParams();
        params = params.append('userId', userId);
        params = params.append('organization', organization);
        params = params.append('userName', userName);
        return  this.httpClient.get<GamePlayer>(this.baseRoute + 'ReadPlayerId', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
