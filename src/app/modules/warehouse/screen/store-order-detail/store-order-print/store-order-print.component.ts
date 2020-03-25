// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, ViewChildren, QueryList, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { StoreOrderDetail } from '@warehouse/model/store-order-detail.model';
import { StoreOrderDetailService } from '@warehouse/service/store-order-detail.service';
import { StoreOrderDetailEditComponent } from '@warehouse/screen/store-order-detail/store-order-detail-edit/store-order-detail-edit.component';
import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { ActivatedRoute } from '@angular/router';
import { StoreOrderService } from '@warehouse/service/store-order.service';
import { StoreOrder } from '@warehouse/model/store-order.model';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { DropdownEntryComponent } from '@otuidataentry/dropdown-entry/dropdown-entry.component';
import { EditEvent } from '@progress/kendo-angular-grid';

@Component({
    selector: 'store-order-print',
    templateUrl: './store-order-print.component.html',
    styleUrls: ['./store-order-print.component.css']
})
export class StoreOrderPrintComponent implements OnInit {

    @Input() storeOrder: any;
    @Input() heavyProducts: any;
    @Input() lightProducts: any;
    @Input() heavyProductsTotal: any;
    @Input() lightProductsTotal: any;
    @Input() orderPrints: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
    }

    ngOnInit() {
     }

}
