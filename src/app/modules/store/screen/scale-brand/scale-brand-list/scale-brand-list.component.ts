// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ScaleBrand } from '@store/model/scale-brand.model';
import { ScaleBrandService } from '@store/service/scale-brand.service';
import { ScaleBrandEditComponent } from '@store/screen/scale-brand/scale-brand-edit/scale-brand-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-scale-brand-list',
    templateUrl: './scale-brand-list.component.html',
    styleUrls: ['./scale-brand-list.component.css', ]
})
export class ScaleBrandListComponent extends ListScreenBase<ScaleBrand> implements AfterViewInit {
    @ViewChild(ScaleBrandEditComponent, {static: true}) editScreen: ScaleBrandEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: ScaleBrandService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Store' }, {Caption: 'Scale Brand', RouterLink: '/store/scale-brand'}];
    }

    createEmptyModel(): ScaleBrand {
        return new ScaleBrand();
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
