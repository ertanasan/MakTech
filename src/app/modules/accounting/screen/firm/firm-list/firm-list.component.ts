// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Firm } from '@accounting/model/firm.model';
import { FirmService } from '@accounting/service/firm.service';
import { FirmEditComponent } from '@accounting/screen/firm/firm-edit/firm-edit.component';
import { FirmType } from '@accounting/model/firm-type.model';
import { FirmTypeService } from '@accounting/service/firm-type.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-firm-list',
    templateUrl: './firm-list.component.html',
    styleUrls: ['./firm-list.component.css', ]
})
export class FirmListComponent extends ListScreenBase<Firm> implements AfterViewInit, OnInit {
    @ViewChild(FirmEditComponent, { static: true }) editScreen: FirmEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FirmService,
        public firmTypeService: FirmTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Firm', RouterLink: '/accounting/firm'}];
    }

    createEmptyModel(): Firm {
        return new Firm();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.firmTypeService.completeList) {
            this.firmTypeService.listAll();
        }
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
