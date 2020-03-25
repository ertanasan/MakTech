import { OnInit, Injectable, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { Subscription } from 'rxjs/Subscription';


export abstract class EditDialogScreenBase extends DialogScreenBase implements OnInit, OnDestroy {
    public unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
    abstract createForm();
    constructor(
        public messageService: GrowlMessageService,
        public translateService: TranslateService,
        public modelName: string,
    ) {
        super(messageService, translateService, modelName);
    }
    ngOnInit() {
        this.createForm();
    }

    ngOnDestroy() {
        this.unsubscribe.forEach(sb => sb.unsubscribe());
    }
}
