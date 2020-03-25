// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, Input, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { process } from '@progress/kendo-data-query';
import { TransferProductDetail } from '@warehouse/model/transfer-product-detail.model';
import { TransferProductDetailService } from '@warehouse/service/transfer-product-detail.service';
import { TransferProductDetailEditComponent } from '@warehouse/screen/transfer-product-detail/transfer-product-detail-edit/transfer-product-detail-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { TransferProductEditComponent } from '@warehouse/screen/transfer-product/transfer-product-edit/transfer-product-edit.component';
import { UnitService } from '@product/service/unit.service';
import { Subscription, Subject } from 'rxjs';
import { TransferProduct } from '@warehouse/model/transfer-product.model';
import { Store } from '@store/model/store.model';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-transfer-product-detail-list',
    templateUrl: './transfer-product-detail-list.component.html',
    styleUrls: ['./transfer-product-detail-list.component.css', ]
})
export class TransferProductDetailListComponent extends ListScreenBase<TransferProductDetail> implements AfterViewInit, OnInit, OnDestroy {
    @ViewChild(TransferProductDetailEditComponent, {static: true}) editScreen: TransferProductDetailEditComponent;
    transferData: TransferProductDetail [] = new Array<TransferProductDetail>();
    public activeList: any = {'data': [], 'total': 0};
    @Input() transferProductStatus;
    transferProductSubscription: Subscription;
    transferProductChanged = new Subject<{'dataItem': TransferProduct, 'store': Store}>();
    productDetailsSubscription: Subscription;
    isReadOnly = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: TransferProductDetailService,
        public productService: ProductService,
        public unitService: UnitService

    ) {
        super(messageService, translateService);
    }

    refreshList() {
        //  this.dataService.list(this.listParams);
        if (this.transferData) {
            this.activeList = process(this.transferData , this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Transfer Product Detail', RouterLink: '/warehouse/transfer-product-detail'}];
    }

    createEmptyModel(): TransferProductDetail {
        return new TransferProductDetail();
    }

    ngOnInit() {
        this.productDetailsSubscription = this.dataService.obsData.subscribe(data => {
          this.transferData = data;
          this.refreshList();
        });
        // Fill reference lists
        this.productService.listAll();
        this.unitService.listAll();

        this.transferProductSubscription = this.transferProductChanged.subscribe(
            item =>  {
                this.createEnabled = false;
                this.updateEnabled = false;
                this.deleteEnabled = false;
                if (!this.isReadOnly) {
                    if (item.dataItem === null || item.dataItem.TransferStatus === 1) {   // CREATE ACTION for sending store
                        this.createEnabled = true;
                        this.updateEnabled = true;
                        this.deleteEnabled = true;
                    } else if (item.store === null) {  // UPDATEorDELETE ACTIONS for HQ staff (warehouse included)
                        this.createEnabled = true;
                        this.updateEnabled = true;
                        this.deleteEnabled = true;
                    } else if (item.dataItem.TransferStatus === 4 && this.modeContext) {  // UPDATEorDELETE ACTIONS for receiving store
                        this.createEnabled = false;
                        this.updateEnabled = true;
                        this.deleteEnabled = true;
                    }
                }
            }
        );
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnDestroy() {
        if (this.transferProductSubscription) {
            this.transferProductSubscription.unsubscribe();
        }
        if (this.productDetailsSubscription) {
            this.productDetailsSubscription.unsubscribe();
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
