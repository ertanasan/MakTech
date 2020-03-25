// Created by OverGenerator
/*Section="Imports"*/
import {Component, OnInit, ViewChild, Input, OnDestroy} from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductReturn } from '@warehouse/model/product-return.model';
import { ProductReturnService } from '@warehouse/service/product-return.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ShipmentPackageType } from '@warehouse/model/shipment-package-type.model';
import { ShipmentPackageTypeService } from '@warehouse/service/shipment-package-type.service';
import { ReturnStatus } from '@warehouse/model/return-status.model';
import { ReturnStatusService } from '@warehouse/service/return-status.service';
import { ReturnDestination } from '@warehouse/model/return-destination.model';
import { ReturnDestinationService } from '@warehouse/service/return-destination.service';
import { of } from 'rxjs/internal/observable/of';
import { CheckableSettings } from '@progress/kendo-angular-treeview';
import { Store } from '@store/model/store.model';
import { ReturnReason } from '@warehouse/model/return-reason.model';
import { ProductReturnReason } from '@warehouse/model/product-return-reason.model';
import { ProductReturnListComponent } from '../product-return-list/product-return-list.component';
import { StoreService } from '@store/service/store.service';
import { SalesService } from '@sale/service/sales.service';
import { Refund } from '@sale/model/refund.model';
import {first} from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-return-edit',
    templateUrl: './product-return-edit.component.html',
    styleUrls: ['./product-return-edit.component.css', ]
})
export class ProductReturnEditComponent extends CRUDDialogScreenBase<ProductReturn> implements OnInit, OnDestroy {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductReturn>;

    store: Store;
    authorized: boolean;
    isStore: boolean;
    isRegion: boolean;
    isCentralOffice: boolean;
    isCustomerReturn = true;
    reusableFlag = false;
    returnOrderStatus: number;
    public Callee: ProductReturnListComponent;
    public reasonTreeView: any[];
    public reasonList: ReturnReason[];
    returnableProducts: Product[] = [];
    unsubscribe = [];

    refundList: Refund[];
    public refundText: string;
    public toView: boolean;

    @Input() viewIntake: boolean;
    @Input() viewDestination: boolean;

    public checkedKeys: any[] = [];
    public hasChildren = (item: any) => item.items && item.items.length > 0;
    public fetchChildren = (item: any) => of(item.items);

    // public selectionMode: any = 'single';

    public get checkableSettings(): CheckableSettings {
        return {
            checkChildren: true,
            checkParents: true,
            enabled: true,
            mode: 'multiple'
        };
    }

