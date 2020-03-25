// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CashDistribution } from '@reconciliation/model/cash-distribution.model';
import { CashDistributionService } from '@reconciliation/service/cash-distribution.service';
import { CashDistributionEditComponent } from '@reconciliation/screen/cash-distribution/cash-distribution-edit/cash-distribution-edit.component';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cash-distribution-list',
    templateUrl: './cash-distribution-list.component.html',
    styleUrls: ['./cash-distribution-list.component.css', ]
})
export class CashDistributionListComponent extends ListScreenBase<CashDistribution> implements AfterViewInit, OnInit {
    @ViewChild(CashDistributionEditComponent, {static: true}) editScreen: CashDistributionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CashDistributionService,
        public reconciliationService: ReconciliationService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Cash Distribution', RouterLink: '/reconciliation/cash-distribution'}];
    }

    createEmptyModel(): CashDistribution {
        return new CashDistribution();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.reconciliationService.completeList) {
            this.reconciliationService.listAll();
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
