import { DialogBaseComponent } from './../dialog-base/dialog-base.component';
import { Component, OnInit, Input } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
    selector: 'ot-message-dialog',
    templateUrl: './message-dialog.component.html',
    styleUrls: ['./message-dialog.component.css']
})
export class MessageDialogComponent extends DialogBaseComponent implements OnInit {
    @Input() message: string;
    @Input() hasAction = false;

    @Input() closeButtonCaption = 'Close';
    @Input() okButtonCaption = 'OK';

    constructor(modalService: BsModalService) {
        super(modalService);
    }
}
