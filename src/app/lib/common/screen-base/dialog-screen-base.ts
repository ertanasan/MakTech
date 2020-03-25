import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { OTScreenBase } from './ot-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { IDialogContainer } from './dialog-container';
import { MainScreenBase } from './main-screen-base';
import { IDialogAction } from './dialog-action';

export abstract class DialogScreenBase extends OTScreenBase {
    abstract container: IDialogContainer;
    mainScreen: MainScreenBase;
    actions: IDialogAction[] = [];
    currentAction: IDialogAction;

    constructor(
        public messageService: GrowlMessageService,
        public translateService: TranslateService,
        public modelName: string,
    ) {
        super(messageService, translateService);
    }
}
