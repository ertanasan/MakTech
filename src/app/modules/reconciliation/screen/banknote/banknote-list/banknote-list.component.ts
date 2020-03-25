// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Banknote } from '@reconciliation/model/banknote.model';
import { BanknoteService } from '@reconciliation/service/banknote.service';
import { BanknoteEditComponent } from '@reconciliation/screen/banknote/banknote-edit/banknote-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-banknote-list',
    templateUrl: './banknote-list.component.html',
    styleUrls: ['./banknote-list.component.css', ]
})
export class BanknoteListComponent extends ListScreenBase<Banknote> implements AfterViewInit {
    @ViewChild(BanknoteEditComponent, {static: true}) editScreen: BanknoteEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: BanknoteService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Banknote', RouterLink: '/reconciliation/banknote'}];
    }

    createEmptyModel(): Banknote {
        return new Banknote();
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
