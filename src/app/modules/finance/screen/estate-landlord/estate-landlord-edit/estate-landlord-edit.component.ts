// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { EstateLandlord } from '@finance/model/estate-landlord.model';
import { EstateLandlordService } from '@finance/service/estate-landlord.service';
import { EstateRent } from '@finance/model/estate-rent.model';
import { EstateRentService } from '@finance/service/estate-rent.service';
import { Landlord } from '@finance/model/landlord.model';
import { LandlordService } from '@finance/service/landlord.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-landlord-edit',
    templateUrl: './estate-landlord-edit.component.html',
    styleUrls: ['./estate-landlord-edit.component.css', ]
})
export class EstateLandlordEditComponent extends CRUDDialogScreenBase<EstateLandlord> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<EstateLandlord>;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: EstateLandlordService,
        public estateRentService: EstateRentService,
        public landlordService: LandlordService,
    ) {
        super(messageService, translateService, dataService, 'Estate Landlord');
        this.hasAutomaticIdentity = false;
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            EstateRent: new FormControl(),
            Landlord: new FormControl(),
            CreateDate: new FormControl(),
            CreateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            OwnershipRate: new FormControl(),
            PaymentRate: new FormControl(),
            IBAN: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
