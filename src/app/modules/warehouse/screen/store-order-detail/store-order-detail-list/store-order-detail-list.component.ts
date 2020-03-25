// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ViewChildren, QueryList, ElementRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreOrderDetail } from '@warehouse/model/store-order-detail.model';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ActivatedRoute } from '@angular/router';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrder } from '@warehouse/model/store-order.model';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';
import { EditEvent, DataStateChangeEvent, PageChangeEvent } from '@progress/kendo-angular-grid';
import { OTPrintingService } from '@otservice/printing.service';
import { process, SortDescriptor } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { StoreService } from '@store/service/store.service';
import { Store } from '@store/model/store.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { anyChanged } from '@progress/kendo-angular-grid/dist/es2015/utils';
import { HttpErrorResponse } from '@angular/common/http';
import { GatheringService } from '@warehouse/service/gathering.service';
// import { forEach } from '@angular/router/src/utils/collection';



/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-order-detail-list',
    templateUrl: './store-order-detail-list.component.html',
    styleUrls: ['./store-order-detail-list.component.css', ]
})
export class StoreOrderDetailListComponent extends ListScreenBase<StoreOrderDetail> implements AfterViewInit, OnInit {
    @ViewChildren(DropdownEntryComponent) productBoxes: QueryList<DropdownEntryComponent>;
    @ViewChild('orderDetailPrint', {static: true}) orderDetailPrint: ElementRef;
    @ViewChild('diffOrdervsShipment', {static: true}) diffOrdervsShipment: CustomDialogComponent;
    @ViewChild('approveConfirm', {static: true}) approveConfirm: CustomDialogComponent;

