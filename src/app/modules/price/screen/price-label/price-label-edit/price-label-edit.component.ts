import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { PriceLabel } from '@price/model/price-label.model';
import { PriceLabelService } from '@price/service/price-label.service';
import { ProductService } from '@product/service/product.service';
import { PricePackageService } from '@price/service/price-package.service';
import { CustomDialogScreenBase } from '@otscreen-base/custom-dialog-screen-base';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

@Component({
    selector: 'ot-price-label-edit',
    templateUrl: './price-label-edit.component.html',
    styleUrls: ['./price-label-edit.component.css', ]
})
export class PriceLabelEditComponent extends CustomDialogScreenBase implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PriceLabel>;

    @Input() selectedProducts: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: PriceLabelService,
        public productService: ProductService,
        public pricePackageService: PricePackageService,
    ) {
        super(messageService, translateService, 'PriceLabel');
    }

    ngOnInit() {
    }

    print() {

    }

}
