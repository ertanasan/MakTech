import { Injectable, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription , Observable, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { OTScreenBase } from '@otscreen-base/ot-screen-base';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { RelationId } from '@otmodel/relation-id.model';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { FormGroup, FormArray } from '@angular/forms';

@Injectable()
export abstract class MainScreenBase extends OTScreenBase implements OnInit, OnDestroy {
    @Input() readFailMessage = 'Item read failed.';

    @Input() isEmbedded = false;
    @Input() useExternalLogic = false;
    @Input() masterId = 0;
    @Input() masterObject: any;
    @Input() leftRelationId = 0;
    @Input() leftRelationObject: any;
    @Input() rightRelationId = 0;
    @Input() rightRelationObject: any;

    breadcrumbItems: MenuItem[];
    dialogs: DialogScreenBase[] = [];
    readSubscription: Subscription;
    autoReadEnabled = true;

    abstract getBreadcrumbItems(): MenuItem[];
    abstract refreshData(id?: number | RelationId);
    abstract createEmptyItem(): any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(messageService, translateService);
        if (!this.isEmbedded) {
            this.breadcrumbItems = this.getBreadcrumbItems();
        }
    }

    ngOnInit() {
    }

    ngOnDestroy() {
        if (this.readSubscription) {
           this.readSubscription.unsubscribe();
        }
    }

    protected readDataItem(dataItem: any): Observable<any> {
        return of(dataItem);
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        // Find action and set action properties
        const dialog = this.dialogs.find(d => d.screenName === target.screenName);
        const action = dialog.actions.find(a => a.name === actionName);
        dialog.currentAction = action;
        dialog.container.actionName = action.name;
        dialog.container.isAcceptable = action.isAcceptable;

        if (action.title) {
            dialog.container.title = this.translateService.instant(action.title, { 0: this.translateService.instant(dialog.modelName) });
        }
        dialog.container.isIdentityHidden = action.isIdentityHidden;
        dialog.container.isIdentityEditable = action.isIdentityEditable;
        dialog.container.isReadOnly = action.controlsDisabled;

        // Set master or relation parent properties
        if (this.masterId !== 0) {
            dialog.container.masterId = this.masterId;
            dialog.container.masterObject = this.masterObject;
        }
        if (this.leftRelationId !== 0) {
            dialog.container.leftRelationId = this.leftRelationId;
            dialog.container.leftRelationObject = this.leftRelationObject;
        }
        if (this.rightRelationId !== 0) {
            dialog.container.rightRelationId = this.rightRelationId;
            dialog.container.rightRelationObject = this.rightRelationObject;
        }

        if (dataItem) {
            if (this.autoReadEnabled) {
                this.readSubscription = this.readDataItem(dataItem).subscribe(
                    data => {
                        dataItem = Object.assign(this.createEmptyItem(), data);
                        dialog.container.show(dataItem);
                    },
                    error => {
                        this.messageService.error(this.translateService.instant(this.readFailMessage));
                        console.error('MainScreenBase.showDialog', error);
                    }
                );
            } else {
                dialog.container.show(dataItem);
            }
        } else {
            dataItem = this.createEmptyItem();
            dialog.container.show(dataItem);
        }
    }

    markAsTouched(formGroup: FormGroup | FormArray) {
        (<any>Object).values(formGroup.controls).forEach(control => {
            control.markAsTouched();
            if (control.controls) {
              this.markAsTouched(control);
            }
          });
    }
}
