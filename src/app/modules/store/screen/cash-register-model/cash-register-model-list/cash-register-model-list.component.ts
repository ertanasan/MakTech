// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { CashRegisterModel } from '@store/model/cash-register-model.model';
import { CashRegisterModelService } from '@store/service/cash-register-model.service';
import { CashRegisterModelEditComponent } from '@store/screen/cash-register-model/cash-register-model-edit/cash-register-model-edit.component';
import { CashRegisterBrand } from '@store/model/cash-register-brand.model';
import { CashRegisterBrandService } from '@store/service/cash-register-brand.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-register-model-list',
    templateUrl: './cash-register-model-list.component.html',
    styleUrls: ['./cash-register-model-list.component.css', ]
})
export class CashRegisterModelListComponent extends ListScreenBase<CashRegisterModel> implements AfterViewInit, OnInit {
    @ViewChild(CashRegisterModelEditComponent, {static: true}) editScreen: CashRegisterModelEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: CashRegisterModelService,
        public cashRegisterBrandService: CashRegisterBrandService,
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
                    this.dataLoading = false;
                },
                error => {
                    this.dataLoading = false;
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Cash Register Model', RouterLink: '/store/cash-register-model'}];
    }

    createEmptyModel(): CashRegisterModel {
        return new CashRegisterModel();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.cashRegisterBrandService.completeList) {
            this.cashRegisterBrandService.listAll();
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
