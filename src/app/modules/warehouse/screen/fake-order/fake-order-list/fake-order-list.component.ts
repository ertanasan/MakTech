// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { FakeOrder } from '@warehouse/model/fake-order.model';
import { FakeOrderService } from '@warehouse/service/fake-order.service';
import { FakeOrderEditComponent } from '@warehouse/screen/fake-order/fake-order-edit/fake-order-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ProductService } from '@product/service/product.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fake-order-list',
    templateUrl: './fake-order-list.component.html',
    styleUrls: ['./fake-order-list.component.css', ]
})
export class FakeOrderListComponent extends ListScreenBase<FakeOrder> implements AfterViewInit, OnInit {
    @ViewChild(FakeOrderEditComponent, {static: true}) editScreen: FakeOrderEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FakeOrderService,
        public storeService: StoreService,
        public productService: ProductService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Fake Order', RouterLink: '/warehouse/fake-order'}];
    }

    createEmptyModel(): FakeOrder {
        return new FakeOrder();
    }

    ngOnInit() {
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.productService.completeList) {
            this.productService.listAll();
        }
        this.commandColumnWidth = 40;
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['OrderDate'];
        super.handleDataStateChange(state);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
