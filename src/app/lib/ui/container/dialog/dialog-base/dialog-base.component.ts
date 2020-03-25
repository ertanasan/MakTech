import { Component, OnInit, EventEmitter, Input, Output, ViewChild, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef, ModalOptions } from 'ngx-bootstrap/modal';

import { ContainerComponent } from '@otui/core/container/container.component';

type bsColor = 'none' | 'primary' | 'secondary' | 'info' | 'warning' | 'danger';

@Component({
    selector: 'ot-dialog-base',
    templateUrl: './dialog-base.component.html',
    styleUrls: ['./dialog-base.component.css']
})
export class DialogBaseComponent extends ContainerComponent implements OnInit {
    @ViewChild(TemplateRef, {static: true}) modal: TemplateRef<any>;
    @Input() caption = '';
    @Input() color: bsColor = 'none';
    @Input() size: string;
    @Input() dialogId = 'dialogId';
    @Input() visible = false;
    @Input() closedByBackdrop = false;
    @Output() onAction: EventEmitter<string> = new EventEmitter();
    @Output() onClose: EventEmitter<string> = new EventEmitter();

    modalConfig = new ModalOptions();
    modalRef: BsModalRef;

    constructor(private modalService: BsModalService) {
        super();
    }

    ngOnInit() {
    }

    getModalClasses(prefix: string) {
        const classes = this.getColorClasses(prefix);
        return classes;
    }

    getDialogClasses() {
        const classes = {};
        if (this.size) {
            classes['modal-' + this.size] = true;
        }
        return classes;
    }

    getColorClasses(prefix: string) {
        const classes = {};
        if (this.color !== 'none') {
            classes[prefix + '-' + this.color] = true;
        }
        return classes;
    }

    show() {
        if (this.color !== 'none') {
            this.modalConfig.class = 'modal-' + this.color;
        }
        if (this.size ) {
            this.modalConfig.class += ' modal-' + this.size;
        }
        if (!this.closedByBackdrop) {
            this.modalConfig.backdrop = 'static';   // To disable modal closing by click on the backdrop
        }
        this.modalRef = this.modalService.show(this.modal, this.modalConfig );
        this.visible = true;
    }

    close(event) {
        if (this.modalRef) {
            this.modalRef.hide();
        }
        this.visible = false;
        this.onClose.emit(event);
    }

    hide() {
        if (this.modalRef) {
            this.modalRef.hide();
        }
        this.visible = false;
    }
}
