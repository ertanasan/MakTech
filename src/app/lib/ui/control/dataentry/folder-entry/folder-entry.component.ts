import { HttpClient, HttpParams } from '@angular/common/http';
import { DocumentHandle } from '@otmodel/document-handle.model';
import { Component, OnInit, Input, Self, Optional, ViewChild, ElementRef } from '@angular/core';
import { NgControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { FolderHandle } from '@otmodel/folder-handle.model';
import { DocumentOperationService } from '@otservice/document-operation.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import swal from 'sweetalert2';
import { saveAs } from 'file-saver';

@Component({
    selector: 'ot-folder-entry',
    templateUrl: './folder-entry.component.html',
    styleUrls: ['./folder-entry.component.css'],
})
export class FolderEntryComponent extends DataEntryBase<FolderHandle> implements OnInit {
    @Input() browsePrompt = this.translateService.instant('Choose file(s)...');
    @Input() deletionAlertTitle = this.translateService.instant('Are you sure?');
    @Input() deletionAlertMessage = this.translateService.instant('This document will be deleted permanently from database.');
    @Input() deletionConfirmText = this.translateService.instant('Delete');
    @Input() deletionCancelText = this.translateService.instant('Cancel');
    @Input() readUrl = '';
    @Input() deleteUrl = '';
    @Input() listUrl = '';
    @Input() tempDocumentDownloadMessage = this.translateService.instant('Document has not been saved yet!');
    @Input() tempDocumentDownloadTitle = this.translateService.instant('Document Download');
    @Input() readonly = false;
    @Input() accept = '';
    folderName: string;
    fileName = '';
    @ViewChild('documentInput', { static: true }) documentElement: ElementRef;
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
        super.ngOnInit();
    }

    downloadDocument(document: DocumentHandle) {
        if (document.documentId) {
            const params = new HttpParams()
                .append(document.itemParameterName || 'itemId', document.itemId.toString())
                .append('documentId', document.documentId.toString());
            this.httpClient.get(this.readUrl, { responseType: 'blob', headers: { 'Accept': 'application/octet-stream' }, observe: 'body', params: params }).subscribe(
                blob => {
                    saveAs(blob, document.fileName);
                    this.messageService.success(this.translateService.instant('File downloaded.'));
                },
                error => {
                    this.messageService.error(this.translateService.instant('File download failed.'));
                }
            );
        } else {
            swal({
                title: this.tempDocumentDownloadMessage,
                text: this.tempDocumentDownloadMessage,
                type: 'info',
                confirmButtonColor: this.utilityService.getColor('primary'),
                cancelButtonColor: this.utilityService.getColor('secondary'),
                confirmButtonText: this.deletionConfirmText,
                cancelButtonText: this.deletionCancelText
            }).then();

        }
    }

    removeDocument(document: DocumentHandle) {
        const folderId = this.value.folderId || this.value.tempFolderId;
        if (document.tempDocumentId > 0) {
            // Delete temp document immediately
            this.documentOperationService.RemoveTempDocument(document.tempDocumentId, folderId).subscribe(
                result => {
                    const index = this.value.documents.indexOf(document, 0);
                    if (index > -1) {
                        this.value.documents.splice(index, 1);
                    }
                    this.resetDocument();
                    this.forceChange();
                }
            );
        } else {
            // Warn user about deletion
            swal(
                {
                    title: this.deletionAlertTitle,
                    text: this.deletionAlertMessage,
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: this.utilityService.getColor('danger'),
                    cancelButtonColor: this.utilityService.getColor('secondary'),
                    confirmButtonText: this.deletionConfirmText,
                    cancelButtonText: this.deletionCancelText
                }
            ).then((confirmResult) => {
                if (confirmResult.value) {
                    const params = new HttpParams()
                        .append(document.itemParameterName || 'itemId', document.itemId.toString())
                        .append('documentId', document.documentId.toString());
                    this.httpClient.delete(this.deleteUrl, { params: params }).subscribe(
                        deleteResult => {
                            const index = this.value.documents.indexOf(document, 0);
                            if (index > -1) {
                                this.value.documents.splice(index, 1);
                            }
                            this.resetDocument();
                            this.forceChange();
                        }
                    );
                }
            }
            );
        }
    }

    fileSelected(files: FileList) {
        if (this.accept !== '') {
            const fileArray = Array.from(files);
            for (let i = 0; i < fileArray.length; i++) {
                if (this.accept.indexOf(fileArray[i].name.split('.').pop()) === -1) {
                    alert('Invalid file extension!');
                    return;
                }
            }
        }
        console.log('Files:', files);
        if (files) {
            if (!this.value.folderId && !this.value.tempFolderId) {
                // Create temp folder
                this.documentOperationService.CreateTempFolder().subscribe(
                    tempFolderId => {
                        this.value.tempFolderId = tempFolderId;
                        this.uploadTempDocument(tempFolderId, files);
                    }
                );
            } else {
                const folderId = this.value.folderId || this.value.tempFolderId;
                this.uploadTempDocument(folderId, files);
            }
        }
    }

    uploadTempDocument(folderId: number, files: FileList) {
        // Upload as temp document
        Array.from(files).forEach((file) => {

            const documentHandle = new DocumentHandle();
            this.documentOperationService.UploadTempDocument(file, folderId).subscribe(
                tempDocumentId => {
                    documentHandle.tempDocumentId = tempDocumentId;
                    documentHandle.isLoading = false;
                    this.forceChange();
                }
            );
            documentHandle.isEmpty = false;
            documentHandle.fileName = file.name;
            documentHandle.isLoading = true;
            this.value.documents.push(documentHandle);
        });
    }

    forceChange() {
        this.changed.forEach(f => f(this.value));
        this.touch();
        this.valueChange.emit(this.value);
    }

    resetDocument() {
        this.fileName = '';
        this.documentElement.nativeElement.value = '';
    }
}
