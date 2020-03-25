import { Component, OnInit, Output, EventEmitter, Input, DoCheck, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { Subject } from 'rxjs/Subject';

import { ModelBase } from '@otmodel/model-base';
import { FormScreenContainerComponent } from '@otuiscreen/form-screen-container/form-screen-container.component';
import { IDialogContainer } from '@otscreen-base/dialog-container';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

@Component({
    selector: 'ot-edit-screen-container',
    templateUrl: './edit-screen-container.component.html',
    styleUrls: ['./edit-screen-container.component.css']
})
export class EditScreenContainerComponent<T extends ModelBase> extends FormScreenContainerComponent<T> implements OnInit, IDialogContainer {
    @ViewChild(CustomDialogComponent, {static: true}) customDialog: CustomDialogComponent;

    // IDialogContainer implementation
    isAcceptable: boolean;
    actionName: string;
    dialogVisible: boolean;
    isIdentityHidden = true;
    isIdentityEditable = false;
    initialItem: T ;
    currentItem: T;
    masterId?: number;
    masterObject?: any;
    leftRelationId?: number;
    leftRelationObject?: any;
    rightRelationId?: number;
    rightRelationObject?: any;
    isReadOnly?: boolean;
    onShow: Subject<T> = new Subject();
    onHide: Subject<any> = new Subject();
    useExternalLogic = false;
    onDialogAction: Subject<T> = new Subject();

    @Input() childActions = '';
    @Input() size: string;
    @Input() delegateMessage: string;

    editorId = 'dialogId';

    constructor(
        formBuilder: FormBuilder,
        messageService: GrowlMessageService
    ) {
        super(formBuilder, messageService);
    }

    ngOnInit() {
    }

    show(dataItem: T) {
        this.progressVisible = false;
        this.initialItem = dataItem;
        if (dataItem.getId() === 0) {
            this.mainForm.reset();
        }
        this.mainForm.patchValue(dataItem);
        if (this.isReadOnly) {
            this.mainForm.disable();
        } else {
            this.mainForm.enable();
        }
        this.customDialog.color = this.actionName === 'Delete' ? 'danger' : 'primary';
        this.customDialog.show();
        this.onShow.next(dataItem);
    }

    onAction( childAction: string) {
        if (this.form.disabled || this.form.valid) {
            this.currentItem = Object.assign(this.initialItem, this.form.value);
            this.currentItem.actionChoice = childAction;
            this.form.ngSubmit.emit();
        } else {
            this.markAsTouched(this.mainForm);
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

    onClose(event: any) {
        this.customDialog.hide();
        this.onHide.next();
    }

    hide() {
        this.customDialog.hide();
        this.onHide.next();
    }
}
