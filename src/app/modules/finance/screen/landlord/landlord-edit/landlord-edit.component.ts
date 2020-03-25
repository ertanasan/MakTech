// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { Landlord, LandlordMikro } from '@finance/model/landlord.model';
import { LandlordService } from '@finance/service/landlord.service';
import {PersonOrLegalIdentity} from '../../../../../util/shared-enums.component';
import swal from "sweetalert2";
import { HttpParams } from '@angular/common/http';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-landlord-edit',
    templateUrl: './landlord-edit.component.html',
    styleUrls: ['./landlord-edit.component.css', ]
})
export class LandlordEditComponent extends CRUDDialogScreenBase<Landlord> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<Landlord>;
    hasLegalRep = false;
    personOrLegalIdentity = PersonOrLegalIdentity;
    currentAccountingCode: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: LandlordService,
        public landlordService: LandlordService,
    ) {
        super(messageService, translateService, dataService, 'Landlord');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            LandlordId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            LandlordName: new FormControl(),
            LandlordType: new FormControl(),
            LandlordAddress: new FormControl(),
            ContactInfo: new FormControl(),
            NationalId: new FormControl(),
            TaxpayerId: new FormControl(),
            TaxOffice: new FormControl(),
            LegalRepresentative: new FormControl(),
            AccountingCode: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
        this.unsubscribe.push(this.container.onShow.subscribe(() => {
            this.hasLegalRep = !!this.container.initialItem.LegalRepresentative;
            this.currentAccountingCode = this.container.actionName !== 'Create' ? this.container.mainForm.controls.AccountingCode.value : '';
        }));
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (this.hasLegalRep) {
            if (!this.container.currentItem.LegalRepresentative) {
                this.messageService.error(this.translateService.instant('Legal representative must be selected') + '.');
                return;
            }
        } else {
            this.container.currentItem.LegalRepresentative = null;
        }
        super.onSubmit();
    }

    onAccountingCodeChange(accountingCode: string) {
        // Get the chosen Mikro Land Lord from complete list
        const mikroLandlord = this.landlordService.mikroLandlordList.find(l => l.Code === accountingCode);

        // Warn user about changing values
        if (this.currentAccountingCode !== '') {
            swal({
                title: this.translateService.instant('Values will be changed'),
                text: this.translateService.instant(`Values will be change according to mikro records (${accountingCode}/${mikroLandlord.Name1}). Are you sure do you want to proceed?`),
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: this.utilityService.getColor('danger'),
                cancelButtonColor: this.utilityService.getColor('secondary'),
                confirmButtonText: this.translateService.instant('Proceed'),
                cancelButtonText: this.translateService.instant('Cancel')
            }).then((confirmResult) => {
                if (confirmResult.value) {
                    this.currentAccountingCode = this.container.mainForm.controls.AccountingCode.value;
                    this.assignValuesByMikroCode(mikroLandlord);
                } else {
                    this.container.mainForm.controls.AccountingCode.setValue(this.currentAccountingCode);
                }
            });
        } else {
            this.currentAccountingCode = this.container.mainForm.controls.AccountingCode.value;
            this.assignValuesByMikroCode(mikroLandlord);
        }
    }

    assignValuesByMikroCode(mikroLandLord: LandlordMikro) {
        this.container.mainForm.controls.LandlordName.setValue(mikroLandLord.Name1);
        this.container.mainForm.controls.LandlordType.setValue(mikroLandLord.LandlordType);
        this.container.mainForm.controls.LandlordAddress.setValue(mikroLandLord.LandlordAddress ? mikroLandLord.LandlordAddress : '');
        this.container.mainForm.controls.ContactInfo.setValue(mikroLandLord.ContactInfo ? mikroLandLord.ContactInfo : '');
        this.container.mainForm.controls.NationalId.setValue(mikroLandLord.NationalId ? mikroLandLord.NationalId : '');
        this.container.mainForm.controls.TaxpayerId.setValue(mikroLandLord.TaxpayerId ? mikroLandLord.TaxpayerId : '');
        this.container.mainForm.controls.TaxOffice.setValue(mikroLandLord.TaxOffice ? mikroLandLord.TaxOffice : '');
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
