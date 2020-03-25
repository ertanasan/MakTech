// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { TransferProductDetail } from '@warehouse/model/transfer-product-detail.model';
import { TransferProductDetailService } from '@warehouse/service/transfer-product-detail.service';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { TransferProduct } from '@warehouse/model/transfer-product.model';
import { TransferProductService } from '@warehouse/service/transfer-product.service';
import { finalize } from 'rxjs/internal/operators/finalize';
import { TransferProductDetailListComponent } from '../transfer-product-detail-list/transfer-product-detail-list.component';
import * as _ from 'lodash';
import { UnitService } from '@product/service/unit.service';
import { Subject } from 'rxjs';
import { EventEmitter } from 'selenium-webdriver';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-transfer-product-detail-edit',
    templateUrl: './transfer-product-detail-edit.component.html',
    styleUrls: ['./transfer-product-detail-edit.component.css']
})
export class TransferProductDetailEditComponent extends CRUDDialogScreenBase<TransferProductDetail> implements OnInit, OnDestroy {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<TransferProductDetail>;
    mainScreen: TransferProductDetailListComponent;

    transferableProducts: Product[] = [];
    unsubscribe = [];

    unitVal: number;
    unitBindingSubscription;
    unitChanged = new Subject<number>();

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: TransferProductDetailService,
        public productService: ProductService,
        public unitService: UnitService,
        public transferProductService: TransferProductService
    ) {
        super(messageService, translateService, dataService, 'Transfer Product Detail');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            TransferProductDetailId: new FormControl(),
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
            Product: new FormControl(),
            TransferProduct: new FormControl(),
            Unit: new FormControl(),
            ProductQuantity: new FormControl(),
        });
    }


    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnInit() {
        super.ngOnInit();
        this.unsubscribe.push(this.unitChanged.subscribe(e => this.unitVal = e ? this.transferableProducts.find(p => p.ProductId === e).Unit : null));

        if (this.productService.completeList) {
            this.transferableProducts = this.productService.completeList.filter(p => p.SuperGroup3 !== 3);
        } else {
            this.productService.listAll();
            this.unsubscribe.push(this.productService.completeListChanged.subscribe( list =>
                this.transferableProducts = list.filter(p => p.SuperGroup3 !== 3)
            ));
        }
    }

    ngOnDestroy() {
        this.unsubscribe.forEach(u => u.unsubscribe());
        super.ngOnDestroy();
    }

    onSubmit() {
        if (this.container.currentItem.Product === null) {
            this.messageService.warning(this.translateService.instant('A product must be selected'));
        } else {
            super.onSubmit();
            this.dataService.obsData.next(this.mainScreen.transferData);
        }
    }

    // create(), update() and delete() METHODS ARE OVERRIDEN TO MAKE THEM OPERATE ON THE FLY. SUBMITTION TO DB WILL BE DONE BY THE productListScreen's onsubmit() METHOD
    create() {
        _.max(this.mainScreen.transferData.map(i => i.CreateId)) === 0 || _.max(this.mainScreen.transferData.map(i => i.CreateId)) === undefined ? this.currentItem.CreateId = 1 : this.currentItem.CreateId = _.max(this.mainScreen.transferData.map(i => i.CreateId)) + 1;
        this.mainScreen.transferData.push(this.currentItem);
        this.mainScreen.refreshData();
        this.container.hide();
    }

    update() {
        if ( this.currentItem.TransferProductDetailId > 0 ) {
            this.mainScreen.transferData[this.mainScreen.transferData.findIndex(data => data.TransferProductDetailId === this.currentItem.TransferProductDetailId)] = this.currentItem;
        } else {
            this.mainScreen.transferData[this.mainScreen.transferData.findIndex(data => data.CreateId === this.currentItem.CreateId )] = this.currentItem;
        }
        this.mainScreen.refreshData();
        this.container.hide();
    }

    delete() {
        if ( this.currentItem.TransferProductDetailId > 0 ) {
            this.mainScreen.transferData.splice(this.mainScreen.transferData.findIndex(data => data.TransferProductDetailId === this.currentItem.TransferProductDetailId), 1);
        } else {
            this.mainScreen.transferData.splice(this.mainScreen.transferData.findIndex(data => data.CreateId === this.currentItem.CreateId), 1);
        }
        this.mainScreen.refreshData();
        this.container.hide();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
