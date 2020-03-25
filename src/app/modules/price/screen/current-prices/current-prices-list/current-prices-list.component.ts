// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CurrentPrices } from '@price/model/current-prices.model';
import { CurrentPricesService } from '@price/service/current-prices.service';
import { CurrentPricesEditComponent } from '@price/screen/current-prices/current-prices-edit/current-prices-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { DataStateChangeEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { process } from '@progress/kendo-data-query';
import { ListParams } from '@otmodel/list-params.model';


/*Section="ClassHeader"*/
@Component({
    selector: 'ot-current-prices-list',
    templateUrl: './current-prices-list.component.html',
    styleUrls: ['./current-prices-list.component.css', ]
})
export class CurrentPricesListComponent extends ListScreenBase<CurrentPrices> implements OnInit {
    @ViewChild(CurrentPricesEditComponent, {static: true}) editScreen: CurrentPricesEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CurrentPricesService,
        public storeService: StoreService,

    ) {
        super(messageService, translateService);
        this.allData = this.allData.bind(this);
    }

    allData() {
        const lp: ListParams = JSON.parse(JSON.stringify(this.listParams));
        lp.pageable = false;
        lp.take = 200000;
        const filteredList = process(this.dataService.completeList, lp);
        // console.log(filteredList);
        return filteredList;
    }


    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['VersionTime'];
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

    refreshList() {
        this.dataService.loading = true;
        this.dataService.listAsync(this.listParams).subscribe(
            result => {
                this.dataService.activeList.data = result.Data;
                this.dataService.activeList.total = result.Total;
                this.dataService.activeListChanged.next(this.dataService.activeList);
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.dataService.loading = false
        );
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Price' }, {Caption: 'Current Prices', RouterLink: '/price/current-prices'}];
    }

    createEmptyModel(): CurrentPrices {
        return new CurrentPrices();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }

        if (!this.dataService.completeList) {
            this.dataService.listAll();
        }
        super.ngOnInit();
    }


    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
