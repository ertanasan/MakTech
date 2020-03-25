// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { DaysOff } from '@reconciliation/model/days-off.model';
import { DaysOffService } from '@reconciliation/service/days-off.service';
import { DaysOffEditComponent } from '@reconciliation/screen/days-off/days-off-edit/days-off-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-days-off-list',
    templateUrl: './days-off-list.component.html',
    styleUrls: ['./days-off-list.component.css', ]
})
export class DaysOffListComponent extends ListScreenBase<DaysOff> implements AfterViewInit, OnInit {
    @ViewChild(DaysOffEditComponent, {static: true}) editScreen: DaysOffEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: DaysOffService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Days Off', RouterLink: '/reconciliation/days-off'}];
    }

    createEmptyModel(): DaysOff {
        this.editScreen.StoreList = [];
        return new DaysOff();
    }

    ngOnInit() {
        this.listParams.dateFields.push('OffDay');

        if (!this.storeService.completeList) {
            this.storeService.listAll();
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
