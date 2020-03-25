import { Injectable, Input, Output, EventEmitter } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { OTBase } from '@otcommon/ot-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { HttpErrorResponse } from '@angular/common/http';

export class OTScreenBase extends OTBase {
    @Input() screenName: string;

    // Mode inputs
    @Input() screenMode: string;
    @Input() modeDefault = true;
    @Input() modeReview = false;
    @Input() modeWorkqueue = false;
    @Input() modeOther = false;
    @Input() modeContext: any;

    @Output() modeEvent: EventEmitter<any> = new EventEmitter<any>();
    @Output() dialogCloseEvent: EventEmitter<any> = new EventEmitter<any>();

    constructor(
        protected messageService: GrowlMessageService,
        protected translateService: TranslateService
    ) {
        super();
    }
    handleHttpError(error: any, defaultMessage: string, modelName: string) {
        if (error instanceof HttpErrorResponse) {
            console.log(error);
            if ((<HttpErrorResponse>error).status === 403) {
                this.messageService.error(this.translateService.instant('You do not have permission to perform this action!'));
            } else {
                if (error.error && error.error['Message']) {

                    const parseResult = this.tryParseJSON(error.error['Message']);
                    if (parseResult) { // valid json string
                        this.messageService.error(`${parseResult.Message}`);
                    } else {
                        this.messageService.error(error.error['Message']);
                    }
                } else {
                    this.messageService.error(this.translateService.instant(defaultMessage, { 0: this.translateService.instant(modelName), 1: error.error }));
                }
            }
        } else {
            this.messageService.error(this.translateService.instant(defaultMessage, { 0: this.translateService.instant(modelName), 1: error }));
        }
    }

    tryParseJSON(jsonString) {
        try {
            const o = JSON.parse(jsonString);
            // Handle non-exception-throwing cases:
            // Neither JSON.parse(false) or JSON.parse(1234) throw errors, hence the type-checking,
            // but... JSON.parse(null) returns null, and typeof null === "object",
            // so we must check for that, too. Thankfully, null is falsey, so this suffices:
            if (o && typeof o === 'object') {
                return o;
            }
        } catch (e) {
            console.log(e);
        }

        return false;
    }
}
