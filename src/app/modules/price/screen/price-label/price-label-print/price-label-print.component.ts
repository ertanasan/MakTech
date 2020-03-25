// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { BaseScreenContainerComponent } from '@otuiscreen/base-screen-container/base-screen-container.component';
import { PriceLabel } from '@price/model/price-label.model';
import { PriceLabelService } from '@price/service/price-label.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';

@Component({
    selector: 'price-label-print',
    templateUrl: './price-label-print.component.html',
    styleUrls: ['./price-label-print.component.css']
})
export class PriceLabelPrintComponent implements OnInit {

    @Input() productID: number;
    @Input() Code: string;
    @Input() name: string;
    @Input() saleVAT: number;
    @Input() total: number;
    @Input() unitName: string;
    @Input() barcodeType: number;
    @Input() barcode: number;
    @Input() privateLabel: boolean;
    @Input() eTrade: boolean;
    @Input() shortName: string;
    @Input() domestic: boolean;
    @Input() country: string;
    @Input() content: string;
    @Input() warning: string;
    @Input() storageCondition: string;
    @Input() expiresIn: number;
    @Input() shelfLife: number;
    @Input() price: number;
    @Input() topPrice: number;
    @Input() priceChangeDate: Date;
    @Input() isLastLabel: boolean;
    @Input() campaign: number;
    @Input() unitPrice: number;
    @Input() weightUnitName: string;
    @Input() package: number;
    @Input() imageContent: string;
    @Input() imageFileName: string;
    printingImageSrc: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: PriceLabelService,
        public productService: ProductService,
        public pricePackageService: PricePackageService,
    ) {
    }

    ngOnInit() {
        if (this.content && this.content.length >= 75) {
            this.content = this.content.slice(0, 76);
        }

        // Section: LOGO DETERMINATION SECTION
        let fileExtension: string;
        if (this.imageContent) {
            fileExtension = this.imageFileName.substring(this.imageFileName.length - 3);
            switch (fileExtension) {
                case 'jpeg':
                    this.printingImageSrc = 'data:image/' + fileExtension + ';base64,' + this.imageContent;
                    break;
                case 'jpg':
                    this.printingImageSrc = 'data:image/' + 'jpeg' + ';base64,' + this.imageContent;
                    break;
                case 'png':
                    this.printingImageSrc = 'data:image/' + fileExtension + ';base64,' + this.imageContent;
                    break;
                default:
                    fileExtension = null;
                    break;
            }
        }
        if (!fileExtension) {
            if (this.campaign && this.campaign > 0) {
                this.printingImageSrc = '\\assets\\label\\kampanya' + this.campaign + '.jpg';
            } else {
                this.printingImageSrc = '\\assets\\label\\ph.jpg';
            }
        }
        // END of Section
    }

}
