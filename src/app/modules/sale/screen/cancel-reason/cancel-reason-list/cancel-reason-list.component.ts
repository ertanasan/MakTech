// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CancelReason } from '@sale/model/cancel-reason.model';
import { CancelReasonService } from '@sale/service/cancel-reason.service';
import { CancelReasonEditComponent } from '@sale/screen/cancel-reason/cancel-reason-edit/cancel-reason-edit.component';
import { Reconciliation } from '@reconciliation/model/reconciliation.model';
import { ReconciliationService } from '@reconciliation/service/reconciliation.service';
import { process } from '@progress/kendo-data-query';
import { DatePipe } from '@angular/common';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cancel-reason-list',
    templateUrl: './cancel-reason-list.component.html',
    styleUrls: ['./cancel-reason-list.component.css', ]
})
export class CancelReasonListComponent extends ListScreenBase<CancelReason> implements AfterViewInit, OnInit {
    @ViewChild(CancelReasonEditComponent, {static: true}) editScreen: CancelReasonEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CancelReasonService,
        public reconciliationService: ReconciliationService,
        public storeService: StoreService,
        public datePipe: DatePipe,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.ListReconciliationCancels(this.datePipe.transform(new Date(), 'yyyy-MM-dd'), -1).subscribe(result => {
            this.dataService.activeList = process(result, this.listParams);
        });
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Sale' }, {Caption: 'Cancel Reason', RouterLink: '/sale/cancel-reason'}];
    }

    createEmptyModel(): CancelReason {
        return new CancelReason();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.reconciliationService.completeList) {
            this.reconciliationService.listAll();
        }
        if (!this.storeService.completeList) {
            this.storeService.listAll();
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
