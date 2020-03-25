// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { CountingType } from '@warehouse/model/counting-type.model';
import { CountingTypeService } from '@warehouse/service/counting-type.service';
import { CountingTypeEditComponent } from '@warehouse/screen/counting-type/counting-type-edit/counting-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-counting-type-list',
    templateUrl: './counting-type-list.component.html',
    styleUrls: ['./counting-type-list.component.css', ]
})
export class CountingTypeListComponent extends ListScreenBase<CountingType> implements AfterViewInit {
    @ViewChild(CountingTypeEditComponent, {static: true}) editScreen: CountingTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: CountingTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Warehouse' }, {Caption: 'Counting Type', RouterLink: '/warehouse/counting-type'}];
    }

    createEmptyModel(): CountingType {
        return new CountingType();
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
