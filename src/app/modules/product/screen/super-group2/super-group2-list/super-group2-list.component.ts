// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SuperGroup2 } from '@product/model/super-group2.model';
import { SuperGroup2Service } from '@product/service/super-group2.service';
import { SuperGroup2EditComponent } from '@product/screen/super-group2/super-group2-edit/super-group2-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group2-list',
    templateUrl: './super-group2-list.component.html',
    styleUrls: ['./super-group2-list.component.css', ]
})
export class SuperGroup2ListComponent extends ListScreenBase<SuperGroup2> implements AfterViewInit {
    @ViewChild(SuperGroup2EditComponent, {static: true}) editScreen: SuperGroup2EditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SuperGroup2Service,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Super Group 2', RouterLink: '/product/super-group2'}];
    }

    createEmptyModel(): SuperGroup2 {
        return new SuperGroup2();
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
