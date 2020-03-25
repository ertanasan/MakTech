// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { ProductCampaign } from '@product/model/product-campaign.model';
import { ProductCampaignService } from '@product/service/product-campaign.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-campaign-edit',
    templateUrl: './product-campaign-edit.component.html',
    styleUrls: ['./product-campaign-edit.component.css', ]
})
export class ProductCampaignEditComponent extends CRUDDialogScreenBase<ProductCampaign> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<ProductCampaign>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductCampaignService,
    ) {
        super(messageService, translateService, dataService, 'Product Campaign');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductCampaignId: new FormControl(),
            Name: new FormControl(),
            ImagePath: new FormControl(),
            Active: new FormControl(),
            Comment: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
