// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreFixture } from '@store/model/store-fixture.model';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { Fixture } from '@product/model/fixture.model';
import { FixtureService } from '@product/service/fixture.service';
import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { FixtureModelService } from '@product/service/fixture-model.service';
import { finalize, first } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import * as fromApp from '@otlib/store/app.reducers';
import { Store as NgrxStore } from '@ngrx/store';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-fixture-edit',
    templateUrl: './store-fixture-edit.component.html',
    styleUrls: ['./store-fixture-edit.component.css', ]
})
export class StoreFixtureEditComponent extends CRUDDialogScreenBase<StoreFixture> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreFixture>;

    public contextState$: Observable<OTContext>;
    isMomendeUser = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: StoreFixtureService,
        public fixtureService: FixtureService,
        public supplierService: SupplierService,
        public commonMethods: OverstoreCommonMethods,
        public storeService: StoreService,
        public fixtureBrandService: FixtureBrandService,
        public fixtureModelService: FixtureModelService,
        public storeFixtureService: StoreFixtureService,
        private store: NgrxStore<fromApp.AppState>,
    ) {
        super(messageService, translateService, dataService, 'Store Fixture');
        this.contextState$ = this.store.select('context');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreFixtureId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            ProductFixture: new FormControl(),
            PurchaseDate: new FormControl(),
            SerialNo: new FormControl(),
            EndOfGuaranteeDate: new FormControl(),
            Supplier: new FormControl(),
            Store: new FormControl(),
            FixtureName: new FormControl(),
            Brand: new FormControl(),
            Model: new FormControl(),
            Quantity: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
        this.contextState$.pipe(first()).subscribe(
            context => {
                this.isMomendeUser = context.Branch.Name === 'Momende';
            }
        )
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onSubmit() {
        if (this.container.currentItem.PurchaseDate) {
            this.container.currentItem.PurchaseDate = this.commonMethods.addHours(this.container.currentItem.PurchaseDate, 3);
        }
        if (this.container.currentItem.EndOfGuaranteeDate) {
            this.container.currentItem.EndOfGuaranteeDate = this.commonMethods.addHours(this.container.currentItem.EndOfGuaranteeDate, 3);
        }
        super.onSubmit();
    }

    brandFilteredList() {
        const fixtureId = this.container.mainForm.value.ProductFixture;
        return this.fixtureBrandService.completeList.filter(row => row.Fixture === fixtureId);
    }

    modelFilteredList() {
        const brandId = this.container.mainForm.value.Brand;
        return this.fixtureModelService.completeList.filter(row => row.Brand === brandId);
    }

    onFixtureChange(event) {
        this.container.mainForm.get('Brand').setValue(null);
        this.container.mainForm.get('Model').setValue(null);
    }

    onBrandChange(event) {
        this.container.mainForm.get('Model').setValue(null);
    }

    create() {
        if (this.mainScreen.isEmbedded && this.isMomendeUser) {
            this.storeFixtureService.createFixture(this.currentItem).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.handleHttpError(error, this.createFailMessage, this.modelName);
                }
            );
        } else {
            super.create();
        }
    }

    update() {
        if (this.mainScreen.isEmbedded && this.isMomendeUser) {
            this.storeFixtureService.updateFixture(this.currentItem).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.handleHttpError(error, this.updateFailMessage, this.modelName);
                }
            );
        } else {
            super.update();
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
