import { Component, OnInit, ViewChild, Input} from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Product } from '@product/model/product.model';
import { ProductService } from '@product/service/product.service';
import { Subgroup } from '@product/model/subgroup.model';
import { SubgroupService } from '@product/service/subgroup.service';
import { SuperGroup1 } from '@product/model/super-group1.model';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup2 } from '@product/model/super-group2.model';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup3 } from '@product/model/super-group3.model';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { Unit } from '@product/model/unit.model';
import { UnitService } from '@product/service/unit.service';
import { BarcodeTypeInt } from '@product/model/barcode-type-int.model';
import { BarcodeTypeIntService } from '@product/service/barcode-type-int.service';
import { SeasonType } from '@product/model/season-type.model';
import { SeasonTypeService } from '@product/service/season-type.service';
import { Country } from '@product/model/country.model';
import { CountryService } from '@product/service/country.service';
import { Warning } from '@product/model/warning.model';
import { WarningService } from '@product/service/warning.service';
import { StorageCondition } from '@product/model/storage-condition.model';
import { StorageConditionService } from '@product/service/storage-condition.service';
import { ProductCampaign } from '@product/model/product-campaign.model';
import { ProductCampaignService } from '@product/service/product-campaign.service';
import { ProductCategoryService } from '@product/service/product-category.service';

@Component({
    selector: 'ot-product-edit',
    templateUrl: './product-edit.component.html',
    styleUrls: ['./product-edit.component.css', ]
})
export class ProductEditComponent extends CRUDDialogScreenBase<Product> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Product>;
    @Input() parentProducts: any;
    selectedCategory: number;
    selectedSubGroup: number;
    subGroupFilterList: Subgroup[];

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: ProductService,
        public categoryService: ProductCategoryService,
        public subgroupService: SubgroupService,
        public superGroup1Service: SuperGroup1Service,
        public superGroup2Service: SuperGroup2Service,
        public superGroup3Service: SuperGroup3Service,
        public unitService: UnitService,
        public barcodeTypeIntService: BarcodeTypeIntService,
        public seasonTypeService: SeasonTypeService,
        public countryService: CountryService,
        public warningService: WarningService,
        public storageConditionService: StorageConditionService,
        public productCampaignService: ProductCampaignService,
    ) {
        super(messageService, translateService, dataService, 'Product');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            ProductId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Code: new FormControl(null, Validators.required),
            Name: new FormControl(null, Validators.required),
            PurchaseVAT: new FormControl(),
            SaleVAT: new FormControl(null, Validators.required),
            Subgroup: new FormControl(),
            SuperGroup1: new FormControl(),
            SuperGroup2: new FormControl(),
            SuperGroup3: new FormControl(),
            Unit: new FormControl(null, Validators.required),
            BarcodeType: new FormControl(),
            SeasonType: new FormControl(),
            OldCode: new FormControl(),
            PrivateLabel: new FormControl(),
            eTrade: new FormControl(),
            GTIPCode: new FormControl(),
            Photo: new FormControl(),
            ShortName: new FormControl(null, Validators.required),
            Domestic: new FormControl(),
            Country: new FormControl(),
            Content: new FormControl(),
            Warning: new FormControl(),
            StorageCondition: new FormControl(),
            ExpiresIn: new FormControl(),
            ShelfLife: new FormControl(),
            Comment: new FormControl(),
            Campaign: new FormControl(),
            Weight: new FormControl(),
            WeightUnit: new FormControl(),
            Active: new FormControl(),
            LoadOrder: new FormControl(),
            Parent: new FormControl(),
            InitialPrice: new FormControl(),
            Category: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onCategoryChange(event) {
        if (this.subgroupService.completeList) {
            this.subGroupFilterList = this.subgroupService.completeList.filter(row => row.Category === event);
            this.selectedSubGroup = undefined;
        }
    }
}
