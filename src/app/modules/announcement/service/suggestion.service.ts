// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Suggestion, SuggestionHistory } from '@announcement/model/suggestion.model';

/*Section="ClassHeader"*/
@Injectable()
export class SuggestionService extends CRUDLService<Suggestion> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Announcement', 'Suggestion');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    public GetHistoryData(suggestionId: number) {
        const params = new HttpParams().append('suggestionId', suggestionId.toString());
        return this.httpClient.get<SuggestionHistory[]>(this.baseRoute + 'ListHistoryData', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
