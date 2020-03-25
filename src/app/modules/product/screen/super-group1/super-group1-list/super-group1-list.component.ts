// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SuperGroup1 } from '@product/model/super-group1.model';
import { SuperGroup1Service } from '@product/service/super-group1.service';
import { SuperGroup1EditComponent } from '@product/screen/super-group1/super-group1-edit/super-group1-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group1-list',
    templateUrl: './super-group1-list.component.html',
    styleUrls: ['./super-group1-list.component.css', ]
})
export class SuperGroup1ListComponent extends ListScreenBase<SuperGroup1> implements AfterViewInit {
    @ViewChild(SuperGroup1EditComponent, {static: true}) editScreen: SuperGroup1EditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SuperGroup1Service,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Super Group 1', RouterLink: '/product/super-group1'}];
    }

    createEmptyModel(): SuperGroup1 {
        return new SuperGroup1();
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
