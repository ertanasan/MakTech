import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit, Input, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { DocumentHandle } from '@otmodel/document-handle.model';
import { DocumentOperationService } from '@otservice/document-operation.service';
import swal from 'sweetalert2';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { saveAs } from 'file-saver';
import { GrowlMessageService } from '@otservice/growl-message.service';

@Component({
    selector: 'ot-document-entry',
    templateUrl: './document-entry.component.html',
    styleUrls: ['./document-entry.component.css'],
})
export class DocumentEntryComponent extends DataEntryBase<DocumentHandle> implements OnInit {
    @Input() browsePrompt = this.translateService.instant('Choose file...');
    @Input() deletionAlertTitle = this.translateService.instant('Are you sure?');
    @Input() deletionAlertMessage = this.translateService.instant('This document will be deleted permanently from database.');
    @Input() deletionConfirmText = this.translateService.instant('Delete');
    @Input() deletionCancelText = this.translateService.instant('Cancel');
    @Input() readonly = false;
    @Input() readUrl: string;
    @Input() deleteUrl: string;
    @Input() extensions: string;
    @Input() allowDelete = true;
    @Input() showExtensionInfo = false;

    showBrowse = true;
    showRead = false;
    showDelete = false;
    filePath = '';

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
        private documentOperationService: DocumentOperationService,
        private utilityService: OTUtilityService,
        public messageService: GrowlMessageService,
        private httpClient: HttpClient,
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        this.browsePrompt = this.translateService.instant(this.browsePrompt);
        super.ngOnInit();
    }

    fileSelected(file: File) {
        if (file) {
            // Upload as temp document
            this.documentOperationService.UploadTempDocument(file).subscribe(
                tempDocumentId => {
                    if (this.value) {
                        this.value.isEmpty = false;
                        this.value.fileName = file.name;
                        this.value.tempDocumentId = tempDocumentId;
                    } else {
                        this.value = {
                            isEmpty: false,
                            isLoading: false,
                            fileName: file.name,
                            tempDocumentId: tempDocumentId,
                            isReadOnly: false
                        };
                    }
                    this.filePath = file.name;
                    this.showBrowse = false;
                    this.showDelete = true;
                    this.forceChange();
                }
            );
        }
    }

    fileDeleted() {
        if (this.value && !this.value.isEmpty) {
            // Check if this is temp document or not
            if (this.value.tempDocumentId > 0) {
                // Delete temp document immediately
                this.documentOperationService.RemoveTempDocument(this.value.tempDocumentId, 0).subscribe(
                    result => {
                        this.resetDocument();
                        this.forceChange();
                    }
                );
            } else {
                // Warn user about deletion
                swal({
                    title: this.deletionAlertTitle,
                    text: this.deletionAlertMessage,
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: this.utilityService.getColor('danger'),
                    cancelButtonColor: this.utilityService.getColor('secondary'),
                    confirmButtonText: this.deletionConfirmText,
                    cancelButtonText: this.deletionCancelText
                }).then((confirmResult) => {
                    if (confirmResult.value) {
                        const params = new HttpParams()
                            .append(this.value.itemParameterName || 'itemId', this.value.itemId.toString())
                            .append('documentId', this.value.documentId.toString());
                        this.httpClient.delete(this.deleteUrl, { params: params }).subscribe(
                            deleteResult => {
                                this.resetDocument();
                                this.forceChange();
                            }
                        );
                    }
                });
            }
        }
    }

    fileDownload() {
        const params = new HttpParams()
            .append(this.value.itemParameterName || 'itemId', this.value.itemId.toString())
            .append('documentId', this.value.documentId.toString());
        this.httpClient.get(this.readUrl, { responseType: 'blob', headers: { 'Accept': 'application/octet-stream' }, observe: 'body', params: params }).subscribe(
            blob => {
                saveAs(blob, this.value.fileName);
                this.messageService.success(this.translateService.instant('Download Success'));
            },
            error => {
                this.messageService.error(this.translateService.instant('Download Failed'));
            }
        );
    }

    resetDocument() {
        if (this.value) {
            this.value.isEmpty = true;
            this.value.fileName = '';
            this.value.tempDocumentId = 0;
            this.value.documentId = null;
        }
        this.showBrowse = true;
        this.showDelete = false;
        this.showRead = false;
    }

    setValue(value: DocumentHandle) {
        if (value && value.documentId) {
            this.showBrowse = false;
            this.showRead = true;
            if (!value.isReadOnly) {
                this.showDelete = true;
            }
        } else {
            this.resetDocument();
        }
        super.setValue(value);
    }
    writeValue(value: DocumentHandle) {
        if (value && value.documentId) {
            this.showBrowse = false;
            this.showRead = true;
            if (!value.isReadOnly) {
                this.showDelete = true;
            }
        } else {
            this.resetDocument();
        }
        super.writeValue(value);
        this.forceChange();
    }

    forceChange() {
        this.changed.forEach(f => f(this.value));
        this.touch();
        this.valueChange.emit(this.value);
    }

    listExtensions() {
        return this.extensions.split(',').join(' ');
    }
}
