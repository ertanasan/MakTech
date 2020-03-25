// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { GamePlay } from '@gamification/model/game-play.model';
import { GameQuestion } from '@gamification/model/game-question.model';
import { GameScore } from '@gamification/model/game.model';

/*Section="ClassHeader"*/
@Injectable()
export class GamePlayService extends CRUDLService<GamePlay> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Gamification', 'GamePlay');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listPlayLevelQuestions(playId, minDiffLevelCode, maxDiffLevelCode, questionCount) {
        let params = new HttpParams();
        params = params.append('playId', playId);
        params = params.append('minDiffLevelCode', minDiffLevelCode);
        params = params.append('maxDiffLevelCode', maxDiffLevelCode);
        params = params.append('questionCount', questionCount);
        return  this.httpClient.get<GameQuestion[]>(this.baseRoute + 'PlayQuestions', { observe: 'body', responseType: 'json', params: params });
    }

    listScores() {
        return this.httpClient.get<GameScore[]>(this.baseRoute + 'ListScores', { observe: 'body', responseType: 'json'});
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
