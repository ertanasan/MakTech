// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { RentPaymentPlan } from '@finance/model/rent-payment-plan.model';
import { RentPaymentPlanService } from '@finance/service/rent-payment-plan.service';
import { RentPaymentPlanEditComponent } from '@finance/screen/rent-payment-plan/rent-payment-plan-edit/rent-payment-plan-edit.component';
import {finalize} from 'rxjs/operators';
import {EstateRentPeriod} from '@finance/model/estate-rent-period.model';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-rent-payment-plan-list',
    templateUrl: './rent-payment-plan-list.component.html',
    styleUrls: ['./rent-payment-plan-list.component.css', ]
})
export class RentPaymentPlanListComponent extends ListScreenBase<RentPaymentPlan> implements AfterViewInit {
    @ViewChild(RentPaymentPlanEditComponent, { static: true }) editScreen: RentPaymentPlanEditComponent;
    @ViewChild('getConsent', {static: true}) getConsent: CustomDialogComponent;
    isKeepExistingPayments = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: RentPaymentPlanService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.isEmbedded) {
            this.listParams.pageable = false;
            this.listParams.skip = 0;
            this.listParams.take = 200;
        }
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    this.dataList = <RentPaymentPlan[]>list.Data;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Rent Payment Plan', RouterLink: '/finance/rent-payment-plan'}];
    }

    createEmptyModel(): RentPaymentPlan {
        const rentPaymentPlan = new RentPaymentPlan();
        if (this.masterId) {
            rentPaymentPlan.RentPeriod = this.masterId;
        }
        return rentPaymentPlan;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['DueDate'];
        super.handleDataStateChange(state);
    }

    onCancelConsent() {
        this.isKeepExistingPayments = true;
        this.getConsent.hide();
    }

    onConsent() {
        this.dataService.generateAllPayments().subscribe(generatedPaymentsCount => {
            this.isKeepExistingPayments = true;
            this.getConsent.hide();
            this.messageService.success(generatedPaymentsCount.toString() + this.translateService.instant('payment plan generated') + '.');
            this.refreshList();
        });
    }

    cloneRow(templatePayment: RentPaymentPlan) {
        this.dataService.clonePayment(templatePayment.RentPaymentPlanId).subscribe(
            clonePaymentId => {
                this.messageService.success(this.translateService.instant(`Payment cloned with ${clonePaymentId} id`) + '.');
                this.refreshList();
            }, error => {
                this.messageService.error(this.translateService.instant('Clone operation halted') + '!');
            }
        );
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
