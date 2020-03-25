// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { RentPaymentPlan } from '@finance/model/rent-payment-plan.model';
import { RentPaymentPlanService } from '@finance/service/rent-payment-plan.service';
import { EstateRentPeriod } from '@finance/model/estate-rent-period.model';
import { EstateRentPeriodService } from '@finance/service/estate-rent-period.service';
import {OverstoreCommonMethods} from '../../../../../util/common-methods.service';
import {Currencies} from '../../../../../util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-rent-payment-plan-edit',
    templateUrl: './rent-payment-plan-edit.component.html',
    styleUrls: ['./rent-payment-plan-edit.component.css', ]
})
export class RentPaymentPlanEditComponent extends CRUDDialogScreenBase<RentPaymentPlan> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<RentPaymentPlan>;
    currencies = Currencies;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: RentPaymentPlanService,
        public estateRentPeriodService: EstateRentPeriodService,
        public commonMethods: OverstoreCommonMethods,
    ) {
        super(messageService, translateService, dataService, 'Rent Payment Plan');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            RentPaymentPlanId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            RentPeriod: new FormControl(),
            PaymentOrder: new FormControl(),
            DueDate: new FormControl(),
            PaymentAmount: new FormControl(),
            Currency: new FormControl(),
            AdditionalPaymentAmount: new FormControl(),
            AdditionalPaymentCurrency: new FormControl(),
            Comment: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (!this.container.currentItem.DueDate) {
            this.messageService.error(this.translateService.instant('Due date must be selected'));
            return;
        } else {
            this.container.currentItem.DueDate = this.commonMethods.addHours(this.container.currentItem.DueDate, 3);
        }
        super.onSubmit();
    }


    //#endregion Customized

    /*Section="ClassFooter"*/
}
