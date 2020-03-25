// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { PromotionType } from '@price/model/promotion-type.model';
import { PromotionTypeService } from '@price/service/promotion-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-promotion-type-edit',
    templateUrl: './promotion-type-edit.component.html',
    styleUrls: ['./promotion-type-edit.component.css', ]
})
export class PromotionTypeEditComponent extends CRUDDialogScreenBase<PromotionType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<PromotionType>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: PromotionTypeService,
    ) {
        super(messageService, translateService, dataService, 'Promotion Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            PromotionTypeId: new FormControl(),
            PromotionName: new FormControl(),
            Description: new FormControl(),
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
