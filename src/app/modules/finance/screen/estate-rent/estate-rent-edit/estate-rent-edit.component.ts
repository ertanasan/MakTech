// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { EstateRent } from '@finance/model/estate-rent.model';
import { EstateRentService } from '@finance/service/estate-rent.service';
import { ContractDraftVersion } from '@finance/model/contract-draft-version.model';
import { ContractDraftVersionService } from '@finance/service/contract-draft-version.service';
import { Folder } from '@document/model/folder.model';
import { FolderService } from '@document/service/folder.service';
import {environment} from '../../../../../../environments/environment';
import { OverstoreCommonMethods } from '../../../../../util/common-methods.service';
import { Branch } from '@organization/model/branch.model';
import { BranchService } from '@organization/service/branch.service';
import {Currencies} from '../../../../../util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-rent-edit',
    templateUrl: './estate-rent-edit.component.html',
    styleUrls: ['./estate-rent-edit.component.css', ]
})
export class EstateRentEditComponent extends CRUDDialogScreenBase<EstateRent> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<EstateRent>;
    currencies = Currencies;

    deleteUrl = '';
    downloadUrl = '';

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: EstateRentService,
        public contractDraftVersionService: ContractDraftVersionService,
        public folderService: FolderService,
        public commonMethods: OverstoreCommonMethods,
        public branchService: BranchService,
    ) {
        super(messageService, translateService, dataService, 'Estate Rent');
        this.deleteUrl = environment.baseRoute + '/Finance/EstateRent/DeleteDocument';
        this.downloadUrl = environment.baseRoute + '/Finance/EstateRent/DownloadDocument';
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            EstateRentId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            ContractDraftVersion: new FormControl(),
            ContractFolder: new FormControl(),
            EstateAddress: new FormControl(),
            RentPurpose: new FormControl(),
            ContractStartDate: new FormControl(),
            ContractEndDate: new FormControl(),
            EstateName: new FormControl(),
            RentFolderHandle: new FormControl(),
            Comment: new FormControl(),
            Branch: new FormControl(),
            Deposit: new FormControl(),
            DepositCurrency: new FormControl(),
            DepositDetails: new FormControl(),
            AdditionalDeposit: new FormControl(),
            AdditionalDepositCurrency: new FormControl(),
            AgentFee: new FormControl(),
            AgentFeeCurrency: new FormControl(),
            AgentFeeDetail: new FormControl(),
            KeyMoney: new FormControl(),
            KeyMoneyCurrency: new FormControl(),
            KeyMoneyDetail: new FormControl(),
            NonrefundableCost: new FormControl(),
            NonrefundableCurrency: new FormControl(),
            NonrefundableCostDetail: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    onSubmit() {
        if (!this.container.currentItem.ContractStartDate || !this.container.currentItem.ContractStartDate) {
            this.messageService.error(this.translateService.instant('Contract start end end dates must be selected'));
            return;
        } else {
            this.container.currentItem.ContractStartDate = this.commonMethods.addHours(this.container.currentItem.ContractStartDate, 3);
            this.container.currentItem.ContractEndDate = this.commonMethods.addHours(this.container.currentItem.ContractEndDate, 3);
        }
        super.onSubmit();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
