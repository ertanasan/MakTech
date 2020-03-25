// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild} from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { SaleDetail } from '@sale/model/sale-detail.model';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { SaleDetailEditComponent } from '@sale/screen/sale-detail/sale-detail-edit/sale-detail-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';
import { ActivatedRoute} from '@angular/router';
import { process } from '@progress/kendo-data-query';
import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';
import {Location, DatePipe} from '@angular/common';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-detail-list',
    templateUrl: './sale-detail-list.component.html',
    styleUrls: ['./sale-detail-list.component.css', ]
})
export class SaleDetailListComponent extends ListScreenBase<SaleDetail>  {

    @ViewChild(SaleDetailEditComponent, {static: true}) editScreen: SaleDetailEditComponent;
    saleId: any;
    sale: Sales;

    saleDetailList: any;
    saleDetailActiveList: any;
    saleDetailLoading: boolean = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SaleDetailService,
        public saleService: SalesService,
        public productService: ProductService, 
        public storeService: StoreService,
        public unitService: UnitService,
        public route: ActivatedRoute,
        private _location: Location
    ) {
        super(messageService, translateService);
    }

    backClicked() {
        this._location.back();
    }

    refreshList() {
        if (this.saleDetailList) {
            this.saleDetailActiveList = process(this.saleDetailList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Sale' }, {Caption: 'Sale Detail', RouterLink: '/sale/sale-detail'}];
    }

    createEmptyModel(): SaleDetail {
        let sd =  new SaleDetail();
        sd.SaleID = this.saleId;
        sd.TransactionDate = this.sale.TransactionDate;
        sd.Store = this.sale.Store;
        sd.TransactionID = this.sale.TransactionCode;
        sd.Event = 1045;
        sd.Organization = 1;
        return sd;
    }

    refreshData() {
        this.getSaleDetailList();
        this.refreshList();
    }

    getSaleDetailList() {
        
        if (this.saleId) {
            this.saleDetailLoading = true;
            this.dataService.listSaleDetail(this.saleId).subscribe(result => {
                this.saleDetailList = result;
                this.refreshList();
                this.saleDetailLoading = false;
            },
            error => {
                this.messageService.error(error);
                this.saleDetailLoading = false;
            });
        }
    }

    ngOnInit() {
        this.saleId = this.route.snapshot.params['saleId'];
        // Fill reference lists
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.unitService.completeList) {
            this.unitService.listAll();
        }
        this.getSaleDetailList();

        this.saleService.read(this.saleId, 'Read').subscribe(result => {
            this.sale = result;
        });

        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    
    //#endregion Customized

    /*Section="ClassFooter"*/
}
