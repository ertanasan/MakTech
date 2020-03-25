// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ElementRef, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreOrder } from '@warehouse/model/store-order.model';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrderEditComponent } from '@warehouse/screen/store-order/store-order-edit/store-order-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Router } from '@angular/router';
import { StoreOrderStatusService } from '@warehouse/service/store-order-status.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { StoreOrderHistoryService } from '@warehouse/service/store-order-history.service';
import { IntlModule, IntlService } from '@progress/kendo-angular-intl';
import { StoreOrderHistoryComponent } from '../store-order-history/store-order-history.component';
import { SelectableSettings, DataStateChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { OTPrintingService } from '@otservice/printing.service';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { PrivilegeCacheService } from '@otservice/privilege-cache.service';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import {PalletPhotoComponent} from '@warehouse/screen/gathering/gathering-control/pallet-photo/pallet-photo.component';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-list',
    templateUrl: './store-order-list.component.html',
    styleUrls: ['./store-order-list.component.css']
})
export class StoreOrderListComponent extends ListScreenBase<StoreOrder> implements AfterViewInit, OnInit, OnDestroy {
    @ViewChild(StoreOrderEditComponent, {static: true}) editScreen: StoreOrderEditComponent;
    @ViewChild(StoreOrderHistoryComponent, {static: true}) historyScreen: StoreOrderHistoryComponent;
    @ViewChild('photoScreen', {static: true}) photoScreen: PalletPhotoComponent;
    @ViewChild('orderPrint', {static: true}) orderPrint: ElementRef;
    @ViewChild('noOrderList', {static: true}) noOrderList: CustomDialogComponent;

    includeCompletedFlag = false;

