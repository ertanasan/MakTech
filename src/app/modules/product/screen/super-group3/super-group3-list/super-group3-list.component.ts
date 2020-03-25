// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { SuperGroup3 } from '@product/model/super-group3.model';
import { SuperGroup3Service } from '@product/service/super-group3.service';
import { SuperGroup3EditComponent } from '@product/screen/super-group3/super-group3-edit/super-group3-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-super-group3-list',
    templateUrl: './super-group3-list.component.html',
    styleUrls: ['./super-group3-list.component.css', ]
})
export class SuperGroup3ListComponent extends ListScreenBase<SuperGroup3> implements AfterViewInit {
    @ViewChild(SuperGroup3EditComponent, {static: true}) editScreen: SuperGroup3EditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: SuperGroup3Service,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Super Group 3', RouterLink: '/product/super-group3'}];
    }

    createEmptyModel(): SuperGroup3 {
        return new SuperGroup3();
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
