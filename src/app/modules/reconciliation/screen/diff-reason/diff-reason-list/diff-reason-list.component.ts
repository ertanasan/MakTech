// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { DiffReason } from '@reconciliation/model/diff-reason.model';
import { DiffReasonService } from '@reconciliation/service/diff-reason.service';
import { DiffReasonEditComponent } from '@reconciliation/screen/diff-reason/diff-reason-edit/diff-reason-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-diff-reason-list',
    templateUrl: './diff-reason-list.component.html',
    styleUrls: ['./diff-reason-list.component.css', ]
})
export class DiffReasonListComponent extends ListScreenBase<DiffReason> implements AfterViewInit {
    @ViewChild(DiffReasonEditComponent, {static: true}) editScreen: DiffReasonEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: DiffReasonService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Reconciliation' }, {Caption: 'Diff Reason', RouterLink: '/reconciliation/diff-reason'}];
    }

    createEmptyModel(): DiffReason {
        return new DiffReason();
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
