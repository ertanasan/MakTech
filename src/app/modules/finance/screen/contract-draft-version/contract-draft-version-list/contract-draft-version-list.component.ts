// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { ContractDraftVersion } from '@finance/model/contract-draft-version.model';
import { ContractDraftVersionService } from '@finance/service/contract-draft-version.service';
import { ContractDraftVersionEditComponent } from '@finance/screen/contract-draft-version/contract-draft-version-edit/contract-draft-version-edit.component';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-contract-draft-version-list',
    templateUrl: './contract-draft-version-list.component.html',
    styleUrls: ['./contract-draft-version-list.component.css', ]
})
export class ContractDraftVersionListComponent extends ListScreenBase<ContractDraftVersion> implements AfterViewInit {
    @ViewChild(ContractDraftVersionEditComponent, { static: true }) editScreen: ContractDraftVersionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: ContractDraftVersionService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Contract Draft Version', RouterLink: '/finance/contract-draft-version'}];
    }

    createEmptyModel(): ContractDraftVersion {
        return new ContractDraftVersion();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    readDataItem(dataItem: ContractDraftVersion) {
        return this.dataService.read(dataItem.ContractDraftVersionId);
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['CreateDate'];
        super.handleDataStateChange(state);
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
