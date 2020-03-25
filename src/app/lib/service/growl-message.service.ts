import { Injectable } from '@angular/core';
import { GrowlMessage } from '@otmodel/growl-message.model';
import { ToasterService } from 'angular2-toaster/angular2-toaster';
import { TranslateService } from '@ngx-translate/core';

declare let toastr: any;

@Injectable({
    providedIn: 'root'
})
export class GrowlMessageService {

    constructor(private toasterService: ToasterService,
        private translateService: TranslateService) {
            translateService.setDefaultLang('tr');
    }

    clear() {
        this.toasterService.clear();
    }

    info(message: string) {
        this.toasterService.pop('info', 'Info', message);
    }

    success(message: string) {
       this.toasterService.pop('success', this.translateService.instant('Success'), message);
    }

    warning(message: string) {
        this.toasterService.pop('warning', this.translateService.instant('Warning'), message);
    }

    error(message: string) {
        this.toasterService.pop('error', this.translateService.instant('Error'), message);
    }

    primary(message: string) {
       this.toasterService.pop('primary', this.translateService.instant('Primary'), message);
    }
}
