// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StorePropertyType } from '@store/model/store-property-type.model';
import { StorePropertyTypeService } from '@store/service/store-property-type.service';
import { StorePropertyService } from '@store/service/store-property.service';
import { finalize } from 'rxjs/operators';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-property-type-edit',
    templateUrl: './store-property-type-edit.component.html',
    styleUrls: ['./store-property-type-edit.component.css', ]
})
export class StorePropertyTypeEditComponent extends CRUDDialogScreenBase<StorePropertyType> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StorePropertyType>;
    @Input() assignOption: string;
    @Input() assignValue: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StorePropertyTypeService,
        public propertyService: StorePropertyService
    ) {
        super(messageService, translateService, dataService, 'Store Property Type');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StorePropertyId: new FormControl(),
            PropertyName: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onSubmit() {
        if (this.container.actionName === 'Create') {
                let restAction = 'Create';
            if (this.container.leftRelationId > 0) {
                restAction = 'AddLeft';
            } else if (this.container.rightRelationId > 0) {
                restAction = 'AddRight';
            }
            this.dataService.create(this.container.currentItem, restAction).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    this.mainScreen.refreshData(this.container.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.messageService.error(this.translateService.instant(this.createFailMessage, {0: this.translateService.instant(this.modelName), 1: error}));
                }
            );
        } else if (this.container.actionName === 'Update') {
            if (this.container.initialItem.PropertyName !== this.container.currentItem.PropertyName) {
                this.dataService.update(this.container.currentItem).pipe(
                    finalize(() => this.container.hideProgress())
                ).subscribe(
                    model => {
                        this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                        this.propertyService.assingValuesToStores(this.container.mainForm.controls.StorePropertyId.value, this.assignValue, this.assignOption);
                        this.mainScreen.refreshData(this.container.currentItem.getId());
                        this.container.hide();
                    },
                    error => {
                        this.messageService.error(this.translateService.instant(this.updateFailMessage, {0: this.translateService.instant(this.modelName), 1: error}));
                    }
                );
            } else {
                this.propertyService.assingValuesToStores(this.container.mainForm.controls.StorePropertyId.value, this.assignValue, this.assignOption);
            }
        } else {
            super.onSubmit();
        }
    }

    onRadioClicked(value: string) {
        this.assignOption = value;
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
