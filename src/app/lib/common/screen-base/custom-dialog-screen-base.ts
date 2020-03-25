import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { DialogScreenBase } from './dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

export abstract class CustomDialogScreenBase extends DialogScreenBase {
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        modelName = ''
    ) {
        super(messageService, translateService, modelName);
    }
}
