// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Fixture } from '@product/model/fixture.model';
import { FixtureService } from '@product/service/fixture.service';
import { FixtureEditComponent } from '@product/screen/fixture/fixture-edit/fixture-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-fixture-list',
    templateUrl: './fixture-list.component.html',
    styleUrls: ['./fixture-list.component.css', ]
})
export class FixtureListComponent extends ListScreenBase<Fixture> implements AfterViewInit {
    @ViewChild(FixtureEditComponent, { static: true }) editScreen: FixtureEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: FixtureService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Fixture', RouterLink: '/product/fixture'}];
    }

    createEmptyModel(): Fixture {
        return new Fixture();
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
