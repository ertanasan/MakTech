// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { TranslateService, TranslationChangeEvent } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StockTaking } from '@warehouse/model/stock-taking.model';
import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { StockTakingEditComponent } from '@warehouse/screen/stock-taking/stock-taking-edit/stock-taking-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { DatePipe } from '@angular/common';
import { DataStateChangeEvent, PageChangeEvent, EditEvent, GridDataResult, GridComponent, RowClassArgs } from '@progress/kendo-angular-grid';
import { process, SortDescriptor } from '@progress/kendo-data-query';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { StockTakingScheduleService } from '@warehouse/service/stock-taking-schedule.service';
import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { formatNumber, parseNumber } from '@telerik/kendo-intl';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { ZoneTypes } from 'app/util/shared-enums.component';
import * as _ from 'lodash';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { ListParams } from '@otmodel/list-params.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';
import { NumericEntryComponent } from '@otuidataentry/numeric-entry/numeric-entry.component';
import { UserService } from '@frame/security/service/user.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-taking-list',
    encapsulation: ViewEncapsulation.None,
    templateUrl: './stock-taking-list.component.html',
    styleUrls: ['./stock-taking-list.component.css', ]
})
export class StockTakingListComponent extends ListScreenBase<StockTaking> implements AfterViewInit, OnInit {
    @ViewChild(StockTakingEditComponent, {static: true}) editScreen: StockTakingEditComponent;
    @ViewChild(GridComponent, {static: true}) grid: GridComponent;
    @ViewChild(InputDialogComponent, {static: true}) valueErrorDialog: InputDialogComponent;
    @ViewChild(CustomDialogComponent, {static: true}) fastEntry: CustomDialogComponent;
    @ViewChild('dropdown_product' , {static: false}) dropdown_product: DropdownEntryComponent;
    @ViewChild('numEntry_numberofPackages' , {static: false}) numEntry_numberofPackages: NumericEntryComponent;
    @ViewChild('numEntry_totalWeight' , {static: false}) numEntry_totalWeight: NumericEntryComponent;

