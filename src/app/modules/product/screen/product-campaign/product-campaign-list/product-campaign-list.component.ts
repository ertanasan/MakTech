// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ProductCampaign } from '@product/model/product-campaign.model';
import { ProductCampaignService } from '@product/service/product-campaign.service';
import { ProductCampaignEditComponent } from '@product/screen/product-campaign/product-campaign-edit/product-campaign-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-product-campaign-list',
    templateUrl: './product-campaign-list.component.html',
    styleUrls: ['./product-campaign-list.component.css', ]
})
export class ProductCampaignListComponent extends ListScreenBase<ProductCampaign> implements AfterViewInit {
    @ViewChild(ProductCampaignEditComponent, {static: true}) editScreen: ProductCampaignEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ProductCampaignService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Product Campaign', RouterLink: '/product/product-campaign'}];
    }

    createEmptyModel(): ProductCampaign {
        return new ProductCampaign();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
