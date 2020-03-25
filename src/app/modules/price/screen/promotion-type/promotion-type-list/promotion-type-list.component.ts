// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { PromotionType } from '@price/model/promotion-type.model';
import { PromotionTypeService } from '@price/service/promotion-type.service';
import { PromotionTypeEditComponent } from '@price/screen/promotion-type/promotion-type-edit/promotion-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-promotion-type-list',
    templateUrl: './promotion-type-list.component.html',
    styleUrls: ['./promotion-type-list.component.css', ]
})
export class PromotionTypeListComponent extends ListScreenBase<PromotionType> implements AfterViewInit {
    @ViewChild(PromotionTypeEditComponent, {static: true}) editScreen: PromotionTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PromotionTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Promotion Type', RouterLink: '/price/promotion-type'}];
    }

    createEmptyModel(): PromotionType {
        return new PromotionType();
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
