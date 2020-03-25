import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { ModelBase } from '@otmodel/model-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { FormScreenContainerComponent } from '../form-screen-container/form-screen-container.component';

@Component({
    selector: 'ot-view-screen-container',
    templateUrl: './view-screen-container.component.html',
    styleUrls: ['./view-screen-container.component.css']
})
export class ViewScreenContainerComponent<T extends ModelBase> extends FormScreenContainerComponent<T> implements OnInit {
    dialogVisible: boolean;
    color = 'info';

    @Input() title: string;
    @Input() childActions = '';
    @Input() size: string;

    constructor(
        formBuilder: FormBuilder,
        messageService: GrowlMessageService
    ) {
        super(formBuilder, messageService);
    }

    ngOnInit() {
    }

    onClose(event: any) {
        this.dialogVisible = false;
    }

}
