import { Component, OnInit, Output, EventEmitter, Input, AfterViewInit, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

import { parseNumber } from '@progress/kendo-angular-intl';

import { DataEntryBase } from '@otcommon/data-entry-base/data-entry-base';
import { Document} from '@document/model/document.model';

import { ImageServiceDescriptor } from './image-service-descriptor.interface';
import { ImageGalleryService } from './image-gallery.service';

@Component({
    selector: 'ot-image-gallery',
    templateUrl: './image-gallery.component.html',
    styleUrls: ['./image-gallery.component.css'],
})
export class ImageGalleryComponent extends DataEntryBase<number> implements OnInit, AfterViewInit {
    @Input() items: any[] = [];
    @Input() imageWidth: '400px';
    @Input() imageHeight: '300px';
    @Input() activeIndex: number;
    @Input() thumbWidth: number;
    @Input() thumbHeight: number;

    _modelId = 0;
    @Input() set modelId(value: number) {
        const refreshRequired = (this._modelId !== value);
        this._modelId = value;
        if (refreshRequired) {
            this.refreshImageList();
        }
    }
    get modelId(): number {
        return this._modelId;
    }

    private _serviceDescriptor: ImageServiceDescriptor;
    @Input() set serviceDescriptor(value: ImageServiceDescriptor) {
        const refreshRequired = (this._serviceDescriptor !== value);
        this._serviceDescriptor = value;
        if (refreshRequired) {
            this.refreshImageList();
        }
    }
    get serviceDescriptor(): ImageServiceDescriptor {
        return this._serviceDescriptor;
    }

    @Output() imageAdded: EventEmitter<File> = new EventEmitter();
    @Output() imageRemoved: EventEmitter<File> = new EventEmitter();

    fileInput: string;

    private _viewInitCompleted = false;

    constructor(
        @Optional() @Self() ngControl: NgControl,
        translateService: TranslateService,
        private imageGalleryService: ImageGalleryService
    ) {
        super(ngControl, translateService);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    ngAfterViewInit() {
        if (this._serviceDescriptor) {
            this._viewInitCompleted = true;
            this.refreshImageList();
        }
    }

    reloadAll() {
        this.items = [];
        this.refreshImageList();
    }

    refreshImageList() {
        if (this._viewInitCompleted && this._modelId && this._serviceDescriptor) {
            this.imageGalleryService.descriptor = this._serviceDescriptor;
            this.imageGalleryService.listImages(this._modelId).subscribe(
                imageList => {
                    if (imageList) {
                        imageList.filter(i => i.Name.endsWith('.thumb')).forEach((thumb) => {
                            this.imageGalleryService.readImage(this._modelId, thumb.DocumentId).subscribe(
                                data => {
                                    this.createImageFromBlob(data, true, thumb, null);
                                }
                            );
                        });
                    }
                }
            );
        }
    }

    createImageFromBlob(image: Blob, isThumb: boolean, thumbDocument: Document, imageDocument: Document) {
        const reader = new FileReader();
        reader.addEventListener('load', () => {
            if (isThumb) {
                const index = this.items.push({ thumb: reader.result, thumbDocument: thumbDocument, imageDocument: imageDocument });
                console.log('createImageFromBlob added item index:', this.items, index);
                if (index === 1) {
                    this.loadItemImage(this.items[0]);
                }
            } else {
                if (thumbDocument) {
                    const item = this.items.find(i => i.thumbDocument && (i.thumbDocument.DocumentId === thumbDocument.DocumentId));
                    if (item) {
                        item.image = reader.result;
                        item.imageDocument = imageDocument;
                    } else {
                        this.items.push({ image: reader.result, thumbDocument: thumbDocument, imageDocument: imageDocument });
                    }
                } else {
                    this.items.push({ image: reader.result, thumbDocument: thumbDocument, imageDocument: imageDocument });
                }
            }
        }, false);

        if (image) {
           reader.readAsDataURL(image);
        }
    }

    imagesAdded(event: any) {
        this.addImage(event.srcElement.files[0]);
        this.fileInput = '';
    }

    addImage(file: File) {
        let addPhotoObservable: Observable<number>;
        this.imageGalleryService.descriptor = this._serviceDescriptor;
        if (this._modelId) {
            addPhotoObservable = this.imageGalleryService.addImage(
                this._modelId, this.innerValue || 0, file, this.thumbWidth, this.thumbHeight);
        } else {
            addPhotoObservable = this.imageGalleryService.addImage(0, this.innerValue || 0, file, this.thumbWidth, this.thumbHeight);
        }
        addPhotoObservable.subscribe(
            folderId => {
                // Set the returning folder id as component value
                this.value = folderId;

                // Also add this image to the items list
                this.createImageFromBlob(file, false, null, null); // File extends Blob
            }
        );
    }

    thumbClick(item: any) {
        // Check image existance and download
        if (item.thumbDocument) {
            this.loadItemImage(item);
            this.activeIndex = this.items.findIndex(i => i.thumbDocument.DocumentId === item.thumbDocument.DocumentId);
        }
    }

    scrollItemChanged(event: any) {
        if (event.item.thumbDocument) {
            this.loadItemImage(event.item);
        }
    }

    loadItemImage(item: any) {
        const thumbDocument: Document = item.thumbDocument;
        const imageDocumentId = parseNumber(thumbDocument.Name.substr(0, thumbDocument.Name.lastIndexOf('.')));
        if (!item.image) {
            this.imageGalleryService.readImage(this._modelId, imageDocumentId).subscribe(
                data => {
                    this.createImageFromBlob(data, false, thumbDocument, null);
                }
            );
        }
    }
}
