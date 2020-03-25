// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { SaleCustomer } from '@sale/model/sale-customer.model';
import { SaleCustomerService } from '@sale/service/sale-customer.service';
import { SaleCustomerEditComponent } from '@sale/screen/sale-customer/sale-customer-edit/sale-customer-edit.component';
import { finalize } from 'rxjs/internal/operators/finalize';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-customer-list',
    templateUrl: './sale-customer-list.component.html',
    styleUrls: ['./sale-customer-list.component.css', ]
})
export class SaleCustomerListComponent extends ListScreenBase<SaleCustomer> implements AfterViewInit {
    @ViewChild(SaleCustomerEditComponent, { static: true }) editScreen: SaleCustomerEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: SaleCustomerService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    this.dataList = list;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Sale' }, {Caption: 'Sale Customer', RouterLink: '/sale/sale-customer'}];
    }

    createEmptyModel(): SaleCustomer {
        return new SaleCustomer();
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
