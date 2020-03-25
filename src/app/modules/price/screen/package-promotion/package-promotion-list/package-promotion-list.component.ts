// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { PackagePromotion } from '@price/model/package-promotion.model';
import { PackagePromotionService } from '@price/service/package-promotion.service';
import { PackagePromotionEditComponent } from '@price/screen/package-promotion/package-promotion-edit/package-promotion-edit.component';
import { PromotionType } from '@price/model/promotion-type.model';
import { PromotionTypeService } from '@price/service/promotion-type.service';
import { PricePackage } from '@price/model/price-package.model';
import { PricePackageService } from '@price/service/price-package.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-package-promotion-list',
    templateUrl: './package-promotion-list.component.html',
    styleUrls: ['./package-promotion-list.component.css', ]
})
export class PackagePromotionListComponent extends ListScreenBase<PackagePromotion> implements AfterViewInit, OnInit {
    @ViewChild(PackagePromotionEditComponent, {static: true}) editScreen: PackagePromotionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PackagePromotionService,
        public promotionTypeService: PromotionTypeService,
        public pricePackageService: PricePackageService,
    ) {
        super(messageService, translateService);
        this.updateEnabled = false;
    }

    refreshList() {
        this.listParams.queryParams.clear();
        this.listParams.queryParams.set('leftId', this.leftRelationId);
        this.listParams.queryParams.set('rightId', this.rightRelationId);
        this.dataLoading = true;
        this.dataService.listAsync(this.listParams).pipe(
            finalize(() => this.dataLoading = false)
        ).subscribe(
            listResult => {
                this.dataList = listResult.Data;
            },
            error => {
                this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
            }
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Package Promotion', RouterLink: '/price/package-promotion'}];
    }

    createEmptyModel(): PackagePromotion {
        const packagePromotion = new PackagePromotion();
        if (this.leftRelationId > 0) {
            packagePromotion.Package = this.leftRelationId;
        }
        if (this.rightRelationId > 0) {
            packagePromotion.PromotionType = this.rightRelationId;
        }
        return packagePromotion;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.leftRelationId && !this.pricePackageService.completeList) {
            this.pricePackageService.listAll();
        }
        if (!this.rightRelationId && !this.promotionTypeService.completeList) {
            this.promotionTypeService.listAll();
        }
        super.ngOnInit();
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
