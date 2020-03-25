// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreFixture } from '@store/model/store-fixture.model';
import { StoreFixtureService } from '@store/service/store-fixture.service';
import { StoreFixtureEditComponent } from '@store/screen/store-fixture/store-fixture-edit/store-fixture-edit.component';
import { Supplier } from '@warehouse/model/supplier.model';
import { SupplierService } from '@warehouse/service/supplier.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { finalize } from 'rxjs/internal/operators/finalize';
import { FixtureService } from '@product/service/fixture.service';
import { process } from '@progress/kendo-data-query';
import { FixtureBrandService } from '@product/service/fixture-brand.service';
import { FixtureModelService } from '@product/service/fixture-model.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-fixture-list',
    templateUrl: './store-fixture-list.component.html',
    styleUrls: ['./store-fixture-list.component.css', ]
})
export class StoreFixtureListComponent extends ListScreenBase<StoreFixture> implements AfterViewInit, OnInit {
    @ViewChild(StoreFixtureEditComponent, {static: true}) editScreen: StoreFixtureEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreFixtureService,
        public supplierService: SupplierService,
        public storeService: StoreService,
        public fixtureService: FixtureService,
        public fixtureBrandService: FixtureBrandService,
        public fixtureModelService: FixtureModelService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (!this.isEmbedded) {
            this.dataService.list(this.listParams);
        } else {
            const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
            if (result) {
                this.dataLoading = true;
                result.subscribe(
                    list => {
                        this.dataList = process(list.Data, this.listParams);
                    },
                    error => {
                        this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                    },
                    () => this.dataLoading = false
                );
            }

        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store Fixture', RouterLink: '/store/store-fixture'}];
    }

    createEmptyModel(): StoreFixture {
        const model = new StoreFixture();
        if (this.isEmbedded) {
            model.Store = this.masterId;
        }
        return model;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.supplierService.completeList) {
            this.supplierService.listAll();
        }
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.fixtureService.completeList) {
            this.fixtureService.listAll();
        }
        if (!this.fixtureBrandService.completeList) {
            this.fixtureBrandService.listAll();
        }
        if (!this.fixtureModelService.completeList) {
            this.fixtureModelService.listAll();
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
