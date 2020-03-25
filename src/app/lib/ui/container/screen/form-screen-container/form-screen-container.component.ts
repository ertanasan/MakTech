import { Component, OnInit, Input, EventEmitter, Output, ContentChild } from '@angular/core';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';

import { ModelBase } from '@otmodel/model-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { BaseScreenContainerComponent } from '../base-screen-container/base-screen-container.component';

@Component({
    selector: 'ot-form-screen-container',
    templateUrl: './form-screen-container.component.html',
    styleUrls: ['./form-screen-container.component.css']
})
export class FormScreenContainerComponent<T extends ModelBase> extends BaseScreenContainerComponent implements OnInit {
    @ContentChild('form' , {static: false}) form: NgForm;
    mainForm: FormGroup;

    @Input() progressVisible = false;
    @Input() formValue: T;
    @Input() title: string;

    constructor(
        public formBuilder: FormBuilder,
        messageService: GrowlMessageService
    ) {
        super();
    }

    ngOnInit() {
    }

    setFormValue(value: T, disable = false) {
        this.formValue = value;
        this.mainForm.patchValue(value);
        if (disable) {
            this.mainForm.disable();
        }
    }

    showProgress() {
        this.progressVisible = true;
    }

    hideProgress() {
        setTimeout(() => {
            this.progressVisible = false;
        }, 1000);
    }
}
