import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { ServiceBase } from '@otservice/service-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

export abstract class CRUDService<T extends ModelBase> extends ServiceBase {
    baseRoute: string;
    currentItem: T;

    constructor(
        protected httpClient: HttpClient,
        protected messageService: GrowlMessageService,
        protected translateService: TranslateService,
        protected module: string,
        protected screen: string,
    ) {
        super();
        this.baseRoute = `${ environment.baseRoute }/${ module }/${ screen}/`;
    }

    create(model: T, action = 'Create') {
        return this.httpClient.post<T>(this.baseRoute + action, model);
    }

    read(id: number, action = 'Read'): Observable<T> {
        const params = new HttpParams().set('id', id.toString());
        return this.httpClient.get<T>(this.baseRoute + action, { observe: 'body', responseType: 'json', params: params });
    }

    update(model: T, action = 'Update') {
        return this.httpClient.put<T>(this.baseRoute + action, model);
    }

    delete(id: number | RelationId, action = 'Delete') {
        let params = new HttpParams();
        if (id instanceof RelationId) {
            params = params.set('leftId', id.left.toString());
            params = params.set('rightId', id.right.toString());
        } else {
            params = params.set('id', id.toString());
        }
        return this.httpClient.delete(this.baseRoute + action, { params: params });
    }

    takeAction(model: T, action = 'TakeAction') {
        return this.httpClient.put<T>(this.baseRoute + action, model);
    }
}
