// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PackagePromotion } from '@price/model/package-promotion.model';
import { PackagePromotionService } from '@price/service/package-promotion.service';
import { PricePackageService } from '@price/service/price-package.service';
import { PromotionTypeService } from '@price/service/promotion-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-promotion-edit',
    templateUrl: './package-promotion-edit.component.html',
    styleUrls: ['./package-promotion-edit.component.css', ]
})
export class PackagePromotionEditComponent extends CRUDDialogScreenBase<PackagePromotion> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PackagePromotion>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PackagePromotionService,
        public pricePackageService: PricePackageService,
        public promotionTypeService: PromotionTypeService,
    ) {
        super(messageService, translateService, dataService, 'Package Promotion');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Package: new FormControl(),
            PromotionType: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
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
