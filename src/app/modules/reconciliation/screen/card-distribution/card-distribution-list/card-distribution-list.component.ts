// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CardDistribution } from '@reconciliation/model/card-distribution.model';
import { CardDistributionService } from '@reconciliation/service/card-distribution.service';
import { CardDistributionEditComponent } from '@reconciliation/screen/card-distribution/card-distribution-edit/card-distribution-edit.component';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-card-distribution-list',
    templateUrl: './card-distribution-list.component.html',
    styleUrls: ['./card-distribution-list.component.css', ]
})
export class CardDistributionListComponent extends ListScreenBase<CardDistribution> implements AfterViewInit, OnInit {
    @ViewChild(CardDistributionEditComponent, {static: true}) editScreen: CardDistributionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CardDistributionService,
        public reconciliationService: ReconciliationService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Card Distribution', RouterLink: '/reconciliation/card-distribution'}];
    }

    createEmptyModel(): CardDistribution {
        return new CardDistribution();
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
