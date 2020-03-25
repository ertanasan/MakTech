// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { PropertyType } from '@product/model/property-type.model';
import { PropertyTypeService } from '@product/service/property-type.service';
import { PropertyTypeEditComponent } from '@product/screen/property-type/property-type-edit/property-type-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-property-type-list',
    templateUrl: './property-type-list.component.html',
    styleUrls: ['./property-type-list.component.css', ]
})
export class PropertyTypeListComponent extends ListScreenBase<PropertyType> implements AfterViewInit {
    @ViewChild(PropertyTypeEditComponent, {static: true}) editScreen: PropertyTypeEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: PropertyTypeService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Property Type', RouterLink: '/product/property-type'}];
    }

    createEmptyModel(): PropertyType {
        return new PropertyType();
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
