// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { EstateRentPeriod } from '@finance/model/estate-rent-period.model';
import { EstateRentPeriodService } from '@finance/service/estate-rent-period.service';
import { EstateRent } from '@finance/model/estate-rent.model';
import { EstateRentService } from '@finance/service/estate-rent.service';
import {OverstoreCommonMethods} from '../../../../../util/common-methods.service';
import {Currencies} from '../../../../../util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-rent-period-edit',
    templateUrl: './estate-rent-period-edit.component.html',
    styleUrls: ['./estate-rent-period-edit.component.css', ]
})
export class EstateRentPeriodEditComponent extends CRUDDialogScreenBase<EstateRentPeriod> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<EstateRentPeriod>;
    currencies = Currencies;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: EstateRentPeriodService,
        public estateRentService: EstateRentService,
        public commonMethods: OverstoreCommonMethods
    ) {
        super(messageService, translateService, dataService, 'Estate Rent Period');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            EstateRentPeriodId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            EstateRent: new FormControl(),
            PeriodOrder: new FormControl(),
            PeriodStartDate: new FormControl(),
            PeriodEndDate: new FormControl(),
            ContractRentAmount: new FormControl(),
            ContractRentCurrency: new FormControl(),
            AdditionalRentAmount: new FormControl(),
            AdditionalRentCurrency: new FormControl(),
            PlannedRentRaise: new FormControl(),
            NegotiationDate: new FormControl(),
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
        if (!this.container.currentItem.PeriodStartDate || !this.container.currentItem.PeriodEndDate) {
            this.messageService.error(this.translateService.instant('Period start and end dates must be selected'));
            return;
        } else {
            this.container.currentItem.PeriodStartDate = this.commonMethods.addHours(this.container.currentItem.PeriodStartDate, 3);
            this.container.currentItem.PeriodEndDate = this.commonMethods.addHours(this.container.currentItem.PeriodEndDate, 3);

            if (this.container.currentItem.NegotiationDate) {
                this.container.currentItem.NegotiationDate = this.commonMethods.addHours(this.container.currentItem.NegotiationDate, 3);
            }
        }
        super.onSubmit();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
