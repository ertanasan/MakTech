// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductionOrder } from '@warehouse/model/production-order.model';
import { ProductionOrderService } from '@warehouse/service/production-order.service';
import { ProductionOrderEditComponent } from '@warehouse/screen/production-order/production-order-edit/production-order-edit.component';
import { ProductionService } from '@warehouse/service/production.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-production-order-list',
    templateUrl: './production-order-list.component.html',
    styleUrls: ['./production-order-list.component.css', ]
})
export class ProductionOrderListComponent extends ListScreenBase<ProductionOrder> implements AfterViewInit, OnInit {
    @ViewChild(ProductionOrderEditComponent, {static: true}) editScreen: ProductionOrderEditComponent;

    statusList = [{value: 1, text: 'Sipariş Girildi'},
        {value: 2, text: 'Ürünler Gönderildi'},
        {value: 3, text: 'Kısmen Tamamlandı'},
        {value: 4, text: 'Tamamlandı'},
        {value: 7, text: 'İptal'}];

    tolerancePct: number;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductionOrderService,
        public productionService: ProductionService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.listParams.dateFields = ['CreateDate'];
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Production Order', RouterLink: '/warehouse/production-order'}];
    }

    createEmptyModel(): ProductionOrder {
        const model = new ProductionOrder();
        model.StatusCode = 0;
        model.Event = 1;
        model.Organization = 1;
        this.editScreen.activeItem = model;
        return model;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);

        if (this.modeReview && !this.isEmbedded) {
            const productionOrderId = this.modeContext.id;
            this.dataService.read(productionOrderId).subscribe(productionOrder => {
                this.editScreen.modeContext = this.modeContext;
                this.editScreen.modeReview = true;
                const dataItem = Object.assign(this.createEmptyItem(), productionOrder);
                this.showDialog(this.editScreen, 'Review', dataItem );
            });
        }
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    ngOnInit() {
        if (!this.productionService.completeList) {
            this.productionService.listAll();
        }
        this.dataService.getTolerancePct().subscribe(percentageValue => this.tolerancePct = percentageValue);
        super.ngOnInit();
    }

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (dataItem) {
            this.editScreen.activeItem = dataItem;
            this.editScreen.initialCompleteQuantity = dataItem.CompletedQuantity ? dataItem.CompletedQuantity : 0;
            this.editScreen.reqQuantity = dataItem.Quantity;
            this.editScreen.onProductionChange(dataItem.Production);
        }
        super.showDialog(target, actionName, dataItem);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
