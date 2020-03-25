// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ContractParameter } from '@finance/model/contract-parameter.model';
import { ContractParameterService } from '@finance/service/contract-parameter.service';
import { ContractParameterEditComponent } from '@finance/screen/contract-parameter/contract-parameter-edit/contract-parameter-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-contract-parameter-list',
    templateUrl: './contract-parameter-list.component.html',
    styleUrls: ['./contract-parameter-list.component.css', ]
})
export class ContractParameterListComponent extends ListScreenBase<ContractParameter> implements AfterViewInit {
    @ViewChild(ContractParameterEditComponent, { static: true }) editScreen: ContractParameterEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ContractParameterService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Contract Parameter', RouterLink: '/finance/contract-parameter'}];
    }

    createEmptyModel(): ContractParameter {
        return new ContractParameter();
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
