// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input, ChangeDetectorRef } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductReturn } from '@warehouse/model/product-return.model';
import { ProductReturnService } from '@warehouse/service/product-return.service';
import { ProductReturnEditComponent } from '@warehouse/screen/product-return/product-return-edit/product-return-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ShipmentPackageType } from '@warehouse/model/shipment-package-type.model';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';
import { ReturnReasonService } from '@warehouse/service/return-reason.service';
import { ReturnReason } from '@warehouse/model/return-reason.model';
import * as _ from 'lodash';
import { ActivatedRoute } from '@angular/router';
import { StoreService } from '@store/service/store.service';
import { Store } from '@store/model/store.model';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';
import { ReturnOrderService } from '@warehouse/service/return-order.service';
import { ReturnOrder } from '@warehouse/model/return-order.model';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';
import { ListScreenContainerComponent } from '@otuiscreen/list-screen-container/list-screen-container.component';
import { GridDataResult, SelectableSettings } from '@progress/kendo-angular-grid';
import { finalize } from 'rxjs/operators';
import { KendoGridCommandColumnWidth, BpmProcessStatus } from 'app/util/shared-enums.component';
import { SalesService } from '@sale/service/sales.service';
import { Refund } from '@sale/model/refund.model';
import { ProductReturnHistoryComponent } from '../product-return-history/product-return-history.component';
import { UserService } from '@frame/security/service/user.service';
import { GetNamePipe } from '@otcommon/pipe/get-name.pipe';
import { ProcessHistoryComponent } from '@app-main/screen/process-history/process-history.component';
import { DatePipe, DecimalPipe } from '@angular/common';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-return-list',
    templateUrl: './product-return-list.component.html',
    styleUrls: ['./product-return-list.component.css', ]
})
export class ProductReturnListComponent extends ListScreenBase<ProductReturn> implements AfterViewInit, OnInit {
    @ViewChild(ProductReturnEditComponent, {static: true}) editScreen: ProductReturnEditComponent;
    @ViewChild(ListScreenContainerComponent, {static: true}) container: ListScreenContainerComponent;
    // @ViewChild(ProductReturnHistoryComponent, {static: true}) historyScreen: ProductReturnHistoryComponent;
    @ViewChild(ProcessHistoryComponent, {static: true}) historyScreen: ProcessHistoryComponent;

    returnOrderId: number;
    storeId: number;
    reasonTreeView: any[] = [];
    // masterReasons: any[] = [];
    returnReason: ReturnReason[];
    returnActiveList: any;
    returnList: ProductReturn[] = [];
    returnOrder: ReturnOrder;

    store: Store;
    authorized: boolean;
    isStore: boolean;
    isRegion: boolean;
    isCentralOffice: boolean;
    productSelection: number[] = [];
    selectableSettings: SelectableSettings;
    selectedStatus = 1;

