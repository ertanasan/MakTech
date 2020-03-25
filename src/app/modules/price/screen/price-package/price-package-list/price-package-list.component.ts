// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';
import { PricePackageEditComponent } from '@price/screen/price-package/price-package-edit/price-package-edit.component';
import { PackageTypeService } from '@price/service/package-type.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { StorePackageService } from '@price/service/store-package.service';
import { OTPrintingService } from '@otservice/printing.service';
import { ProductPrice } from '@price/model/product-price.model';
import { ProductPriceService } from '@price/service/product-price.service';
import { StorePackage } from '@price/model/store-package.model';
import { ListParams } from '@otmodel/list-params.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { PackageVersion } from '@price/model/package-version.model';
import { UserService } from '@security/service/user.service';
import {contextReducer} from '@otlib/auth/store/context.reducers';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { map } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-price-package-list',
    templateUrl: './price-package-list.component.html',
    styleUrls: ['./price-package-list.component.css', ]
})
export class PricePackageListComponent extends ListScreenBase<PricePackage> implements AfterViewInit, OnInit {
    @ViewChild(PricePackageEditComponent, {static: true}) editScreen: PricePackageEditComponent;
    @ViewChild('packagePrint', {static: true}) packagePrint: ElementRef;
    @ViewChild('printSettingsDialog', {static: true}) printSettingsDialog: InputDialogComponent;
    @ViewChild('packageImageDialog', {static: true}) packageImageDialog: CustomDialogComponent;

    includeInactives: boolean;
    packageVersions: PackageVersion[] = [];

    // properties which will be used in print document
    selectedPackage: PricePackage;
    selectedPackageStores: StorePackage[] = [];
    selectedPackageProducts: ProductPrice[] = [];
    selectedVersion = 0;
    selectedDate = new Date();
    enterredDepartment = 'SATIN ALMA DEPARTMANI';
    enterredTitle = 'FİYAT PAKET DOKÜMANI';
    enterredContent = 'Yukarıda detayları verilen fiyat paketine göre fiyatları değişecek ürünler, uygulanacakları mağazalar ve geçerlilik süreleri ekteki tablolarda sunulmuştur.';
    enterredAuthor = 'Kübra ÖZCANBEY';
    enterredApprover = 'Murat TOPLU';