    public orderid: number;
    public fromStore: string;
    public storeOrder: StoreOrder;
    public formGroup: FormGroup;
    public editedRowIndex: number;
    public heavyOrderDetails: any;
    public lightOrderDetails: any;
    public origOrderDetails: any;
    public productSelectionEnabled: boolean;
    heavyProductsTotal: any = { packageTotal: 0, weightTotal: 0, priceTotal: 0 };
    ligthProductsTotal: any = { packageTotal: 0, weightTotal: 0, priceTotal: 0 };
    public titleTotalQuantity = 'Toplam Miktar';
    public titleTotalSellingPrice = 'Toplam Tutar';
    diffOrdervsShipmentList: any;
    public storeOrderPrevStatus: number;
    private d: any;
    public localeDString: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreOrderDetailService,
        public productService: ProductService,
        public route: ActivatedRoute,
        public storeOrderService: StoreOrderService,
        public printingService: OTPrintingService,
        public formBuilder: FormBuilder,
        public datePipe: DatePipe,
        public storeService: StoreService,
        public gatheringService: GatheringService
    ) {
        super(messageService, translateService);
    }

    refreshList() {

        if (this.dataService.originalData) {
            this.dataService.orderDetails = process(this.dataService.originalData, this.listParams);
        }

    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Store Order Detail', RouterLink: '/warehouse/store-order-detail'}];
    }

    createEmptyModel(): StoreOrderDetail {
        return new StoreOrderDetail();
    }

    readOrderDetails() {
        this.dataService.loading = true;
        this.dataService.listStoreOrderDetails(this.orderid).subscribe(
            result => {
                this.listParams.pageable = true;
                this.listParams.take = 10;
                result.forEach(r => {
                    r.TotalQuantity = Math.round ( r.IntakeQuantity * r.OrderUnitQuantity * 10 ) / 10;
                    r.TotalAmount = r.IntakeQuantity * r.OrderUnitQuantity * r.PriceAmount;
                    r.UnitQuantityText = `${r.OrderUnitQuantity} ${r.Unit}`;
                    r.OldOrderQuantity = r.OrderQuantity;
                    r.OldRevisedQuantity = r.RevisedQuantity;
                    r.OldShippedQuantity = r.ShippedQuantity;
                    r.OldIntakeQuantity = r.IntakeQuantity;
                });
                this.dataService.originalData = JSON.parse(JSON.stringify(result));
                this.dataService.orderDetails.data = result;
                this.origOrderDetails = JSON.parse(JSON.stringify(result));
                this.dataService.orderDetails.total = result.length;

                this.heavyOrderDetails = this.dataService.orderDetails.data.filter(detail => (detail.LoadOrder && detail.LoadOrder.substring(0, 1) === 'A' && detail.ShippedQuantity > 0));
                this.lightOrderDetails = this.dataService.orderDetails.data.filter(detail => !(detail.LoadOrder && detail.LoadOrder.substring(0, 1) === 'A') && detail.ShippedQuantity > 0);
                this.heavyOrderDetails.forEach ( r => {
                    this.heavyProductsTotal.packageTotal += r.ShippedQuantity;
                    if (r.Unit === 'KG') {
                        this.heavyProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity;
                    } else {
                        this.heavyProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity * (r.WeightAmount / 1000);
                    }
                    this.heavyProductsTotal.priceTotal += r.TotalAmount;
                });
                this.lightOrderDetails.forEach ( r => {
                    this.ligthProductsTotal.packageTotal += r.ShippedQuantity;
                    if (r.Unit === 'KG') {
                        this.ligthProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity;
                    } else {
                        this.ligthProductsTotal.weightTotal += r.ShippedQuantity * r.OrderUnitQuantity * (r.WeightAmount / 1000);
                    }
                    this.ligthProductsTotal.priceTotal += r.TotalAmount;
                });
                this.refreshList();
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.dataService.loading = false
        );
    }

    ngOnInit() {
        this.orderid = this.route.snapshot.params['orderid'];
        this.fromStore = this.route.snapshot.params['fromStore'];

        this.storeOrderService.read(this.orderid).subscribe(dataItem => {

            this.storeOrder = dataItem;
            this.productSelectionEnabled = (this.storeOrder.Status <= 2);
            switch (this.storeOrder.Status) {
                case 1 :
                    this.titleTotalQuantity = 'Sipariş Edilen Miktar';
                    this.titleTotalSellingPrice = 'Sipariş Edilen Tutar';
                    break;
                case 2 :
                    this.titleTotalQuantity = 'Revize Edilen Miktar';
                    this.titleTotalSellingPrice = 'Revize Edilen Tutar';
                    break;
                case 3 :
                    this.titleTotalQuantity = 'Sevk Edilen Miktar';
                    this.titleTotalSellingPrice = 'Sevk Edilen Tutar';
                    break;
                default :
                    this.titleTotalQuantity = 'Teslim Alınan Sevk Miktarı';
                    this.titleTotalSellingPrice = 'Teslim Alınan Tutar';
                    break;
            }

            this.readOrderDetails();
        });

        // Fill reference lists
        if (!this.dataService.warehouseProductUnits) {
            this.dataService.listWarehouseProductUnits();
        }


        super.ngOnInit();

    }

    ngAfterViewInit() {

        this.productBoxes.changes.subscribe(
            list => {
            }
        );
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    handleDataStateChange(state: DataStateChangeEvent) {

        this.listParams.take = 10;
        this.listParams.pageable = true;
        this.listParams.skip = state.skip;
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

    public createFormGroup(dataItem: any): FormGroup {

        let fg: FormGroup = null;
        if ((this.fromStore === 'store' && this.storeOrder.Status < 2) || this.storeOrder.Status < 2) {
            fg = this.formBuilder.group({
                OrderQuantity: new FormControl(dataItem.OrderQuantity),
            });
        } else if (this.fromStore === 'head' && this.storeOrder.Status === 2) {
            fg = this.formBuilder.group({
                RevisedQuantity: new FormControl(dataItem.RevisedQuantity),
            });
        } else if (this.fromStore === 'head' &&  this.storeOrder.Status === 3) {
            fg = this.formBuilder.group({
                ShippedQuantity: new FormControl(dataItem.ShippedQuantity),
                TotalQuantity: new FormControl(dataItem.TotalQuantity),
            });
        } else if (this.fromStore === 'store' &&  this.storeOrder.Status === 4) {
            fg = this.formBuilder.group({
                IntakeQuantity: new FormControl(dataItem.IntakeQuantity),
                TotalQuantity: new FormControl(dataItem.TotalQuantity),
            });
        } else {
            fg = this.formBuilder.group({});
        }

        return fg;
    }

    public editHandler({ sender, rowIndex, dataItem }: EditEvent): void {
        if (this.formGroup && !this.formGroup.valid) {
            return;
        }

        // this.createFormGroup(dataItem);
        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cellClickHandler({ sender, rowIndex, columnIndex, dataItem, isEdited }) {

        if (!isEdited) {
            sender.editCell(rowIndex, columnIndex, this.createFormGroup(dataItem));
        }

    }

    public cellCloseHandler(args: any) {

        const { formGroup, dataItem, column } = args;

        if (!formGroup.valid) {
            args.preventDefault();
        } else if (formGroup.dirty) {
            if (args.column.field === 'OrderQuantity' && formGroup.value.OrderQuantity) {
                if (dataItem.ClosetoOrder && this.fromStore) {
                    this.messageService.warning('Bu ürün siparişe kapalıdır, giriş yapamazsınız.');
                    dataItem.OrderQuantity = 0;
                } else {
                    if (formGroup.value.OrderQuantity > 0) {
                        dataItem.OrderQuantity = formGroup.value.OrderQuantity;
                    } else {
                        dataItem.OrderQuantity = 0;
                    }
                    dataItem.RevisedQuantity = dataItem.OrderQuantity;
                    dataItem.ShippedQuantity = dataItem.OrderQuantity;
                    dataItem.IntakeQuantity = dataItem.OrderQuantity;
                    dataItem.TotalQuantity  = dataItem.OrderQuantity * dataItem.OrderUnitQuantity;
                    dataItem.TotalAmount = dataItem.OrderQuantity * dataItem.OrderUnitQuantity * dataItem.PriceAmount;
                }
            } else if (args.column.field === 'RevisedQuantity' && formGroup.value.RevisedQuantity) {
                if (formGroup.value.RevisedQuantity > 0) {
                    dataItem.RevisedQuantity = formGroup.value.RevisedQuantity;
                } else {
                    dataItem.RevisedQuantity = 0;
                }
                dataItem.ShippedQuantity = dataItem.RevisedQuantity;
                dataItem.IntakeQuantity = dataItem.RevisedQuantity;
                dataItem.TotalQuantity  = dataItem.RevisedQuantity * dataItem.OrderUnitQuantity;
                dataItem.TotalAmount = dataItem.RevisedQuantity * dataItem.OrderUnitQuantity * dataItem.PriceAmount;
            } else if (args.column.field === 'ShippedQuantity' && formGroup.value.ShippedQuantity) {
                if (formGroup.value.ShippedQuantity > 0) {
                    dataItem.ShippedQuantity = formGroup.value.ShippedQuantity;
                } else {
                    dataItem.ShippedQuantity = 0;
                }
                dataItem.IntakeQuantity = dataItem.ShippedQuantity;
                dataItem.TotalQuantity  = Math.round( dataItem.ShippedQuantity * dataItem.OrderUnitQuantity * 10 ) / 10;
                dataItem.TotalAmount = dataItem.ShippedQuantity * dataItem.OrderUnitQuantity * dataItem.PriceAmount;
            } else if (args.column.field === 'IntakeQuantity' && formGroup.value.IntakeQuantity) {
                if (formGroup.value.IntakeQuantity > 0) {
                    dataItem.IntakeQuantity = formGroup.value.IntakeQuantity;
                } else {
                    dataItem.IntakeQuantity = 0;
                }
                dataItem.TotalQuantity  = Math.round( dataItem.IntakeQuantity * dataItem.OrderUnitQuantity * 10 ) / 10;
                dataItem.TotalAmount = dataItem.IntakeQuantity * dataItem.OrderUnitQuantity * dataItem.PriceAmount;
            } else if (args.column.field === 'TotalQuantity' && formGroup.value.TotalQuantity && this.storeOrder.Status === 3) {
                if (formGroup.value.TotalQuantity > 0) {
                    dataItem.TotalQuantity = formGroup.value.TotalQuantity;
                } else {
                    dataItem.TotalQuantity = 0;
                }
                dataItem.ShippedQuantity = dataItem.TotalQuantity / dataItem.OrderUnitQuantity;
                dataItem.IntakeQuantity = dataItem.ShippedQuantity;
                dataItem.TotalAmount = dataItem.TotalQuantity * dataItem.PriceAmount;
            } else if (args.column.field === 'TotalQuantity' && formGroup.value.TotalQuantity && this.storeOrder.Status === 4) {
                if (formGroup.value.TotalQuantity > 0) {
                    dataItem.TotalQuantity = formGroup.value.TotalQuantity;
                } else {
                    dataItem.TotalQuantity = 0;
                }
                dataItem.IntakeQuantity = dataItem.TotalQuantity / dataItem.OrderUnitQuantity;
                dataItem.TotalAmount = dataItem.TotalQuantity * dataItem.PriceAmount;
            }
        }

    }


    public onDeleteRow(event, dataItem, rowIndex) {
        if ((this.dataService.orderDetails.total - 1) === rowIndex) {
            dataItem = new StoreOrderDetail();
        } else {
            this.dataService.orderDetails.data.splice(rowIndex, 1);
        }

        if (dataItem.StoreOrderDetailId > 0) {
            this.dataService.deletedDetails.push(dataItem);
        }
    }

    public updateOrderStatus(opCode) {
        const promiseArray = [];
        let returnmessage = '';

        if (opCode === 'Save') {
            if (this.storeOrder.Status === 2 && this.fromStore === 'store') {
                this.storeOrder.Status = 1;
                promiseArray.push(this.storeOrderService.update(this.storeOrder, 'update').toPromise());
                returnmessage = 'Sipariş Kaydedildi, Onaysız hale getirildi.';
            } else {
                returnmessage = 'Sipariş Kaydedildi';
            }
        } else if (opCode === 'Approve') {
            promiseArray.push(this.storeOrderService.update(this.storeOrder, 'update').toPromise());
            returnmessage = 'Sipariş Onaylandı';
        } else if (opCode === 'Check') {
            promiseArray.push(this.storeOrderService.update(this.storeOrder, 'update').toPromise());
            returnmessage = 'Sipariş Kontrolü Tamamlandı';
        } else if (opCode === 'Ship') {
            promiseArray.push(this.storeOrderService.dispatch(this.storeOrder).toPromise());
            returnmessage = 'Sipariş Sevk Edildi, İrsaliye Kesildi';
        } else if (opCode === 'Accept') {
            promiseArray.push(this.storeOrderService.update(this.storeOrder, 'update').toPromise());
            returnmessage = 'Sevk edilen ürünler kabul edildi';
        }
        Promise.all(promiseArray).then(value => {
            this.readOrderDetails();
            this.messageService.success(returnmessage); // || this.translateService.get('Exception occured with an empty error message.'));
        }).catch(error => {
            this.messageService.error('Beklenmeyen bir hata oluştu.');
            this.storeOrder.Status = this.storeOrderPrevStatus;
        });
    }

    public controlAndUpdate(opCode) {
        this.storeOrderService.mikroShipmentControl(this.storeOrder.StoreOrderId).subscribe(controlList => {
            if (controlList.length > 0) {
                let productList = '';
                controlList.forEach(row => {
                    productList += row.ProductName + ' - ';
                });
                this.messageService.error(`${productList} ürünleri siparişe kapalı olduğundan mikro'ya sevk edilmedi.`);
                this.readOrderDetails();
            } else {
                this.updateOrderStatus (opCode);
            }
        });
    }

    public processRows(opCode) {

        const result = this.dataService.PostStoreOrderDetails();
        if (result === 0) {
            if (opCode === 'Save') {
                this.messageService.success('Siparişde değişiklik yapılmadı.');
            } else {
                if (opCode === 'Ship') {
                    this.controlAndUpdate(opCode);
                } else {
                    this.updateOrderStatus(opCode);
                }
            }

        } else {
            result.subscribe(res => {
                if (opCode === 'Ship') {
                    this.controlAndUpdate(opCode);
                } else {
                    this.updateOrderStatus(opCode);
                }
            });
        }
    }

    public onSave() {
        this.processRows('Save');
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    public onApprove() {
        if (this.storeOrder.AuthorizationLevel >= 3) {
            const shipmentDate = this.datePipe.transform(this.storeOrder.ShipmentDate, 'dd.MM.yyyy');
            if (confirm(`Sevk Tarihi : ${shipmentDate} dir. Onaylıyor musunuz?`)) {
                this.storeOrderPrevStatus = 1;
                this.storeOrder.Status = 2;
                this.processRows('Approve');
            }
        } else {
            let lastOrderEntry: number;
            lastOrderEntry = 16;
            if (!this.storeService.userStores) {
                this.storeService.listUserStores().subscribe(result => {
                    if (result.length === 1) {
                        lastOrderEntry = result[0].LastOrderEntry;
                    }
                });
            } else {
                if ((<Store[]>this.storeService.userStores).length === 1) {
                    lastOrderEntry = this.storeService.userStores[0].LastOrderEntry;
                }
            }

            const ct = new Date(this.storeOrderService.currentTime);
             if (ct.getHours() >= lastOrderEntry && this.storeOrder.AuthorizationLevel < 3) {
                 this.messageService.error(`Son sipariş giriş ve onaylama saati : ${lastOrderEntry}.`);
                 return;
             }

            this.storeOrderService.getShipmentDay(this.storeOrder.Store).subscribe(result => {
                this.d = <Date> result;
                this.d = this.addHours(this.d, 12);

                const shipmentDate = this.datePipe.transform(this.d, 'yyyy-MM-dd');
                // o güne ait sipariş önceden var mı?
                this.storeOrderService.getOrderofDay(this.storeOrder.Store, shipmentDate).subscribe( resultorder => {

                    const order = <StoreOrder> resultorder;
                    if (order.StoreOrderId > 0  && this.orderid.toString() !== order.StoreOrderId.toString() && this.storeOrder.AuthorizationLevel < 3) {
                        this.messageService.error(`${shipmentDate} tarihinde önceden girilmiş bir siparişiniz var ona giriş yapınız. Sipariş No : ${order.StoreOrderId}`);
                    } else {
                        this.localeDString = this.d.toLocaleDateString();
                        this.approveConfirm.caption = 'Approve';
                        this.approveConfirm.show();
                    }
                });

            });
        }
    }

    public approveOnClicked() {
        this.storeOrder.Status = 2;
        this.storeOrder.ShipmentDate = this.d;
        this.processRows('Approve');
        this.approveConfirm.hide();
    }

    public onChecked() {
        this.storeOrderPrevStatus = this.storeOrder.Status;
        this.storeOrder.Status = 3;
        this.processRows('Check');
    }

    public onShipped() {
        // this.gatheringService.listGatheringByStoreOrderId(this.storeOrder.StoreOrderId).subscribe(
        //     list => {
        //         let completedGatheringCount = 0;
        //         list.forEach(g => g.GatheringStatus === 19 ? completedGatheringCount += 1 : null);
        //         if (completedGatheringCount === list.length) {
                    this.storeOrderPrevStatus = this.storeOrder.Status;
                    this.storeOrder.Status = 4;
                    this.processRows('Ship');
        //         } else {
        //             this.messageService.error('Bu siparişin toplama işlemleri henüz tamamlanmadığı için sevk işlemi gerçekleştirilememektedir.');
        //         }
        //     }, error => this.messageService.error('Siparişin Toplama bilgilerine erişimde bir hata oluştuğundan dolayı sevk etme işlemi gerçekleştirilemedi!')
        // );
    }

    public onAccepted() {
        this.storeOrderPrevStatus = this.storeOrder.Status;
        this.storeOrder.Status = 5;
        this.processRows('Accept');
    }


    public onDiffOrdervsShipment() {
        const list: StoreOrderDetail[] = [];
        this.dataService.originalData.forEach(row => {
            if ((row.ShippedQuantity > 0 || row.OrderQuantity > 0) && row.ShippedQuantity !== row.OrderQuantity) {
                list.push(row);
            }
        });
        this.diffOrdervsShipmentList = {data: list, total: list.length};
        this.diffOrdervsShipment.caption = `${'Sipariş ile Sevk Miktarı Farklı Ürünler'}`;
        this.diffOrdervsShipment.show();
    }

    onFileSelected(event) {
        this.dataService.loading = true;
        const formData = new FormData();
        formData.append('file[]', event.target.files[0]);
        this.storeOrderService.addProductsFromExcel(formData, this.storeOrder.StoreOrderId).subscribe(result => {
            // console.log('result ', result);
            this.dataService.loading = false;
            if (!result || result === '') {
                this.messageService.success('Veriler sisteme başarılı bir şekilde aktarıldı.');
            } else {
                this.messageService.error(result.toString());
            }
            event.target.value = '';
            this.readOrderDetails();
        }, (error: HttpErrorResponse) => {
            console.log('error ', error);
            this.dataService.loading = false;
            this.messageService.error(error.error);
            event.target.value = '';
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
         }
         </style>
        `;
        this.printingService.print(this.orderDetailPrint.nativeElement.innerHTML, styles, 1200, 700);

    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}