    store: Store;
    stockTakingSchedule: StockTakingSchedule;
    public scheduleid: number;
    public fromStore: string;
    storeList: Store[];
    updateModel: StockTaking;
    updateDataItem: StockTaking;
    fastEntryModel: StockTaking;
    public entryType = 1;
    zoneName1: string;
    zoneName2: string;
    zoneName3: string;
    newDataList: any;
    feProduct: number;
    fepackageQuantity: number;
    fepackageUnit: string;
    fenumberOfPackages: number;
    fetotalWeight: number;
    zoneId: any;
    saveMessage: string;
    valueBeforeEdit: number; // sütun giriş sırasında zonetotal'ı ayarlamak için önceki değeri saklıyor. 
    isDepot: boolean;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StockTakingService,
        public storeService: StoreService,
        public productService: ProductService,
        public storageZoneService: StorageZonesService,
        public stockTakingScheduleService: StockTakingScheduleService,
        public formBuilder: FormBuilder,
        public datePipe: DatePipe,
        public route: ActivatedRoute,
        private privilegeCacheService: PrivilegeCacheService,
        public userService: UserService,
    ) {
        super(messageService, translateService);
        this.allStockTakingData = this.allStockTakingData.bind(this);
    }

    getList() {
        this.dataService.listStockTakingProducts(this.scheduleid).subscribe(list => {
            list.forEach(row => {
                row.CountingPrice = row.CountingValue * row.UnitPrice;
            });
            this.dataService.stockTakingProductList = list;
            this.arrangeSelection();
        }, error => {
            this.messageService.error(error.message);
        });
    }

    refreshList() {
        this.arrangeSelection();
        // this.dataService.stockTakingDetails = process(this.dataService.stockTakingDetails.data, this.listParams);
        // this.getList();
    }

    createEmptyModel(): StockTaking {
        return new StockTaking();
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Stock Taking', RouterLink: '/warehouse/stock-taking-list'}];
    }

    readStockTaking(cb) {
        this.updateEnabled = false;
        this.stockTakingScheduleService.read(this.scheduleid).subscribe(dataItem => {
            this.stockTakingSchedule = dataItem;
            this.editScreen.stockTakingSchedule = this.stockTakingSchedule;
            if (dataItem.CountingStatus === 1) {
                this.updateEnabled = true;
            }
            if (dataItem.Store !== 999) {
                this.storageZoneService.getZoneList(ZoneTypes.Store);
                this.isDepot = false;
            } else {
                this.storageZoneService.getZoneList(dataItem.CountingType === 1 ? ZoneTypes.WarehouseGeneral : ZoneTypes.WarehouseDrill);
                this.isDepot = true;
            }
            cb();
        });
    }

    readUserStores() {
        this.storeService.listUserStores().subscribe(list => {
            this.storeList = list;
            this.store = null;
            if (this.storeList.length === 1) {
                this.store = this.storeList[0];
            }

            this.privilegeCacheService.checkPrivilege('Update Completed Counting').subscribe(
                result => {
                    if (result) {
                        this.updateEnabled = true;
                    }
            });
            /*
            if (list[0].UserBranchType === 'Central Office' && this.stockTakingSchedule.Store !== 999) {
              this.updateEnabled = true;
            }*/
          }, error => {
            this.messageService.error(error);
        });
    }

    ngOnInit() {
        // Read snapshots from URL
        this.scheduleid = this.route.snapshot.params['scheduleid'];
        this.fromStore = this.route.snapshot.params['fromStore'];

        // Get the parent item (stock taking schedule)
        this.readStockTaking(() => {
            // Get the store of the user
            this.readUserStores();
        });

        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }

        if (!this.userService.completeList) {
            this.userService.listAll();
        }

        this.initListParams();

        // Get the stockTaking products list
        this.getList();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    public createFormGroup(dataItem: any): FormGroup {
        let fg: FormGroup = null;
        fg = this.formBuilder.group({
            // CountingValue: new FormControl(dataItem.CountingValue),
            CountingValue: new FormControl(formatNumber(dataItem.CountingValue, {style: 'decimal'}, 'tr')),
            Zone1: new FormControl(formatNumber(dataItem.Zone1, {style: 'decimal'}, 'tr')),
            Zone2: new FormControl(formatNumber(dataItem.Zone2, {style: 'decimal'}, 'tr')),
            Zone3: new FormControl(formatNumber(dataItem.Zone3, {style: 'decimal'}, 'tr')),
            ZoneTotal: new FormControl(formatNumber(dataItem.ZoneTotal, {style: 'decimal'}, 'tr')),
        });
        return fg;
    }

    handleDataStateChange(state: DataStateChangeEvent) {

        super.handleDataStateChange(state);

    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {
        if (this.updateEnabled) {
            if (this.entryType === 2) {
                switch(columnIndex) {
                    case 6 : this.valueBeforeEdit = dataItem.Zone1; break;
                    case 7 : this.valueBeforeEdit = dataItem.Zone2; break;
                    case 8 : this.valueBeforeEdit = dataItem.Zone3; break;
                    default : this.valueBeforeEdit = 0;
                }
            } else this.valueBeforeEdit = 0;
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }
    }

    public commitValue() {
        if (this.updateModel.StockTakingId > 0) {
            this.dataService.updateRow(this.updateModel).subscribe(result => {
                this.updateDataItem.CountingDate = this.updateModel.CountingDate;
                if (this.entryType === 1) {
                    this.updateDataItem.CountingValue = this.updateModel.CountingValue;
                    this.updateDataItem.CountingPrice = this.updateModel.CountingPrice;
                } else {
                    for (let i = 1; i <= 3; i++) {
                        this.updateDataItem[`Zone${i}`] = this.updateModel[`Zone${i}`];
                    }
                }
            }, error => {
                console.log('error : ', error);
                this.messageService.error(error.error);
            });
        } else {
            this.updateModel.Event = 1;
            this.updateModel.Organization = 1;
            this.dataService.create(this.updateModel, 'create').subscribe(result => {
                this.updateDataItem.CountingDate = this.updateModel.CountingDate;
                this.updateDataItem.Event = 1;
                this.updateDataItem.Organization = 1;
                if (this.entryType === 1) {
                    this.updateDataItem.StockTakingId = result.StockTakingId;
                    this.updateDataItem.CountingValue = this.updateModel.CountingValue;
                    this.updateDataItem.CountingPrice = this.updateModel.CountingPrice;
                } else {
                    for (let i = 1; i <= 3; i++) {
                        this.updateDataItem[`Zone${i}`] = this.updateModel[`Zone${i}`];
                        if (this.storageZoneService.zoneList[i - 1].StorageZonesId === this.updateModel.Zone) {
                            this.updateDataItem[`StockTakingId${i}`] = result.StockTakingId;
                        }
                    }
                }
            }, error => {
                this.messageService.error(error);
            });
        }
    }

    onActionValueError(event) {
        this.commitValue();
        this.valueErrorDialog.hide();
    }

    updateZoneValue(dataItem, formGroup, zoneGroup) {
        this.updateDataItem = dataItem;
        this.updateModel = JSON.parse(JSON.stringify(this.updateDataItem));
        switch (zoneGroup) {
            case 1 :
                this.updateModel.CountingValue = parseNumber(formGroup.value.Zone1, 'tr');
                this.updateModel.Zone1 = parseNumber(formGroup.value.Zone1, 'tr');
                this.updateModel.StockTakingId = dataItem.StockTakingId1;
                this.updateModel.Zone = this.storageZoneService.zoneList[0].StorageZonesId;
                break;
            case 2 :
                this.updateModel.CountingValue = parseNumber(formGroup.value.Zone2, 'tr');
                this.updateModel.Zone2 = parseNumber(formGroup.value.Zone2, 'tr');
                this.updateModel.StockTakingId = dataItem.StockTakingId2;
                this.updateModel.Zone = this.storageZoneService.zoneList[1].StorageZonesId;
                break;
            case 3 :
                this.updateModel.CountingValue = parseNumber(formGroup.value.Zone3, 'tr');
                this.updateModel.Zone3 = parseNumber(formGroup.value.Zone3, 'tr');
                this.updateModel.StockTakingId = dataItem.StockTakingId3;
                this.updateModel.Zone = this.storageZoneService.zoneList[2].StorageZonesId;
                break;
        }
        this.updateModel.CountingDate = this.addHours(new Date(), 3);
        const countingItemValue: number = this.updateDataItem.UnitPrice * this.updateModel.CountingValue;
        this.updateModel.CountingPrice = countingItemValue;
        const isStore: boolean = (this.updateDataItem.Store !== 999);
        const isDepot: boolean = (this.updateDataItem.Zone === 1);
        if (isStore && ((isDepot && countingItemValue > 10000) || (!isDepot && countingItemValue > 3000))) {
            this.valueErrorDialog.caption = `${'Hatalı Veri'}`;
            this.valueErrorDialog.show();
        } else {
            // console.log('updateModel 2: ', this.updateModel);
            this.commitValue();
        }
    }
    public cellCloseHandler(args: any) {
        const { formGroup, dataItem, column } = args;
        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            if (args.column.field === 'CountingValue' && formGroup.value.CountingValue) {

                this.updateDataItem = dataItem;
                this.updateModel = JSON.parse(JSON.stringify(this.updateDataItem));
                this.updateModel.CountingValue = parseNumber(formGroup.value.CountingValue, 'tr');
                this.updateModel.CountingDate = this.addHours(new Date(), 3);

                const countingItemValue: number = this.updateDataItem.UnitPrice * this.updateModel.CountingValue;
                this.updateModel.CountingPrice = countingItemValue;
                const isStore: boolean = (this.updateDataItem.Store !== 999);
                const isDepot: boolean = (this.updateDataItem.Zone === 1);
                if (isStore && ((isDepot && countingItemValue > 10000) || (!isDepot && countingItemValue > 3000))) {
                    this.valueErrorDialog.caption = `${'Hatalı Veri'}`;
                    this.valueErrorDialog.show();
                } else {
                    this.commitValue();
                }
            } else if (args.column.field === 'Zone1' && formGroup.value.Zone1) {
                args.dataItem.ZoneTotal = args.dataItem.ZoneTotal - this.valueBeforeEdit + Number(formGroup.value.Zone1);
                this.updateZoneValue(dataItem, formGroup, 1);
            } else if (args.column.field === 'Zone2' && formGroup.value.Zone2) {
                args.dataItem.ZoneTotal = args.dataItem.ZoneTotal - this.valueBeforeEdit + Number(formGroup.value.Zone2);
                this.updateZoneValue(dataItem, formGroup, 2);
            } else if (args.column.field === 'Zone3' && formGroup.value.Zone3) {
                args.dataItem.ZoneTotal = args.dataItem.ZoneTotal - this.valueBeforeEdit + Number(formGroup.value.Zone3);
                this.updateZoneValue(dataItem, formGroup, 3);
            }
        }
    }

    public onSave() {
        const promiseArray = [];
        let returnmessage = '';

        const result = this.dataService.PostStockTakings();
        if (result === 0) {
            returnmessage = 'No changes in Stock Takings';
        } else {
            promiseArray.push(result.toPromise());
            promiseArray.push(this.stockTakingScheduleService.update(this.stockTakingSchedule, 'update').toPromise());
            returnmessage = 'Stock Takings saved.';
        }

        Promise.all(promiseArray).then(value => {
            this.getList();
            this.messageService.success(returnmessage); // || this.translateService.get('Exception occured with an empty error message.'));
        }).catch(error => this.messageService.error('Beklenmeyen bir hata oluştu.'));
    }

    onEnterClicked(e) {
        if (this.grid.activeCell && this.entryType === 1) {
            this.grid.focusCell(this.grid.activeCell.rowIndex + 1, this.grid.activeCell.colIndex);
        } else {
            e.preventDefault();
        }
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    public allStockTakingData(): any {
        return <GridDataResult> {
            data: this.dataService.stockTakingProductList,
            total: this.dataService.stockTakingProductList.length,
        };
    }

    public getStockTakingFileName(): string {
        const d: Date = this.addHours(new Date(), 3);
        const d2 = this.datePipe.transform(d, 'yyyyMMdd');
        return `StokSayım_${d2}.xlsx`;
    }

    arrangeSelection() {
        if (!this.storageZoneService.zoneList) { return; }
        const zoneid1 = this.storageZoneService.zoneList[0].StorageZonesId;
        const zoneid2 = this.storageZoneService.zoneList[1].StorageZonesId;
        const zoneid3 = this.storageZoneService.zoneList[2].StorageZonesId;
        this.zoneName1 = this.storageZoneService.zoneList[0].ZoneName;
        this.zoneName2 = this.storageZoneService.zoneList[1].ZoneName;
        this.zoneName3 = this.storageZoneService.zoneList[2].ZoneName;
        const sourcelist = this.dataService.stockTakingProductList;
        if (this.entryType === 2) {
            this.newDataList = _.uniqBy(sourcelist, 'Product');
            this.newDataList.forEach (row => {
                const productList =  _.filter(sourcelist, ['Product', row.Product]);
                let zoneTotal = 0;
                productList.forEach(pr => {
                    zoneTotal += pr.CountingValue;
                    if (pr.StockRed) {
                        row.StockRed = pr.StockRed;
                    }
                    switch (pr.Zone) {
                        case zoneid1 : row.Zone1 = pr.CountingValue; row.StockTakingId1 = pr.StockTakingId; break;
                        case zoneid2 : row.Zone2 = pr.CountingValue; row.StockTakingId2 = pr.StockTakingId; break;
                        case zoneid3 : row.Zone3 = pr.CountingValue; row.StockTakingId3 = pr.StockTakingId; break;
                    }
                });
                row.ZoneTotal = zoneTotal;
            });
            this.dataService.stockTakingDetails = process(this.newDataList, this.listParams);
        } else {
            this.newDataList = this.dataService.stockTakingProductList;
            this.dataService.stockTakingDetails = process(this.newDataList, this.listParams);
        }
    }

    initListParams() {
        this.listParams = new ListParams();
            this.listParams.pageable = {
                buttonCount: 5, // when type is numeric
                info: true,
                type: 'input', // 'numeric'
                pageSizes: [10, 20, 50, 100, 250], // true
                previousNext: true,
                refresh: true
              };
    }

    onSelectedChange(event, selection) {
        if (this.entryType !== selection) {
            this.entryType = selection;
            this.initListParams();
            this.getList();
        }
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        this.editScreen.entryType = this.entryType;
        this.editScreen.zoneName1 = this.zoneName1;
        this.editScreen.zoneName2 = this.zoneName2;
        this.editScreen.zoneName3 = this.zoneName3;
        super.showDialog(target, actionName, dataItem);
    }

    public rowCallback(context: RowClassArgs) {
        if (context.dataItem.StockRed) {   // change this condition as you need
          return {
            passive: true
          };
        }
    }

    onFastEntry() {
        this.fastEntry.caption = 'Hızlı Giriş';
        this.fastEntry.show();
    }

    onClose(event) {
        this.fastEntry.hide();
    }

    onFastEntryProductChange() {
        const productList =  _.filter(this.productService.completeList, ['ProductId', this.feProduct]);
        this.fepackageQuantity = productList[0].PackageQuantity;
        this.fepackageUnit = (productList[0].Unit === 1) ? 'KG' : 'ADET';
        setTimeout(() => {
            this.fenumberOfPackages = 0;
            this.numEntry_numberofPackages.focus();
        }, 100);
    }

    onNumberofPackagesChange() {
        this.fetotalWeight = Math.round(this.fenumberOfPackages * this.fepackageQuantity * 1000) / 1000;
    }

    onTotalWeightChange() {
        this.fenumberOfPackages = this.fetotalWeight / this.fepackageQuantity;
    }

    onEnterNumberofPackages() {
        this.numEntry_totalWeight.focus();
    }

    onEnterTotalWeight() {
        this.save(() => {
            this.saveMessage = 'Kaydedildi';
            setTimeout(() => {
                this.saveMessage = '';
                this.dropdown_product.focus();
            }, 1000);
        });
    }

    onZoneChanged(vzoneId) {
        this.zoneId = vzoneId;
        this.dropdown_product.focus();
    }

    save(cb) {
        if (!(this.zoneId > 0)) {
            this.messageService.warning('Bölge seçimi yapmalısınız.');
            return;
        }

        if (!(this.fetotalWeight > 0)) {
            this.messageService.warning('Miktar giriniz.');
            return;
        }

        this.fastEntryModel = new StockTaking();
        this.fastEntryModel.StockTakingSchedule = this.stockTakingSchedule.StockTakingScheduleId;
        this.fastEntryModel.Store = this.stockTakingSchedule.Store;
        this.fastEntryModel.Product = this.feProduct;
        this.fastEntryModel.CountingValue = this.fetotalWeight;
        this.fastEntryModel.Zone = this.zoneId;
        this.dataService.fastEntryUpdate(this.fastEntryModel).subscribe(() => {
            cb();
        });
    }

    getControlClasses() {
        const classes = {};
        classes['form-control'] = true;
        classes['row'] = true;
        return classes;
    }

    mikroTransfer() {
        this.dataService.MikroTransfer().subscribe(result => {
            this.messageService.success("Mikro'ya transfer edildi.");
        }, error => {
            this.messageService.error(error.error.text);
            console.log(error);
        })
    }

}
