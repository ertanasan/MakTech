
import { Observable } from 'rxjs/Observable';
import { fromPromise } from 'rxjs/observable/fromPromise';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient } from '@angular/common/http';
import { OTTranslationService } from './ot-translation.service';

export class OTTranslateLoader extends TranslateHttpLoader {

  public originalSuffix: string;
  constructor(http: HttpClient, private translateService: OTTranslationService, prefix?: string, suffix?: string) {
    super(http, prefix, suffix);
    this.originalSuffix = suffix;
  }

  getTranslation(lang: string) {
   // this.suffix = this.originalSuffix + this.translateService.defaultCache;
   return super.getTranslation(lang);
  }
}