    addHours(_datetime, _hour) {
        const d = new Date(_datetime);
        d.setHours(d.getHours() + _hour);
        return d;
    }

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductReturnService,
        public productService: ProductService,
        public shipmentPackageTypeService: ShipmentPackageTypeService,
        public returnStatusService: ReturnStatusService,
        public returnDestinationService: ReturnDestinationService,
        public productReturnService: ProductReturnService,
        public storeService: StoreService,
        public saleService: SalesService,
    ) {
        super(messageService, translateService, dataService, 'Product Return');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductReturnId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            ReturnDate: new FormControl(),
            WaybillDate: new FormControl(),
            Product: new FormControl(),
            Supplier: new FormControl(),
            ManufacturingDate: new FormControl(),
            ExpireDate: new FormControl(),
            ReturnQuantity: new FormControl(),
            PackageType: new FormControl(),
            ReturnReasonText: new FormControl(),
            ReturnStatus: new FormControl(),
            ReturnDestination: new FormControl(),
            Store: new FormControl(),
            IntakeAmount: new FormControl(),
            IsCustomerReturn: new FormControl(),
            ReusableFlag: new FormControl(),
            SaleDetailId: new FormControl(),
            SaleDetailText: new FormControl(),
            WaybillText: new FormControl(),
        });
    }

    ngOnInit() {
        if (this.productService.completeList) {
            this.returnableProducts = this.productService.completeList.filter(p => p.SuperGroup3 !== 3);
        } else {
            this.productService.listAll();
            this.unsubscribe.push(this.productService.completeListChanged.subscribe( list =>
                this.returnableProducts = list.filter(p => p.SuperGroup3 !== 3)
            ));
        }

        super.ngOnInit();
    }

    ngOnDestroy(): void {
        this.unsubscribe.forEach(u => u.unsubscribe());
        super.ngOnDestroy();
    }

    onRadioClicked(value) {
        this.isCustomerReturn = value;
        this.container.mainForm.patchValue({ReturnQuantity : null, PackageType : null, SaleDetailId: null});
    }

    onReuseClicked(value) {
        this.reusableFlag = value;
    }

    review() {
        if (this.currentItem.actionChoice !== 'İptal' && !this.inputControl()) {
            this.container.hideProgress();
            return;
        }
        if (this.currentItem.WaybillDate) {
            this.currentItem.WaybillDate = this.addHours(this.currentItem.WaybillDate, 3);
        }
        super.review();
    }

    inputControl() {
        if (!this.currentItem.Product) {
            this.messageService.warning('Ürün seçiniz'); return false;
        }

        if (!this.currentItem.PackageType) {
            this.messageService.warning('Paket tipi seçiniz'); return false;
        }

        if (!this.currentItem.ReturnReasonText || this.currentItem.ReturnReasonText.length === 0) {
            this.messageService.warning('İade nedeni açıklaması giriniz'); return false;
        }

        if (this.checkedKeys.length === 0) {
            this.messageService.warning('İade nedeni seçiniz'); return false;
        }

        if (this.viewIntake && this.currentItem.IntakeAmount <= 0) {
            this.messageService.warning('Kabul miktarı giriniz'); return false;
        }

        if (this.viewIntake && !this.currentItem.ReturnDestination) {
            this.messageService.warning('İade deposu seçiniz'); return false;
        }

        if (this.isCustomerReturn && !this.currentItem.SaleDetailId) {
            this.messageService.warning('Müşteri iadelerinde iade fişini seçmeniz gerekmektedir.'); return false;
        }

        if (this.currentItem.ReturnQuantity <= 0) {
            this.messageService.warning('İade miktarı giriniz'); return false;
        }

        if (this.currentItem.ProcessInstance && !this.currentItem.WaybillDate) {
            this.messageService.warning('İrsaliye Tarihini giriniz.'); return false;
        }

        if (this.currentItem.ProcessInstance && !this.currentItem.WaybillText) {
            this.messageService.warning('İrsaliye Numarasını giriniz.'); return false;
        }

        return true;
    }

    save() {
        if (!this.inputControl()) {
            this.container.hideProgress();
            return;
        }

        if (this.currentItem.ReturnDate) {
            this.currentItem.ReturnDate = this.addHours(this.currentItem.ReturnDate, 3);
        }
        if (this.currentItem.ManufacturingDate) {
            this.currentItem.ManufacturingDate = this.addHours(this.currentItem.ManufacturingDate, 3);
        }
        if (this.currentItem.ExpireDate) {
            this.currentItem.ExpireDate = this.addHours(this.currentItem.ExpireDate, 3);
        }

        const newlist: ProductReturnReason[] = [];
        const selectedList: string[] = [];
        this.checkedKeys.forEach(k => {
            if (k.search('_') === -1) {
                selectedList.push(this.reasonTreeView[parseInt(k, 10)].text);
            } else {
                const tk: string[] = k.split('_');
                selectedList.push(this.reasonTreeView[parseInt(tk[0], 10)].items[parseInt(tk[1], 10)].text);
            }
        });
        selectedList.forEach(s => {
            const returnReasonId = this.reasonList.filter(row => row.ReasonName === s)[0].ReturnReasonId;
            if (this.currentItem.ReturnReason) {
                const r = this.currentItem.ReturnReason.filter(row => row.ReturnReason === returnReasonId);
                if (r.length === 0) {
                    const newrow: ProductReturnReason = new ProductReturnReason();
                    newrow.ReturnReason = returnReasonId;
                    newlist.push(newrow);
                } else {
                    newlist.push(r[0]);
                }
            } else {
                const newrow: ProductReturnReason = new ProductReturnReason();
                newrow.ReturnReason = returnReasonId;
                newlist.push(newrow);
            }
        });
        this.currentItem.ReturnReason = newlist;
        this.currentItem.IsCustomerReturn = this.isCustomerReturn;
        this.productReturnService.SaveProductReturn(this.currentItem).subscribe(result => {
            let productReturnId: number;
            productReturnId = parseInt(result.toString(), 10);
            this.productReturnService.read(productReturnId).subscribe(row => {
                this.messageService.success('Kaydedildi');
                this.mainScreen.refreshData();
                this.container.hide();
                this.container.hideProgress();
            });

        }, error => {
            this.messageService.error(error);
            this.container.hideProgress();
        });


    }

    create() {
        this.save();
    }

    update() {
        this.save();
    }

    onStoreProductChange(event) {
        this.container.mainForm.patchValue({ReturnQuantity : null, PackageType : null, SaleDetailId: null});
        this.getRefundList();
    }

    getRefundList() {
        if (this.container.mainForm.value.Store && this.container.mainForm.value.Product) {
            this.saleService.listRefunds(this.container.mainForm.value.Store, this.container.mainForm.value.Product).subscribe(result => {
                // console.log('getRefundList : ', result );
                this.refundList = result;
            });
        }
    }

    onRefundSelected(event) {
        const refundRow: Refund = this.refundList.filter(row => (row.SaleDetailId === event))[0];

        if (refundRow.Unit === 1) {
            this.container.mainForm.patchValue({ReturnQuantity : refundRow.Quantity / 1000, PackageType : 6}); // kg
        } else {
            this.container.mainForm.patchValue({ReturnQuantity : refundRow.Quantity, PackageType : 8}); // adet
        }
    }

    onPackageTypeChanged() {
        if (this.container.mainForm.value.SaleDetailId && this.container.mainForm.value.SaleDetailId > 0) {
            this.onRefundSelected(this.container.mainForm.value.SaleDetailId);
        }
    }

}
