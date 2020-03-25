// Created by OverGenerator
/*Section="Imports"*/
import {Component, ViewChild, AfterViewInit, OnInit} from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Landlord } from '@finance/model/landlord.model';
import { LandlordService } from '@finance/service/landlord.service';
import { LandlordEditComponent } from '@finance/screen/landlord/landlord-edit/landlord-edit.component';
import {BpaActionStatus, PersonOrLegalIdentity} from '../../../../../util/shared-enums.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-landlord-list',
    templateUrl: './landlord-list.component.html',
    styleUrls: ['./landlord-list.component.css', ]
})
export class LandlordListComponent extends ListScreenBase<Landlord> implements AfterViewInit, OnInit {
    @ViewChild(LandlordEditComponent, { static: true }) editScreen: LandlordEditComponent;
    personOrLegalIdentity = PersonOrLegalIdentity;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: LandlordService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (!this.dataService.completeList) {
            this.dataService.listAll(this.listParams);
        }
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Landlord', RouterLink: '/finance/landlord'}];
    }

    createEmptyModel(): Landlord {
        return new Landlord();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    ngOnInit() {
        this.dataService.listAllLandlordsFromMikro();
        super.ngOnInit();
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
