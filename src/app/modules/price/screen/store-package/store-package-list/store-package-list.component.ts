// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StorePackage } from '@price/model/store-package.model';
import { StorePackageService } from '@price/service/store-package.service';
import { StorePackageEditComponent } from '@price/screen/store-package/store-package-edit/store-package-edit.component';
import { StoreService } from '@store/service/store.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { process } from '@progress/kendo-data-query';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-package-list',
    templateUrl: './store-package-list.component.html',
    styleUrls: ['./store-package-list.component.css', ]
})
export class StorePackageListComponent extends ListScreenBase<StorePackage> implements AfterViewInit, OnInit, OnDestroy {
    @ViewChild(StorePackageEditComponent, {static: true}) editScreen: StorePackageEditComponent;
    includeInactivesFlag = false;
    dataList: { data: StorePackage[], total: number } = { data: [], total: 0 };

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StorePackageService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
    }

    revertInacitiveFlag() {
        this.includeInactivesFlag = !this.includeInactivesFlag;
        this.refreshList();
    }

    refreshList() {
        if (this.dataService.loading) {
            return;
        }
        if (this.isEmbedded) {
            this.dataService.listByMaster(this.listParams, this.masterId);
        } else {
            if (this.includeInactivesFlag) {
                this.dataService.list(this.listParams);
            } else {
                this.dataService.loading = true;
                this.dataService.listAllAsync().subscribe( storePackages => {
                    this.dataService.excludeInactives(storePackages);
                    this.dataService.excludeInactivesSubject.subscribe( activeStorePackages => {
                        this.dataService.activeList = process(activeStorePackages, this.listParams);
                    });
                    this.dataService.loading = false;
                });
            }
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Store Package', RouterLink: '/price/store-package'}];
    }

    createEmptyModel(): StorePackage {
        const storePackage = new StorePackage();
        if (this.masterId > 0) {
            storePackage.Package = this.masterId;
        }
        return storePackage;
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['StartTime', 'EndTime'];
        this.listParams.skip = state.skip;
        if (state.sort) {
            this.listParams.sort = state.sort;
        }
        if (state.filter) {
            this.listParams.filter = state.filter;
        }
        if (state.group) {
            this.listParams.group = state.group;
        }
        this.refreshList();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized


    isActive(endTime: Date) {
        return new Date(endTime) >= new Date();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
