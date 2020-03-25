import { Component, OnInit, Input, Output, EventEmitter, ViewChild, AfterViewInit, TemplateRef } from '@angular/core';
import { DialogBaseComponent } from '../dialog-base/dialog-base.component';
import { BsModalService, BsModalRef, ModalOptions } from 'ngx-bootstrap/modal';

@Component({
    selector: 'ot-custom-dialog',
    templateUrl: './custom-dialog.component.html',
    styleUrls: ['./custom-dialog.component.css']
})
export class CustomDialogComponent extends DialogBaseComponent implements OnInit {

    constructor(modalService: BsModalService ) {
        super(modalService);
    }
}