    packageImageInfo = { imageFileSrc: null, isOpen: false };

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PricePackageService,
        public userService: UserService,
        public printingService: OTPrintingService,
        public packageTypeService: PackageTypeService,
        public storePackageService: StorePackageService,
        public productPriceService: ProductPriceService,
        public packageVersionService: PackageVersionService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Price Package', RouterLink: '/price/price-package'}];
    }

    createEmptyModel(): PricePackage {
        return new PricePackage();
    }

    ngOnInit() {
        // Initialize properties
        this.includeInactives = false;
        this.excludeInactives();

        // Fill reference lists
        this.packageTypeService.listAll();

        if (!this.storePackageService.completeList) {
            this.storePackageService.listAll();
        }
        if (!this.userService.completeList) {
            this.userService.listAll();
        }

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    showDialog(target: DialogScreenBase, actionName: string, dataItem?: PricePackage) {
        if (actionName === 'Delete') {
            this.storePackageService.listByMasterAsync(null, dataItem.PackageId).subscribe(result => {
                const countStore =  result.length;
                if (countStore) {
                    this.messageService.error('There is an active StorePackage for this package');
                } else {
                    super.showDialog(target, actionName, dataItem);
                }
            });
        } else {
            this.editScreen.isCampaignGeneral = dataItem && dataItem.PackageType === 3;
            super.showDialog(target, actionName, dataItem);
        }
    }

    onIncludeInactivesChcBxClicked() {
        this.listParams.filter.filters = [];
        if (this.includeInactives === true) { // if  includeInactives were TRUE before clicked
            this.excludeInactives();
        }
        this.refreshList();
    }

    excludeInactives() {
        this.listParams.filter.logic = 'or';
        this.listParams.filter.filters.push( {field: 'ActiveStores', operator: 'gt', value: 0 } );
        const fifteenDaysBefore = new Date();
        fifteenDaysBefore.setDate(fifteenDaysBefore.getDate() - 15);
        this.listParams.filter.filters.push( {field: 'CreateDate', operator: 'gt', value: fifteenDaysBefore.toDateString() } );
    }

    showPrintSettings(packageToPrint: PricePackage) {
        this.selectedPackage = packageToPrint;
        const packageVersionLP = new ListParams();
        packageVersionLP.filter.filters.push( {field: 'Package', operator: 'eq', value: packageToPrint.PackageId } );
        this.packageVersionService.listAsync(packageVersionLP).subscribe( pV => {
            this.packageVersions = pV.Data;
            this.printSettingsDialog.show();
        });
    }

    printPackage(packageToPrint: PricePackage) {
        // this.selectedPackage = packageToPrint;
        this.storePackageService.listByMasterAsync(this.listParams, packageToPrint.PackageId).subscribe( stores => {
            this.selectedPackageStores = stores;
            this.productPriceService.getPackagePrices(packageToPrint.PackageId).subscribe( pP => {
                this.selectedPackageProducts = pP.filter( p => p.PackageVersion === this.selectedVersion);
                this.showPrintDialog();
            });
        });
    }

    showPrintDialog() {
        const styles = `
        <style type="text/css" media="screen, print">
        @media print {
            @page
            {
               size: A4;
               margin: 0.5cm 0.5cm 0.5cm 0.5cm;
            }

            * {
                font-family: Calibri;
            }

            header nav, footer
            {
                display: none;
            }

            td {
                border-collapse: collapse;
            }

            .td1
            {
                font-size: 15;
                padding-top:5px;
                padding-bottom:5px;
                text-align: center;
            }
            .td2
            {
                border-bottom: 1px solid #ddd;
                font-size: 13;
                padding-top:5px;
                padding-bottom:5px;
                text-align: center;
            }
            .td3
            {
                border-bottom: 1px solid #ddd;
                font-size: 13;
                padding-top:5px;
                padding-bottom:5px;
                text-align: center;
            }
            .td4
            {
                font-size: 13;
                padding-top:5px;
                padding-bottom:5px;
            }
            .printrow
            {
                padding-top: 5px;
                padding-botton: 5px;
            }
            .pagebreak {
                page-break-after: always;
            }

            .nopagebreak {
                page-break-after: avoid;
            }

            .divSeperator {
                margin-top: 30px;
            }

            .pageHeaderTable {
                border: 1px solid lightgray;
                border-collapse: collapse;
                color: lightgray;
            }

            .pageHeaderTableRow {
                color: lightgray;
                text-align: center;
            }
         }
         </style>
        `;
        setTimeout(() => {
            this.printingService.print(this.packagePrint.nativeElement.innerHTML, styles, 1200, 700);
        }, 1000);
    }

    readDataItem(dataItem: PricePackage) {
        return this.dataService.read(dataItem.PackageId);
    }

    onPreviewBtnClicked(dataItem: PricePackage) {
        this.readDataItem(dataItem).pipe(map(result => dataItem = result)).subscribe(result => {
            const fileExtension = dataItem.ImageDocument.fileName.substring(dataItem.ImageDocument.fileName.length - 3);
            this.dataService.getImageContent(dataItem.Image).subscribe(content => {

                switch (fileExtension) {
                    case 'jpg':
                        this.packageImageInfo = {imageFileSrc: 'data:image/jpeg;base64,' + content, isOpen: true};
                        this.packageImageDialog.show();
                        break;
                    case 'png':
                        this.packageImageInfo = {imageFileSrc: 'data:image/png;base64,' + content, isOpen: true};
                        this.packageImageDialog.show();
                        break;
                    default:
                        this.messageService.warning(this.translateService.instant('Image file format is not suitable'));
                        break;
                }
            });
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