    store: Store;
    shipmentDay: Date;
    newEnabled: boolean;
    updateEnabled: boolean;
    accessPhotoPrivilege = false;
    currentTime: Date;
    selectableSettings: SelectableSettings;
    orderSelection: number[] = [];
    orderDetailPrints: any = [];
    todayString: string;
    baseDate: Date;
    noOrderStoreList: Store[];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreOrderService,
        public storeOrderDetailService: StoreOrderDetailService,
        public storeService: StoreService,
        public orderStatusService: StoreOrderStatusService,
        public printingService: OTPrintingService,
        public orderStatusHistoryService: StoreOrderHistoryService,
        public router: Router,
        public route: Router,
        public datePipe: DatePipe,
        public intl: IntlService,
        public privilegeCacheService: PrivilegeCacheService,
    ) {
        super(messageService, translateService);
        this.setSelectableSettings();
        this.allZData = this.allZData.bind(this);
    }

    public allZData(): any {
        return <GridDataResult> {
            data: this.dataList,
            total: (<any[]>this.dataList).length
        };
    }

    public setSelectableSettings(): void {
        this.selectableSettings = {
            checkboxOnly: false,
            mode: 'multiple'
        };
    }

    revertCompletedFlag() {
        this.includeCompletedFlag = !this.includeCompletedFlag;
        console.log('includeCompletedFlag : ', this.includeCompletedFlag);
        this.refreshList();
    }

    refreshList() {

        if (this.dataService.keptListParams !== null && this.dataService.keptListParams !== undefined) {
            this.dataService.activeList = this.dataService.getKeptState('activeList');
            this.listParams = this.dataService.getKeptState('listParams');
            this.dataService.clearKeptState();
            this.dataService.activeListChanged.next(this.dataService.activeList);
        } else {
            this.dataService.listOrders(this.includeCompletedFlag
                , this.datePipe.transform(new Date(this.baseDate), 'yyyy-MM-dd')).subscribe(
                result => {
                    this.dataList = result;
                    this.dataService.activeList = process(result, this.listParams);
                    this.dataService.activeListChanged.next(this.dataService.activeList);
                },
                error => {
                    this.messageService.error(error.message);
                },
                () => this.dataService.loading = false
            );
        }
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.skip = state.skip;
        this.listParams.take = state.take;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        if ((<StoreOrder[]>this.dataList)) {
            (<StoreOrder[]>this.dataList).map(t => {
                t.OrderDate = new Date(t.OrderDate);
                t.ShipmentDate = new Date(t.ShipmentDate);
                if (t.LastApproveUser) {
                    t.LastApproveTime = new Date(t.LastApproveTime);
                }
                if (t.DispatchUser) {
                    t.DispatchTime = new Date(t.DispatchTime);
                }
             });
            this.dataService.activeList = process(<StoreOrder[]>this.dataList, this.listParams);
            this.dataService.activeListChanged.next(this.dataService.activeList);
        }
    }

    public onSelectedKeysChange(e) {

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{ Caption: 'Warehouse' }, { Caption: 'Store Order', RouterLink: '/warehouse/store-order' }];
    }

    findShipmentDate(): any {
        const date = new Date();
        date.setDate(date.getDate() + 2);
        return date;
    }

    pad(num, size) {
        let s = num + '';
        while (s.length < size) {
            s = '0' + s;
        }
        return s;
    }

    dateToString(d: Date): string {
        const year = d.getFullYear();
        const month = d.getMonth() + 1;
        const day = d.getDate();
        return `${year}${this.pad(month, 2)}${this.pad(day, 2)}`;
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    public getxlsFileName(reportName: string): string {

        return `${reportName}_${this.todayString}.xlsx`;
    }

    onNew() {

        if (this.store) {
            this.dataService.getShipmentDay(this.store.StoreId).subscribe(
                result => {
                    this.shipmentDay = new Date(<Date>result);
                    this.shipmentDay = this.addHours(this.shipmentDay, 12);
                    this.showDialog(this.historyScreen, 'Create');
                },
                error => {
                    this.messageService.error(this.translateService.instant('Shipment Schedule should be defined.'));
                });
        } else {
            this.showDialog(this.historyScreen, 'Create');
        }
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {

        if (actionName === 'Read') {
            this.orderStatusHistoryService.ListStoreOrderHistory(dataItem.StoreOrderId).subscribe(result => {
                this.historyScreen.history = result;
                super.showDialog(target, actionName, dataItem);
            });
        } else if (actionName === 'Photo') {
            this.photoScreen.onShow.next(dataItem);
            this.photoScreen.dialog.show();
        } else {
            if (actionName === 'Update') {
                // this.editScreen.statusReadOnly = dataItem.Status === 4 ? false : true;
                // this.editScreen.statusStepBack = false;
                this.orderStatusService.previousStatusArr = [];
                this.orderStatusService.completeList.forEach(status => {
                    if (status.StoreOrderStatusId <= dataItem.Status || status.StoreOrderStatusId === 9) {
                        this.orderStatusService.previousStatusArr.push(status);
                    }
                });
            }
            super.showDialog(target, actionName, dataItem);
        }
    }

    createEmptyModel(): StoreOrder {

        const storeOrder = new StoreOrder();

        if (this.store) {
            this.historyScreen.container.isReadOnly = true;
            storeOrder.Store = this.store.StoreId;
            storeOrder.OrderDate = new Date();
            storeOrder.ShipmentDate = new Date(this.shipmentDay);
            storeOrder.Status = 1;
            storeOrder.OrderCode = `${this.store.Name}-${this.dateToString(storeOrder.OrderDate)}`;
            this.historyScreen.viewDetails = false;
            this.historyScreen.isStore = true;
        } else {
            this.historyScreen.viewDetails = true;
            this.historyScreen.isStore = false;
            storeOrder.Status = 2;
            storeOrder.OrderDate = new Date();
        }
        this.historyScreen.currentTime = this.currentTime;
        return storeOrder;
    }

    showEditScreen() {
        this.router.navigateByUrl('/StoreOrderDetail/Index');
    }

    ngOnInit() {
        this.baseDate = new Date();
        this.baseDate.setDate(this.baseDate.getDate() - 15);
        super.ngOnInit();
        this.privilegeCacheService.checkPrivilege('WHS-Create StoreOrder').subscribe( result => {
            this.newEnabled = result;
        });
        this.privilegeCacheService.checkPrivilege('WHS-AccessPhoto StoreOrder').subscribe( result => {
            this.accessPhotoPrivilege = result;
        });

        const d: Date = new Date();
        this.todayString = this.datePipe.transform(d, 'yyyyMMdd');

        this.updateEnabled = false;
        this.storeService.listUserStores().subscribe(list => {
            if (list.length === 1) {
                this.store = list[0];
            } else {
                this.updateEnabled = true;
                this.store = null;
            }
        });

        if (!this.orderStatusService.completeList) {
            this.orderStatusService.listAll();
        }

        this.dataService.getTime().subscribe(result => this.currentTime = <Date>result);
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.historyScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
        this.dialogs.push(this.historyScreen);
    }

    exportReportData() {
        this.dataService.exportReportData(this.listParams);
    }

    updatetoControlStatus() {
        this.dataService.printOrders(this.orderSelection).subscribe(orders => {
            orders.forEach(order => {
                // onaylandı ise ve merkez kullanıcısı ise kontrol edildi yapılsın.
                if (order.Status === 2 && !this.store) {
                    order.Status = 3;
                    this.dataService.update(order, 'update').subscribe(() => {

                    }, error => {
                        this.messageService.error(error.error.text);
                    });
                }
            });
        });
    }
    getPrintData() {
        this.orderDetailPrints = [];
        this.dataService.printOrders(this.orderSelection).subscribe(orders => {
            this.dataService.printDetails(this.orderSelection).subscribe(orderDetails => {
                orders.forEach(order => {

                    // onaylandı ise ve merkez kullanıcısı ise kontrol edildi yapılsın.
                    if (order.Status === 2 && !this.store) {
                        order.Status = 3;
                        this.dataService.update(order, 'update').subscribe(() => {

                        }, error => {
                            this.messageService.error(error);
                        });
                    }

                    const details = orderDetails.filter(det => (det.StoreOrder === order.StoreOrderId));
                    details.forEach(r => {
                        r.TotalQuantity = Math.round(r.ShippedQuantity * r.OrderUnitQuantity * 10) / 10;
                        r.TotalAmount = r.ShippedQuantity * r.OrderUnitQuantity * r.PriceAmount;
                        r.UnitQuantityText = `${r.OrderUnitQuantity} ${r.Unit}`;
                    });

                    const heavyOrderDetails = details.filter(detail => (detail.LoadOrder && detail.LoadOrder.substring(0, 1) === 'A' && detail.ShippedQuantity > 0));
                    const lightOrderDetails = details.filter(detail => !(detail.LoadOrder && detail.LoadOrder.substring(0, 1) === 'A') && detail.ShippedQuantity > 0);
                    const heavyProductsTotal: any = { packageTotal: 0, weightTotal: 0, priceTotal: 0 };
                    const ligthProductsTotal: any = { packageTotal: 0, weightTotal: 0, priceTotal: 0 };
                    heavyOrderDetails.forEach(r => {
                        heavyProductsTotal.packageTotal += r.ShippedQuantity;
                        if (r.Unit === 'KG') {
                            heavyProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity;
                        } else {
                            heavyProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity * (r.WeightAmount / 1000);
                        }
                        heavyProductsTotal.priceTotal += r.TotalAmount;
                    });
                    lightOrderDetails.forEach(r => {
                        ligthProductsTotal.packageTotal += r.ShippedQuantity;
                        if (r.Unit === 'KG') {
                            ligthProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity;
                        } else {
                            ligthProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity * (r.WeightAmount / 1000);
                        }
                        ligthProductsTotal.priceTotal += r.TotalAmount;
                    });

                    this.orderDetailPrints.push({
                        heavyProducts: heavyOrderDetails, lightProducts: lightOrderDetails
                        , heavyTotal: heavyProductsTotal, lightTotal: ligthProductsTotal, storeOrder: order
                    });

                });
                this.showPrintDialog();
            });
        });
    }

    ngOnDestroy() {
        if (this.route.routerState.snapshot.url.indexOf('/Warehouse/StoreOrderDetail/') === 0) {
            this.dataService.keepState(this.listParams, this.dataService.activeList);
        }
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

            .td1
            {
                border-bottom: 1px solid #ddd;
                border-right: 1px solid #ddd;
                font-size: 15;
                padding-top:5px;
                padding-bottom:5px;
            }
            .td2
            {
                border-bottom: 1px solid #ddd;
                border-right: 1px solid #ddd;
                font-size: 15;
                padding-top:5px;
                padding-bottom:5px;
            }
            .td3
            {
                border-bottom: 1px solid #ddd;
                border-right: 1px solid #ddd;
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
         }
         </style>
        `;
        setTimeout(() => {
            /*
            let width = 1200;
            let height = 700;
            if (width > (screen.width - 100)) {
                width = screen.width - 100;
            }
            if (height > (screen.height - 100)) {
                height = screen.height - 100;
            }
            var left = (screen.width/2)-(width/2);
            var top = (screen.height/2)-(height/2);
            let popupWindow = window.open('', '_blank', `width=${width},height=${height},scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no,top=${top},left=${left}`);
            if (popupWindow) {
                popupWindow.document.open();
                popupWindow.document.write(`
                    <html>
                    <head>
                        ${styles}
                    </head>
                    <body onload="window.print()">
                        ${this.orderPrint.nativeElement.innerHTML}
                    </body>
                    </html>`
                );
            } else {
                this.messageService.error('window açılamadı.');
            }    */
            this.printingService.print(this.orderPrint.nativeElement.innerHTML, styles, 1200, 700);
        }, 1000);
    }

    getNoOrderStoreList() {
        this.dataService.noOrderStoreList().subscribe(result => {
            this.noOrderStoreList = result;
            this.noOrderList.show();
        })
    }
}
