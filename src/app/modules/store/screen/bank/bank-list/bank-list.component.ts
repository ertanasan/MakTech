// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';
import { BankEditComponent } from '@store/screen/bank/bank-edit/bank-edit.component';
import { KendoGridCommandColumnWidth } from 'app/util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-bank-list',
    templateUrl: './bank-list.component.html',
    styleUrls: ['./bank-list.component.css', ]
})
export class BankListComponent extends ListScreenBase<Bank> implements OnInit, AfterViewInit {
    @ViewChild(BankEditComponent, {static: true}) editScreen: BankEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: BankService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Bank', RouterLink: '/store/bank'}];
    }

    createEmptyModel(): Bank {
        return new Bank();
    }

    ngOnInit() {
        this.commandColumnWidth = KendoGridCommandColumnWidth.ThreeButton;
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
