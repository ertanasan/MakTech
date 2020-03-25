import {finalize, first, toArray} from 'rxjs/operators';
import { Component, ViewChild, OnInit, AfterViewInit, TemplateRef, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { PriceLabel } from '@price/model/price-label.model';
import { PriceLabelService } from '@price/service/price-label.service';
import { PriceLabelEditComponent } from '@price/screen/price-label/price-label-edit/price-label-edit.component';
import { process } from '@progress/kendo-data-query';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { OTPrintingService } from '@otservice/printing.service';
import { Warning } from '@product/model/warning.model';
import { PriceLabelPrintService } from '@price/service/price-label-print.service';
import { PriceLabelPrint } from '@price/model/price-label-print.model';
import * as _ from 'lodash';
import { RadioEntryComponent } from '@otuidataentry/radio-entry/radio-entry.component';
import {PricePackageService} from '@price/service/price-package.service';
import {PricePackage} from '@price/model/price-package.model';
import {Subject} from 'rxjs';

@Component({
    selector: 'ot-price-label-list',
    templateUrl: './price-label-list.component.html',
    styleUrls: ['./price-label-list.component.css'],
    providers: [OTPrintingService]
})
export class PriceLabelListComponent extends ListScreenBase<PriceLabel> implements AfterViewInit, OnInit {

    @ViewChild('priceLabelPrint', {static: true}) priceLabelPrint: ElementRef;
    @ViewChild('priceLabelBigPrint', {static: true}) priceLabelBigPrint: ElementRef;
    @ViewChild('radio', {static: true}) otRadio: RadioEntryComponent;
    priceLabels: PriceLabel[] = [];
    selectedProducts =  [];
    labelSize = '';
    packageImageList: { packageId: number, imageContent: string, fileName: string }[] = [];
    baseUrl: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PriceLabelService,
        private printingService: OTPrintingService,
        private priceLabelPrintService: PriceLabelPrintService,
        public packageService: PricePackageService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.activeList = process(this.priceLabels, this.listParams);

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Price' }, { Caption: 'Price Label', RouterLink: '/price/price-label' }];
    }

    createEmptyModel(): PriceLabel {
        return new PriceLabel();
    }

    ngOnInit() {
        this.dataService.getLabelPriceList().pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            result => {
                this.priceLabels = result;
                this.getPackageImages();
                this.refreshList();
            },
            error => {
                this.messageService.error(`Package Change Error : ${error.message}`);
            }
        );
        this.otRadio.choice = 'Small';
        this.labelSize = 'Small';
        this.dataService.getLabelPriceCheckedList(this.labelSize).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            result => {
                this.selectedProducts = result;
            },
            error => {
                this.messageService.error(`Package Change Error : ${error.message}`);
            }
        );

        const currentPageUrl = window.location.href;
        this.baseUrl = currentPageUrl.slice(0, currentPageUrl.length - 22);
        super.ngOnInit();
    }

    getPackageImages() {
        const packageDataReady = new Subject();
        this.packageService.listAll();
        this.packageService.completeListChanged.pipe(first()).subscribe(list => {
            const packagesWithImage = list.filter(p => p.Image && p.Image > 0);
            let fetchedPackagesCounter = 0;
            packagesWithImage.forEach( packageWithImage => {
                const promiseArr = new Array<Promise<any>>();
                promiseArr.push(this.packageService.getImageContent(packageWithImage.Image).toPromise());
                promiseArr.push(this.packageService.read(packageWithImage.PackageId).toPromise());
                Promise.all(promiseArr).then(result => {
                    fetchedPackagesCounter++;
                    this.packageImageList.push({ packageId: packageWithImage.PackageId,
                                                 imageContent: result[0],
                                                 fileName: result[1].ImageDocument.fileName });
                    if (packagesWithImage.length === fetchedPackagesCounter) {
                        packageDataReady.next();
                    }
                });
            });
            packageDataReady.pipe(first()).subscribe(() => {
                this.priceLabels.forEach(pl => {
                    const packageImageForTheLabel = this.packageImageList.find(pil => pil.packageId === pl.Package);
                    if (packageImageForTheLabel) {
                        pl.ImageContent = packageImageForTheLabel.imageContent;
                        pl.ImageFileName = packageImageForTheLabel.fileName;
                    }
                });
            });
        });
    }

    selectedChange() {
        this.dataService.getLabelPriceCheckedList(this.labelSize).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
        result => this.selectedProducts = result,
        error => this.messageService.error(`Package Change Error : ${error.message}`)
        );
    }
    ngAfterViewInit() {
    }

    getSelectedProducts(): PriceLabel[] {
        return this.priceLabels.filter((l) => {
            if (this.selectedProducts.indexOf(l.ProductID) !== -1) {
                l.ProductInfoUrl = this.baseUrl + 'PublicOperations/ProductInfo/' + l.ProductID.toString();
                return true;
            }
            return false;
        });
    }

    // size: 9.6cm 5cm;
    showPrintDialog() {

        if (this.labelSize === '') {
            this.messageService.warning('Etiket boyutu seçimi yapmalısınız.');
            return;
        }

        const styles = `
        <style type="text/css" media="screen, print">
            @page {
               margin: 3mm 0mm 0mm 0mm;
            }

            header nav, footer {display: none;}

            .not-last-label {page-break-after: always;}

            table {
                border: 1px solid #CCC;
                border-collapse: collapse;
                max-width:90mm;
                table-layout:fixed;
                border: 1px solid black;
                table-layout: fixed;
            }

            table td
            {
                table-layout:fixed;
                overflow:hidden;
                word-wrap:break-word;
                padding: 0; margin: 0;
            }

            .rotate {
               text-align: center;
               white-space: nowrap;
               vertical-align: middle;
               width: 1.5em;
               font-family:"IDAHC39M Code 39 Barcode";
               font-size: 11
            }
            .rotate div {
               transform: rotate(-90.0deg);
               -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
               -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
               -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
               filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
               -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
               margin-left: -10em;
               margin-right: -10em;
            }
            .rotate_nobarcode {
                text-align: center;
                white-space: nowrap;
                vertical-align: middle;
                width: 1.5em;
                font-family:"Courier";
                font-size: 11;
             }
             .rotate_nobarcode div {
                transform: rotate(-90.0deg);
                -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
                -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
                filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
             }
             .a {
               border: none;
               font-size: 10px;
               font-family: calibri;
            }
            .qrcode-small img {
                width: 19mm!important;
                margin-left: -2mm!important;
            }
         </style>
        `;


        const stylesBig = `
        <style type="text/css" media="screen, print">
            @page {
               margin: 3mm 0mm 0mm 3mm;
            }

            header nav, footer {display: none;}

            .not-last-label {page-break-after: always;}

            table {
                border: 1px solid #CCC;
                border-collapse: collapse;
                max-width:130mm;
                max-height:90mm;
                table-layout:fixed;
                border: 1px solid black;
                table-layout: fixed;
            }

            table td
            {
                table-layout:fixed;
                overflow:hidden;
                word-wrap:break-word;
            }

            .rotate {
               text-align: center;
               white-space: nowrap;
               vertical-align: middle;
               width: 2.25em;
               font-family:"IDAHC39M Code 39 Barcode";
               font-size: 17px
            }
            .rotate div {
               transform: rotate(-90.0deg);
               -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
               -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
               -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
               filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
               -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
               margin-left: -10em;
               margin-right: -10em;
            }
            .rotate_nobarcode {
                text-align: center;
                white-space: nowrap;
                vertical-align: middle;
                width: 2.25em;
                font-family:"Courier";
                font-size: 17px
             }
             .rotate_nobarcode div {
                transform: rotate(-90.0deg);
                -moz-transform: rotate(-90.0deg);  /* FF3.5+ */
                -o-transform: rotate(-90.0deg);  /* Opera 10.5 */
                -webkit-transform: rotate(-90.0deg);  /* Saf3.1+, Chrome */
                filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083);  /* IE6,IE7 */
                -ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=0.083)"; /* IE8 */
                margin-left: -10em;
                margin-right: -10em;
             }

            .a {
               border: none;
               font-size: 15px;
               font-family: calibri;
            }
            .qrcode-small img {
                width: 19mm!important;
                margin-left: -2mm!important;
            }
         </style>
        `;

        if (this.labelSize === 'Small') {

            this.priceLabelPrintService.markAsPrinted(this.getSelectedProducts(), 'Small');
            this.printingService.print(this.priceLabelPrint.nativeElement.innerHTML, styles, 1200, 700);
        } else {
            this.printingService.print(this.priceLabelBigPrint.nativeElement.innerHTML, stylesBig, 1200, 700);
            this.priceLabelPrintService.markAsPrinted(this.getSelectedProducts(), 'Large');
        }
    }
}
