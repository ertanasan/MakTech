import { Injectable, OnInit, Input, OnDestroy } from '@angular/core';

import { ModelBase } from '@otmodel/model-base';
import { EditDialogScreenBase } from '@otscreen-base/edit-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { CRUDService } from '@otservice/crud.service';
import { TranslateService } from '@ngx-translate/core';
import { pipe, Subscription } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

export abstract class CRUDDialogScreenBase<T extends ModelBase> extends EditDialogScreenBase implements OnInit, OnDestroy {

    @Input() missingActionMessage = 'Unable to find current action {{0}} in the action list';
    @Input() createSuccessMessage = '{{0}} is created successfully.';
    @Input() createFailMessage = '{{0}} create failed: {{1}}';
    @Input() updateSuccessMessage = '{{0}} is updated successfully.';
    @Input() updateFailMessage = '{{0}} update failed: {{1}}';
    @Input() deleteSuccessMessage = '{{0}} is deleted successfully.';
    @Input() deleteFailMessage = '{{0}} delete failed: {{1}}';

    @Input() createTitle = 'New {{0}}';
    @Input() readTitle = '{{0}} Details';
    @Input() updateTitle = 'Update {{0}}';
    @Input() deleteTitle = 'Delete {{0}}';
    @Input() reviewTitle = 'Review {{0}}';

    currentItem: T;
    hasAutomaticIdentity = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: CRUDService<T>,
        modelName: string,
    ) {
        super(messageService, translateService, modelName);
    }

    ngOnInit() {
        super.ngOnInit();

        this.unsubscribe.push(this.container.onHide.subscribe( s => this.mainScreen.dialogCloseEvent.emit()));

        this.actions.push(
            {
                name: 'Create',
                isAcceptable: true,
                title: this.createTitle,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: !this.hasAutomaticIdentity,
                submitCallback: () => this.create(),
            },
            {
                name: 'Read',
                isAcceptable: false,
                title: this.readTitle,
                controlsDisabled: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
            },
            {
                name: 'Update',
                isAcceptable: true,
                title: this.updateTitle,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
                submitCallback: () => this.update(),
            },
            {
                name: 'Delete',
                isAcceptable: true,
                title: this.deleteTitle,
                controlsDisabled: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
                submitCallback: () => this.delete(),
            },
            {
                name: 'Review',
                isAcceptable: false,
                title: this.reviewTitle,
                controlsDisabled: false,
                hasChildren: true,
                isIdentityHidden: this.hasAutomaticIdentity,
                isIdentityEditable: false,
                submitCallback: () => this.review()
            }
        );
    }

    onSubmit() {
        this.currentItem = this.container.currentItem;

        if (this.container.useExternalLogic) {
            this.container.onDialogAction.next(this.currentItem);
        } else {
            this.container.showProgress();
            // Find current action
            const currentAction = this.actions.find(a => a.name === this.container.actionName);
            if (currentAction) {
                currentAction.submitCallback();
            } else {
                this.messageService.error(this.translateService.instant(this.missingActionMessage, { 0: currentAction })); // 'Unable to find current action {{0}} in the action list'
            }
        }
    }

    create() {
        // Determine crate REST controller action name
        let restAction = 'Create';
        if (this.container.leftRelationId > 0) {
            restAction = 'AddLeft';
        } else if (this.container.rightRelationId > 0) {
            restAction = 'AddRight';
        }

        // Make the REST call

        this.dataService.create(this.currentItem, restAction).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
            },
            error => {
                    this.handleHttpError(error, this.createFailMessage, this.modelName);
            }
        );
    }

    update() {
        this.dataService.update(this.currentItem).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
            },
            error => {
                this.handleHttpError(error, this.updateFailMessage, this.modelName);
            }
        );
    }

    delete() {
        this.dataService.delete(this.currentItem.getId()).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.deleteSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                this.mainScreen.refreshData();
                this.container.hide();
            },
            error => {
                this.handleHttpError(error, this.deleteFailMessage, this.modelName);
            }
        );
    }

    review() {
        this.currentItem.action = this.modeContext.actionId;
        this.dataService.takeAction(this.currentItem).pipe(
            finalize(() => this.container.hideProgress())
        ).subscribe(
            model => {
                this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                this.mainScreen.refreshData(this.currentItem.getId());
                this.container.hide();
                this.mainScreen.modeEvent.emit();
            },
            error => {
                this.handleHttpError(error, this.updateFailMessage, this.modelName);
            }
        );
    }

    ngOnDestroy(): void {
        super.ngOnDestroy();
    }

}
