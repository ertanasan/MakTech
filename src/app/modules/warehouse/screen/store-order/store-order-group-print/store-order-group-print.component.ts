import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'store-order-group-print',
    templateUrl: './store-order-group-print.component.html',
    styleUrls: ['./store-order-group-print.component.css']
})
export class StoreOrderGroupPrintComponent implements OnInit {

    @Input() orderPrints: any;
    NumberOfOrders: number;
    constructor() {
    }

    ngOnInit() {
        this.NumberOfOrders = this.orderPrints.Length;
    }

}
