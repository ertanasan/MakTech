import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';

import { DialogBaseComponent } from './../dialog-base/dialog-base.component';
import { BsModalRef, ModalOptions, BsModalService } from 'ngx-bootstrap/modal';

@Component({
    selector: 'ot-input-dialog',
    templateUrl: './input-dialog.component.html',
    styleUrls: ['./input-dialog.component.css']
})
export class InputDialogComponent extends DialogBaseComponent implements OnInit {

    constructor(modalService: BsModalService) {
        super(modalService);
    }
}
