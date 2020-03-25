// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { StoreProperty } from '@store/model/store-property.model';
import { StorePropertyService } from '@store/service/store-property.service';
import { StorePropertyEditComponent } from '@store/screen/store-property/store-property-edit/store-property-edit.component';
import { StoreService } from '@store/service/store.service';
import { StorePropertyTypeService } from '@store/service/store-property-type.service';
import { DialogScreenBase } from '@otscreen-base/dialog-screen-base';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-property-list',
    templateUrl: './store-property-list.component.html',
    styleUrls: ['./store-property-list.component.css', ]
})
export class StorePropertyListComponent extends ListScreenBase<StoreProperty> implements AfterViewInit, OnInit {
    @ViewChild(StorePropertyEditComponent, {static: true}) editScreen: StorePropertyEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: StorePropertyService,
        public storeService: StoreService,
        public storePropertyTypeService: StorePropertyTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
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

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Store Property', RouterLink: '/store/store-property'}];
    }

    createEmptyModel(): StoreProperty {
        return new StoreProperty();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        if (!this.storePropertyTypeService.completeList) {
            this.storePropertyTypeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    showDialog(target: DialogScreenBase, actionName: string, dataItem?: any) {
        if (actionName === 'Create') {
            this.editScreen.edit = false;
            this.storePropertyTypeService.listRemainingPropertyTypes(this.masterId);
            super.showDialog(target, actionName);
        } else {
            this.editScreen.edit = true;
            super.showDialog(target, actionName, dataItem);
        }
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
