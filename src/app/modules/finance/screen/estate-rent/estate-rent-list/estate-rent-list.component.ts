// Created by OverGenerator
/*Section="Imports"*/
import {Component, ViewChild, AfterViewInit, OnInit} from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { EstateRent } from '@finance/model/estate-rent.model';
import { EstateRentService } from '@finance/service/estate-rent.service';
import { EstateRentEditComponent } from '@finance/screen/estate-rent/estate-rent-edit/estate-rent-edit.component';
import {ContractDraftVersionService} from '@finance/service/contract-draft-version.service';
import {ContractDraftVersion} from '@finance/model/contract-draft-version.model';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import {ContractParameterService} from '@finance/service/contract-parameter.service';
import {ContractParameter} from '@finance/model/contract-parameter.model';
import {BranchService} from '@organization/service/branch.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-rent-list',
    templateUrl: './estate-rent-list.component.html',
    styleUrls: ['./estate-rent-list.component.css', ]
})
export class EstateRentListComponent extends ListScreenBase<EstateRent> implements OnInit, AfterViewInit {
    @ViewChild(EstateRentEditComponent, { static: true }) editScreen: EstateRentEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: EstateRentService,
        public contractDraftVersionService: ContractDraftVersionService,
        public contractParameterService: ContractParameterService,
        public branchService: BranchService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Estate Rent', RouterLink: '/finance/estate-rent'}];
    }

    createEmptyModel(): EstateRent {
        const dataItem = new EstateRent();
        dataItem.RentPurpose = this.contractParameterService.completeList.find(p => p.ParameterName === 'RentPurpose').Value;
        return dataItem;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnInit() {
        this.readEnabled = true;
        this.contractDraftVersionService.listAll();
        this.contractParameterService.listAll();
        this.branchService.listAll();
        super.ngOnInit();
    }

    readDataItem(dataItem: EstateRent) {
        return this.dataService.read(dataItem.EstateRentId);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate', 'ContractStartDate', 'ContractEndDate'];
        super.handleDataStateChange(state);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
