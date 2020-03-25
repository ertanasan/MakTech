// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Cashier } from '@store/model/cashier.model';
import { CashierService } from '@store/service/cashier.service';
import { CashierEditComponent } from '@store/screen/cashier/cashier-edit/cashier-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CashierTemplateService } from '@store/service/cashier-template.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cashier-list',
    templateUrl: './cashier-list.component.html',
    styleUrls: ['./cashier-list.component.css', ]
})
export class CashierListComponent extends ListScreenBase<Cashier> implements AfterViewInit, OnInit {
    @ViewChild(CashierEditComponent, {static: true}) editScreen: CashierEditComponent;

    workingTypeList = [{WorkingTypeId: 0, WorkingTypeName: 'Saatlik'},
                      {WorkingTypeId: 1, WorkingTypeName: 'Günlük'},
                      {WorkingTypeId: 2, WorkingTypeName: 'Haftalık'},
                      {WorkingTypeId: 3, WorkingTypeName: 'Aylık'}];
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CashierService,
        public storeService: StoreService,
        public cashierTemplateService: CashierTemplateService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        console.log(this.dataService.activeList);
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Cashier', RouterLink: '/store/cashier'}];
    }

    createEmptyModel(): Cashier {
        const model = new Cashier();
        model.Password = (1000 + Math.floor(Math.random() * 8999));
        model.IsActive = false;
        model.CashierFlag = true;
        model.Salesman = false;
        return model;
    }

    ngOnInit() {

        this.storeService.listUserStores();
        if (!this.cashierTemplateService.completeList) {
            this.cashierTemplateService.listAll();
        }
        this.storeService.listAllTitles();
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
