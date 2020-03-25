// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StorageCondition } from '@product/model/storage-condition.model';
import { StorageConditionService } from '@product/service/storage-condition.service';
import { StorageConditionEditComponent } from '@product/screen/storage-condition/storage-condition-edit/storage-condition-edit.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-storage-condition-list',
    templateUrl: './storage-condition-list.component.html',
    styleUrls: ['./storage-condition-list.component.css', ]
})
export class StorageConditionListComponent extends ListScreenBase<StorageCondition> implements AfterViewInit {
    @ViewChild(StorageConditionEditComponent, {static: true}) editScreen: StorageConditionEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StorageConditionService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Product' }, {Caption: 'Storage Condition', RouterLink: '/product/storage-condition'}];
    }

    createEmptyModel(): StorageCondition {
        return new StorageCondition();
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
