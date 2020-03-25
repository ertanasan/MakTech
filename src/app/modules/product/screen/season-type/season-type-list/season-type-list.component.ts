// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SeasonType } from '@product/model/season-type.model';
import { SeasonTypeService } from '@product/service/season-type.service';
import { SeasonTypeEditComponent } from '@product/screen/season-type/season-type-edit/season-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-season-type-list',
    templateUrl: './season-type-list.component.html',
    styleUrls: ['./season-type-list.component.css', ]
})
export class SeasonTypeListComponent extends ListScreenBase<SeasonType> implements AfterViewInit {
    @ViewChild(SeasonTypeEditComponent, {static: true}) editScreen: SeasonTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SeasonTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Season Type', RouterLink: '/product/season-type'}];
    }

    createEmptyModel(): SeasonType {
        return new SeasonType();
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