    settings: Array<any> = [{text: 'Onayla'}, {text: 'Reddet'}];
    processStatus = BpmProcessStatus;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductReturnService,
        public productService: ProductService,
        public shipmentPackageTypeService: ShipmentPackageTypeService,
        public route: ActivatedRoute,
        public returnReasonService: ReturnReasonService,
        public storeService: StoreService,
        public returnOrderService: ReturnOrderService,
        public returnDestinationService: ReturnDestinationService,
        public saleService: SalesService,
        public userService: UserService,
        public getNamePipe: GetNamePipe,
        public datePipe: DatePipe,
        public decimalPipe: DecimalPipe,
    ) {
        super(messageService, translateService);
        this.translateService.setDefaultLang('tr');
        this.setSelectableSettings();
        this.allData = this.allData.bind(this);
    }

    public setSelectableSettings(): void {
        this.selectableSettings = {
            checkboxOnly: false,
            mode: 'multiple'
        };
    }

    public onSelectedKeysChange(e) {

    }

    public onApprove(event) {
        const promiseArray = [];
        let rowCount = 0;
        let messageText = 'onaylandı';
        this.productSelection.forEach (id => {
            const selectedRow = _.filter(this.returnList, ['ProductReturnId', id])[0];
            if (selectedRow.StatusCode === 1) {
                rowCount++;
                if (event.text === 'Onayla') {
                    selectedRow.StatusCode = 2;
                } else {
                    selectedRow.StatusCode = 6;
                    messageText = 'reddedildi';
                }
                // console.log(selectedRow);
                promiseArray.push(this.dataService.ApproveProductReturn(selectedRow).toPromise());
            }
        });
        Promise.all(promiseArray).then(value => {
            this.messageService.success(`${rowCount} adet kayıt ${messageText}`);
            this.refreshData();
            this.productSelection = [];
        }).catch(error => this.messageService.error('Beklenmeyen bir hata oluştu.'));
    }

    refreshList() {
        this.returnActiveList = process(this.returnList, this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Product Return', RouterLink: '/warehouse/product-return'}];
    }

    createEmptyModel(): ProductReturn {
        this.editScreen.reasonTreeView = this.reasonTreeView;
        const model = new ProductReturn();
        model.StatusCode = 1;
        model.ReturnDate = new Date();
        if (this.isStore) {
            model.Store = this.store.StoreId;
        }
        return model;
    }

    onFilter() {
        this.readReturnProductsbyStatus(this.selectedStatus);
    }

    fillReturnReasons(returnReason) {
        this.editScreen.checkedKeys = [];
        returnReason.forEach(rr => {
            const reason = this.editScreen.reasonList.filter(row => row.ReturnReasonId === rr.ReturnReason)[0];
            const parentReason = this.editScreen.reasonList.filter(row => row.ReturnReasonId === reason.Parent);
            let MasterParentReason = [];
            if (parentReason.length > 0) {
                MasterParentReason = this.editScreen.reasonList.filter(row => row.ReturnReasonId === parentReason[0].Parent);
            }
            this.reasonTreeView.forEach((tv, ind1) => {
                if (MasterParentReason.length > 0) {
                    if (tv.text === MasterParentReason[0].ReasonName) {
                        tv.items.forEach((i, ind2) => {
                            if (i.text === parentReason[0].ReasonName) {
                                tv.items.forEach((i2, ind3) => {
                                    if (i2.text === reason.ReasonName) {
                                        this.editScreen.checkedKeys.push(`${ind1}_${ind2}_${ind3}`);
                                    }
                                });
                            }
                        });
                    }
                } else if (parentReason.length > 0) {
                    if (tv.text === parentReason[0].ReasonName) {
                        tv.items.forEach((i, ind2) => {
                            if (i.text === reason.ReasonName) {
                                this.editScreen.checkedKeys.push(`${ind1}_${ind2}`);
                            }
                        });
                    }
                } else {
                    if (tv.text === reason.ReasonName) {
                        this.editScreen.checkedKeys.push(ind1.toString());
                    }
                }
            });
        });
    }

    setEditScreenValues(actionName: string, dataItem: any, cb) {
        if (dataItem && dataItem.ReturnReason) {
            this.fillReturnReasons(dataItem.ReturnReason);
            this.editScreen.viewIntake = (dataItem.StatusCode === 3);
            // this.editScreen.viewDestination = (dataItem.StatusCode === 4);
        } else {
            this.editScreen.checkedKeys = [];
        }
        this.editScreen.toView = false;
        if (actionName === 'Read' || actionName === 'Review') {
            this.editScreen.toView = true;
        }
        if (dataItem) {
            this.editScreen.isCustomerReturn = dataItem.IsCustomerReturn;
            if (dataItem.SaleDetailId) {
                this.setRefundText(dataItem.SaleDetailId, dataItem, () => { cb(); });
            } else {
                cb();
            }
        } else {
            cb();
        }
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        // if (actionName === 'ShowHistory') {
        //     this.dataService.GetHistoryData(dataItem.ProductReturnId).subscribe(
        //         result => {
        //             if (result.length) {
        //                 this.historyScreen.title = this.getNamePipe.transform(dataItem.Store, 'StoreId', 'Name', this.storeService.userStores) + ' (' + dataItem.ProductReturnId.toString() + ') ' + this.translateService.instant('Action History');
        //                 this.historyScreen.historyData = result;
        //                 this.historyScreen.processStatus = this.getNamePipe.transform(result[0].ProcessStatusCode, 'value', 'text', this.processStatus);
        //                 this.historyScreen.dialog.show();
        //             } else {
        //                 this.messageService.warning(this.translateService.instant('No history record found'));
        //             }
        //         }, error => {
        //             this.messageService.error(this.translateService.instant('An error occurred while getting history records'));
        //         }
        //     );
        //     return;
        // }
        if (actionName === 'ShowHistory') {
            this.historyScreen.ProcessInstanceId = dataItem.ProcessInstance;
            this.historyScreen.dialog.show();
        } else if (!this.editScreen.reasonList) {
            this.readReturnReasons(() => {
                this.setEditScreenValues(actionName, dataItem, () => {
                    super.showDialog(target, actionName, dataItem);
                });
            });
        } else {
            this.setEditScreenValues(actionName, dataItem, () => {
                super.showDialog(target, actionName, dataItem);
            });
        }
    }

    setRefundText(saleDetailId, dataItem: ProductReturn, cb) {
        this.saleService.readRefund(saleDetailId).subscribe(result => {
            // console.log(result);
            dataItem.SaleDetailText = result.RefundDescription;
            this.editScreen.refundText = result.RefundDescription;
            cb();
        });
    }

    userStoreInfo() {
        this.storeService.listUserStores().subscribe(list => {
            this.storeService.userStores = list;
            if (list.length === 1) {
                this.store = list[0];
                this.authorized = false;
            } else {
                this.authorized = true;
            }

            this.isStore = false;
            this.isRegion = false;
            this.isCentralOffice = false;
            if (list[0].UserBranchType === 'Branch') {
                this.isStore = true;
            } else if (list[0].UserBranchType === 'Region') {
                this.isRegion = true;
            } else if (list[0].UserBranchType === 'Central Office') {
                this.isCentralOffice = true;
            }
            this.editScreen.store = this.store;
            this.editScreen.authorized = this.authorized;
            this.editScreen.isStore = this.isStore;
            this.editScreen.isRegion = this.isRegion;
            this.editScreen.isCentralOffice = this.isCentralOffice;
        });
    }

    readReturnReasons(cb) {
        this.reasonTreeView = [];
        this.returnReasonService.listAllAsync().subscribe(serviceList => {
            this.returnReason = _.sortBy(serviceList, 'ReturnReasonId');
            this.editScreen.reasonList = this.returnReason;
            const masterReasons = _.filter(serviceList, ['Parent', null]);
            masterReasons.forEach (row => {
                const l1 = {text: row.ReasonName, items: []};
                const reasonL2 = _.filter(serviceList, ['Parent', row.ReturnReasonId]);
                reasonL2.forEach (row2 => {
                    const reasonL3 = _.filter(serviceList, ['Parent', row2.ReturnReasonId]);
                    let l2;
                    if (reasonL3.length > 0) {
                        l2 = {text: row2.ReasonName, items: []};
                        reasonL3.forEach (row3 => {
                            l2.items.push({text: row3.ReasonName});
                        });
                    } else {
                        l2 = {text: row2.ReasonName};
                    }
                    l1.items.push(l2);
                });
                this.reasonTreeView.push(l1);
            });
            cb();
        });
    }

    refreshData() {
        this.readReturnProductsbyStatus(this.selectedStatus);
        this.refreshList();
    }

    readReturnProductsbyStatus (statusCode) {
        this.dataService.loading = true;
        this.dataService.ListStatus(statusCode).subscribe(list => {
            this.returnList = list;
            ((<ProductReturn[]>this.returnList)).map(t => {
                t.ReturnDate = new Date(t.ReturnDate);
                if (t.WaybillDate) {
                    t.WaybillDate = new Date(t.WaybillDate);
                }
            });
            this.returnActiveList = process(this.returnList, this.listParams);
            this.dataService.loading = false;
        });
    }

    ngOnInit() {
        // this.commandColumnWidth = KendoGridCommandColumnWidth.ThreeButton;
        this.readEnabled = true;
        this.userStoreInfo();

        if (!this.productService.completeList) {
            this.productService.listAll();
        }

        if (!this.userService.completeList) {
            this.userService.listAll();
        }

        this.shipmentPackageTypeService.loading = true;
        if (!this.shipmentPackageTypeService.shortList) {
            this.shipmentPackageTypeService.listAllAsync().pipe(
                finalize(() => this.shipmentPackageTypeService.loading = false)
            ).subscribe(data => {
                this.shipmentPackageTypeService.shortList = [];
                data.forEach (row => {
                    if (row.PackageTypeName === 'KG' || row.PackageTypeName === 'ADET') {
                        this.shipmentPackageTypeService.shortList.push(row);
                    }
                });
            });
        }

        if (!this.returnDestinationService.completeList) {
            this.returnDestinationService.listAll();
        }
        this.readReturnReasons(() => {});
        this.readReturnProductsbyStatus(1);
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.editScreen.Callee = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const productReturnId = this.modeContext.id;
            this.dataService.read(productReturnId).subscribe(productReturn => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), productReturn);
                // this.editScreen.returnOrderId = orderId;
                // this.editScreen.initDetails();
                // console.log(dataItem);
                this.showDialog(this.editScreen, 'Review', dataItem );
                // this.showDetailScreen(dataItem);
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    public allData(): any {
        const newList = JSON.parse(JSON.stringify(this.returnList));
        newList.forEach(row => {
            row.StoreName = this.storeService.userStores.filter(r => r.StoreId === row.Store)[0].Name;
            row.ReturnDateStr = this.datePipe.transform(row.ReturnDate, 'dd.MM.yyyy');
            row.WaybillDateStr = this.datePipe.transform(row.WaybillDate, 'dd.MM.yyyy');
            row.ProductName = this.productService.completeList.filter(r => r.ProductId === row.Product)[0].Name;
            row.ManufacturingDateStr = this.datePipe.transform(row.ManufacturingDate, 'dd.MM.yyyy');
            row.ExpireDateDateStr = this.datePipe.transform(row.ExpireDate, 'dd.MM.yyyy');
            // row.ReturnQuantity = this.decimalPipe.transform(row.ReturnQuantity, '1.2-2', 'tr');
            row.PackageTypeName = this.shipmentPackageTypeService.shortList.filter(r => r.ShipmentPackageTypeId === row.PackageType)[0].PackageTypeName;
        });

        const exportLP = <ListParams>JSON.parse(JSON.stringify(this.listParams));
        exportLP.take = 1000000;
        return <GridDataResult> {
            data: process(newList, exportLP).data,
            total: newList.length
        };
    }

    public getxlsFileName(): string {
        const todayString = this.datePipe.transform(new Date(), 'yyyyMMdd');
        return `${'AyipliUrunIade'}_${todayString}.xlsx`;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
