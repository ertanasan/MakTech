// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { Branch } from '@organization/model/branch.model';
import { BranchService } from '@organization/service/branch.service';
import { City } from '@store/model/city.model';
import { CityService } from '@store/service/city.service';
import { Town } from '@store/model/town.model';
import { TownService } from '@store/service/town.service';
import { RegionManagers } from '@store/model/region-managers.model';
import { RegionManagersService } from '@store/service/region-managers.service';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-edit',
    templateUrl: './store-edit.component.html',
    styleUrls: ['./store-edit.component.css', ]
})
export class StoreEditComponent extends CRUDDialogScreenBase<Store> implements OnInit, OnDestroy {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<Store>;
    townList: Town[] /*= this.townService.completeList.filter(t => t.TownId === this.container.initialItem.Town)*/;
    showSubscription: Subscription;
    organizationBranches: any;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: StoreService,
        public branchService: BranchService,
        public cityService: CityService,
        public townService: TownService,
        public regionManagersService: RegionManagersService,
        public utilityService: OverstoreCommonMethods,
    ) {
        super(messageService, translateService, dataService, 'Store');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            OrganizationBranch: new FormControl(),
            IpAddress: new FormControl(),
            Advance: new FormControl(),
            OpeningDate: new FormControl(),
            ClosingDate: new FormControl(),
            ActiveFlag: new FormControl(),
            ProductionFlag: new FormControl(),
            City: new FormControl(),
            Town: new FormControl(),
            Address: new FormControl(),
            // RegionManager: new FormControl(),
            InConstruction: new FormControl(),
        });
    }

    ngOnInit() {
        if (!this.branchService.branchTreeList) {
            this.branchService.getBranchTree();
        }
        this.showSubscription = this.container.onShow.subscribe(item => {
            this.townList = this.townService.completeList.filter(t => t.City === item.City);
        });
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onCityValueChange(value: any) {
        this.container.mainForm.get('Town').reset();
        this.refreshTownList(value);
    }

    refreshTownList(cityId: number = 0) {
        this.townList = [];
        if (cityId !== 0) {
            this.townList = this.townService.completeList.filter(t => t.City === cityId);
        }
    }

    ngOnDestroy(): void {
        if (this.showSubscription) {
            this.showSubscription.unsubscribe();
        }
    }

    onSubmit() {
        if (this.container.currentItem.OpeningDate) {
            this.container.currentItem.OpeningDate = this.utilityService.addHours(this.container.currentItem.OpeningDate, 3);
        }
        if (this.container.currentItem.ClosingDate) {
            this.container.currentItem.ClosingDate = this.utilityService.addHours(this.container.currentItem.ClosingDate, 3);
        }
        super.onSubmit();
    }
    //#endregion Customized
    /*Section="ClassFooter"*/
}
