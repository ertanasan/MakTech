// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreScales } from '@store/model/store-scales.model';
import { StoreScalesService } from '@store/service/store-scales.service';
import { StoreScalesEditComponent } from '@store/screen/store-scales/store-scales-edit/store-scales-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ScaleModelService } from '@store/service/scale-model.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-scales-list',
    templateUrl: './store-scales-list.component.html',
    styleUrls: ['./store-scales-list.component.css']
})
export class StoreScalesListComponent extends ListScreenBase<StoreScales> implements AfterViewInit, OnInit {
    @ViewChild(StoreScalesEditComponent, {static: true}) editScreen: StoreScalesEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StoreScalesService,
        public storeService: StoreService,
        public scaleModelService: ScaleModelService
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
                        this.dataList = list;
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
        return [{ Caption: 'Store' }, { Caption: 'Store Scales', RouterLink: '/store/store-scales' }];
    }

    createEmptyModel(): StoreScales {
        return new StoreScales();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.scaleModelService.completeList) {
            this.scaleModelService.listAll();
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
