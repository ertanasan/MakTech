// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CashierTemplate } from '@store/model/cashier-template.model';
import { CashierTemplateService } from '@store/service/cashier-template.service';
import { CashierTemplateEditComponent } from '@store/screen/cashier-template/cashier-template-edit/cashier-template-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-cashier-template-list',
    templateUrl: './cashier-template-list.component.html',
    styleUrls: ['./cashier-template-list.component.css', ]
})
export class CashierTemplateListComponent extends ListScreenBase<CashierTemplate> implements OnInit, AfterViewInit {
    @ViewChild(CashierTemplateEditComponent, {static: true}) editScreen: CashierTemplateEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CashierTemplateService
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Cashier Template', RouterLink: '/store/cashier-template'}];
    }

    createEmptyModel(): CashierTemplate {
        return new CashierTemplate();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    ngOnInit() {
        super.ngOnInit();
    }
}
