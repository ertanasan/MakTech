// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreProperty } from '@store/model/store-property.model';
import { StorePropertyService } from '@store/service/store-property.service';
import { StoreService } from '@store/service/store.service';
import { StorePropertyTypeService } from '@store/service/store-property-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-property-edit',
    templateUrl: './store-property-edit.component.html',
    styleUrls: ['./store-property-edit.component.css', ]
})
export class StorePropertyEditComponent extends CRUDDialogScreenBase<StoreProperty> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreProperty>;

    @Input() edit : boolean = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StorePropertyService,
        public storeService: StoreService,
        public storePropertyTypeService: StorePropertyTypeService,
    ) {
        super(messageService, translateService, dataService, 'Store Property');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            Store: new FormControl(),
            PropertyType: new FormControl(),
            PropertyValue: new FormControl(),
            PropertyId: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    onSubmit() {
        if (this.container.masterId) {
            this.container.currentItem.Store = this.container.masterId;
        }
        super.onSubmit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
