// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { Status } from '@store-upload/model/status.model';
import { StatusService } from '@store-upload/service/status.service';
import { StatusEditComponent } from '@store-upload/screen/status/status-edit/status-edit.component';

/*Section="ClassHeader"*/
@Component({
  selector: 'ot-status-list',
  templateUrl: './status-list.component.html',
  styleUrls: ['./status-list.component.css',
  ]
})
export class StatusListComponent extends ListScreenBase<Status> implements AfterViewInit {
    @ViewChild(StatusEditComponent, {static: true}) editScreen: StatusEditComponent;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public dataService: StatusService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'StoreUpload' }, {Caption: 'Status', RouterLink: '/store-upload/status'}];
    }

    createEmptyModel(): Status {
        return new Status();
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
