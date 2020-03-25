import { ServiceBase } from '@otservice/service-base';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class  OTTranslationService extends ServiceBase {
  baseRoute = '';
  public defaultCache = '1';
  protected httpClient: HttpClient;
  constructor(protected handler: HttpBackend,
    protected messageService: GrowlMessageService
    ) {
      super();
      this.baseRoute = `${ environment.baseRoute }/Parameter/Translation/`;
      this.httpClient = new HttpClient(handler);
  }

  readVersion(): Observable<string> {
    return this.httpClient.get<string>(this.baseRoute + 'TranslationVersion', { observe: 'body', responseType: 'json' });
  }
}
