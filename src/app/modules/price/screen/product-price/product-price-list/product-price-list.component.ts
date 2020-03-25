// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { TranslateService, TranslationChangeEvent } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import '@progress/kendo-angular-intl/locales/en/all';
import '@progress/kendo-angular-intl/locales/tr/all';

import { ProductPrice } from '@price/model/product-price.model';
import { ProductPriceService } from '@price/service/product-price.service';
import { ProductPriceEditComponent } from '@price/screen/product-price/product-price-edit/product-price-edit.component';
import { ModelBase } from '@otmodel/model-base';
import { MainScreenBase } from '@otscreen-base/main-screen-base';
import { ListParams } from '@otmodel/list-params.model';
import { PageChangeEvent, DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Subscription } from 'rxjs';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { PriceModule } from '@price/price.module';
import { PricePackageService } from '@price/service/price-package.service';
import { process } from '@progress/kendo-data-query';
import { _ } from '@biesbjerg/ngx-translate-extract/dist/utils/utils';
import { IntlService } from '@progress/kendo-angular-intl';
import { OTPrintingService } from '@otservice/printing.service';
import { Package } from '@product/model/package.model';
import { StorePackageService } from '@price/service/store-package.service';
import { StorePackage } from '@price/model/store-package.model';
import { UserService } from '@frame/security/service/user.service';

const baseCommandColumnWidth = 22;
const singleCommandColumnWidth = 40;

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-price-list',
    templateUrl: './product-price-list.component.html',
    styleUrls: ['./product-price-list.component.css']
})
export class ProductPriceListComponent<T extends ModelBase> extends MainScreenBase implements AfterViewInit, OnInit {

    listParams: ListParams = new ListParams();
    dataLoading = false;
    translateSubscription: Subscription;
    private editedRowIndex: number;
    public formGroup: FormGroup;
    dataList: T[];
    packageId: number;
    mainData: any;

    commandColumnWidth = 142;

    @ViewChild('packagePricePrint', {static: true}) productPricePrint: ElementRef;
    selectedPackage: Package;
    selectedPackageProducts: ProductPrice[] = [];
    selectedPackageStores: StorePackage[] = [];

    constructor(
        messageService: GrowlMessageService,
        protected translateService: TranslateService,
        public userService: UserService,
        public dataService: ProductPriceService,
        public printingService: OTPrintingService,
        public packageService: PricePackageService,
        public storePackageService: StorePackageService,
        private formBuilder: FormBuilder
    ) {
        super(messageService, translateService);
    }

    refreshData(id?: number) {
        this.refreshList();
    }

    createEmptyItem(): any {
        return this.createEmptyModel();
    }

    refreshList() {
        if (this.mainData) {
            this.mainData.map(t => {
               t.UpdateDate = new Date(t.UpdateDate);
            });
            this.dataService.activeList = process(this.mainData, this.listParams);
        }
    }

    packageChanged() {
        this.dataService.getPackagePrices(this.packageId).subscribe(result => {
            this.dataService.activeList.data = result;
            this.dataService.activeList.total = result.length;

            this.dataService.activeList.data.forEach((m) => {
                m.OldPriceAmount = m.PriceAmount;
                // m.PriceChanged = m.PackageProduct; // (m.CurrentPriceAmount !== m.PriceAmount);
                m.OldTopPriceAmount = m.TopPriceAmount;
                m.OldPrintTopPriceFlag = m.PrintTopPriceFlag;
                m.OldPackageProduct = m.PackageProduct;
            });

            this.mainData = JSON.parse(JSON.stringify(this.dataService.activeList.data));
            this.dataService.activeList = {
                data: this.mainData.slice(0, 10),
                total: this.mainData.length
            };
        },
        error => {
            this.dataLoading = false;
            this.messageService.error(`Package Change Error : ${error.message}`);
        });
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Price' }, { Caption: 'Product Price', RouterLink: '/price/product-price' }];
    }

    createEmptyModel(): ProductPrice {
        return new ProductPrice();
    }

    ngOnInit() {
        if (!this.userService.completeList) {
            this.userService.listAll();
        }

        this.dataLoading = true;
        this.packageService.listAllAsync().subscribe(
            list => {
                this.dataLoading = false;
                this.packageService.completeList = list;
                this.packageId = 1;
            },
            error => {
                this.dataLoading = false;
                this.messageService.error(error.message);
            }
        );
        this.refreshList();
        this.translateSubscription = this.translateService.onLangChange.subscribe((event: TranslationChangeEvent) => {
            this.refreshList();
        });
        super.ngOnInit();
    }

    ngAfterViewInit() {
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    public createFormGroup(dataItem: any): FormGroup {
        return this.formBuilder.group({
            PriceAmount: new FormControl(dataItem.PriceAmount),
            TopPriceAmount: new FormControl(dataItem.TopPriceAmount),
        });
    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {
        if (!isEdited) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }
    }

    public cellCloseHandler(args: any) {
        const { formGroup, dataItem } = args;

        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            this.dataService.assignValues(dataItem, formGroup.value);
            if (!dataItem.PackageProduct) {
                dataItem.PackageProduct = (dataItem.CurrentPriceAmount !== dataItem.PriceAmount);
            }
        }
    }

    public onSave() {
        const updatedRows = [];
        this.mainData.forEach((r) => {
            if (!r.PackageProduct) {
                r.PackageProduct = (r.CurrentPriceAmount !== r.PriceAmount);
            }
            if (   r.OldTopPriceAmount !== r.TopPriceAmount
                || r.OldPrintTopPriceFlag !== r.PrintTopPriceFlag
                || r.OldPriceAmount !== r.PriceAmount
                || r.OldPackageProduct !== r.PackageProduct) {
                updatedRows.push(r);
            }
        });
        if (updatedRows.length > 0) {
            this.dataService.updatePrices(updatedRows).subscribe(
                result => {
                    this.messageService.success(this.translateService.instant('Prices Updated.'));
                    this.packageChanged();
                },
                error => {
                    this.messageService.error(this.translateService.instant('Update failed. Error: {{0}}', error));
                }
            );
        } else {
            this.messageService.warning(`Nothing to update.`);
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {

        this.listParams.skip = 0;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }

        this.refreshList();
    }

    handlePageChange(event: PageChangeEvent) {
        this.listParams.skip = event.skip;
        this.dataService.activeList = {
            data: this.mainData.slice(this.listParams.skip, this.listParams.skip + this.listParams.take),
            total: this.mainData.length
        };
        this.refreshList();
    }

    handleSortChange(sort: SortDescriptor[]) {

        if (sort) {
            this.listParams.sort = sort;
        }
        this.refreshList();
    }

    onPrint() {
        this.selectedPackageProducts = [];
        this.mainData.forEach((r) => {
            if (  r.PackageProduct === true || (r.CurrentPriceAmount !== r.PriceAmount)) {
                this.selectedPackageProducts.push(r);
            }
        });
        this.printPrices();
    }

    printPrices() {
        const packageLP = new ListParams();
        packageLP.filter.filters.push( {field: 'PackageId', operator: 'eq', value: this.packageId } );
        this.packageService.listAsync(packageLP).subscribe( p => {
            this.selectedPackage = p.Data[0];
            this.storePackageService.listByMasterAsync(this.listParams, this.selectedPackage.PackageId).subscribe( stores => {
                this.selectedPackageStores = stores;
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
            this.printingService.print(this.productPricePrint.nativeElement.innerHTML, styles, 1200, 700);
        }, 1000);
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
