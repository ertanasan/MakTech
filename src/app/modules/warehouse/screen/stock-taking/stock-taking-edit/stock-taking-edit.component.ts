// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StockTaking } from '@warehouse/model/stock-taking.model';
import { StockTakingService } from '@warehouse/service/stock-taking.service';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { DatePipe } from '@angular/common';
import { StorageZonesService } from '@warehouse/service/storage-zones.service';
import { StockTakingSchedule } from '@warehouse/model/stock-taking-schedule.model';
import { InputDialogComponent } from '@otuicontainer/dialog/input-dialog/input-dialog.component';
import { parseNumber } from '@telerik/kendo-intl';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-stock-taking-edit',
    templateUrl: './stock-taking-edit.component.html',
    styleUrls: ['./stock-taking-edit.component.css', ]
})
export class StockTakingEditComponent extends CRUDDialogScreenBase<StockTaking> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StockTaking>;
    @ViewChild(InputDialogComponent, {static: true}) valueErrorDialog: InputDialogComponent;

    public stockTakingSchedule: StockTakingSchedule;
    public updateModel: StockTaking;
    public updateDataItem: StockTaking;
    public entryType = 1;
    zoneName1: string;
    zoneName2: string;
    zoneName3: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StockTakingService,
        public storeService: StoreService,
        public productService: ProductService,
        public datePipe: DatePipe,
        public storageZoneService: StorageZonesService
    ) {
        super(messageService, translateService, dataService, 'Stock Taking');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StockTakingId: new FormControl(),
            ProductName: new FormControl(),
            Zone: new FormControl(),
            CountingValue: new FormControl(),
            Zone1: new FormControl(),
            Zone2: new FormControl(),
            Zone3: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    commitValue() {
        const itemIndex = this.getIndex();
        const dataItem = this.dataService.stockTakingDetails.data[itemIndex];
        if (itemIndex !== -1) {
            if (this.updateModel.StockTakingId > 0) {
                this.dataService.updateRow(this.updateModel).subscribe(result => {
                    dataItem.CountingDate = this.updateModel.CountingDate;
                    if (this.entryType === 1) {
                        dataItem.CountingValue = this.updateModel.CountingValue;
                        dataItem.CountingPrice = this.updateModel.CountingPrice;
                    } else {
                        for (let i = 1; i <= 3; i++) {
                            dataItem[`Zone${i}`] = this.container.currentItem[`Zone${i}`];
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
                    dataItem.CountingDate = this.updateModel.CountingDate;
                    dataItem.Event = 1;
                    dataItem.Organization = 1;
                    if (this.entryType === 1) {
                        dataItem.StockTakingId = result.StockTakingId;
                        dataItem.CountingValue = this.updateModel.CountingValue;
                        dataItem.CountingPrice = this.updateModel.CountingPrice;
                    } else {
                        for (let i = 1; i <= 3; i++) {
                            dataItem[`Zone${i}`] = this.container.currentItem[`Zone${i}`];
                            if (this.storageZoneService.zoneList[i - 1].StorageZonesId === this.updateModel.Zone) {
                                dataItem[`StockTakingId${i}`] = result.StockTakingId;
                            }
                        }
                    }
                }, error => {
                    this.messageService.error(error);
                });
            }
        } else {
            this.messageService.error(`An unexpected error occured during updating counting value of ${this.container.mainForm.value.ProductName} at ${this.container.mainForm.value.Zone}`);
        }
    }

    onActionValueError(event) {
        this.commitValue();
        this.valueErrorDialog.hide();
        this.container.hide();
    }

    updateZoneValue(dataItem, zoneGroup) {
        this.updateDataItem = dataItem;
        this.updateModel = JSON.parse(JSON.stringify(this.updateDataItem));
        switch (zoneGroup) {
            case 1 :
                this.updateModel.CountingValue = this.container.currentItem.Zone1;
                this.updateModel.Zone1 = this.container.currentItem.Zone1;
                this.updateModel.StockTakingId = dataItem.StockTakingId1;
                this.updateModel.Zone = this.storageZoneService.zoneList[0].StorageZonesId;
                break;
            case 2 :
                this.updateModel.CountingValue = this.container.currentItem.Zone2;
                this.updateModel.Zone2 = this.container.currentItem.Zone2;
                this.updateModel.StockTakingId = dataItem.StockTakingId2;
                this.updateModel.Zone = this.storageZoneService.zoneList[1].StorageZonesId;
                break;
            case 3 :
                this.updateModel.CountingValue = this.container.currentItem.Zone3;
                this.updateModel.Zone3 = this.container.currentItem.Zone3;
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
            return false;
        } else {
            if (this.updateModel.CountingValue) {
                this.commitValue();
            }
            return true;
        }
    }

    onSubmit() {
        const itemIndex = this.getIndex();
        if (itemIndex !== -1) {
            this.updateDataItem = this.dataService.stockTakingDetails.data[itemIndex];
            // console.log('onSubmit : ', this.updateDataItem);
            this.updateModel = JSON.parse(JSON.stringify(this.dataService.stockTakingDetails.data[itemIndex]));
            if (this.entryType === 1) {
                this.updateModel.CountingValue = this.container.mainForm.value.CountingValue;
                this.updateModel.CountingDate = this.addHours(new Date(), 3);

                const countingItemValue: number = this.updateDataItem.UnitPrice * this.updateModel.CountingValue;
                const isStore: boolean = (this.updateDataItem.Store !== 999);
                const isDepot: boolean = (this.updateDataItem.Zone === 1);
                if (isStore && ((isDepot && countingItemValue > 10000) || (!isDepot && countingItemValue > 3000))) {
                    this.valueErrorDialog.caption = `${'Hatalı Veri'}`;
                    this.valueErrorDialog.show();
                } else {
                    this.commitValue();
                    this.container.hide();
                }
            } else {
                if (this.updateZoneValue(this.updateDataItem, 1)) {
                    if (this.updateZoneValue(this.updateDataItem, 2)) {
                        if (this.updateZoneValue(this.updateDataItem, 3)) {
                            this.container.hide();
                        }
                    }
                }
            }

        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getIndex() {
        let index = -1;
        this.dataService.stockTakingDetails.data.forEach(s => {
            if (s['ProductName'] === this.container.mainForm.value.ProductName && s['Zone'] === this.container.mainForm.value.Zone) {
                index = this.dataService.stockTakingDetails.data.indexOf(s);
            }
        });
        return index;
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
